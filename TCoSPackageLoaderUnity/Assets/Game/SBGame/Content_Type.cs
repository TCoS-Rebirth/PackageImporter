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

namespace SBGame
{
    
    
    public class Content_Type : Content_API
    {
        
        [IgnoreFieldExtraction()]
        [FieldTransient()]
        public int ExCleanIndex;
        
        //[TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        //[TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        //public int ResourceId;
        
        public Content_Type()
        {
        }
        
        public enum EContentHook
        {
            
            ECH_None ,
            
            ECH_Kill ,
            
            ECH_Defeat ,
            
            ECH_Interact ,
            
            ECH_Converse ,
            
            ECH_Trigger ,
            
            ECH_Eradicate ,
            
            ECH_Loot ,
            
            ECH_Death ,
            
            ECH_Aggro ,
            
            ECH_Timer ,
            
            ECH_Killed ,
            
            ECH_QuestFinished ,
            
            ECH_Script ,
            
            ECH_Spotted ,
            
            ECH_PvPKill ,
            
            ECH_InventoryUpdate,
        }
    }
}
/*
final native function sv_RemoveHooks(Game_Pawn aPawn);
final native function sv_OnHook(Game_PlayerPawn aPlayerPawn,byte aHookType,Object aObjParam,int aNumParam);
final native function sv_Detach(Game_Pawn aPawn);
final native function sv_Attach(Game_Pawn aPawn);
final function int GetResourceId() {
return ResourceId;                                                          
}
*/
