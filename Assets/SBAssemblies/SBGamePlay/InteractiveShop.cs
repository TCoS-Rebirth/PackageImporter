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
    
    
    [System.Serializable] public class InteractiveShop : InteractiveLevelElement
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveShop")]
        public Shop_Base Shop;
        
        [Sirenix.OdinInspector.FoldoutGroup("InteractiveShop")]
        public LocalizedString ShopSign;
        
        public InteractiveShop()
        {
        }
    }
}
/*
event RadialMenuSelect(Pawn aPlayerPawn,byte aMainOption,byte aSubOption) {
if (aPlayerPawn != None && Shop != None
&& Shop.CanEnterShop(Game_PlayerPawn(aPlayerPawn),aSubOption)) {
if (Game_Pawn(aPlayerPawn).Trading != None) {                             
Game_Pawn(aPlayerPawn).Trading.cl_SetShop(Shop,aSubOption);             
}
}
Super.RadialMenuSelect(aPlayerPawn,aMainOption,aSubOption);                 
}
event string cl_GetToolTip() {
return ShopSign.Text;                                                       
}
*/
