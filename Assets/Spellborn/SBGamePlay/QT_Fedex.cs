using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Fedex : Quest_Target
    {
        [FoldoutGroup("Fedex")]
        [FieldConst()]
        public NPC_Type Address;

        [FoldoutGroup("Fedex")]
        [FieldConst()]
        public Content_Inventory Cargo;

        [FoldoutGroup("Fedex")]
        [FieldConst()]
        public int Price;

        [FoldoutGroup("Talk")]
        [FieldConst()]
        public Conversation_Topic ThankYou;

        public QT_Fedex()
        {
        }
    }
}
/*
protected final native function NPC_Type GetTarget();
event string GetActiveText(Game_ActiveTextItem aItem) {
local export editinline NPC_Type A;
if (aItem.Tag == "T") {                                                     
A = Address;                                                              
if (A == None) {                                                          
A = Quest_Type(Outer).Finisher;                                         
}
if (A != None) {                                                          
return A.GetActiveText(aItem.SubItem);                                  
} else {                                                                  
return "?Target?";                                                      
}
} else {                                                                    
if (aItem.Tag == "O") {                                                   
if (Cargo.Count() >= aItem.Ordinality) {                                
return Cargo.GetItem(aItem.Ordinality).GetActiveText(aItem.SubItem);  
} else {                                                                
return "?Object?";                                                    
}
} else {                                                                  
return Super.GetActiveText(aItem);                                      
}
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_FedexText.Text;                   
}
*/