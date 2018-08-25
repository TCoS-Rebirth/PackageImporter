using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Interactor : Quest_Target
    {
        [FoldoutGroup("Interact")]
        public NameProperty TargetTag;

        [FoldoutGroup("Interact")]
        public byte Option;

        [FoldoutGroup("Interact")]
        public LocalizedString TargetDescription;

        [FoldoutGroup("Interact")]
        [FieldConst()]
        public int Amount;

        public QT_Interactor()
        {
        }
    }
}
/*
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem.Tag == "T") {                                                     
return TargetDescription.Text;                                            
} else {                                                                    
if (aItem.Tag == "Q") {                                                   
return "" @ string(Amount);                                             
} else {                                                                  
return Super.GetActiveText(aItem);                                      
}
}
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
local Actor act;
act = Actor(aObject);                                                       
if (act != None && act.Tag == TargetTag) {                                  
aSubOptions[aSubOptions.Length] = Option;                                 
}
}
protected function AppendProgressText(out string aDescription,int aProgress) {
if (Amount > 1) {                                                           
}
}
protected function string GetDefaultDescription() {
return Class'StringReferences'.default.QT_InteractText.Text;                
}
*/