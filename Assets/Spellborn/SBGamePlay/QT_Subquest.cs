using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class QT_Subquest : Quest_Target
    {
        public Quest_Type SubQuest;

        public QT_Subquest()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
if (SubQuest != None) {                                                   
return SubQuest.GetActiveText(aItem.SubItem);                           
} else {                                                                  
return "?Quest?";                                                       
}
} else {                                                                    
return Super.GetActiveText(aItem);                                        
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_SubQuestText.Text;                
}
*/