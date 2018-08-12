using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Hunt : Quest_Target
    {
        [FoldoutGroup("Hunt")]
        [FieldConst()]
        public NPC_Type Target;

        [FoldoutGroup("Hunt")]
        [FieldConst()]
        public int Amount;

        public QT_Hunt()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return Target.GetActiveText(aItem.SubItem);                               
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
return Class'StringReferences'.default.QT_HuntText.Text;                    
}
*/