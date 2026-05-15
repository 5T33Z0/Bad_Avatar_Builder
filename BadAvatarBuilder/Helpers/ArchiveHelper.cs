using Spectre.Console;
using System.Diagnostics;
using SharpCompress.Common;
using SharpCompress.Archives;

using static BadAvatarBuilder.Utilities.Constants;

namespace BadAvatarBuilder.Helpers
{
    internal static class ArchiveHelper
    {
        internal static async Task ExtractFileAsync(string friendlyName, string archivePath, ProgressTask task)
        {
            string subFolder = Path.Combine(EXTRACTED_DIR, friendlyName);
            Directory.CreateDirectory(subFolder);

            try
            {
                var archive = ArchiveFactory.Open(archivePath);
                task.MaxValue = archive.Entries.Count();
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                        entry.WriteToDirectory(subFolder, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });

                    task.Increment(1);
                }
            }
            catch (Exception ex)
            {
                // Sorry, but these exceptions are invalid. The files extract just fine.
                Debug.WriteLine(ex);
            }
        }
    }
}