using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Exterminate : Quest_Target
    {
        [FoldoutGroup("Kill")]
        [FieldConst()]
        public NPC_Taxonomy Target;

        [FoldoutGroup("Kill")]
        [FieldConst()]
        public int KillAmount;

        public QT_Exterminate()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
if (Target != None) {                                                     
return Target.GetActiveText(aItem.SubItem);                             
} else {                                                                  
return "?Target?";                                                      
}
} else {                                                                    
if (aItem.Tag == "Q") {                                                   
return "" @ string(KillAmount);                                         
} else {                                                                  
return Super.GetActiveText(aItem);                                      
}
}
}
protected function AppendProgressText(out string aDescription,int aProgress) {
if (KillAmount > 1) {                                                       
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_ExterminateText.Text;             
}
*/