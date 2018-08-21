using System;
using System.Collections.Generic;
using Engine;
using Network;
using SBBase;
using SBGame;
using UnityEngine;
using Utilities;

namespace User
{
    public partial class GameSession : PlayerSession
    {

        DB_Item CreateDBItemFromItemSet<T>(List<T> set, int setIndex, int characterID, byte color1, byte color2) where T:Item_Type
        {
            var item = new DB_Item();
            var gameItem = set[setIndex];
            item.ItemTypeID = gameItem.ResourceID;
            item.LocationSlot = (int)gameItem.EquipmentSlot;
            item.LocationType = (int)Game_Item.EItemLocationType.ILT_Equipment;
            item.LocationID = 0;
            item.Id = ServiceContainer.GetService<IDatabase>().Characters.AllocateItemID();
            item.Color1 = color1;
            item.Color2 = color2;
            item.StackSize = 1;
            item.CharacterID = characterID;
            return item;
        }

		[HandlesPacket(GameHeader.C2S_CS_CREATE_CHARACTER)]
        void C2S_CS_CREATE_CHARACTER(NetworkPacket packet)
		{
		    var db = ServiceContainer.GetService<IDatabase>();
		    var ccItems = ServiceContainer.GetService<IGameResources>().CCItemSets;
		    var universe = ServiceContainer.GetService<IGameResources>().Universe;
		    var map = ServiceContainer.GetService<IMapHandler>().GetPersistentMap(universe.EntryWorld.worldID);
		    var start = map.Find<PlayerStart>(playerStart => playerStart.NavigationTag.Equals(universe.EntryPortal.Tag));
		    if (start == null) throw new NullReferenceException("Entry portal is null");

            var lod0 = packet.ReadByteArray();
            var lod1 = packet.ReadByteArray();
            var lod2 = packet.ReadByteArray();
            var lod3 = packet.ReadByteArray();
            var name = packet.ReadString();
            var archeType = packet.ReadInt32();

            var skillDeck = new DB_SkillDeck();
		    skillDeck.Id = db.Characters.AllocateSkillDeckID();
            skillDeck.mName = name; //TODO investigate - probably wrong
            for (var i = 0; i < 5; i++)
            {
                skillDeck.mSkills.Add(packet.ReadInt32());
            }

            var shieldIndicator = packet.ReadInt32();
		    Debug.Log("Shield: " + shieldIndicator);
            //Lods parsing
            Array.Reverse(lod0);
            Array.Reverse(lod1);
            Array.Reverse(lod2);
            Array.Reverse(lod3);
            //lod0
            var rightGauntletColour1 = lod0[5];
            var rightGauntletColour2 = lod0[6];
            var leftGauntletColour1 = lod0[7];
            var leftGauntletColour2 = lod0[8];
            var rightGloveColour1 = lod0[9];
            var rightGloveColour2 = lod0[10];
            var leftGloveColour1 = lod0[11];
            var leftGloveColour2 = lod0[12];
            //Lod0 rest
            var voiceId = lod0[0]; //
            var rightArmTattooId = (byte) (lod0[3] & 0x0F);
            var chestTattooId = (byte) (lod0[4] & 0x0F);
            var leftArmTattooId = (byte) ((lod0[4] & 0xF0) >> 4);
            //Lod1
            var shinRightColour1 = lod1[0];
            var shinRightColour2 = lod1[1];
            var shinLeftColour1 = lod1[2];
            var shinLeftColour2 = lod1[3];
            var thighRightColour1 = lod1[4];
            var thighRightColour2 = lod1[5];
            var thighLeftColour1 = lod1[6];
            var thighLeftColour2 = lod1[7];
            var beltColour1 = lod1[8];
            var beltColour2 = lod1[9];
            var rightShoulderColour1 = lod1[10];
            var rightShoudlerColour2 = lod1[11];
            var leftShoulderColour1 = lod1[12];
            var leftShoulderColour2 = lod1[13];
            var helmetColour1 = lod1[14];
            var helmetColour2 = lod1[15];
            var shoesColour1 = lod1[16];
            var shoesColour2 = lod1[17];
            var pantsColour1 = lod1[18];
            var pantsColour2 = lod1[19];
            //Lod2
            var rangedWeaponId = (byte) (((lod2[1] & 0x0F) << 2) | ((lod2[2] & 0xC0) >> 6));
            var shieldId = (byte) (((lod2[2] & 0x3F) << 2) | ((lod2[3] & 0xC0) >> 6));
            var meleeWeaponId = (byte) (((lod2[3] & 0x3F) << 2) | ((lod2[4] & 0xC0) >> 6));
            var shinRightId = (byte) (lod2[4] & 0x3F);
            var shinLeftId = (byte) ((lod2[5] & 0xFC) >> 2);
            var thighRightId = (byte) (((lod2[5] & 0x03) << 4) | ((lod2[6] & 0xF0) >> 4));
            var thighLeftId = (byte) (((lod2[6] & 0x0F) << 2) | ((lod2[7] & 0xC0) >> 6));
            var beltId = (byte) (lod2[7] & 0x3F);
            var gauntletRightId = (byte) ((lod2[8] & 0xFC) >> 2);
            var gauntletLeftId = (byte) (((lod2[8] & 0x03) << 4) | ((lod2[9] & 0xF0) >> 4));
            var shoulderRightId = (byte) (((lod2[9] & 0x0F) << 2) | ((lod2[10] & 0xC0) >> 6));
            var shoulderLeftId = (byte) (lod2[10] & 0x3F);
            var helmetId = (byte) ((lod2[11] & 0xFC) >> 2);
            var shoesId = (byte) (((lod2[11] & 0x03) << 5) | ((lod2[12] & 0xF8) >> 3));
            var pantsId = (byte) (((lod2[12] & 0x07) << 4) | ((lod2[13] & 0xF0) >> 4));
            var gloveRightId = (byte) (((lod2[13] & 0x0F) << 2) | ((lod2[14] & 0xC0) >> 6));
            var gloveLeftId = (byte) (lod2[14] & 0x3F);
            //Lod3
            var chestArmourColour1 = (byte) (((lod3[0] & 0xFE) << 1) | (lod3[1] >> 7));
            var chestArmourColour2 = (byte) (((lod3[1] & 0x7F) << 1) | (lod3[2] >> 7));
            var chestArmourId = (byte) ((lod3[2] & 0x7E) >> 1);
            var chestClothColour1 = (byte) ((lod3[2] << 7) | (lod3[3] >> 1));
            var chestClothColour2 = (byte) ((lod3[3] << 7) | (lod3[4] >> 1));
            var chestClothID = (byte) ((lod3[4] << 7) | (lod3[5] >> 1));
            var hairColour = (byte) ((lod3[5] << 7) | (lod3[6] >> 1));
            var hairStyleId = (byte) (((lod3[6] & 0x01) << 5) | (lod3[7] >> 3));
            var bodyColour = (byte) ((lod3[7] << 5) | (lod3[8] >> 3));
            var headTypeId = (byte) (((lod3[8] & 0x07) << 4) | ((lod3[9] & 0xF0) >> 4));
            var bodyTypeId = (byte) ((lod3[9] & 0x0C) >> 2);
            var genderId = (byte) ((lod3[9] & 0x02) >> 1);
            var raceId = (byte) (lod3[9] & 0x01);

		    var dbChar = new DB_Character
		    {
		        Id = db.Characters.AllocateCharacterID(),
                Name = name,
		        AccountID = Account.UID,
		        Dead = (byte) Game_Pawn.EPawnStates.PS_ALIVE,
		        FactionId = 77467, //Enclave (correct?)
		        LastUsedTimestamp = DatabaseUtility.GetUnixTimestamp(DateTime.Now),
		        Location = UnitConversion.ToUnreal(start.transform.position),
		        Rotation = start.Rotation,
		        Money = 0,
		        worldID = (int) map.ID
		    };
		    AppearancePackUtility.Pack(
		        raceId, genderId, bodyTypeId, headTypeId, bodyColour, chestTattooId, leftArmTattooId, rightArmTattooId,
		        hairStyleId, hairColour, voiceId, out dbChar.AppearancePart1, out dbChar.AppearancePart2);

		    var items = new List<DB_Item>();
		    if (shoesId > 0) items.Add(CreateDBItemFromItemSet(ccItems.ShoesSet, shoesId, dbChar.Id, shoesColour1, shoesColour2));
		    if (pantsId > 0) items.Add(CreateDBItemFromItemSet(ccItems.PantsSet, pantsId, dbChar.Id, pantsColour1, pantsColour2));
		    if (chestClothID > 0) items.Add(CreateDBItemFromItemSet(ccItems.ChestClothesSet, chestClothID, dbChar.Id, chestClothColour1, chestClothColour2));
		    if (chestArmourId > 0) items.Add(CreateDBItemFromItemSet(ccItems.ChestSet, chestArmourId, dbChar.Id, chestArmourColour1, chestArmourColour2));
		    if (beltId > 0) items.Add(CreateDBItemFromItemSet(ccItems.BeltSet, beltId, dbChar.Id, beltColour1, beltColour2));
		    if (helmetId > 0) items.Add(CreateDBItemFromItemSet(ccItems.HeadGearSet, helmetId, dbChar.Id, helmetColour1, helmetColour2));
		    if (shinLeftId > 0) items.Add(CreateDBItemFromItemSet(ccItems.LeftShinSet, shinLeftId, dbChar.Id, shinLeftColour1, shinLeftColour2));
		    if (shinRightId > 0) items.Add(CreateDBItemFromItemSet(ccItems.RightShinSet, shinRightId, dbChar.Id, shinRightColour1, shinRightColour2));
		    if (shoulderLeftId > 0) items.Add(CreateDBItemFromItemSet(ccItems.LeftShoulderSet, shoulderLeftId, dbChar.Id, leftShoulderColour1, leftShoulderColour2));
		    if (shoulderRightId > 0) items.Add(CreateDBItemFromItemSet(ccItems.RightShoulderSet, shoulderRightId, dbChar.Id, rightShoulderColour1, rightShoudlerColour2));
		    if (thighLeftId > 0) items.Add(CreateDBItemFromItemSet(ccItems.LeftThighSet, thighLeftId, dbChar.Id, thighLeftColour1, thighLeftColour2));
		    if (thighRightId > 0) items.Add(CreateDBItemFromItemSet(ccItems.RightThighSet, thighRightId, dbChar.Id, thighRightColour1, thighRightColour2));
		    if (gloveLeftId > 0) items.Add(CreateDBItemFromItemSet(ccItems.LeftGloveSet, gloveLeftId, dbChar.Id, leftGloveColour1, leftGloveColour2));
		    if (gloveRightId > 0) items.Add(CreateDBItemFromItemSet(ccItems.RightGloveSet, gloveRightId, dbChar.Id, rightGloveColour1, rightGloveColour2));
		    if (gauntletLeftId > 0) items.Add(CreateDBItemFromItemSet(ccItems.LeftGauntletSet, gauntletLeftId, dbChar.Id, leftGauntletColour1, leftGauntletColour2));
		    if (gauntletRightId > 0) items.Add(CreateDBItemFromItemSet(ccItems.RightGauntletSet, gauntletRightId, dbChar.Id, rightGauntletColour1, rightGauntletColour2));
		    if (meleeWeaponId > 0) items.Add(CreateDBItemFromItemSet(ccItems.MainWeaponSet, meleeWeaponId, dbChar.Id, 0, 0));
		    if (rangedWeaponId > 0) items.Add(CreateDBItemFromItemSet(ccItems.MainWeaponSet, rangedWeaponId, dbChar.Id, 0, 0));
		    if (shieldId > 0) items.Add(CreateDBItemFromItemSet(ccItems.OffhandWeaponSet, shieldId, dbChar.Id, 0, 0));

		    var charSheet = new DB_CharacterSheet
		    {
		        ClassId = archeType,
		        ExtraBodyPoints = 0,
		        ExtraMindPoints = 0,
		        ExtraFocusPoints = 0,
		        FamePoints = 0,
		        Health = 100,
		        PepPoints = 0,
		        SelectedSkilldeckID = skillDeck.Id
		    };

		    if (!db.Characters.Save(new Database.DBPlayerCharacter(dbChar, charSheet)) ||
		        !db.Characters.Save(skillDeck) ||
		        !db.Characters.Save(items))
		    {
		        Debug.LogError("Error saving newly created character for " + Account.Name);
		        var outMsg = GameHeader.S2C_CS_CREATE_CHARACTER_ACK.CreatePacket();
		        outMsg.WriteInt32((int) PacketStatusCode.UNKNOWN_ERROR);
		        Connection.SendMessage(outMsg);
		    }
		    else
		    {
		        Debug.Log(string.Format("Character '{0}' created for {1}", dbChar.Name, Account.Name));
		        var outMsg = GameHeader.S2C_CS_CREATE_CHARACTER_ACK.CreatePacket();
		        outMsg.WriteInt32((int) PacketStatusCode.NO_ERROR);
		        outMsg.Write(dbChar);
		        outMsg.Write(charSheet);
                outMsg.Write(items);
		        Connection.SendMessage(outMsg);
		    }

		}

