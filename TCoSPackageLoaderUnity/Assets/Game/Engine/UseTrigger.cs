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

namespace Engine
{
    
    
    public class UseTrigger : Triggers
    {
        
        [FieldCategory(Category="UseTrigger")]
        public string Message = string.Empty;
        
        public UseTrigger()
        {
        }
    }
}
/*
function Touch(Actor Other) {
if (Pawn(Other) != None) {                                                  
if (AIController(Pawn(Other).Controller) != None) {                       
UsedBy(Pawn(Other));                                                    
}
}
}
function UsedBy(Pawn User) {
TriggerEvent(Event,self,User);                                              
}
function bool SelfTriggered() {
return True;                                                                
}
*/
