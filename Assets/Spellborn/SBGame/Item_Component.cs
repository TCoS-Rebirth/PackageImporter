using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Item_Component : UObject
    {
        public Item_Component()
        {
        }
    }
}
/*
event Item_Component ReplaceComponent() {
return None;                                                                
}
function ToConsole(Console C) {
}
event bool IsNPCItem() {
return False;                                                               
}
event Appearance_Base GetAppearance() {
return None;                                                                
}
event byte GetWeaponType() {
return 0;                                                                   
}
event OnSheathe(Game_Pawn aPawn) {
}
event OnDraw(Game_Pawn aPawn) {
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
}
event OnUse(Game_Pawn aPawn,Game_Item aItem) {
}
event bool CanEquip(Game_Pawn aPawn,Game_Item aItem) {
return True;                                                                
}
event bool CanUse(Game_Pawn aPawn,Game_Item aItem) {
return True;                                                                
}
*/