using Spectre.Console;
using BadBuilder.Models;
using BadBuilder.Helpers;

namespace BadBuilder
{
    internal partial class Program
    {
        static string PromptDiskSelection(List<DiskInfo> disks)
        {
            var choices = new List<string>();
            foreach (var disk in disks)
            {
                if (disk.Type == DriveType.Removable)
                {
                    choices.Add($"{disk.DriveLetter} ({disk.SizeFormatted}) - {disk.Type}");
                }
            }

            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select disk to format:")
                    .HighlightStyle(GreenStyle)
                    .AddChoices(choices)
            );
        }

        static bool PromptFormatConfirmation(string selectedDisk)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<bool>($"[#FF7200 bold]WARNING: [/]Are you sure you would like to format [bold]{selectedDisk.Substring(0, 3)}[/]? All data on this drive will be lost.")
                    .AddChoice(true)
                    .AddChoice(false)
                    .DefaultValue(false)
                    .ChoicesStyle(GreenStyle)
                    .DefaultValueStyle(OrangeStyle)
                    .WithConverter(choice => choice ? "y" : "n")
            );
        }

        static bool FormatDisk(DiskInfo disk)
        {
            bool ret = true;
            string output = string.Empty;

            AnsiConsole.Status().SpinnerStyle(LightOrangeStyle).Start($"[#76B900]Formatting disk[/] {disk.DriveLetter} ({disk.SizeFormatted}) - {disk.Type}", async ctx =>
            {
                ClearConsole();
                output = DiskHelper.FormatDisk(disk);
                if (output != string.Empty) ret = false;
            });

            if (!ret)
            {
                AnsiConsole.Clear();
                ShowWelcomeMessage();
                Console.Write("\n" + output + "\n");
            }

            return ret;
        }
    }
}