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
    
    
    public class InteractiveDoor : InteractiveLevelElement
    {
        
        [FieldCategory(Category="InteractiveDoor")]
        public int DestinationWorld;
        
        [FieldCategory(Category="InteractiveDoor")]
        public string Parameter = string.Empty;
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public string spawnPointTag = string.Empty;
        
        [FieldCategory(Category="InteractiveDoor")]
        public LocalizedString DoorSign;
        
        [FieldCategory(Category="InteractiveDoor")]
        public bool IsInstance;
        
        public InteractiveDoor()
        {
        }
    }
}
/*
event string cl_GetToolTip() {
return DoorSign.Text;                                                       
}
*/
