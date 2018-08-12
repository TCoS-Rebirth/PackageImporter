using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Shop : Interaction_Component
    {
        [FoldoutGroup("Interaction_Shop")]
        public Shop_Base Shop;

        [FoldoutGroup("Interaction_Shop")]
        public byte ShopOption;

        public Interaction_Shop()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse && Shop != None) {                                            
Shop.sv_EnterShop(Game_PlayerPawn(aInstigator),ShopOption);               
}
}
*/