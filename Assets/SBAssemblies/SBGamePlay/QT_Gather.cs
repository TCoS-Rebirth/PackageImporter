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
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGamePlay
{
    
    
    [System.Serializable] public class QT_Gather : Quest_Target
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("Gather")]
        [FieldConst()]
        public Item_Type Cargo;
        
        [Sirenix.OdinInspector.FoldoutGroup("Gather")]
        [FieldConst()]
        public List<NPC_Type> NamedDroppers = new List<NPC_Type>();
        
        [Sirenix.OdinInspector.FoldoutGroup("Gather")]
        [FieldConst()]
        public List<NPC_Taxonomy> GroupedDroppers = new List<NPC_Taxonomy>();
        
        [Sirenix.OdinInspector.FoldoutGroup("Gather")]
        [FieldConst()]
        public int Amount;
        
        [Sirenix.OdinInspector.FoldoutGroup("Gather")]
        [FieldConst()]
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
