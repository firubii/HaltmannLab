using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KPRLVL;

namespace KPRLVL
{
    public class Level
    {
        public uint Height;
        public uint Width;
        public string Background;
        public string Tileset;
        public Stage StageData;
        public List<Block> TileBlock = new List<Block>();
        public List<Collision> TileCollision = new List<Collision>();
        public List<Decoration> MLandDecoration = new List<Decoration>();
        public List<Decoration> BLandDecoration = new List<Decoration>();
        public List<Decoration> FLandDecoration = new List<Decoration>();
        public List<Dictionary<string, string>> Objects = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Items = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Bosses = new List<Dictionary<string, string>>();
        public List<Dictionary<string, string>> Enemies = new List<Dictionary<string, string>>();

        public Level()
        {
            Height = 1;
            Width = 1;
            Background = "";
            Tileset = "";
            StageData = new Stage();
            TileBlock = new List<Block>();
            TileCollision = new List<Collision>();
            MLandDecoration = new List<Decoration>();
            BLandDecoration = new List<Decoration>();
            FLandDecoration = new List<Decoration>();
            Objects = new List<Dictionary<string, string>>();
            Items = new List<Dictionary<string, string>>();
            Bosses = new List<Dictionary<string, string>>();
            Enemies = new List<Dictionary<string, string>>();
        }
        public Level(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                Read(reader);
            }
        }

