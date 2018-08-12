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
        public byte Part;

        [FoldoutGroup("Base")]
        public bool SelectableInCharacterCreation;

        [FoldoutGroup("Base")]
        public byte ColorMode;

        [FoldoutGroup("Base")]
        public bool ShowGuildLogo;

        public byte Specular;

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

        public Appearance_Base()
        {
        }

        [Serializable] public struct Attachment
        {
            public string MeshGroup;

            public byte SocketId;

            public byte Covers;

            public string AlternativeTexture;
        }

        [Serializable] public struct SubTextureLocation
        {
            public int Angle;

            public float Scale;

            public float CenterU;

            public float CenterV;
        }

        public enum ESpecularMode
        {
            Specular_None,

            Specular_Metal,

            Specular_Hair,
        }

        public enum EColorizeMode
        {
            Colorize_None,

            Colorize_OneColor,

            Colorize_TwoColor,

            Colorize_Unreal,

            Colorize_Skin,
        }

        public enum CoverageFlag
        {
            Covers_LeftAnkle,

            Covers_Belt,

            Covers_Chest,

            Covers_Head,

            Covers_HipLeft,

            Covers_HipRight,

            Covers_LeftLowerArm,

            Covers_LeftShoulder,

            Covers_LeftUpperArm,

            Covers_LeftLowerLeg,

            Covers_LeftUpperLeg,

            Covers_RightLowerArm,

            Covers_RightShoulder,

            Covers_RightUpperArm,

            Covers_RightLowerLeg,

            Covers_RightUpperLeg,

            Covers_Nothing,

            Covers_RightAnkle,
        }

        public enum AppearanceSocket
        {
            AS_Head,

            AS_RightPauldron,

            AS_LeftPauldron,

            AS_Chest,

            AS_BackMain,

            AS_LeftHandHolster,

            AS_RightHandHolster,

            AS_LeftBracer,

            AS_RightBracer,

            AS_LeftCalf,

            AS_RightCalf,

            AS_LeftThigh,

            AS_RightThigh,

            AS_Base,

            AS_Belt,

            AS_MainShoulderSheath,

            AS_OffhandShoulderSheath,

            AS_Shield,

            AS_ShieldSheath,
        }

        public enum AppearancePart
        {
            AP_ChestClothes,

            AP_LeftGlove,

            AP_RightGlove,

            AP_Pants,

            AP_Shoes,

            AP_HeadGearArmour,

            AP_LeftShoulderArmour,

            AP_RightShoulderArmour,

            AP_LeftGauntlet,

            AP_RightGauntlet,

            AP_ChestArmour,

            AP_Belt,

            AP_LeftThigh,

            AP_RightThigh,

            AP_LeftShin,

            AP_RightShin,

            AP_MainWeapon,

            AP_OffhandWeapon,

            AP_Hair,

            AP_MainSheath,

            AP_OffhandSheath,

            AP_Body,

            AP_Head,

            AP_Tattoo,

            AP_ClassTattoo,
        }
    }
}
/*
final native event string GetStaticAttachmentStr(Game_Pawn aPawn,int aIndex);
final native event StaticMesh GetStaticAttachment(Game_Pawn aPawn,int aIndex);
*/