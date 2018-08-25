using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QC_Timed : Quest_Condition
    {
        [FoldoutGroup("Condition")]
        [FieldConst()]
        public int Seconds;

        public QC_Timed()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "Q") {                                                     
return GetTimeText(Seconds);                                              
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QC_TimedText.Text;                   
}
*/