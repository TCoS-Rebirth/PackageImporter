﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;
using TCosReborn.Framework.Common;


namespace SBGamePlay
{


    public class InteractiveShop : InteractiveLevelElement
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveShop")]
        public Shop_Base Shop;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="InteractiveShop")]
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