        [HandlesPacket(GameHeader.C2S_CS_DELETE_CHARACTER)]
        void C2S_DELETE_CHARACTER(NetworkPacket packet)
        {
            var charID = packet.ReadInt32();
            var success = ServiceContainer.GetService<IDatabase>().Characters.DeleteCharacter(charID, Account.UID);
            var response = GameHeader.S2C_CS_DELETE_CHARACTER_ACK.CreatePacket();
            response.WriteInt32(success ? 0 : 3);
            response.WriteInt32(success ? charID : -1);
            Connection.SendMessage(response);
        }

        [HandlesPacket(GameHeader.C2S_CS_SELECT_CHARACTER)]
        void C2S_SELECT_CHARACTER(NetworkPacket packet)
        {
            var charID = packet.ReadInt32();
            var db = ServiceContainer.GetService<IDatabase>().Characters;
            var character = db.GetCharacter(charID, Account.UID);
            if (character == null)
            {
                var msg = GameHeader.S2C_CS_SELECT_CHARACTER_ACK.CreatePacket();
                msg.WriteInt32(2);
                Connection.SendMessage(msg);
            }
            else
            {
                ActiveCharacterMap = ServiceContainer.GetService<IMapHandler>().GetPersistentMap((MapIDs)character.worldID); //TODO change to instanceID / handle instances when needed
                ActiveCharacter = ActiveCharacterMap.Spawn(ServiceContainer.GetService<IGameResources>().PlayerPrefab, character.Location, character.Rotation, controller => 
                {
                    controller.AccountID = Account.UID;
                    controller.DBCharacter = character;
                    controller.DBCharacterSheet = db.GetSheet(character.Id);
                    controller.DBSkilldecks.Add(db.GetSkillDeck(0));
                    //controller.DBCharacterSkills = TODO
                    //controller.DBSkillTokens = TODO
                    //controller.DBFinishedQuests = TODO
                    //controller.DBQuestObjectiveIds = TODO
                    //controller.DBQuestObjectiveValues = TODO
                    //controller.DBPersistentVariables = TODO
                    controller.DBItems = db.GetItems(character.Id);   
                });
                LoadClientMap(ActiveCharacterMap.ID);
            }
        }
    }
}
