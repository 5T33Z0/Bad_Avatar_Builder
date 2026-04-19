global using DownloadItem = (string name, string url);
global using ArchiveItem = (string name, string path);
global using HomebrewApp = (string name, string folder, string entryPoint);

using Spectre.Console;
using BadBuilder.Models;
using BadBuilder.Helpers;
using BadBuilder.Utilities;

using static BadBuilder.Utilities.Constants;

namespace BadBuilder
{
    internal partial class Program
    {
        static readonly Style OrangeStyle = new(new Color(255, 114, 0));
        static readonly Style LightOrangeStyle = new(new Color(255, 172, 77));
        static readonly Style PeachStyle = new(new Color(255, 216, 153));

        static readonly Style GreenStyle = new(new Color(118, 185, 0));
        static readonly Style GrayStyle = new(new Color(132, 133, 137));

        static string TargetDriveLetter = string.Empty;

        static ActionQueue actionQueue = new();

        static DiskInfo? targetDisk = null;

        static void Main(string[] args)
        {
            ShowWelcomeMessage();

            while (true)
            {
                Console.WriteLine();
                string action = PromptForAction();

                if (action == "Exit") Environment.Exit(0);

                List<DiskInfo> disks = DiskHelper.GetDisks();
                string selectedDisk = PromptDiskSelection(disks);
                TargetDriveLetter = selectedDisk[..3];

                int diskIndex = disks.FindIndex(disk => $"{disk.DriveLetter} ({disk.SizeFormatted}) - {disk.Type}" == selectedDisk);
                targetDisk = disks[diskIndex];

                bool confirmation = PromptFormatConfirmation(selectedDisk);
                if (confirmation)
                {
                    if (!FormatDisk(targetDisk)) continue; 
                    break;
                }
            }

            List<ArchiveItem> downloadedFiles = DownloadRequiredFiles().Result;
            ExtractFiles(downloadedFiles).Wait();

            ClearConsole();
            string selectedDefaultApp = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Which program should be launched by BadUpdate?")
                .HighlightStyle(GreenStyle)
                .AddChoices(
                    "FreeMyXe",
                    "XeUnshackle"
                )
            );

            string XexToolPath = Path.Combine($@"{EXTRACTED_DIR}", "BadUpdate Tools", "XePatcher", "XexTool.exe");
            if (!File.Exists(XexToolPath))
            {
                throw new FileNotFoundException($"XexTool.exe not found at path: {XexToolPath}");
            }

            AnsiConsole.MarkupLine("[#76B900]{0}[/] Copying requried files and folders.", Markup.Escape("[*]"));
            foreach (var folder in Directory.GetDirectories($@"{EXTRACTED_DIR}"))
            {
                switch (folder.Split("\\").Last())
                {
                    case "XeXmenu":
                        EnqueueMirrorDirectory(
                            Path.Combine(folder, $"{ContentFolder}C0DE9999"),
                            Path.Combine(TargetDriveLetter, $"{ContentFolder}C0DE9999"),
                            7
                        );
                        break;

                    case "FreeMyXe":
                        if (selectedDefaultApp != "FreeMyXe") break;
                        EnqueueFileCopy(
                            Path.Combine(folder, "FreeMyXe.xex"),
                            Path.Combine(TargetDriveLetter, "BadUpdatePayload", "default.xex"),
                            9
                        );
                        break;

                    case "XeUnshackle":
                        if (selectedDefaultApp != "XeUnshackle") break;
                        string subFolderPath = Directory.GetDirectories(folder).FirstOrDefault();
                        File.Delete(Path.Combine(subFolderPath, "README - IMPORTANT.txt"));
                        EnqueueMirrorDirectory(
                            subFolderPath,
                            TargetDriveLetter,
                            9
                        );
                        break;

                    case "BadUpdate":
                        actionQueue.EnqueueAction(async () =>
                        {
                            using (StreamWriter writer = new(Path.Combine(TargetDriveLetter, "name.txt")))
                                writer.WriteLine("USB Storage Device");

                            using (StreamWriter writer = new(Path.Combine(TargetDriveLetter, "info.txt")))
                                writer.WriteLine($"This drive was created with BadBuilder by Pdawg.\nFind more info here: https://github.com/Pdawg-bytes/BadBuilder\nConfiguration: \n-  BadUpdate target binary: {selectedDefaultApp}");

                            Directory.CreateDirectory(Path.Combine(TargetDriveLetter, "Apps"));
                            await FileSystemHelper.MirrorDirectoryAsync(Path.Combine(folder, "Rock Band Blitz"), TargetDriveLetter);
                        }, 10);
                        break;

                    case "Rock Band Blitz":
                        EnqueueMirrorDirectory(
                            Path.Combine(folder, $"{ContentFolder}5841122D\\000D0000"),
                            Path.Combine(TargetDriveLetter, $"{ContentFolder}5841122D\\000D0000"),
                            8
                        );
                        break;

                    case "Simple 360 NAND Flasher":
                        actionQueue.EnqueueAction(async () =>
                        {
                            await PatchHelper.PatchXexAsync(Path.Combine(folder, "Simple 360 NAND Flasher", "Default.xex"), XexToolPath);
                            await FileSystemHelper.MirrorDirectoryAsync(Path.Combine(folder, "Simple 360 NAND Flasher"), Path.Combine(TargetDriveLetter, "Apps", "Simple 360 NAND Flasher"));
                        }, 6);
                        break;

                    default: throw new Exception($"[-] Unexpected directory in working folder: {folder}");
                }
            }
            actionQueue.ExecuteActionsAsync().Wait();

