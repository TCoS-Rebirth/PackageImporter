﻿using System;
using Engine;
using SBBase;

namespace SBGame
{
    [Serializable]
    public class Game_CombatState: Base_Component
    {
        [NonSerialized] public ECombatMode mCombatMode;
        [NonSerialized] public int mMainWeapon;
        [NonSerialized] public int mOffhandWeapon;
        [NonSerialized] public bool mDrawing;
        [NonSerialized] public bool mReDraw;
        [NonSerialized] public bool mSheathing;
        [NonSerialized] public bool mReSheathe;
        [NonSerialized] public byte mReDrawMode;
        [NonSerialized] public int mReDrawNewMainWeapon;
        [NonSerialized] public int mReDrawNewOffhandWeapon;
        [NonSerialized] public float mDrawSheatheTimer;
        [NonSerialized] public float cDrawSheatheTime;
        [NonSerialized] public byte mWeaponFlag;
        private bool mExecutingBodySlotSkill;
        private bool mPreparedBonusGiven;
        [NonSerialized] public bool CombatCollision;

        public enum ECombatMode
        {
            CBM_Idle,
            CBM_Melee,
            CBM_Ranged,
            CBM_Cast,
        }

        public void RemovePreparedBonusConditional()
        {
            if (mPreparedBonusGiven)
            {
                mPreparedBonusGiven = false;
                var outer = Outer as Game_Pawn;
                outer.CharacterStats.IncreaseMeleeResistanceDelta(-0.05f);
                outer.CharacterStats.IncreaseRangedResistanceDelta(-0.05f);
                outer.CharacterStats.IncreaseMagicResistanceDelta(-0.05f);
            }
        }
    }
}
/*
function GivePreparedBonusConditional() {
if (!mPreparedBonusGiven) {                                                 
mPreparedBonusGiven = True;                                               
Outer.CharacterStats.IncreaseMeleeResistanceDelta(0.05000000);            
Outer.CharacterStats.IncreaseRangedResistanceDelta(0.05000000);           
Outer.CharacterStats.IncreaseMagicResistanceDelta(0.05000000);            
}
}
function bool IsExecutingBodySlotSkill() {
return mExecutingBodySlotSkill;                                             
}
protected native function sv2cl_SetExecutingBodySlotSkill_CallStub();
event sv2cl_SetExecutingBodySlotSkill(bool aExecutingBodySlotSkill) {
mExecutingBodySlotSkill = aExecutingBodySlotSkill;                          
}
event sv_SetExecutingBodySlotSkill(bool aExecutingBodySlotSkill) {
mExecutingBodySlotSkill = aExecutingBodySlotSkill;                          
sv2cl_SetExecutingBodySlotSkill_CallStub(mExecutingBodySlotSkill);          
}
protected final event byte ResolveWeaponFlag(byte aMode,export editinline Item_Type aMainWeapon,export editinline Item_Type aOffhandWeapon) {
if (aMode == 0) {                                                           
return Class'SBAnimationFlags'.0;                                         
} else {                                                                    
if (aMode == 1) {                                                         
if (aOffhandWeapon != None) {                                           
return aOffhandWeapon.GetWeaponType();                                
} else {                                                                
if (aMainWeapon != None) {                                            
return aMainWeapon.GetWeaponType();                                 
} else {                                                              
return 1;                                                           
}
}
} else {                                                                  
if (aMode == 2) {                                                       
return aMainWeapon.GetWeaponType();                                   
} else {                                                                
if (aMode == 3) {                                                     
return 1;                                                           
} else {                                                              
if (aMainWeapon != None) {                                          
return aMainWeapon.GetWeaponType();                               
} else {                                                            
return 1;                                                         
}
}
}
}
}
}
protected native function ResolveWeapons(byte aMode,export out editinline Item_Type oMainWeapon,export out editinline Item_Type oOffhandWeapon);
protected event Item_Type GetOffhandWeapon() {
local export editinline Item_Type ret;
if (mOffhandWeapon != 0) {                                                  
ret = Item_Type(Class'SBDBSync'.GetResourceObject(mOffhandWeapon));       
return ret;                                                               
} else {                                                                    
return None;                                                              
}
}
protected event Item_Type GetMainWeapon() {
local export editinline Item_Type ret;
if (mMainWeapon != 0) {                                                     
ret = Item_Type(Class'SBDBSync'.GetResourceObject(mMainWeapon));          
return ret;                                                               
} else {                                                                    
return None;                                                              
}
}
protected function cl_SheatheWeapon() {
Outer.PlaySheatheWeaponAnim(mWeaponFlag,False);                             
mCombatMode = 0;                                                            
mWeaponFlag = ResolveWeaponFlag(mCombatMode,None,None);                     
if (CombatCollision) {                                                      
Outer.SetCollision(True,False);                                           
}
}
protected native function sv2rel_SheatheWeapon_CallStub();
protected event sv2rel_SheatheWeapon() {
if (mDrawing) {                                                             
mReSheathe = True;                                                        
} else {                                                                    
cl_SheatheWeapon();                                                       
}
}
protected function cl_DrawWeapon(byte aMode,int aNewMainWeapon,int aNewOffhandWeapon) {
local export editinline Item_Type newMainWeapon;
local export editinline Item_Type newOffhandWeapon;
local export editinline Item_Type sheathWeapon;
if (aNewMainWeapon != 0) {                                                  
newMainWeapon = Item_Type(Class'SBDBSync'.GetResourceObject(aNewMainWeapon));
} else {                                                                    
newMainWeapon = None;                                                     
}
if (aNewOffhandWeapon != 0) {                                               
newOffhandWeapon = Item_Type(Class'SBDBSync'.GetResourceObject(aNewOffhandWeapon));
}
sheathWeapon = GetMainWeapon();                                             
if (sheathWeapon != None) {                                                 
sheathWeapon.OnSheathe(Outer);                                            
}
sheathWeapon = GetOffhandWeapon();                                          
if (sheathWeapon != None) {                                                 
sheathWeapon.OnSheathe(Outer);                                            
}
mWeaponFlag = ResolveWeaponFlag(aMode,newMainWeapon,newOffhandWeapon);      
if (aMode != 3 && mCombatMode == 0) {                                       
Outer.ClearPawnAnims();                                                   
Outer.PlayDrawWeaponAnim(mWeaponFlag,True);                               
} else {                                                                    
Outer.ClearPawnAnims();                                                   
if (newMainWeapon != None) {                                              
newMainWeapon.OnDraw(Outer);                                            
}
if (newOffhandWeapon != None) {                                           
newOffhandWeapon.OnDraw(Outer);                                         
}
}
mCombatMode = aMode;                                                        
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
Outer.ClearAnimsByType(1,0.30000001);                                       
Outer.SetCollision(True,CombatCollision);                                   
}
protected native function sv2rel_DrawWeapon_CallStub();
protected event sv2rel_DrawWeapon(byte aMode,int aNewMainWeapon,int aNewOffhandWeapon) {
if (mSheathing) {                                                           
mReDrawMode = aMode;                                                      
mReDrawNewMainWeapon = aNewMainWeapon;                                    
mReDrawNewOffhandWeapon = aNewOffhandWeapon;                              
mReDraw = True;                                                           
} else {                                                                    
if (mDrawing && mReSheathe) {                                             
mReSheathe = False;                                                     
} else {                                                                  
cl_DrawWeapon(aMode,aNewMainWeapon,aNewOffhandWeapon);                  
}
}
}
function bool IsDrawing() {
return mDrawing;                                                            
}
function bool IsSheathing() {
return mSheathing;                                                          
}
function bool CheckWeaponType(byte aWeaponType) {
switch (aWeaponType) {                                                      
case 0 :                                                                  
return True;                                                            
case 1 :                                                                  
return mCombatMode == 1;                                                
case 2 :                                                                  
return mCombatMode == 2;                                                
case 3 :                                                                  
return mCombatMode == 3;                                                
case 4 :                                                                  
return mCombatMode == 1 || mCombatMode == 3;                            
default:                                                                  
return False;                                                           
}
}
}
function byte GetWeaponFlag() {
if (mExecutingBodySlotSkill) {                                              
return 1;                                                                 
} else {                                                                    
return mWeaponFlag;                                                       
}
}
function OnDoneSheathing(bool aMainHand) {
local export editinline Item_Type WeaponType;
if (aMainHand) {                                                            
WeaponType = GetMainWeapon();                                             
WeaponType.OnSheathe(Outer);                                              
mMainWeapon = 0;                                                          
mSheathing = False;                                                       
} else {                                                                    
WeaponType = GetOffhandWeapon();                                          
WeaponType.OnSheathe(Outer);                                              
mOffhandWeapon = 0;                                                       
}
Outer.ClearAnimsByType(1,0.00000000);                                       
if (mReDraw) {                                                              
mReDraw = False;                                                          
cl_DrawWeapon(mReDrawMode,mReDrawNewMainWeapon,mReDrawNewOffhandWeapon);  
}
}
function OnDoneDrawing(bool aMainHand) {
local export editinline Item_Type WeaponType;
if (aMainHand) {                                                            
WeaponType = GetMainWeapon();                                             
if (WeaponType != None) {                                                 
WeaponType.OnDraw(Outer);                                               
}
mDrawing = False;                                                         
} else {                                                                    
WeaponType = GetOffhandWeapon();                                          
if (WeaponType != None) {                                                 
WeaponType.OnDraw(Outer);                                               
}
}
Outer.ClearAnimsByType(1,0.00000000);                                       
if (mReSheathe) {                                                           
mReSheathe = False;                                                       
cl_SheatheWeapon();                                                       
}
}
native function bool sv_CanSwitchToWeapon(byte aWeaponType);
event bool sv_SwitchToWeaponType(byte aWeaponType) {
switch (aWeaponType) {                                                      
case 0 :                                                                  
return True;                                                            
case 1 :                                                                  
return sv_SwitchToMode(1);                                              
case 2 :                                                                  
return sv_SwitchToMode(2);                                              
case 3 :                                                                  
return sv_SwitchToMode(3);                                              
case 4 :                                                                  
if (mCombatMode != 1 && mCombatMode != 3) {                             
return sv_SwitchToMode(3);                                            
} else {                                                                
return True;                                                          
}
default:                                                                  
}
}
}
function bool sv_SwitchToMode(byte aMode) {
local export editinline Item_Type newMainWeapon;
local export editinline Item_Type newOffhandWeapon;
local export editinline Item_Type WeaponType;
ResolveWeapons(aMode,newMainWeapon,newOffhandWeapon);                       
if (mCombatMode != aMode) {                                                 
if (mCombatMode != 0) {                                                   
if (aMode != 0) {                                                       
if (aMode == 3 || newMainWeapon != None) {                            
WeaponType = GetMainWeapon();                                       
if (WeaponType != None) {                                           
WeaponType.OnSheathe(Outer);                                      
}
WeaponType = GetOffhandWeapon();                                    
if (WeaponType != None) {                                           
WeaponType.OnSheathe(Outer);                                      
}
mCombatMode = aMode;                                                
mWeaponFlag = ResolveWeaponFlag(mCombatMode,newMainWeapon,newOffhandWeapon);
if (newMainWeapon != None) {                                        
newMainWeapon.OnDraw(Outer);                                      
mMainWeapon = newMainWeapon.GetResourceId();                      
} else {                                                            
mMainWeapon = 0;                                                  
}
if (newOffhandWeapon != None) {                                     
newOffhandWeapon.OnDraw(Outer);                                   
mOffhandWeapon = newOffhandWeapon.GetResourceId();                
} else {                                                            
mOffhandWeapon = 0;                                               
}
sv2rel_DrawWeapon_CallStub(mCombatMode,mMainWeapon,mOffhandWeapon); 
return True;                                                        
} else {                                                              
return False;                                                       
}
} else {                                                                
return sv_SheatheWeapon();                                            
}
} else {                                                                  
return sv_DrawWeapon(aMode);                                            
}
} else {                                                                    
return True;                                                              
}
}
event bool sv_SheatheWeapon() {
local export editinline Item_Type oldMainWeapon;
local export editinline Item_Type oldOffhandWeapon;
if (Outer.CharacterStats.IsMovementFrozen()
|| mCombatMode == 0
|| mSheathing) {
return False;                                                             
}
if (mDrawing) {                                                             
mReSheathe = !mReSheathe;                                                 
return False;                                                             
}
mCombatMode = 0;                                                            
mSheathing = True;                                                          
mDrawSheatheTimer = cDrawSheatheTime;                                       
oldMainWeapon = GetMainWeapon();                                            
if (oldMainWeapon != None) {                                                
oldMainWeapon.OnSheathe(Outer);                                           
}
oldOffhandWeapon = GetOffhandWeapon();                                      
if (oldOffhandWeapon != None) {                                             
oldOffhandWeapon.OnSheathe(Outer);                                        
}
mMainWeapon = 0;                                                            
mOffhandWeapon = 0;                                                         
mWeaponFlag = ResolveWeaponFlag(mCombatMode,None,None);                     
sv2rel_SheatheWeapon_CallStub();                                            
if (CombatCollision) {                                                      
Outer.SetCollision(True,False);                                           
}
Outer.Skills.sv_FireCondition(None,3);                                      
RemovePreparedBonusConditional();                                           
Outer.CharacterStats.UnsetStatsState(1);                                    
return True;                                                                
}
event bool sv_DrawWeapon(byte aInitialMode) {
local export editinline Item_Type newMainWeapon;
local export editinline Item_Type newOffhandWeapon;
local export editinline Item_Type oldMainWeapon;
local export editinline Item_Type oldOffhandWeapon;
if (Outer.CharacterStats.IsMovementFrozen()) {                              
return False;                                                             
}
if (mCombatMode != 0 || mDrawing) {                                         
return False;                                                             
}
if (mSheathing) {                                                           
return False;                                                             
}
if (Outer.sv_IsResting()) {                                                 
Outer.sv_Sit(False);                                                      
}
ResolveWeapons(aInitialMode,newMainWeapon,newOffhandWeapon);                
if (newMainWeapon == None && aInitialMode != 3) {                           
return False;                                                             
}
mCombatMode = aInitialMode;                                                 
oldMainWeapon = GetMainWeapon();                                            
if (oldMainWeapon != None) {                                                
oldMainWeapon.OnSheathe(Outer);                                           
}
oldOffhandWeapon = GetOffhandWeapon();                                      
if (oldOffhandWeapon != None) {                                             
oldOffhandWeapon.OnSheathe(Outer);                                        
}
mDrawing = True;                                                            
mDrawSheatheTimer = cDrawSheatheTime;                                       
mWeaponFlag = ResolveWeaponFlag(mCombatMode,newMainWeapon,newOffhandWeapon);
if (newMainWeapon != None) {                                                
newMainWeapon.OnDraw(Outer);                                              
mMainWeapon = newMainWeapon.GetResourceId();                              
} else {                                                                    
mMainWeapon = 0;                                                          
}
if (newOffhandWeapon != None) {                                             
newOffhandWeapon.OnDraw(Outer);                                           
mOffhandWeapon = newOffhandWeapon.GetResourceId();                        
} else {                                                                    
mOffhandWeapon = 0;                                                       
}
sv2rel_DrawWeapon_CallStub(aInitialMode,mMainWeapon,mOffhandWeapon);        
Outer.SetCollision(True,CombatCollision);                                   
Outer.Skills.sv_FireCondition(None,4);                                      
GivePreparedBonusConditional();                                             
Outer.CharacterStats.SetStatsState(1);                                      
if (Outer.IsShifted()) {                                                    
Outer.Unshift();                                                          
}
return True;                                                                
}
native function bool CombatReady();
event cl_OnFrame(float DeltaTime) {
if (mDrawSheatheTimer > 0.00000000) {                                       
mDrawSheatheTimer -= DeltaTime;                                           
if (mDrawSheatheTimer <= 0.00000000) {                                    
if (mDrawing) {                                                         
mDrawing = False;                                                     
}
if (mSheathing) {                                                       
mSheathing = False;                                                   
}
}
}
}
private final native function Init();
*/
