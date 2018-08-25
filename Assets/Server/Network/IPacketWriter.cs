using System.Collections.Generic;
using Engine;
using UnityEngine;

public interface IPacketWriter
{
    void WriteByte(byte b);
    void WriteByteArray(byte[] b);
    void WriteByteArrayWithoutLength(byte[] b);
    void WriteUint16(ushort s);
    void WriteUint32(uint i);
    void WriteInt32(int i);
    void WriteFloat(float f);
    void WriteString(string s);
    void WriteVector3(Vector3 v);
    void WriteVector(Vector v);
    void WriteRotator(Rotator r);
    void WriteQuaternion(Quaternion q);
    void Write(IPacketWritable writable);
    void Write<T>(List<T> writables) where T:IPacketWritable;
    void Write<T>(List<T> items, System.Action<T> customWriteHandler);
    void Write<T>(List<T> items, System.Action<int, T> customWriteHandler);
}