using Spectre.Console;
using System.Diagnostics;

namespace BadAvatarBuilder.Helpers
{
    internal static class PatchHelper
    {
        internal static async Task PatchXexAsync(string xexPath, string xexToolPath)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = xexToolPath,
                    Arguments = $"-m r -r a \"{xexPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
            {
                string status = "[-]";
                AnsiConsole.MarkupLineInterpolated($"\n[#FF7200]{status}[/] The program {Path.GetFileNameWithoutExtension(xexPath)} was unable to be patched. XexTool output:");
                Console.WriteLine(process.StandardError.ReadToEnd());
            }
        }
    }
}