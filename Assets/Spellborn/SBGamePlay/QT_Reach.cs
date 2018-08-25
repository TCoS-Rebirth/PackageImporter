using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Reach : Quest_Target
    {
        [FoldoutGroup("Reach")]
        public NameProperty GoalTag;

        [FoldoutGroup("Reach")]
        public LocalizedString GoalDescription;

        public QT_Reach()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return GoalDescription.Text;                                              
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_ReachText.Text;                   
}
*/