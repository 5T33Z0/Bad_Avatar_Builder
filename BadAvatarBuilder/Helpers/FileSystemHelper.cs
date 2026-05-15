namespace BadAvatarBuilder.Helpers
{
    internal static class FileSystemHelper
    {
        internal static async Task MirrorDirectoryAsync(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            string[] files = Directory.GetFiles(sourceDir);
            foreach (var file in files)
            {
                string relativePath = Path.GetRelativePath(sourceDir, file);
                string destFile = Path.Combine(destDir, relativePath);

                Directory.CreateDirectory(Path.GetDirectoryName(destFile));

                await CopyFileAsync(file, destFile);
            }

            string[] directories = Directory.GetDirectories(sourceDir);
            foreach (var dir in directories)
            {
                var relativePath = Path.GetRelativePath(sourceDir, dir);
                var destSubDir = Path.Combine(destDir, relativePath);

                await MirrorDirectoryAsync(dir, destSubDir);
            }
        }

        internal static async Task CopyFileAsync(string sourceFile, string destFile)
        {
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                await sourceStream.CopyToAsync(destStream);
        }
    }
}