using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_UseAt : Quest_Target
    {
        [FoldoutGroup("Use")]
        [FieldConst()]
        public Item_Type Item;

        [FoldoutGroup("Use")]
        public NameProperty UseLocationTag;

        [FoldoutGroup("Use")]
        public LocalizedString LocationDescription;

        [FoldoutGroup("Use")]
        [FieldConst()]
        public int Amount;

        [FoldoutGroup("Use")]
        public byte Option;

        public QT_UseAt()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return LocationDescription.Text;                                          
} else {                                                                    
if (aItem.Tag == "O") {                                                   
if (Item != None) {                                                     
return Item.GetActiveText(aItem.SubItem);                             
} else {                                                                
return "?Object?";                                                    
}
} else {                                                                  
if (aItem.Tag == "Q") {                                                 
return "" @ string(Amount);                                           
} else {                                                                
return Super.GetActiveText(aItem);                                    
}
}
}
}
protected function AppendProgressText(out string aDescription,int aProgress) {
if (Amount > 1) {                                                           
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_UseAtText.Text;                   
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
local Quest_Trigger Area;
if (aObject == None) {                                                      
foreach aPlayerPawn.TouchingActors(Class'Quest_Trigger',Area) {           
if (Area.Tag == UseLocationTag) {                                       
aSubOptions[aSubOptions.Length] = Option;                             
}
}
}
}
*/