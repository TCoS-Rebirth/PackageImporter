﻿using System;

namespace SBGame
{
    [Serializable] public class IC_Shield : IC_Appearance
    {
        public IC_Shield()
        {
        }
    }
}
/*
event OnSheathe(Game_Pawn aPawn) {
local export editinline Game_EquippedAppearance pawnAppearance;
local byte Part;
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
Part = GetSheathPart();                                                   
pawnAppearance.SneakySetValue(Part,Appearance._AS_Index);                 
pawnAppearance.SneakySetValue(Appearance.Part,0);                         
pawnAppearance.Apply();                                                   
}
}
event OnDraw(Game_Pawn aPawn) {
local export editinline Game_EquippedAppearance pawnAppearance;
local byte Part;
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
pawnAppearance.SneakySetValue(Appearance.Part,Appearance._AS_Index);      
Part = GetSheathPart();                                                   
pawnAppearance.SneakySetValue(Part,0);                                    
pawnAppearance.Apply();                                                   
}
}
event OnUnequip(Game_Pawn aPawn,Game_Item aItem) {
local export editinline Game_EquippedAppearance pawnAppearance;
local byte Part;
if (Appearance == None) {                                                   
return;                                                                   
}
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
Part = GetAppearancePart(aPawn);                                          
pawnAppearance.SetValue(Part,0);                                          
pawnAppearance.SetColorValue(Part,0,0);                                   
pawnAppearance.SetColorValue(Part,0,1);                                   
}
}
event OnEquip(Game_Pawn aPawn,Game_Item aItem) {
local export editinline Game_EquippedAppearance pawnAppearance;
local byte Part;
if (Appearance == None) {                                                   
return;                                                                   
}
pawnAppearance = Game_EquippedAppearance(aPawn.Appearance.GetBase());       
if (pawnAppearance != None) {                                               
Part = GetAppearancePart(aPawn);                                          
pawnAppearance.SetValue(Part,Appearance._AS_Index);                       
pawnAppearance.SetColorValue(Part,aItem.Color1,0);                        
pawnAppearance.SetColorValue(Part,aItem.Color2,1);                        
}
}
protected function byte GetAppearancePart(Game_Pawn aPawn) {
if (aPawn.combatState != None
&& aPawn.combatState.CombatReady()) {   
return Appearance.Part;                                                   
} else {                                                                    
return GetSheathPart();                                                   
}
}
protected function byte GetSheathPart() {
return 20;                                                                  
}
*/