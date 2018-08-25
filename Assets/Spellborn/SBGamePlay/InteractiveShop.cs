using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class InteractiveShop : InteractiveLevelElement
    {
        [FoldoutGroup("InteractiveShop")]
        public Shop_Base Shop;

        [FoldoutGroup("InteractiveShop")]
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