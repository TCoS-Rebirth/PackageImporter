﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;
using System.Collections.Generic;


namespace SBGamePlay
{


    public class QT_Gather : Quest_Target
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Gather")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Item_Type Cargo;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Gather")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<NPC_Type> NamedDroppers = new List<NPC_Type>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Gather")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<NPC_Taxonomy> GroupedDroppers = new List<NPC_Taxonomy>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Gather")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int Amount;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Gather")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float DropChance;
        
        public QT_Gather()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "O") {                                                     
if (Cargo != None) {                                                      
return Cargo.GetActiveText(aItem.SubItem);                              
} else {                                                                  
return "?Object?";                                                      
}
} else {                                                                    
if (aItem.Tag == "Q") {                                                   
return "" @ string(Amount);                                             
} else {                                                                  
return Super.GetActiveText(aItem);                                      
}
}
}
protected function AppendProgressText(out string aDescription,int aProgress) {
if (Amount > 1) {                                                           
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_GatherText.Text;                  
}
*/
