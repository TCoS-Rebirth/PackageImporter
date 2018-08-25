using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Kill : Quest_Target
    {
        [FoldoutGroup("Kill")]
        [FieldConst()]
        public List<NPC_Type> Targets = new List<NPC_Type>();

        public QT_Kill()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
if (aItem.Ordinality <= Targets.Length) {                                 
return Targets[aItem.Ordinality].GetActiveText(aItem.SubItem);          
} else {                                                                  
return "?Target?";                                                      
}
}
if (aItem.Tag == "Q") {                                                     
return "" @ string(Targets.Length);                                       
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function AppendProgressText(out string aDescription,int aProgress) {
local int ti;
local int killcount;
if (Targets.Length > 1) {                                                   
ti = 0;                                                                   
while (ti < Targets.Length) {                                             
if ((aProgress & 1 << ti) != 0) {                                       
++killcount;                                                          
}
++ti;                                                                   
}
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_KillText.Text;                    
}
*/