﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGamePlay
{
    
    
    public class QT_UseOn : Quest_Target
    {
        
        [FieldCategory(Category="Use")]
        [FieldConst()]
        public Item_Type Item;
        
        [FieldCategory(Category="Use")]
        [FieldConst()]
        public NPC_Type Target;
        
        [FieldCategory(Category="Use")]
        [FieldConst()]
        public int Amount;
        
        [FieldCategory(Category="Use")]
        public byte Option;
        
        public QT_UseOn()
        {
        }
    }
}
/*
protected final native function NPC_Type GetTarget();
event string GetActiveText(Game_ActiveTextItem aItem) {
local export editinline NPC_Type t;
if (aItem.Tag == "T") {                                                     
t = GetTarget();                                                          
if (t != None) {                                                          
return t.GetActiveText(aItem.SubItem);                                  
} else {                                                                  
return "?Target?";                                                      
}
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
return Class'StringReferences'.default.QT_UseOnText.Text;                   
}
event RadialMenuCollect(Game_Pawn aPlayerPawn,Object aObject,byte aMainOption,out array<byte> aSubOptions) {
if (aObject != None && aObject == Target) {                                 
aSubOptions[aSubOptions.Length] = Option;                                 
}
}
*/
