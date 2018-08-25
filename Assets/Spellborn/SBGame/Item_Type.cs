using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Item_Type : Content_Type
    {
        [FieldConst()]
        public List<Item_Component> Components = new List<Item_Component>();

        [FoldoutGroup("ReadOnly")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public string Logo; //texture

        [FoldoutGroup("ReadOnly")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        public string SecondaryLogo; //texture

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool RequiresTicksValue;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private bool RequiresTicksDetermined;

        [FoldoutGroup("ReadOnly"), ReadOnly]
        [FieldConst()]
        public EItemType ItemType;

        [FoldoutGroup("General")]
        [FieldConst()]
        public int StackableAmount;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool Tradable;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool RecyclableIntoMoney;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool Sellable;

        [FoldoutGroup("General"), ReadOnly]
        [FieldConst()]
        public SBGameEnums.EquipmentSlot EquipmentSlot;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool Equipable;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool BindOnPickup;

        [FoldoutGroup("General")]
        [FieldConst()]
        public bool BindOnEquip;

        [FoldoutGroup("General"), ReadOnly]
        [FieldConst()]
        public EItemRarity ItemRarity;

        [FoldoutGroup("General")]
        [FieldConst()]
        protected int BuyPriceValue;

        [FoldoutGroup("General")]
        [FieldConst()]
        protected int SellPriceValue;

        [FoldoutGroup("General")]
        [FieldConst()]
        protected int RecyclePriceValue;

        [FoldoutGroup("General")]
        [FieldConst()]
        public byte MinLevel;

        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Info")]
        [FieldConst()]
        public LocalizedString Name;

        [FoldoutGroup("Info")]
        [FieldConst()]
        public LocalizedString Description;

        [FoldoutGroup("OnUse")]
        [FieldConst()]
        public float UseCooldown;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Content_Event> UseEvents = new List<Content_Event>();

        public T GetItemComponent<T>() where T : Item_Component
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var ic = Components[i] as T;
                if (ic != null) return ic;
            }
            return null;
        }

        public T GetItemComponent<T>(Predicate<T> predicate) where T : Item_Component
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var ic = Components[i] as T;
                if (ic != null && predicate(ic)) return ic;
            }
            return null;
        }

        #region enums
        public enum EItemType
        {
            IT_BodySlot = 0,

            IT_JewelryRing = 1,

            IT_JewelryNecklace = 2,

            IT_JewelryQualityToken = 3,

            IT_WeaponQualityToken = 4,

            IT_SkillToken = 5,

            IT_QuestItem = 6,

            IT_Trophy = 7,

            IT_ContainerSuitBag = 8,

            IT_ContainerExtraInventory = 9,

            IT_Resource = 10,

            IT_WeaponOneHanded = 11,

            IT_WeaponDoublehanded = 12,

            IT_WeaponDualWielding = 13,

            IT_WeaponRanged = 14,

            IT_WeaponShield = 15,

            IT_ArmorHeadGear = 16,

            IT_ArmorLeftShoulder = 17,

            IT_ArmorRightShoulder = 18,

            IT_ArmorLeftGauntlet = 19,

            IT_ArmorRightGauntlet = 20,

            IT_ArmorChest = 21,

            IT_ArmorBelt = 22,

            IT_ArmorLeftThigh = 23,

            IT_ArmorLeftShin = 24,

            IT_ClothChest = 25,

            IT_ClothLeftGlove = 26,

            IT_ClothRightGlove = 27,

            IT_ClothPants = 28,

            IT_ClothShoes = 29,

            IT_MiscellaneousTickets = 30,

            IT_MiscellaneousKey = 31,

            IT_MiscellaneousLabyrinthKey = 32,

            IT_Recipe = 33,

            IT_ArmorRightThigh = 34,

            IT_ArmorRightShin = 35,

            IT_ItemToken = 36,

            IT_Consumable = 37,

            IT_Broken = 38,
        }

        public enum EItemRarity
        {
            IR_Trash = 0,

            IR_Resource = 1,

            IR_Common = 2,

            IR_Uncommon = 3,

            IR_Rare = 4,

            IR_Ancestral = 5,

            IR_Mumian = 6,
        }
        #endregion

        public virtual Appearance_MainWeapon.EAppMainWeaponType GetWeaponType() 
        {
            return Appearance_MainWeapon.EAppMainWeaponType.EMW_Undetermined;                                                                   
        }
    }
}
/*
final event int GetBreakdownValue() {
return RecyclePriceValue;                                                   
}
final event int GetSellValue() {
return SellPriceValue;                                                      
}
final event int GetBuyPrice() {
return BuyPriceValue;                                                       
}

function bool IsNPCType() {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
if (Components[i].IsNPCItem()) {                                          
return True;                                                            
}
++i;                                                                      
}
return False;                                                               
}
event string GetName() {
if (Len(Name.Text) > 0) {                                                   
return Name.Text;                                                         
} else {                                                                    
return Class'StringReferences'.default._Unknown_item_.Text;               
}
}
final native function IC_EquipEffects GetEquipEffectsTokenComponent();
final native function IC_TokenItem GetItemTokenComponent();
final native function IC_TokenSkill GetSkillTokenComponent();
final native function Appearance_Base GetAppearance();
event int GetComponent(class<Object> ComponentClass) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
if (Components[i].Class == ComponentClass) {                              
return i;                                                               
}
i++;                                                                      
}
return -1;                                                                  
}
event OnSheathe(Game_Pawn aPawn) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
Components[i].OnSheathe(aPawn);                                           
i++;                                                                      
}
}
event OnDraw(Game_Pawn aPawn) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
Components[i].OnDraw(aPawn);                                              
i++;                                                                      
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
Components[i].OnUnequip(aPawn,aItem);                                     
i++;                                                                      
}
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
Components[i].OnEquip(aPawn,aItem);                                       
i++;                                                                      
}
}
event OnUse(Game_Pawn aPawn,Game_Item aItem) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
Components[i].OnUse(aPawn,aItem);                                         
i++;                                                                      
}
if (UseCooldown > 0) {                                                      
aItem.OnItemUsed();                                                       
}
}
event bool CanEquip(Game_Pawn aPawn,Game_Item aItem) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
if (!Components[i].CanEquip(aPawn,aItem)) {                               
return False;                                                           
}
i++;                                                                      
}
return True;                                                                
}
event bool sv_CanUse(Game_Pawn aPawn,Game_Item aItem) {
local int i;
i = 0;                                                                      
while (i < Components.Length) {                                             
if (!Components[i].CanUse(aPawn,aItem)) {                                 
return False;                                                           
}
i++;                                                                      
}
i = 0;                                                                      
while (i < Requirements.Length) {                                           
if (Requirements[i] == None
|| !Requirements[i].CheckPawn(aPawn)) {
return False;                                                           
}
i++;                                                                      
}
if (aPawn.CharacterStats.mRecord.FameLevel < MinLevel) {                    
return False;                                                             
}
return True;                                                                
}
final native function byte GetItemLevel();
final native function bool ShouldUseSecondaryLogo(Game_Pawn aPawn);
static native function LoadAllItems();
*/