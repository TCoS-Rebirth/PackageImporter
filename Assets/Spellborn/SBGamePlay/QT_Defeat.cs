using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Defeat : Quest_Target
    {
        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public NPC_Type Target;

        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public float DefeatFraction;

        [FoldoutGroup("Defeat")]
        [FieldConst()]
        public Conversation_Topic LastWords;

        public QT_Defeat()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return Target.GetActiveText(aItem.SubItem);                               
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_DefeatText.Text;                  
}
*/