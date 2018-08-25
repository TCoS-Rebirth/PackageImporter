using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QC_Protect : Quest_Condition
    {
        [FoldoutGroup("Condition")]
        [FieldConst()]
        public List<NPC_Type> Targets = new List<NPC_Type>();

        [FoldoutGroup("Condition")]
        [FieldConst()]
        public int Slack;

        public QC_Protect()
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
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QC_ProtectText.Text;                 
}
*/