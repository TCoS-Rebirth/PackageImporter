﻿using System;

namespace SBGame
{
    [Serializable] public class IC_Equipment : IC_Appearance
    {
        public IC_Equipment()
        {
        }
    }
}
/*
function ToConsole(Console C) {
C.Message("        Appearance = " $ string(Appearance)
@ string(Appearance.Part)
@ string(Appearance._AS_Index)
@ string(Appearance._AS_Set),0.00000000);
}
event UpdateColours(Game_Pawn aPawn,Game_Item aItem) {
local export editinline Game_EquippedAppearance pawnAppearance;
if (Appearance == None) {                                                   
return;                                                                   
}
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SetColorValue(Appearance.Part,aItem.Color1,0);             
pawnAppearance.SetColorValue(Appearance.Part,aItem.Color2,1);             
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
local export editinline Game_EquippedAppearance pawnAppearance;
if (Appearance == None) {                                                   
return;                                                                   
}
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SetValue(Appearance.Part,0);                               
pawnAppearance.SetColorValue(Appearance.Part,0,0);                        
pawnAppearance.SetColorValue(Appearance.Part,0,1);                        
}
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
local export editinline Game_EquippedAppearance pawnAppearance;
if (Appearance == None) {                                                   
return;                                                                   
}
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SetValue(Appearance.Part,Appearance._AS_Index);            
pawnAppearance.SetColorValue(Appearance.Part,aItem.Color1,0);             
pawnAppearance.SetColorValue(Appearance.Part,aItem.Color2,1);             
}
}
*/