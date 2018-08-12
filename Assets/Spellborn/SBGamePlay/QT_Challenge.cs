using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Challenge : Quest_Target
    {
        [FoldoutGroup("Challenge")]
        public int TargetWorld;

        [FoldoutGroup("Challenge")]
        public NameProperty CompletionTag;

        [FoldoutGroup("Challenge")]
        public NameProperty FailureTag;

        [FoldoutGroup("Challenge")]
        public Item_Type Pass;

        public QT_Challenge()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "O") {                                                     
if (Pass != None) {                                                       
return Pass.GetActiveText(aItem.SubItem);                               
} else {                                                                  
return "?Object?";                                                      
}
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
*/