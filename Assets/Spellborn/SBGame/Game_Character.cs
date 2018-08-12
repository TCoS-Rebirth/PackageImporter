using System;
using SBBase;

namespace SBGame
{
    [Serializable] public class Game_Character : Base_Component
    {
        public NPC_Taxonomy mFaction;

        public int mFactionId;

        public NPC_Taxonomy mOldFaction;

        public Game_Character()
        {
        }
    }
}
/*
protected event cl_SetFaction(int aFactionId) {
mFactionId = aFactionId;                                                    
if (aFactionId != 0) {                                                      
mFaction = NPC_Taxonomy(Class'SBDBSync'.GetResourceObject(aFactionId));   
} else {                                                                    
mFaction = None;                                                          
}
}
event bool UnshiftFaction() {
if (IsShifted()) {                                                          
mFaction = mOldFaction;                                                   
mOldFaction = None;                                                       
return True;                                                              
}
return False;                                                               
}
event bool ShiftFaction(export editinline NPC_Taxonomy newFaction) {
if (mFaction == newFaction) {                                               
return False;                                                             
}
UnshiftFaction();                                                           
mOldFaction = mFaction;                                                     
mFaction = newFaction;                                                      
return True;                                                                
}
native function bool IsShifted();
event NPC_Taxonomy GetFaction() {
return mFaction;                                                            
}
protected native function sv2clrel_SetFaction_CallStub();
protected event sv2clrel_SetFaction(int aFactionId) {
cl_SetFaction(aFactionId);                                                  
}
event sv_SetFaction(export editinline NPC_Taxonomy aFaction) {
mFaction = aFaction;                                                        
if (mFaction != None) {                                                     
mFactionId = aFaction.GetResourceId();                                    
} else {                                                                    
mFactionId = 0;                                                           
}
sv2clrel_SetFaction_CallStub(mFactionId);                                   
}
final native function string sv_GetName();
final event string cl_GetFullName() {
if (Outer.Appearance.IsShifted()) {                                         
return Outer.Appearance.GetShiftedNPCType().GetLongName();                
} else {                                                                    
return cl_GetBaseFullName();                                              
}
}
final event string cl_GetName() {
if (Outer.Appearance.IsShifted()) {                                         
return Outer.Appearance.GetShiftedNPCType().GetShortName();               
} else {                                                                    
return cl_GetBaseName();                                                  
}
}
function string cl_GetBaseFullName() {
return "<Unspecified character>";                                           
}
event string cl_GetBaseName() {
return "<Unknown>";                                                         
}
function string GetGuildName() {
return "";                                                                  
}
final native function int GetMoney();
function cl_OnInit() {
Super.cl_OnInit();                                                          
if (mFaction == None) {                                                     
cl_SetFaction(mFactionId);                                                
}
}
*/