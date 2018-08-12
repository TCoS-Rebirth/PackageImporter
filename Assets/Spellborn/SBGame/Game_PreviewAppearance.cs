using System;

namespace SBGame
{
    [Serializable] public class Game_PreviewAppearance : Game_EquippedAppearance
    {
        //public delegate<OnCheckPartValidity> @__OnCheckPartValidity__Delegate;

        //public delegate<OnCheckItemTypeValidity> @__OnCheckItemTypeValidity__Delegate;

        public Game_PreviewAppearance()
        {
        }
    }
}
/*
native function RemoveItem(Game_Item aItem);
native function ApplyItem(Game_Item aNewItem);
native function ApplyItems(array<Game_Item> aItems);
native function InitFromPawn(Game_Pawn aPawn);
event bool IsValidItem(byte aTestItemType) {
return OnCheckItemTypeValidity(aTestItemType);                              
}
event bool IsValidPart(export editinline Game_EquippedAppearance aAppearance,byte aPartType,int aPartValue) {
return OnCheckPartValidity(aAppearance,aPartType,aPartValue);               
}
delegate bool OnCheckItemTypeValidity(byte aTestItemType) {
return True;                                                                
}
delegate bool OnCheckPartValidity(export editinline Game_EquippedAppearance aAppearance,byte aPartType,int aPartValue) {
return aAppearance != None;                                                 
}
*/