        public void Read(BinaryReader reader)
        {
            reader.BaseStream.Seek(0x14, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Width = reader.ReadUInt32();
            Height = reader.ReadUInt32();
            for (int i = 0; i < Width*Height; i++)
            {
                Block block = new Block();
                block.ID = reader.ReadInt16();
                TileBlock.Add(block);
            }

            reader.BaseStream.Seek(0x1C, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            reader.BaseStream.Seek(0x8, SeekOrigin.Current);
            for (int i = 0; i < Width * Height; i++)
            {
                Collision collision = new Collision();
                collision.Modifier = reader.ReadByte();
                collision.Material = reader.ReadByte();
                collision.Shape = reader.ReadByte();
                collision.Unk = reader.ReadByte();
                TileCollision.Add(collision);
            }

            reader.BaseStream.Seek(0x20, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            long decoAddress = reader.BaseStream.Position;

            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Background = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

            reader.BaseStream.Seek(decoAddress + 0x4, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            Tileset = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));

            reader.BaseStream.Seek(decoAddress + 0x8, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Shape = reader.ReadInt16();
                decoration.WaterShape = reader.ReadSByte();
                decoration.Group = reader.ReadSByte();
                BLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(decoAddress + 0xC, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Shape = reader.ReadInt16();
                decoration.WaterShape = reader.ReadSByte();
                decoration.Group = reader.ReadSByte();
                MLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(decoAddress + 0x10, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32() + 0x8, SeekOrigin.Begin);
            for (int i = 0; i < Width * Height; i++)
            {
                Decoration decoration = new Decoration();
                decoration.Shape = reader.ReadInt16();
                decoration.WaterShape = reader.ReadSByte();
                decoration.Group = reader.ReadSByte();
                FLandDecoration.Add(decoration);
            }

            reader.BaseStream.Seek(0x24, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            uint pos = (uint)reader.BaseStream.Position;
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            StageData.BGM = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.BaseStream.Seek(pos + 0x4, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            StageData.Unk_String = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
            reader.BaseStream.Seek(pos + 0x8, SeekOrigin.Begin);
            StageData.Unk_1 = reader.ReadUInt32();
            StageData.Unk_2 = reader.ReadUInt32();
            StageData.Unk_3 = reader.ReadUInt32();
            StageData.Unk_4 = reader.ReadUInt32();
            StageData.Unk_5 = reader.ReadUInt32();
            StageData.Unk_6 = reader.ReadUInt32();
            StageData.Unk_7 = reader.ReadUInt32();
            StageData.Unk_8 = reader.ReadUInt32();
            StageData.Unk_9 = reader.ReadUInt32();
            StageData.Unk_10 = reader.ReadUInt32();
            StageData.Unk_11 = reader.ReadUInt32();
            StageData.Unk_12 = reader.ReadUInt32();
            StageData.Unk_13 = reader.ReadUInt32();
            StageData.Unk_14 = reader.ReadUInt32();

            reader.BaseStream.Seek(0x28, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            uint count = reader.ReadUInt32();
            List<uint> offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Objects.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Items.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x30, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Bosses.Add(ReadYAML(reader.ReadBytes(length)));
            }
            offsets.Clear();

            reader.BaseStream.Seek(0x34, SeekOrigin.Begin);
            reader.BaseStream.Seek(reader.ReadUInt32(), SeekOrigin.Begin);
            count = reader.ReadUInt32();
            offsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(offsets[i] + 0x8, SeekOrigin.Begin);
                int length = reader.ReadInt32() + 0xC;
                reader.BaseStream.Seek(offsets[i], SeekOrigin.Begin);
                Enemies.Add(ReadYAML(reader.ReadBytes(length)));
            }
        }

        public void Write(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write));
            writer.Write(new byte[] {
                0x58, 0x42, 0x49, 0x4E, 0x34, 0x12, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE9, 0xFD, 0x00, 0x00,
                0x0B, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x78, 0x56, 0x34, 0x12
            });
            writer.Write(Width);
            writer.Write(Height);
            for (int i = 0; i < TileBlock.Count; i++)
            {
                writer.Write(TileBlock[i].ID);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            uint pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x18, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x1C, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);

            pos = (uint)writer.BaseStream.Position;
            writer.Write(pos + 0x4);
            writer.Write(Width);
            writer.Write(Height);
            for (int i = 0; i < TileCollision.Count; i++)
            {
                writer.Write(TileCollision[i].Modifier);
                writer.Write(TileCollision[i].Material);
                writer.Write(TileCollision[i].Shape);
                writer.Write(TileCollision[i].Unk);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x20, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            uint bgOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint tilesetOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint bLandOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint mLandOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint fLandOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(bLandOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Width);
            writer.Write(Height);
            for (int i = 0; i < BLandDecoration.Count; i++)
            {
                writer.Write(BLandDecoration[i].Shape);
                writer.Write(BLandDecoration[i].WaterShape);
                writer.Write(BLandDecoration[i].Group);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(mLandOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Width);
            writer.Write(Height);
            for (int i = 0; i < MLandDecoration.Count; i++)
            {
                writer.Write(MLandDecoration[i].Shape);
                writer.Write(MLandDecoration[i].WaterShape);
                writer.Write(MLandDecoration[i].Group);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(fLandOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Width);
            writer.Write(Height);
            for (int i = 0; i < FLandDecoration.Count; i++)
            {
                writer.Write(FLandDecoration[i].Shape);
                writer.Write(FLandDecoration[i].WaterShape);
                writer.Write(FLandDecoration[i].Group);
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x24, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            uint bgmStringOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            uint unkStringOffset = (uint)writer.BaseStream.Position;
            writer.Write(0);
            writer.Write(StageData.Unk_1);
            writer.Write(StageData.Unk_2);
            writer.Write(StageData.Unk_3);
            writer.Write(StageData.Unk_4);
            writer.Write(StageData.Unk_5);
            writer.Write(StageData.Unk_6);
            writer.Write(StageData.Unk_7);
            writer.Write(StageData.Unk_8);
            writer.Write(StageData.Unk_9);
            writer.Write(StageData.Unk_10);
            writer.Write(StageData.Unk_11);
            writer.Write(StageData.Unk_12);
            writer.Write(StageData.Unk_13);
            writer.Write(StageData.Unk_14);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x28, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            List<uint> yamlOffsets = new List<uint>();
            writer.Write(Objects.Count);
            for (int i = 0; i < Objects.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Objects.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Objects[i]));
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Items.Count);
            for (int i = 0; i < Items.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Items.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Items[i]));
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x30, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Bosses.Count);
            for (int i = 0; i < Bosses.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Bosses.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Bosses[i]));
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x34, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            yamlOffsets = new List<uint>();
            writer.Write(Enemies.Count);
            for (int i = 0; i < Enemies.Count; i++)
            {
                yamlOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                pos = (uint)writer.BaseStream.Position;
                writer.BaseStream.Seek(yamlOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.Write(WriteYAML(Enemies[i]));
            }
            while ((writer.BaseStream.Length).ToString("X").Last() != '0')
            {
                writer.Write((byte)0);
            }

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(bgOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Background.Length);
            writer.Write(Encoding.UTF8.GetBytes(Background));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(tilesetOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(Tileset.Length);
            writer.Write(Encoding.UTF8.GetBytes(Tileset));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(bgmStringOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(StageData.BGM.Length);
            writer.Write(Encoding.UTF8.GetBytes(StageData.BGM));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(unkStringOffset, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0x38, SeekOrigin.Begin);
            writer.Write(pos);
            writer.BaseStream.Seek(0, SeekOrigin.End);
            writer.Write(StageData.Unk_String.Length);
            writer.Write(Encoding.UTF8.GetBytes(StageData.Unk_String));
            while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
            {
                writer.Write((byte)0);
            }
            writer.Write(0);

            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
            writer.Write(pos);

            writer.Flush();
            writer.Dispose();
            writer.Close();
        }

        private Dictionary<string, string> ReadYAML(byte[] yamlFile)
        {
            Dictionary<string, string> yaml = new Dictionary<string, string>();
            BinaryReader reader = new BinaryReader(new MemoryStream(yamlFile));
            reader.BaseStream.Seek(0x1C, SeekOrigin.Begin);
            uint count = reader.ReadUInt32();
            List<uint> nameOffsets = new List<uint>();
            List<uint> valOffsets = new List<uint>();
            for (int i = 0; i < count; i++)
            {
                nameOffsets.Add(reader.ReadUInt32());
                valOffsets.Add(reader.ReadUInt32());
            }
            for (int i = 0; i < count; i++)
            {
                reader.BaseStream.Seek(nameOffsets[i], SeekOrigin.Begin);
                string name = string.Join("", reader.ReadChars(reader.ReadInt32()));
                reader.BaseStream.Seek(valOffsets[i], SeekOrigin.Begin);
                uint valtype = reader.ReadUInt32();
                switch (valtype)
                {
                    case 1:
                        {
                            uint val = reader.ReadUInt32();
                            string strVal = val.ToString();
                            if (name == "x" || name == "y")
                            {
                                int offset = int.Parse(val.ToString("X8").ToCharArray().Last().ToString(), System.Globalization.NumberStyles.HexNumber);
                                uint coord = uint.Parse("0" + string.Join("", val.ToString("X8").ToCharArray().Take(7)), System.Globalization.NumberStyles.HexNumber);
                                strVal = coord + " | " + offset;
                            }
                            yaml.Add("int " + name, strVal);
                            break;
                        }
                    case 2:
                        {
                            yaml.Add("float " + name, reader.ReadSingle().ToString());
                            break;
                        }
                    case 3:
                        {
                            yaml.Add("bool " + name, Convert.ToBoolean(reader.ReadSingle()).ToString());
                            break;
                        }
                    case 4:
                        {
                            uint stringoffset = reader.ReadUInt32();
                            reader.BaseStream.Seek(stringoffset, SeekOrigin.Begin);
                            string stringval = Encoding.UTF8.GetString(reader.ReadBytes(reader.ReadInt32()));
                            yaml.Add("string " + name, stringval);
                            break;
                        }
                }
            }
            return yaml;
        }

        private byte[] WriteYAML(Dictionary<string, string> yaml)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            List<uint> stringOffsets = new List<uint>();
            List<string> strings = new List<string>();
            List<uint> valuePointers = new List<uint>();
            List<uint> valueOffsets = new List<uint>();

            uint pos = 0;

            writer.Write(new byte[] {
                0x58, 0x42, 0x49, 0x4E, 0x34, 0x12, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9F, 0x4E, 0x00, 0x00,
                0x59, 0x41, 0x4D, 0x4C, 0x02, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00
            });
            writer.Write((uint)yaml.Count);

            foreach (KeyValuePair<string, string> pair in yaml)
            {
                strings.Add(pair.Key.Replace(pair.Key.Split(' ')[0] + " ", ""));
                stringOffsets.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
                valuePointers.Add((uint)writer.BaseStream.Position);
                writer.Write(0);
            }
            foreach (KeyValuePair<string, string> pair in yaml)
            {
                string valType = pair.Key.Split(' ')[0];
                valueOffsets.Add((uint)writer.BaseStream.Position);
                switch (valType)
                {
                    case "int":
                        {
                            writer.Write(1);

                            uint val;

                            if (pair.Key == "int x" || pair.Key == "int y")
                            {
                                string[] coords = pair.Value.Replace(" ", "").Split('|');
                                uint offset = uint.Parse(coords[1]);
                                uint coord = uint.Parse(coords[0]);
                                val = uint.Parse(coord.ToString("X7") + offset.ToString("X1"), System.Globalization.NumberStyles.HexNumber);
                            }
                            else
                            {
                                val = uint.Parse(pair.Value);
                            }

                            writer.Write(val);
                            break;
                        }
                    case "float":
                        {
                            writer.Write(2);
                            writer.Write(float.Parse(pair.Value));
                            break;
                        }
                    case "bool":
                        {
                            writer.Write(3);
                            if (pair.Value == "True")
                            {
                                writer.Write((uint)1);
                            }
                            else
                            {
                                writer.Write((uint)0);
                            }
                            break;
                        }
                    case "string":
                        {
                            writer.Write(4);
                            strings.Add(pair.Value);
                            stringOffsets.Add((uint)writer.BaseStream.Position);
                            writer.Write(0);
                            break;
                        }
                }
            }

            for (int i = 0; i < strings.Count; i++)
            {
                writer.BaseStream.Seek(0, SeekOrigin.End);
                pos = (uint)writer.BaseStream.Position;
                writer.Write(strings[i].Length);
                writer.Write(Encoding.UTF8.GetBytes(strings[i]));
                writer.Write(0);
                while ((writer.BaseStream.Length).ToString("X").Last() != '0' && (writer.BaseStream.Length).ToString("X").Last() != '4' && (writer.BaseStream.Length).ToString("X").Last() != '8' && (writer.BaseStream.Length).ToString("X").Last() != 'C')
                {
                    writer.Write((byte)0);
                }
                writer.BaseStream.Seek(stringOffsets[i], SeekOrigin.Begin);
                writer.Write(pos);
            }

            for (int i = 0; i < valueOffsets.Count; i++)
            {
                writer.BaseStream.Seek(valuePointers[i], SeekOrigin.Begin);
                writer.Write(valueOffsets[i]);
            }

            writer.BaseStream.Seek(0, SeekOrigin.End);
            pos = (uint)writer.BaseStream.Position;
            writer.BaseStream.Seek(0x8, SeekOrigin.Begin);
            writer.Write(pos - 1);

            return stream.GetBuffer().Take((int)pos).ToArray();
        }
    }
}
