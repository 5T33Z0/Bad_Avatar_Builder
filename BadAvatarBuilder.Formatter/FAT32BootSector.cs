using System.Runtime.InteropServices;

namespace BadAvatarBuilder.Formatter
{
    // Reference: https://cscie92.dce.harvard.edu/spring2024/K70F120M/bootSector.h

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 512)]
    internal unsafe struct FAT32BootSector
    {
        [FieldOffset(0)] public fixed byte JumpCode[3];
        [FieldOffset(3)] public fixed char OEMName[8];

        [FieldOffset(11)] internal ushort BytesPerSector;
        [FieldOffset(13)] internal byte SectorsPerCluster;
        [FieldOffset(14)] internal ushort ReservedSectorCount;
        [FieldOffset(16)] internal byte NumberOfFATs;
        [FieldOffset(17)] internal ushort MaxRootEntries;  // Unused in FAT32
        [FieldOffset(19)] internal ushort TotalSectors16;  // If 0, use TotalSectors
        [FieldOffset(21)] internal byte MediaDescriptor;
        [FieldOffset(22)] internal ushort SectorsPerFAT16; // Unused in FAT32
        [FieldOffset(24)] internal ushort SectorsPerTrack;
        [FieldOffset(26)] internal ushort NumberOfHeads;
        [FieldOffset(28)] internal uint HiddenSectors;
        [FieldOffset(32)] internal uint TotalSectors;      // Total sectors (if TotalSectors16 is 0)

        // FAT32-specific fields
        [FieldOffset(36)] internal uint SectorsPerFAT;
        [FieldOffset(40)] internal ushort FATFlags;
        [FieldOffset(42)] internal ushort FileSystemVersion;
        [FieldOffset(44)] internal uint RootCluster;
        [FieldOffset(48)] internal ushort FSInfoSector;
        [FieldOffset(50)] internal ushort BackupBootSector;

        [FieldOffset(52)] public fixed byte Reserved[12];

        [FieldOffset(64)] public byte DriveNumber;
        [FieldOffset(65)] public byte Reserved1;
        [FieldOffset(66)] public byte BootSignature;
        [FieldOffset(67)] public uint VolumeID;
        [FieldOffset(71)] public fixed char VolumeLabel[11];
        [FieldOffset(82)] public fixed char FileSystemType[8];
        [FieldOffset(90)] public fixed byte Reserved2[420];

        [FieldOffset(510)] internal ushort Signature;
    }
}