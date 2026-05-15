using Spectre.Console;
using BadAvatarBuilder.Helpers;

namespace BadAvatarBuilder
{
    internal partial class Program
    {
        internal static async Task ExtractFiles(List<ArchiveItem> filesToExtract)
        {
            filesToExtract.Sort((a, b) => b.name.Length.CompareTo(a.name.Length));

            await AnsiConsole.Progress()
            .Columns(
                new TaskDescriptionColumn(),
                new ProgressBarColumn().FinishedStyle(GreenStyle).CompletedStyle(LightOrangeStyle),
                new PercentageColumn().CompletedStyle(GreenStyle)
            )
            .StartAsync(async ctx =>
            {
                AnsiConsole.MarkupLine("[#76B900]{0}[/] Extracting files.", Markup.Escape("[*]"));
                await Task.WhenAll(filesToExtract.Select(async item =>
                {
                    var task = ctx.AddTask(item.name, new ProgressTaskSettings { AutoStart = false });
                    await ArchiveHelper.ExtractFileAsync(item.name, item.path, task);
                }));
            });
        }
    }
}