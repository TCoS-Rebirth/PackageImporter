using System;
using System.Collections.Generic;
using System.Text;
using Engine;
using UnityEngine;
using Utilities;

namespace Network
{

    public partial class NetworkPacket: IPacketWriter
    {
        void EnsureBuffersize(int more)
        {
            if (position + more > buffer.Length)
            {
                Array.Resize(ref buffer, buffer.Length + more);
            }
        }

        public void WriteByte(byte b)
        {
            EnsureBuffersize(1);
            buffer[position] = b;
            position += 1;
        }

        public void WriteByteArray(byte[] b)
        {
            WriteUint32((ushort) b.Length);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteByteArrayWithoutLength(byte[] b)
        {
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteUint16(ushort s)
        {
            var b = BitConverter.GetBytes(s);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteUint32(uint i)
        {
            var b = BitConverter.GetBytes(i);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteInt32(int i)
        {
            var b = BitConverter.GetBytes(i);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteFloat(float f)
        {
            var b = BitConverter.GetBytes(f);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteString(string s)
        {
            var b = Encoding.Unicode.GetBytes(s);
            WriteUint32((uint) s.Length);
            EnsureBuffersize(b.Length);
            System.Buffer.BlockCopy(b, 0, buffer, position, b.Length);
            position += b.Length;
        }

        public void WriteVector3(Vector3 vec)
        {
            WriteFloat(vec.x);
            WriteFloat(vec.y);
            WriteFloat(vec.z);
        }

        public void WriteRotator(Rotator rot)
        {
            WriteInt32(rot.Pitch);
            WriteInt32(rot.Yaw);
            WriteInt32(rot.Roll);
        }

        public void WriteVector(Vector vec)
        {
            WriteFloat(vec.X);
            WriteFloat(vec.Y);
            WriteFloat(vec.Z);
        }

        public void WriteQuaternion(Quaternion q)
        {
            WriteRotator(UnitConversion.ToUnreal(q));
        }

        public void Write(IPacketWritable writable)
        {
            writable.Write(this);
        }

        public void Write<T>(List<T> writables) where T:IPacketWritable
        {
            WriteInt32(writables.Count);
            for (int i = 0; i < writables.Count; i++)
            {
                Write(writables[i]);
            }
        }

        public void Write<T>(List<T> items, Action<T> customWritehHandler)
        {
            WriteInt32(items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                customWritehHandler(items[i]);
            }
        }

        public void Write<T>(List<T> items, Action<int, T> customWritehHandler)
        {
            WriteInt32(items.Count);
            for (int i = 0; i < items.Count; i++)
            {
                customWritehHandler(i, items[i]);
            }
        }
    }
}