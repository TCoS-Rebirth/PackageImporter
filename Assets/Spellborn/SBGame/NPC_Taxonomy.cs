using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;
using Color = Engine.Color;

namespace SBGame
{
    [Serializable] public class NPC_Taxonomy : Content_Type
    {
        [FoldoutGroup("NPC_Taxonomy")]
        public string ClassesPackage = string.Empty;

        [FoldoutGroup("Description")]
        public LocalizedString prefix;

        [FoldoutGroup("Description")]
        public LocalizedString Description;

        [FoldoutGroup("Description")]
        public LocalizedString Postfix;

        [FoldoutGroup("Description")]
        [FieldConst()]
        public string Note = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Color AlternativeMainColor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Color AlternativeSecondaryColor;

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public Color ClothColor1;

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public Color ClothColor2;

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public Color ArmorColor1;

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public Color ArmorColor2;

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public string PaletteArmor; //texture

        [FoldoutGroup("Overrides")]
        [NonSerialized, HideInInspector]
        public string PaletteClothing; //texture

        public int CachedColorCloth1;

        public int CachedColorCloth2;

        public int CachedColorArmor1;

        public int CachedColorArmor2;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<NPC_Taxonomy> Enemies = new List<NPC_Taxonomy>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<NPC_Taxonomy> Friendlies = new List<NPC_Taxonomy>();

        [FoldoutGroup("Relations")]
        public List<NPC_Taxonomy> Likes = new List<NPC_Taxonomy>();

        [FoldoutGroup("Relations")]
        public List<NPC_Taxonomy> Dislikes = new List<NPC_Taxonomy>();

        [FoldoutGroup("Loot")]
        public List<LootTable> Loot = new List<LootTable>();

        public NPC_Taxonomy Parent;

        public NPC_Taxonomy()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem == None || aItem.Tag == "") {                                     
return GetDescription();                                                  
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
final native function AppendLoot(out array<LootTable> lootz);
native function int GetArmorColor2();
native function int GetArmorColor1();
native function int GetClothColor2();
native function int GetClothColor1();
native function string GetDescription();
final native function bool DoesntLike(export editinline NPC_Taxonomy aTaxonomyNode);
final native function bool IsParent(export editinline NPC_Taxonomy aTaxonomyNode);
function NPC_Taxonomy GetRoot() {
local export editinline NPC_Taxonomy P;
P = GetParent();                                                            
if (P != None) {                                                            
while (P.GetParent() != None) {                                           
P = P.GetParent();                                                      
}
}
return Parent;                                                              
}
function NPC_Taxonomy GetParent() {
return Parent;                                                              
}
*/