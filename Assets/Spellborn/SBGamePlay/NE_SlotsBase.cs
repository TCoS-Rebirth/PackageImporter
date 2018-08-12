using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NE_SlotsBase : NPC_Equipment
    {
        [FoldoutGroup("Equipment")]
        public Item_Type W01_MeleeWeapon;

        [FoldoutGroup("Equipment")]
        public Item_Type W02_RangedWeapon;

        [FoldoutGroup("Equipment")]
        public Item_WeaponShield W03_Shield;

        [FoldoutGroup("Equipment")]
        public Item_ClothChest C01_Chest;

        [FoldoutGroup("Equipment")]
        public Item_ClothLeftGlove C02_LeftGlove;

        [FoldoutGroup("Equipment")]
        public Item_ClothRightGlove C03_RightGlove;

        [FoldoutGroup("Equipment")]
        public Item_ClothPants C04_Pants;

        [FoldoutGroup("Equipment")]
        public Item_ClothShoes C05_Shoes;

        [FoldoutGroup("Equipment")]
        public Item_ArmorHeadGear A01_Helmet;

        [FoldoutGroup("Equipment")]
        public Item_ArmorRightShoulder A02_RightShoulder;

        [FoldoutGroup("Equipment")]
        public Item_ArmorLeftShoulder A03_LeftShoulder;

        [FoldoutGroup("Equipment")]
        public Item_ArmorRightGauntlet A04_RightGauntlet;

        [FoldoutGroup("Equipment")]
        public Item_ArmorLeftGauntlet A05_LeftGauntlet;

        [FoldoutGroup("Equipment")]
        public Item_ArmorChest A06_ChestArmour;

        [FoldoutGroup("Equipment")]
        public Item_ArmorBelt A07_Belt;

        [FoldoutGroup("Equipment")]
        public Item_ArmorLeftThigh A08_LeftThigh;

        [FoldoutGroup("Equipment")]
        public Item_ArmorRightThigh A09_RightThigh;

        [FoldoutGroup("Equipment")]
        public Item_ArmorLeftShin A10_LeftShin;

        [FoldoutGroup("Equipment")]
        public Item_ArmorRightShin A11_RightShin;

        [FoldoutGroup("Equipment")]
        public Item_JewelryRing J01_LeftRing;

        [FoldoutGroup("Equipment")]
        public Item_JewelryRing J02_RightRing;

        [FoldoutGroup("Equipment")]
        public Item_JewelryNecklace J03_Necklace;

        public NE_SlotsBase()
        {
        }

        [Serializable] public struct NE_ItemColor
        {
            public int Color1;

            public int Color2;
        }
    }
}