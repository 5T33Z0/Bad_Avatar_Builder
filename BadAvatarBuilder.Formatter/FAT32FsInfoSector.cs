using System.Runtime.InteropServices;

namespace BadAvatarBuilder.Formatter
{
    // Reference: https://cscie92.dce.harvard.edu/spring2024/K70F120M/fsInfo.h

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 512)]
    internal unsafe struct FAT32FsInfoSector
    {
        [FieldOffset(0)] public uint LeadSignature;

        [FieldOffset(4)] public fixed byte Reserved1[480]; // Zeros

        [FieldOffset(484)] public uint StructureSignature;
        [FieldOffset(488)] public uint FreeClusterCount;
        [FieldOffset(492)] public uint NextFreeCluster;

        [FieldOffset(496)] public fixed byte Reserved2[12];

        [FieldOffset(508)] public uint TrailSignature;
    }
}