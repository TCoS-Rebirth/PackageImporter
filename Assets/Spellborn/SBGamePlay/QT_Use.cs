using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Use : Quest_Target
    {
        [FoldoutGroup("Use")]
        [FieldConst()]
        public Item_Type Item;

        [FoldoutGroup("Use")]
        public byte Option;

        [FoldoutGroup("Use")]
        [FieldConst()]
        public int Amount;

        public QT_Use()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
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
protected function AppendProgressText(out string aDescription,int aProgress) {
if (Amount > 1) {                                                           
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_UseText.Text;                     
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
if (aObject == None) {                                                      
aSubOptions[aSubOptions.Length] = Option;                                 
}
}
*/