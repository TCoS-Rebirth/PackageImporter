﻿using System;

namespace Utilities
{
    /// <summary>
    /// TODO inefficient, uses array copying
    /// </summary>
    public class LODPackUtility
    {
        byte[] output;

        public LODPackUtility(int sizeInBytes)
        {
            output = new byte[sizeInBytes];
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
            output = ShiftLeft(output, sizeInBit);
            output[output.Length - 1] |= (byte)(value & maskValue);
        }

        byte[] ShiftLeft(byte[] value, int bitcount)
        {
            var temp = new byte[value.Length];
            if (bitcount >= 8)
            {
                Array.Copy(value, bitcount / 8, temp, 0, temp.Length - bitcount / 8);
            }
            else
            {
                Array.Copy(value, temp, temp.Length);
            }
            if (bitcount % 8 != 0)
            {
                for (var i = 0; i < temp.Length; i++)
                {
                    temp[i] <<= bitcount % 8;
                    if (i < temp.Length - 1)
                    {
                        temp[i] |= (byte)(temp[i + 1] >> 8 - bitcount % 8);
                    }
                }
            }
            return temp;
        }

        public byte[] GetByteArray()
        {
            Array.Reverse(output);
            return output;
        }
    }
}