            File.AppendAllText(Path.Combine(TargetDriveLetter, "info.txt"), $"-  Disk formatted using {(targetDisk.TotalSize < 31 * GB ? "Windows \"format.com\"" : "BadBuilder Large FAT32 formatter")}\n");
            File.AppendAllText(Path.Combine(TargetDriveLetter, "info.txt"), $"-  Disk total size: {targetDisk.TotalSize} bytes\n");

            ClearConsole();
            if (!PromptAddHomebrew())
            {
                WriteHomebrewLog(1);
                AnsiConsole.MarkupLine("\n[#76B900]{0}[/] Your USB drive is ready to go.", Markup.Escape("[+]"));
                Console.Write("\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine();

            List<HomebrewApp> homebrewApps = ManageHomebrewApps();

            AnsiConsole.Status()
                .SpinnerStyle(OrangeStyle)
                .StartAsync("Copying and patching homebrew apps.", async ctx =>
                {
                    await Task.WhenAll(homebrewApps.Select(async item =>
                    {
                        await FileSystemHelper.MirrorDirectoryAsync(item.folder, Path.Combine(TargetDriveLetter, "Apps", item.name));
                        await PatchHelper.PatchXexAsync(item.entryPoint, XexToolPath);
                    }));
                }).Wait();

            WriteHomebrewLog(homebrewApps.Count + 1);

            string status = "[+]";
            AnsiConsole.MarkupLineInterpolated($"\n[#76B900]{status}[/] [bold]{homebrewApps.Count}[/] apps copied.");

            AnsiConsole.MarkupLine("\n[#76B900]{0}[/] Your USB drive is ready to go.", Markup.Escape("[+]"));

            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void EnqueueMirrorDirectory(string sourcePath, string destinationPath, int priority)
        {
            actionQueue.EnqueueAction(async () =>
            {
                await FileSystemHelper.MirrorDirectoryAsync(sourcePath, destinationPath);
            }, priority);
        }

        static void EnqueueFileCopy(string sourceFile, string destinationFile, int priority)
        {
            actionQueue.EnqueueAction(async () =>
            {
                await FileSystemHelper.CopyFileAsync(sourceFile, destinationFile);
            }, priority);
        }

        static void WriteHomebrewLog(int count)
        {
            string logPath = Path.Combine(TargetDriveLetter, "info.txt");
            string logEntry = $"-  {count} homebrew app(s) added (including Simple 360 NAND Flasher)\n";
            File.AppendAllText(logPath, logEntry);
        }


        static void ShowWelcomeMessage() => AnsiConsole.Markup(
            """
            [#4D8C00]██████╗  █████╗ ██████╗ ██████╗ ██╗   ██╗██╗██╗     ██████╗ ███████╗██████╗[/]
            [#65A800]██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║   ██║██║██║     ██╔══██╗██╔════╝██╔══██╗[/]
            [#76B900]██████╔╝███████║██║  ██║██████╔╝██║   ██║██║██║     ██║  ██║█████╗  ██████╔╝[/]
            [#A1CF3E]██╔══██╗██╔══██║██║  ██║██╔══██╗██║   ██║██║██║     ██║  ██║██╔══╝  ██╔══██╗[/]
            [#CCE388]██████╔╝██║  ██║██████╔╝██████╔╝╚██████╔╝██║███████╗██████╔╝███████╗██║  ██║[/]
            [#CCE388]╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚═════╝  ╚═════╝ ╚═╝╚══════╝╚═════╝ ╚══════╝╚═╝  ╚═╝[/]

            [#76B900]───────────────────────────────────────────────────────────────────────v0.31[/]
            ───────────────────────Xbox 360 [#FF7200]BadUpdate[/] USB Builder───────────────────────
                                        [#848589]Created by Pdawg[/]
            [#76B900]────────────────────────────────────────────────────────────────────────────[/]

        """);

        static string PromptForAction() => AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .HighlightStyle(GreenStyle)
            .AddChoices(
                "Build exploit USB",
                "Exit"
            )
        );

        static void ClearConsole()
        {
            AnsiConsole.Clear();
            ShowWelcomeMessage();
            Console.WriteLine();
        }
    }
}