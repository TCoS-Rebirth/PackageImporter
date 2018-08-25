using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Place : Quest_Target
    {
        [FoldoutGroup("Place")]
        [FieldConst()]
        public Content_Inventory Cargo;

        [FoldoutGroup("Place")]
        public NameProperty TargetTag;

        [FoldoutGroup("Place")]
        public LocalizedString TargetDescription;

        [FoldoutGroup("Place")]
        public byte Option;

        [FoldoutGroup("Place")]
        [FieldConst()]
        public int Amount;

        public QT_Place()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return TargetDescription.Text;                                            
} else {                                                                    
if (aItem.Tag == "O") {                                                   
return Cargo.GetActiveText(aItem.SubItem);                              
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
return Class'StringReferences'.default.QT_PlaceText.Text;                   
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
local Actor act;
act = Actor(aObject);                                                       
if (act != None && act.Tag == TargetTag) {                                  
aSubOptions[aSubOptions.Length] = Option;                                 
}
}
*/