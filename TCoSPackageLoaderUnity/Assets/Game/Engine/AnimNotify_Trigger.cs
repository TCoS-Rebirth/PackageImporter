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
    
    
    public class AnimNotify_Trigger : AnimNotify_Scripted
    {
        
        [FieldCategory(Category="AnimNotify_Trigger")]
        public NameProperty EventName;
        
        public AnimNotify_Trigger()
        {
        }
    }
}
/*
event Notify(Actor Owner) {
Owner.TriggerEvent(EventName,Owner,Pawn(Owner));                            
}
*/
