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

namespace Engine
{
    
    
    [System.Serializable] public class AvoidMarker : Triggers
    {
        
        public byte TeamNum;
        
        public AvoidMarker()
        {
        }
    }
}
/*
function StartleBots() {
local Pawn P;
foreach CollidingActors(Class'Pawn',P,CollisionRadius) {                    
if (RelevantTo(P)) {                                                      
AIController(P.Controller).Startle(self);                               
}
}
}
function bool RelevantTo(Pawn P) {
return AIController(P.Controller) != None;                                  
}
function Touch(Actor Other) {
if (Pawn(Other) != None && RelevantTo(Pawn(Other))) {                       
Pawn(Other).Controller.FearThisSpot(self);                                
}
}
*/
