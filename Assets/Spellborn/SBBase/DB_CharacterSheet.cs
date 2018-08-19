using System;

namespace SBBase
{
    [Serializable]
    public class DB_CharacterSheet: Base_DBObject, IPacketWritable
    {
        public int ClassId;

        public float FamePoints;

        public float PepPoints;

        public float Health;

        public int SelectedSkilldeckID;

        public byte ExtraBodyPoints;

        public byte ExtraMindPoints;

        public byte ExtraFocusPoints;

        public DB_CharacterSheet()
        {
        }

        public void Write(IPacketWriter writer)
        {
            writer.WriteInt32(ClassId);
            writer.WriteFloat(FamePoints);
            writer.WriteFloat(PepPoints);
            writer.WriteFloat(Health);
            writer.WriteInt32(SelectedSkilldeckID);
            writer.WriteByte(ExtraBodyPoints);
            writer.WriteByte(ExtraMindPoints);
            writer.WriteByte(ExtraFocusPoints);
            writer.WriteByte(0); //mAvailableAttributePoints
        }
    }
}