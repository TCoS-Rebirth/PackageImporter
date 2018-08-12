using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Wait : Quest_Target
    {
        [FoldoutGroup("Condition")]
        [FieldConst()]
        public int Seconds;

        public QT_Wait()
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
return Class'StringReferences'.default.QT_WaitText.Text;                    
}
*/