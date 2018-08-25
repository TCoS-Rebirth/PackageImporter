using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Take : Quest_Target
    {
        [FoldoutGroup("Take")]
        [FieldConst()]
        public Content_Inventory Cargo;

        [FoldoutGroup("Take")]
        public NameProperty SourceTag;

        [FoldoutGroup("Take")]
        public LocalizedString SourceDescription;

        [FoldoutGroup("Take")]
        public byte Option;

        [FoldoutGroup("Take")]
        [FieldConst()]
        public int Amount;

        public QT_Take()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return SourceDescription.Text;                                            
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
return Class'StringReferences'.default.QT_TakeText.Text;                    
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
local Actor act;
act = Actor(aObject);                                                       
if (act != None && act.Tag == SourceTag) {                                  
aSubOptions[aSubOptions.Length] = Option;                                 
}
}
*/