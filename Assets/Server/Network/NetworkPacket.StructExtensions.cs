using SBBase;

namespace Network
{
    public static class StructWriter
    {
        public static void Write(this NetworkPacket packet, DB_Character character)
        {
            packet.WriteInt32(character.Id);
            packet.WriteByte(character.Dead);
            packet.WriteInt32(character.AccountID);
            packet.WriteString(character.Name);
            packet.WriteVector(character.Location);
            packet.WriteInt32(character.worldID);
            packet.WriteInt32(character.AppearancePart1);
            packet.WriteInt32(character.AppearancePart2);
            packet.WriteRotator(character.Rotation);
            packet.WriteInt32(character.FactionId);
            packet.WriteInt32(character.LastUsedTimestamp);
        }

        public static void Write(this NetworkPacket packet, DB_CharacterSheet sheet)
        {
            packet.WriteInt32(sheet.ClassId);
            packet.WriteFloat(sheet.FamePoints);
            packet.WriteFloat(sheet.PepPoints);
            packet.WriteFloat(sheet.Health);
            packet.WriteInt32(sheet.SelectedSkilldeckID);
            packet.WriteByte(sheet.ExtraBodyPoints);
            packet.WriteByte(sheet.ExtraMindPoints);
            packet.WriteByte(sheet.ExtraFocusPoints);
            packet.WriteByte(0); //extra attribute points?
        }

        public static void Write(this NetworkPacket packet, DB_Item item)
        {
            packet.WriteInt32(item.Id);
            packet.WriteInt32(item.ItemTypeID);
            packet.WriteByte(item.LocationType);
            packet.WriteInt32(item.LocationID);
            packet.WriteInt32(item.LocationSlot);
            packet.WriteInt32(item.StackSize);
            packet.WriteByte(item.Attuned);
            packet.WriteByte(item.Color1);
            packet.WriteByte(item.Color2);
            packet.WriteInt32(item.Serial);
        }
    }
}
