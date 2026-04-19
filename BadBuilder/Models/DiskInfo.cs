namespace BadBuilder.Models
{
    internal class DiskInfo
    {
        internal string DriveLetter { get; init; }
        internal string VolumeLabel { get; init; }

        internal System.IO.DriveType Type { get; init; }
        internal string SizeFormatted { get; init; }
        internal long TotalSize { get; init; }
        internal long AvailableFreeSpace { get; init; }

        internal DiskInfo(string driveLetter, System.IO.DriveType type, long totalSize, string volumeLabel, long availableFreeSpace)
        {
            DriveLetter = driveLetter;
            VolumeLabel = volumeLabel;

            Type = type;
            SizeFormatted = FormatSize(totalSize);
            TotalSize = totalSize;
            AvailableFreeSpace = availableFreeSpace;
        }

        private static string FormatSize(long bytes)
        {
            const double KB = 1024.0;
            const double MB = KB * 1024;
            const double GB = MB * 1024;
            const double TB = GB * 1024;

            if (bytes >= TB) return $"{bytes / TB:F2} TB";
            if (bytes >= GB) return $"{bytes / GB:F2} GB";
            if (bytes >= MB) return $"{bytes / MB:F2} MB";
            if (bytes >= KB) return $"{bytes / KB:F2} KB";
            return $"{bytes} bytes";
        }
    }
}