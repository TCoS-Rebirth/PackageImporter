﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;
using TCosReborn.Framework.Common;


namespace SBGamePlay
{


    public class QT_Interactor : Quest_Target
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interact")]
        public string TargetTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interact")]
        public byte Option;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interact")]
        public LocalizedString TargetDescription;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Interact")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
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
