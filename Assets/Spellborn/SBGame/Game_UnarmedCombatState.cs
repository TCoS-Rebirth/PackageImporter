using System;

namespace SBGame
{
    [Serializable] public class Game_UnarmedCombatState : Game_NPCCombatState
    {
        public Game_UnarmedCombatState()
        {
        }
    }
}
/*
protected native function sv2rel_SetMonsterMode_CallStub();
protected event sv2rel_SetMonsterMode(byte aMode) {
mCombatMode = aMode;                                                        
if (mCombatMode != 0) {                                                     
Outer.SetCollision(True,CombatCollision);                                 
} else {                                                                    
if (CombatCollision) {                                                    
Outer.SetCollision(True,False);                                         
}
}
mSheathing = False;                                                         
mDrawing = False;                                                           
mMainWeapon = 0;                                                            
mOffhandWeapon = 0;                                                         
mWeaponFlag = ResolveWeaponFlag(mCombatMode,None,None);                     
}
function bool sv_SwitchToMode(byte aMode) {
if (mCombatMode != aMode) {                                                 
if (mCombatMode != 0) {                                                   
if (aMode != 0) {                                                       
mCombatMode = aMode;                                                  
mWeaponFlag = ResolveWeaponFlag(mCombatMode,None,None);               
mMainWeapon = 0;                                                      
mOffhandWeapon = 0;                                                   
sv2rel_SetMonsterMode_CallStub(mCombatMode);                          
return True;                                                          
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
if (Outer.CharacterStats.IsMovementFrozen()) {                              
return False;                                                             
}
if (mCombatMode == 0 || mSheathing || mDrawing) {                           
return False;                                                             
}
mCombatMode = 0;                                                            
mSheathing = False;                                                         
mMainWeapon = 0;                                                            
mOffhandWeapon = 0;                                                         
mWeaponFlag = ResolveWeaponFlag(mCombatMode,None,None);                     
sv2rel_SetMonsterMode_CallStub(mCombatMode);                                
if (CombatCollision) {                                                      
Outer.SetCollision(True,False);                                           
}
Outer.Skills.sv_FireCondition(None,3);                                      
return True;                                                                
}
event bool sv_DrawWeapon(byte aInitialMode) {
mCombatMode = aInitialMode;                                                 
mDrawing = False;                                                           
mWeaponFlag = 0;                                                            
mMainWeapon = 0;                                                            
mOffhandWeapon = 0;                                                         
sv2rel_SetMonsterMode_CallStub(aInitialMode);                               
Outer.SetCollision(True,CombatCollision);                                   
Outer.Skills.sv_FireCondition(None,4);                                      
mWeaponFlag = 1;                                                            
return True;                                                                
}
*/