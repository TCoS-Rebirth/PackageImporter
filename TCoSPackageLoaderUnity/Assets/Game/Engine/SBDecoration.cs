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
    
    
    public class SBDecoration : Actor
    {
        
        [FieldCategory(Category="SBDecoration")]
        public NameProperty Animation;
        
        [FieldCategory(Category="SBDecoration")]
        public float speed;
        
        public SBDecoration()
        {
        }
    }
}
/*
function PostBeginPlay() {
if (IsClient()) {                                                           
if (Animation != 'None') {                                                
LoopAnim(Animation,speed);                                              
}
}
Super.PostBeginPlay();                                                      
}
*/
