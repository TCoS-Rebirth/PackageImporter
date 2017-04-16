using System;
using SBGame;

namespace TCosReborn.Framework.Utility
{
    public class AppearanceHelper
    {
        public class LODCreator
        {
            byte[] _lod;

            public LODCreator(int sizeInBytes)
            {
                _lod = new byte[sizeInBytes];
            }

            public void Add(int value, byte sizeInBit)
            {
                byte maskValue = 0xFF;
                switch (sizeInBit)
                {
                    case 1:
                        maskValue = 0x01;
                        break;
                    case 2:
                        maskValue = 0x03;
                        break;
                    case 3:
                        maskValue = 0x07;
                        break;
                    case 4:
                        maskValue = 0x0F;
                        break;
                    case 5:
                        maskValue = 0x1F;
                        break;
                    case 6:
                        maskValue = 0x3F;
                        break;
                    case 7:
                        maskValue = 0x7F;
                        break;
                    case 8:
                        maskValue = 0xFF;
                        break;
                }
                _lod = ShiftLeft(_lod, sizeInBit);
                _lod[_lod.Length - 1] |= (byte) (value & maskValue);
            }

            public byte[] ShiftLeft(byte[] value, int bitcount)
            {
                var temp = new byte[value.Length];
                if (bitcount >= 8)
                {
                    Array.Copy(value, bitcount/8, temp, 0, temp.Length - bitcount/8);
                }
                else
                {
                    Array.Copy(value, temp, temp.Length);
                }
                if (bitcount%8 != 0)
                {
                    for (var i = 0; i < temp.Length; i++)
                    {
                        temp[i] <<= bitcount%8;
                        if (i < temp.Length - 1)
                        {
                            temp[i] |= (byte) (temp[i + 1] >> 8 - bitcount%8);
                        }
                    }
                }
                return temp;
            }

            public byte[] GetByteArray()
            {
                Array.Reverse(_lod);
                return _lod;
            }
        }

        public class AppearancePartCreator
        {
            public int AppearancePart1;
            public int AppearancePart2;

            public AppearancePartCreator(int bodyColor, int bodyType, int chestTattoo, Content_API.NPCGender gender, int hairColor, int hairStyle, int headType,
                Content_API.NPCRace race, int tattooLeft, int tattooRight, int voice)
            {
                var a1 = 0;
                a1 = a1 | (int)race;
                a1 = a1 | ((int)gender << 1);
                a1 = a1 | (bodyType << 2);
                a1 = a1 | (headType << 4);
                a1 = a1 | (0 << 10);
                a1 = a1 | (bodyColor << 11);
                a1 = a1 | (chestTattoo << 19);
                a1 = a1 | (tattooLeft << 23);
                a1 = a1 | (tattooRight << 27);
                a1 = a1 | ((0 & 1) << 31); //unused tattoo
                AppearancePart1 = a1;

                var a2 = 0;
                a2 = a2 | (0 >> 1); //unused tattoo
                a2 = a2 | (hairColor << 3);
                a2 = a2 | (voice << 20);
                a2 = a2 | (hairStyle << 23);
                AppearancePart2 = a2;
            }

        }
    }
}