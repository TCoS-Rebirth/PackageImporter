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
    
    
    public class LevelSummary : UObject
    {
        
        [FieldCategory(Category="LevelSummary")]
        public string Title = string.Empty;
        
        [FieldCategory(Category="LevelSummary")]
        public string Description = string.Empty;
        
        [FieldCategory(Category="LevelSummary")]
        public string LevelEnterText = string.Empty;
        
        [FieldCategory(Category="LevelSummary")]
        public string Author = string.Empty;
        
        [FieldCategory(Category="LevelSummary")]
        public string DecoTextName = string.Empty;
        
        [FieldCategory(Category="LevelSummary")]
        public int IdealPlayerCountMin;
        
        [FieldCategory(Category="LevelSummary")]
        public int IdealPlayerCountMax;
        
        [FieldCategory(Category="LevelSummary")]
        public bool HideFromMenus;
        
        [FieldCategory(Category="SinglePlayer")]
        public int SinglePlayerTeamSize;
        
        [FieldCategory(Category="LevelSummary")]
        [IgnoreFieldExtraction()]
        public Material Screenshot;
        
        [FieldCategory(Category="LevelSummary")]
        public string ExtraInfo = string.Empty;
        
        public LevelSummary()
        {
        }
    }
}
