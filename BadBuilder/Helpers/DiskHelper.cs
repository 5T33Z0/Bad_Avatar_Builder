using BadBuilder.Models;
using BadBuilder.Formatter;
using System.Runtime.InteropServices;
using Spectre.Console;

namespace BadBuilder.Helpers
{
    internal static class DiskHelper
    {
        internal static List<DiskInfo> GetDisks()
        {
            var disks = new List<DiskInfo>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    disks.Add(new DiskInfo(drive.Name, drive.DriveType, drive.TotalSize, drive.VolumeLabel, drive.AvailableFreeSpace));
                }
            }

            return disks;
        }

        internal static string FormatDisk(DiskInfo disk)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "\u001b[38;2;255;114;0m[-]\u001b[0m Formatting is currently only supported on Windows. Please format your drive manually and try again.";

            return DiskFormatter.FormatVolume(disk.DriveLetter[0], disk.TotalSize);
        }
    }
}