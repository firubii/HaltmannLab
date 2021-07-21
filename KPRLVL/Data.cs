using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRLVL
{
    public struct Block
    {
        public short ID;
    }

    public struct Collision
    {
        public byte Modifier;
        public byte Material;
        public byte Shape;
        public byte Unk;
    }

    public struct Decoration
    {
        public short Shape;
        public sbyte WaterShape;
        public sbyte Group;
    }

    public struct Stage
    {
        public string BGM;
        public string Unk_String;
        public uint Unk_1;
        public uint Unk_2;
        public uint Unk_3;
        public uint Unk_4;
        public uint Unk_5;
        public uint Unk_6;
        public uint Unk_7;
        public uint Unk_8;
        public uint Unk_9;
        public uint Unk_10;
        public uint Unk_11;
        public uint Unk_12;
        public uint Unk_13;
        public uint Unk_14;
    }
}
