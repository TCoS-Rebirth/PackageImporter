﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using System.Collections.Generic;
using TCosReborn.Framework.Common;


namespace SBGame
{


    public class NPC_Taxonomy : Content_Type
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="NPC_Taxonomy")]
        public string ClassesPackage = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        public LocalizedString prefix;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        public LocalizedString Description;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        public LocalizedString Postfix;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Description")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public string Note = string.Empty;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Color AlternativeMainColor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Color AlternativeSecondaryColor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color ClothColor1;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color ClothColor2;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color ArmorColor1;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color ArmorColor2;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture PaletteArmor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Overrides")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture PaletteClothing;
        
        public int CachedColorCloth1;
        
        public int CachedColorCloth2;
        
        public int CachedColorArmor1;
        
        public int CachedColorArmor2;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<NPC_Taxonomy> Enemies = new List<NPC_Taxonomy>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<NPC_Taxonomy> Friendlies = new List<NPC_Taxonomy>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Relations")]
        public List<NPC_Taxonomy> Likes = new List<NPC_Taxonomy>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Relations")]
        public List<NPC_Taxonomy> Dislikes = new List<NPC_Taxonomy>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Loot")]
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
