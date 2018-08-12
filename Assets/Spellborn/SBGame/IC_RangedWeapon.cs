using System;

namespace SBGame
{
    [Serializable] public class IC_RangedWeapon : IC_Appearance
    {
        public IC_RangedWeapon()
        {
        }
    }
}
/*
event byte GetWeaponType() {
return Class'SBAnimationFlags'.5;                                           
}
event OnSheathe(Game_Pawn aPawn) {
local export editinline Game_EquippedAppearance pawnAppearance;
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SneakySetValue(Appearance.Part,0);                         
pawnAppearance.Apply();                                                   
}
}
event OnDraw(Game_Pawn aPawn) {
local export editinline Game_EquippedAppearance pawnAppearance;
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SneakySetValue(Appearance.Part,Appearance._AS_Index);      
pawnAppearance.Apply();                                                   
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
}
*/