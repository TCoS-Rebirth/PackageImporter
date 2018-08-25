using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Talk : Quest_Target
    {
        [FoldoutGroup("Talk")]
        [FieldConst()]
        public NPC_Type Person;

        [FoldoutGroup("Talk")]
        [FieldConst()]
        public Conversation_Topic Topic;

        public QT_Talk()
        {
        }
    }
}
/*
protected final native function NPC_Type GetTarget();
event string GetActiveText(Game_ActiveTextItem aItem) {
local export editinline NPC_Type t;
if (aItem.Tag == "T") {                                                     
t = GetTarget();                                                          
if (t != None) {                                                          
return t.GetActiveText(aItem.SubItem);                                  
} else {                                                                  
return "?Target?";                                                      
}
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_TalkText.Text;                    
}
*/