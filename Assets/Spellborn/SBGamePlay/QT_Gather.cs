using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Gather : Quest_Target
    {
        [FoldoutGroup("Gather")]
        [FieldConst()]
        public Item_Type Cargo;

        [FoldoutGroup("Gather")]
        [FieldConst()]
        public List<NPC_Type> NamedDroppers = new List<NPC_Type>();

        [FoldoutGroup("Gather")]
        [FieldConst()]
        public List<NPC_Taxonomy> GroupedDroppers = new List<NPC_Taxonomy>();

        [FoldoutGroup("Gather")]
        [FieldConst()]
        public int Amount;

        [FoldoutGroup("Gather")]
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