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
    
    
    public class NE_Standard : NPC_Equipment
    {
        
        [FieldCategory(Category="Equipment")]
        public List<Item_Type> Items = new List<Item_Type>();
        
        [FieldCategory(Category="Equipment")]
        public byte Color1;
        
        [FieldCategory(Category="Equipment")]
        public byte Color2;
        
        public NE_Standard()
        {
        }
    }
}
/*
function Apply(Game_Pawn aPawn) {
local export editinline Game_NPCItemManager itemManager;
itemManager = Game_NPCItemManager(aPawn.itemManager);                       
if (itemManager != None) {                                                  
itemManager.InitializeArray(Items,Color1,Color2,Color1,Color2);           
}
}
*/
