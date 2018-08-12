using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Deliver : Quest_Target
    {
        [FoldoutGroup("Deliver")]
        [FieldConst()]
        public NPC_Type Address;

        [FoldoutGroup("Deliver")]
        [FieldConst()]
        public Item_Type Cargo;

        [FoldoutGroup("Deliver")]
        [FieldConst()]
        public int Amount;

        [FoldoutGroup("Deliver")]
        [FieldConst()]
        public Conversation_Topic DeliveryConversation;

        public QT_Deliver()
        {
        }
    }
}
/*
protected final native function NPC_Type GetTarget();
event string GetActiveText(Game_ActiveTextItem aItem) {
local Game_ActiveTextItem pluralityItem;
local export editinline NPC_Type t;
if (aItem.Tag == "T") {                                                     
t = GetTarget();                                                          
if (t != None) {                                                          
return t.GetActiveText(aItem.SubItem);                                  
} else {                                                                  
return "?Target?";                                                      
}
} else {                                                                    
if (aItem.Tag == "Q") {                                                   
return "" @ string(Amount);                                             
} else {                                                                  
if (aItem.Tag == "O") {                                                 
if (Cargo != None) {                                                  
return Cargo.GetActiveText(aItem.SubItem);                          
} else {                                                              
return "?Object?";                                                  
}
} else {                                                                
if (aItem.Tag == "OS") {                                              
if (Cargo != None) {                                                
pluralityItem.Tag = "Q";                                          
pluralityItem.Ordinality = Amount;                                
pluralityItem.SubItem = aItem.SubItem;                            
return Cargo.GetActiveText(pluralityItem);                        
} else {                                                            
return "?Object?";                                                
}
} else {                                                              
return Super.GetActiveText(aItem);                                  
}
}
}
}
}
function bool sv_OnComplete(Game_Pawn aPawn,optional Game_Pawn aTargetPawn) {
local Content_Inventory tempInventory;
if (Super.sv_OnComplete(aPawn,aTargetPawn)) {                               
tempInventory = new Class'Content_Inventory';                             
tempInventory.AddItem(Cargo,Amount,0,0);                                  
if (RemoveItems(aPawn,tempInventory)) {                                   
return True;                                                            
}
}
return False;                                                               
}
protected function AppendProgressText(out string aDescription,int aProgress) {
if (aProgress > Amount) {                                                   
aProgress = Amount;                                                       
}
if (Amount > 1) {                                                           
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_DeliverText.Text;                 
}
*/