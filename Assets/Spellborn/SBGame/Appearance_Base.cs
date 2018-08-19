using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Appearance_Base : UObject
    {
        //[TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Base")]
        //public LocalizedString Name;

        [FoldoutGroup("Base")]
        public LocalizedString Description;

        [FoldoutGroup("Base")]
        [NonSerialized, HideInInspector]
        public string Palette1;

        [FoldoutGroup("Base")]
        [NonSerialized, HideInInspector]
        public string Palette2;

        [FoldoutGroup("Base")]
        public byte PaletteDefaultColor1;

        [FoldoutGroup("Base")]
        public byte PaletteDefaultColor2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public byte SortHelp;

        [FoldoutGroup("_LowLevel")]
        public AppearancePart Part;

        [FoldoutGroup("Base")]
        public bool SelectableInCharacterCreation;

        [FoldoutGroup("Base")]
        public EColorizeMode ColorMode;

        [FoldoutGroup("Base")]
        public bool ShowGuildLogo;

        [FoldoutGroup("Attachments")]
        public List<Attachment> Attachments = new List<Attachment>();

        [FoldoutGroup("Constraints")]
        public bool ExcludeHumans;

        [FoldoutGroup("Constraints")]
        public bool ExcludeDaevi;

        [FoldoutGroup("Constraints")]
        public bool ExcludeMale;

        [FoldoutGroup("Constraints")]
        public bool ExcludeFemale;

        [FoldoutGroup("Constraints")]
        public bool ExcludeFat;

        [FoldoutGroup("Constraints")]
        public bool ExcludeSkinny;

        [FoldoutGroup("Constraints")]
        public bool ExcludeHulk;

        [FoldoutGroup("Constraints")]
        public bool ExcludeAthletic;

        [FoldoutGroup("Constraints")]
        public bool ExcludeHumansInCharacterCreation;

        [FoldoutGroup("Constraints")]
        public bool ExcludeDaeviInCharacterCreation;

        public bool ApplyToTorso;

        public bool ApplyToRightArmUpper;

        public bool ApplyToLeftArmUpper;

        public bool ApplyToRightArmLower;

        public bool ApplyToLeftArmLower;

        public bool ApplyToRightHand;

        public bool ApplyToLeftHand;

        public bool ApplyToPelvis;

        public bool ApplyToThighs;

        public bool ApplyToCalves;

        public bool ApplyToFeet;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Item_Type _IT;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int _AS_Index;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool _AS_Set;

        [Serializable] public struct Attachment
        {
            public string MeshGroup;

            public AppearanceSocket SocketId;

            public CoverageFlag Covers;

            public string AlternativeTexture;
        }

        public enum EColorizeMode
        {
            Colorize_None = 0,

            Colorize_OneColor = 1,

            Colorize_TwoColor = 2,

            Colorize_Unreal = 3,

            Colorize_Skin = 4,
        }

        public enum CoverageFlag
        {
            Covers_LeftAnkle = 0,

            Covers_Belt = 1,

            Covers_Chest = 2,

            Covers_Head = 3,

            Covers_HipLeft = 4,

            Covers_HipRight = 5,

            Covers_LeftLowerArm = 6,

            Covers_LeftShoulder = 7,

            Covers_LeftUpperArm = 8,

            Covers_LeftLowerLeg = 9,

            Covers_LeftUpperLeg = 10,

            Covers_RightLowerArm = 11,

            Covers_RightShoulder = 12,

            Covers_RightUpperArm = 13,

            Covers_RightLowerLeg = 14,

            Covers_RightUpperLeg = 15,

            Covers_Nothing = 16,

            Covers_RightAnkle = 17,
        }

        public enum AppearanceSocket
        {
            AS_Head = 0,

            AS_RightPauldron = 1,

            AS_LeftPauldron = 2,

            AS_Chest = 3,

            AS_BackMain = 4,

            AS_LeftHandHolster = 5,

            AS_RightHandHolster = 6,

            AS_LeftBracer = 7,

            AS_RightBracer = 8,

            AS_LeftCalf = 9,

            AS_RightCalf = 10,

            AS_LeftThigh = 11,

            AS_RightThigh = 12,

            AS_Base = 13,

            AS_Belt = 14,

            AS_MainShoulderSheath = 15,

            AS_OffhandShoulderSheath = 16,

            AS_Shield = 17,

            AS_ShieldSheath = 18,
        }

        public enum AppearancePart
        {
            AP_ChestClothes = 0,

            AP_LeftGlove = 1,

            AP_RightGlove = 2,

            AP_Pants = 3,

            AP_Shoes = 4,

            AP_HeadGearArmour = 5,

            AP_LeftShoulderArmour = 6,

            AP_RightShoulderArmour = 7,

            AP_LeftGauntlet = 8,

            AP_RightGauntlet = 9,

            AP_ChestArmour = 10,

            AP_Belt = 11,

            AP_LeftThigh = 12,

            AP_RightThigh = 13,

            AP_LeftShin = 14,

            AP_RightShin = 15,

            AP_MainWeapon = 16,

            AP_OffhandWeapon = 17,

            AP_Hair = 18,

            AP_MainSheath = 19,

            AP_OffhandSheath = 20,

            AP_Body = 21,

            AP_Head = 22,

            AP_Tattoo = 23,

            AP_ClassTattoo = 24,
        }
    }
}
/*
final native event string GetStaticAttachmentStr(Game_Pawn aPawn,int aIndex);
final native event StaticMesh GetStaticAttachment(Game_Pawn aPawn,int aIndex);
*/