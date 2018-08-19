using System;

namespace SBGame
{
    [Serializable] public class Game_PlayerSkills : Game_Skills
    {
        
    }
}
/*
final function cl_SaveSkilldeckSkills(array<int> aNewSkilldeckSkills) {
local int i;
local bool skilldeckChanged;
local int oldResourceId;
if (aNewSkilldeckSkills.Length != SkilldeckSkills.Length) {                 
skilldeckChanged = True;                                                  
} else {                                                                    
i = 0;                                                                    
while (i < aNewSkilldeckSkills.Length) {                                  
if (SkilldeckSkills[i] != None) {                                       
oldResourceId = SkilldeckSkills[i].GetResourceId();                   
}
if (aNewSkilldeckSkills[i] != oldResourceId) {                          
skilldeckChanged = True;                                              
goto jl0089;                                                          
}
++i;                                                                    
}
}
if (skilldeckChanged) {                                                     
cl2sv_SaveSkilldeckSkills_CallStub(aNewSkilldeckSkills);                  
cl_UpdateSkilldeckSkills(aNewSkilldeckSkills);                            
}
}
protected native function cl2sv_SaveSkilldeckSkills_CallStub();
protected event cl2sv_SaveSkilldeckSkills(array<int> aNewSkilldeckSkills) {
local int i;
local int j;
local bool skillValid;
local Game_Controller gc;
gc = Game_Controller(Outer.Controller);                                     
i = 0;                                                                      
while (i < aNewSkilldeckSkills.Length) {                                    
skillValid = False;                                                       
j = 0;                                                                    
while (j < gc.DBCharacterSkills.Length) {                                 
if (aNewSkilldeckSkills[i] == gc.DBCharacterSkills[j]) {                
skillValid = True;                                                    
goto jl0091;                                                          
}
++j;                                                                    
}
if (!skillValid) {                                                        
aNewSkilldeckSkills[i] = 0;                                             
}
++i;                                                                      
}
i = GetSkilldeckIndex(gc.DBCharacterSheet.SelectedSkilldeckID);             
Class'SBDBAsync'.SetCharacterSkilldeckSkills(Outer,gc.DBCharacter.Id,gc.DBCharacterSheet.SelectedSkilldeckID,aNewSkilldeckSkills);
gc.DBSkilldecks[i].mSkills = aNewSkilldeckSkills;                           
sv_UpdateSkilldeckSkills();                                                 
}
protected function cl_UpdateSkilldeckSkills(array<int> aSkilldeckSkills) {
local int i;
SkilldeckSkills.Length = mTiers * mTierSlots;                               
i = 0;                                                                      
while (i < aSkilldeckSkills.Length) {                                       
if (i < aSkilldeckSkills.Length && aSkilldeckSkills[i] != 0) {            
SkilldeckSkills[i] = FSkill_Type(Class'SBDBSync'.GetResourceObject(aSkilldeckSkills[i]));
} else {                                                                  
SkilldeckSkills[i] = None;                                              
}
++i;                                                                      
}
OnSkilldeckChanged();                                                       
}
protected native event sv_UpdateSkilldeckSkills();
protected function cl_AddActiveSkill(int aSkillID,float aStartTime,float aDuration,float aSkillSpeed,bool aFreezeMovement,bool aFreezeRotation,int aTokenItemID,int AnimVarNr,Vector aLocation,Rotator aRotation) {
Super.cl_AddActiveSkill(aSkillID,aStartTime,aDuration,aSkillSpeed,aFreezeMovement,aFreezeRotation,aTokenItemID,AnimVarNr,aLocation,aRotation);
StartSkillAnimation(LastSkill.Skill,AnimVarNr,LastSkill.SkillSpeed);        
if (LastSkill.LockedMovement) {                                             
Outer.CharacterStats.FreezeMovement(True);                                
}
if (LastSkill.LockedRotation) {                                             
Outer.CharacterStats.FreezeRotation(True);                                
}
cl_StartSkillTracers(LastSkill.Skill,Item_Type(Class'SBDBSync'.GetResourceObject(aTokenItemID)),AnimVarNr);
}
final native function LoadTokens();
final function cl_SetSkills(array<int> aCharacterSkills,array<int> aSkilldeckSkills) {
local Object skillResource;
local int i;
CharacterSkills.Length = aCharacterSkills.Length;                           
i = 0;                                                                      
while (i < aCharacterSkills.Length) {                                       
skillResource = Class'SBDBSync'.GetResourceObject(aCharacterSkills[i]);   
CharacterSkills[i] = FSkill_Type(skillResource);                          
++i;                                                                      
}
cl_UpdateSkilldeckSkills(aSkilldeckSkills);                                 
OnCharacterSkillsChanged();                                                 
}
protected native function sv2cl_SetSkills_CallStub();
final event sv2cl_SetSkills(array<int> aCharacterSkills,array<int> aSkilldeckSkills) {
cl_SetSkills(aCharacterSkills,aSkilldeckSkills);                            
}
function cl_OnInit() {
local Game_PlayerController Controller;
local int Index;
Super.cl_OnInit();                                                          
if (Outer.IsLocalPlayer()) {                                                
LoadTokens();                                                             
Controller = Game_PlayerController(Outer.Controller);                     
Index = GetSkilldeckIndex(Controller.DBCharacterSheet.SelectedSkilldeckID);
cl_SetSkills(Controller.DBCharacterSkills,Controller.DBSkilldecks[Index].mSkills);
}
}
native function ReportError(export editinline FSkill_Type aSkillType,byte ssf);
*/