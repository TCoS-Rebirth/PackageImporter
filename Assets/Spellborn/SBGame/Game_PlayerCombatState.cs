﻿using System;

namespace SBGame
{
    [Serializable] public class Game_PlayerCombatState : Game_CombatState
    {
        public Game_PlayerCombatState()
        {
        }
    }
}
/*
protected native function sv2cl_SheatheWeapon_CallStub();
private event sv2cl_SheatheWeapon() {
local Game_PlayerController GPC;
if (mDrawing) {                                                             
mReSheathe = True;                                                        
} else {                                                                    
GPC = Game_PlayerController(Outer.Controller);                            
if (GPC != None) {                                                        
if (GPC.GUI != None) {                                                  
GPC.GUI.HideCombatBar();                                              
}
if (GPC.Input != None) {                                                
GPC.Input.EnableSkills(False);                                        
}
}
if (mCombatMode != 3 && mCombatMode != 0) {                               
Outer.PlaySheatheWeaponAnim(mWeaponFlag,False);                         
mWeaponFlag = ResolveWeaponFlag(0,None,None);                           
}
mSheathing = True;                                                        
mDrawSheatheTimer = cDrawSheatheTime;                                     
mCombatMode = 0;                                                          
Outer.SendDesktopMessage("",Class'StringReferences'.default.You_sheathe_your_weapon.Text,Class'Game_Desktop'.6);
if (CombatCollision) {                                                    
Outer.SetCollision(True,False);                                         
}
}
}
protected function cl_DrawPlayerWeapon(byte aMode) {
local export editinline Item_Type newMainWeapon;
local export editinline Item_Type newOffhandWeapon;
local Game_PlayerController GPC;
GPC = Game_PlayerController(Outer.Controller);                              
if (GPC != None) {                                                          
GPC.GUI.ShowCombatBar();                                                  
GPC.Input.EnableSkills(True);                                             
}
if (GetMainWeapon() == None) {                                              
Outer.SendDesktopMessage("",Class'StringReferences'.default.You_draw_your_weapon.Text,Class'Game_Desktop'.6);
} else {                                                                    
GetMainWeapon().OnSheathe(Outer);                                         
}
if (GetOffhandWeapon() != None) {                                           
GetOffhandWeapon().OnSheathe(Outer);                                      
}
ResolveWeapons(aMode,newMainWeapon,newOffhandWeapon);                       
if (newMainWeapon != None) {                                                
mMainWeapon = newMainWeapon.GetResourceId();                              
} else {                                                                    
mMainWeapon = 0;                                                          
}
if (newOffhandWeapon != None) {                                             
mOffhandWeapon = newOffhandWeapon.GetResourceId();                        
} else {                                                                    
mOffhandWeapon = 0;                                                       
}
mWeaponFlag = ResolveWeaponFlag(aMode,newMainWeapon,newOffhandWeapon);      
if (aMode != 3) {                                                           
Outer.PlayDrawWeaponAnim(mWeaponFlag,mCombatMode != 0);                   
mDrawing = True;                                                          
mDrawSheatheTimer = cDrawSheatheTime;                                     
} else {                                                                    
GetMainWeapon().OnSheathe(Outer);                                         
GetOffhandWeapon().OnSheathe(Outer);                                      
mMainWeapon = 0;                                                          
mOffhandWeapon = 0;                                                       
}
mCombatMode = aMode;                                                        
Outer.SetCollision(True,CombatCollision);                                   
}
protected native function sv2cl_DrawWeapon_CallStub();
private event sv2cl_DrawWeapon(byte aMode) {
if (mSheathing) {                                                           
mReDrawMode = aMode;                                                      
mReDraw = True;                                                           
} else {                                                                    
if (mDrawing && mReSheathe) {                                             
mReSheathe = False;                                                     
} else {                                                                  
cl_DrawPlayerWeapon(aMode);                                             
}
}
}
protected native function sv2cl_SetWeapon_CallStub();
private event sv2cl_SetWeapon(byte aMode) {
local export editinline Item_Type newMainWeapon;
local export editinline Item_Type newOffhandWeapon;
GetMainWeapon().OnSheathe(Outer);                                           
GetOffhandWeapon().OnSheathe(Outer);                                        
ResolveWeapons(aMode,newMainWeapon,newOffhandWeapon);                       
if (newMainWeapon != None) {                                                
mMainWeapon = newMainWeapon.GetResourceId();                              
} else {                                                                    
mMainWeapon = 0;                                                          
}
if (newOffhandWeapon != None) {                                             
mOffhandWeapon = newOffhandWeapon.GetResourceId();                        
} else {                                                                    
mOffhandWeapon = 0;                                                       
}
mWeaponFlag = ResolveWeaponFlag(aMode,newMainWeapon,newOffhandWeapon);      
if (aMode != 3) {                                                           
if (newMainWeapon != None) {                                              
newMainWeapon.OnDraw(Outer);                                            
}
if (newOffhandWeapon != None) {                                           
newOffhandWeapon.OnDraw(Outer);                                         
}
} else {                                                                    
GetMainWeapon().OnSheathe(Outer);                                         
GetOffhandWeapon().OnSheathe(Outer);                                      
mMainWeapon = 0;                                                          
mOffhandWeapon = 0;                                                       
}
Outer.ClearAnimsByType(1,0.30000001);                                       
mCombatMode = aMode;                                                        
}
protected native function cl2sv_SwitchWeaponType_CallStub();
event cl2sv_SwitchWeaponType(byte aWeaponType) {
sv_SwitchToWeaponType(aWeaponType);                                         
}
protected native function sv2cl_DrawSheatheFailed_CallStub();
event sv2cl_DrawSheatheFailed(byte aMode) {
Outer.SendDesktopMessage("",Class'StringReferences'.default.Unable_to_draw_weapon.Text,Class'Game_Desktop'.6);
}
protected native function cl2sv_DrawSheatheWeapon_CallStub();
event cl2sv_DrawSheatheWeapon(byte aMode) {
if (Outer.mPvPSettings != None
&& !Outer.mPvPSettings.AllowDrawWeapon) {
sv_SheatheWeapon();                                                       
}
if (mCombatMode == 0) {                                                     
if (sv_DrawWeapon(aMode)) {                                               
return;                                                                 
} else {                                                                  
if (aMode != 1 && sv_DrawWeapon(1)) {                                   
return;                                                               
} else {                                                                
if (aMode != 2 && sv_DrawWeapon(2)) {                                 
return;                                                             
} else {                                                              
if (aMode != 3 && sv_DrawWeapon(3)) {                               
return;                                                           
} else {                                                            
sv2cl_DrawSheatheFailed_CallStub(aMode);                          
}
}
}
}
} else {                                                                    
if (!sv_SheatheWeapon()) {                                                
}
}
}
function bool sv_SwitchToMode(byte aMode) {
if (aMode != mCombatMode) {                                                 
if (Super.sv_SwitchToMode(aMode)) {                                       
sv2cl_SetWeapon_CallStub(aMode);                                        
return True;                                                            
} else {                                                                  
return False;                                                           
}
} else {                                                                    
return True;                                                              
}
}
function bool sv_SheatheWeapon() {
if (Super.sv_SheatheWeapon()) {                                             
sv2cl_SheatheWeapon_CallStub();                                           
Game_PlayerController(Outer.Controller).Input.EnableSkills(False);        
return True;                                                              
} else {                                                                    
return False;                                                             
}
}
function bool sv_DrawWeapon(byte aMode) {
if (Super.sv_DrawWeapon(aMode)) {                                           
sv2cl_DrawWeapon_CallStub(aMode);                                         
Game_PlayerController(Outer.Controller).Input.EnableSkills(True);         
return True;                                                              
} else {                                                                    
return False;                                                             
}
}
*/