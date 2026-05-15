namespace BadAvatarBuilder.Formatter
{
    static class Constants
    {
        internal const string ORANGE = "\u001b[38;2;255;114;0m";

        internal const string ANSI_RESET = "\u001b[0m";

        internal const long KB = 1024L;
        internal const long MB = 1048576L;
        internal const long GB = 1073741824L;
        internal const long TB = 1099511627776L;

        internal const int FMIFS_HARDDISK = 0xC;

        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint OPEN_EXISTING = 3;
        internal const uint FILE_SHARE_READ = 1;
        internal const uint FILE_BEGIN = 0;
        internal const uint FILE_FLAG_NO_BUFFERING = 0x20000000;

        internal const uint IOCTL_DISK_GET_DRIVE_GEOMETRY = 0x00070000;
        internal const uint IOCTL_DISK_GET_PARTITION_INFO_EX = 0x00070048;
        internal const uint IOCTL_DISK_GET_PARTITION_INFO = 0x00074004;
        internal const uint IOCTL_DISK_SET_PARTITION_INFO = 0x0007C008;
        internal const uint FSCTL_LOCK_VOLUME = 0x00090018;
        internal const uint FSCTL_DISMOUNT_VOLUME = 0x00090020;
        internal const uint FSCTL_UNLOCK_VOLUME = 0x0009001C;
        internal const uint FSCTL_QUERY_RETRIEVAL_POINTERS = 0x0009003B;
        internal const uint FSCTL_GET_COMPRESSION = 0x0009003C;
        internal const uint FSCTL_SET_COMPRESSION = 0x0009C040;
        internal const uint FSCTL_SET_BOOTLOADER_ACCESSED = 0x0009004F;
        internal const uint FSCTL_MARK_AS_SYSTEM_HIVE = 0x0009004F;
        internal const uint FSCTL_OPLOCK_BREAK_ACK_NO_2 = 0x00090050;
        internal const uint FSCTL_INVALIDATE_VOLUMES = 0x00090054;
        internal const uint FSCTL_QUERY_FAT_BPB = 0x00090058;
        internal const uint FSCTL_REQUEST_FILTER_OPLOCK = 0x0009005C;
        internal const uint FSCTL_FILESYSTEM_GET_STATISTICS = 0x00090060;
        internal const uint FSCTL_GET_NTFS_VOLUME_DATA = 0x00090064;
        internal const uint FSCTL_GET_NTFS_FILE_RECORD = 0x00090068;
        internal const uint FSCTL_GET_VOLUME_BITMAP = 0x0009006F;
        internal const uint FSCTL_GET_RETRIEVAL_POINTERS = 0x00090073;
        internal const uint FSCTL_MOVE_FILE = 0x00090074;
        internal const uint FSCTL_IS_VOLUME_DIRTY = 0x00090078;
        internal const uint FSCTL_ALLOW_EXTENDED_DASD_IO = 0x00090083;
    }
}