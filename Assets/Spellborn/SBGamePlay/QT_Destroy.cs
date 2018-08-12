using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Destroy : Quest_Target
    {
        [FoldoutGroup("Destroy")]
        [FieldConst()]
        public NPC_Type Target;

        [FoldoutGroup("Destroy")]
        [FieldConst()]
        public int Amount;

        public QT_Destroy()
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
return Class'StringReferences'.default.QT_DestroyText.Text;                 
}
*/