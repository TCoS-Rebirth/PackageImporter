using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Game_PlayerStats : Game_CharacterStats
    {
        [FieldConst()]
        public float FreeToPlayMaxFamePoints;

        public bool mFreeToPlayLimitReached;

        public int mFamePoints;

        public int mPePPoints;

        [FieldConst()]
        public bool mMayChooseClass;

        [FieldConst()]
        public byte mAvailableAttributePoints;

        public Game_PlayerStats()
        {
        }
    }
}
/*
function LocalizedString GetPePRankDescription() {
local LocalizedString emptyLS;
switch (mRecord.PePRank) {                                                  
case 1 :                                                                  
return Class'StringReferences'.default.PePRank1Description;             
case 2 :                                                                  
return Class'StringReferences'.default.PePRank2Description;             
case 3 :                                                                  
return Class'StringReferences'.default.PePRank3Description;             
case 4 :                                                                  
return Class'StringReferences'.default.PePRank4Description;             
case 5 :                                                                  
return Class'StringReferences'.default.PePRank5Description;             
default:                                                                  
return emptyLS;                                                         
}
}
}
protected native function sv2cl_UpdateFocusAndSoulAffinity_CallStub();
protected native event sv2cl_UpdateFocusAndSoulAffinity(int aFocus,float aSoulAffinity);
protected native function sv2cl_UpdateMindAndSpiritAffinity_CallStub();
protected native event sv2cl_UpdateMindAndSpiritAffinity(int aMind,float aSpiritAffinity);
protected native function sv2cl_UpdateBodyAndRuneAffinity_CallStub();
protected native event sv2cl_UpdateBodyAndRuneAffinity(int aBody,float aRuneAffinity);
protected native function sv2cl_UpdateUpgradeInfo_CallStub();
protected native event sv2cl_UpdateUpgradeInfo(bool aMayChooseClass,byte aAvailableAttributePoints);
protected native function sv2cl_UpdatePePPoints_CallStub();
protected native event sv2cl_UpdatePePPoints(float aPePPoints);
protected native function sv2cl_UpdateFamePoints_CallStub();
protected native event sv2cl_UpdateFamePoints(float aFamePoints);
protected native function sv2cl_SetClass_CallStub();
protected event sv2cl_SetClass(byte aClass) {
SetCharacterClass(aClass);                                                  
}
function sv_SetClass(byte aClass) {
SetCharacterClass(aClass);                                                  
sv_UpdateStats();                                                           
sv2cl_SetClass_CallStub(aClass);                                            
Class'SBDBAsync'.SetCharacterClass(Outer,Outer.GetCharacterID(),aClass - 1);
if (Outer.BodySlots != None) {                                              
Outer.BodySlots.sv_SetMode(Outer.BodySlots.GetBodySlotModeByClass());     
}
SetClassToUniverse(aClass);                                                 
}
protected native function cl2sv_SetClass_CallStub();
event cl2sv_SetClass(byte aClass) {
sv_SetClass(aClass);                                                        
}
native function SetClassToUniverse(byte aClass);
native function int GetMaximumPePRank();
native function int GetMinimumPePRank();
native function int GetMaximumFameLevel();
native function int GetMinimumFameLevel();
native event int GetNextPePRankPoints(int rank);
protected native function sv2clrel_OnUpdatePePRank_CallStub();
event sv2clrel_OnUpdatePePRank(int aNewPePRank) {
if (aNewPePRank > mRecord.PePRank) {                                        
Outer.cl_PlayPawnEffect(1);                                               
if (Outer.IsLocalPlayer()) {                                              
Game_Desktop(Game_PlayerController(Outer.Controller).Player.GUIDesktop).OnRankUp(aNewPePRank);
}
}
mRecord.PePRank = aNewPePRank;                                              
}
protected native function sv2clrel_OnLevelUp_CallStub();
event sv2clrel_OnLevelUp(int aNewLevel) {
local Game_PlayerController Controller;
local bool levelUp;
levelUp = aNewLevel > mRecord.FameLevel;                                    
mRecord.FameLevel = aNewLevel;                                              
if (levelUp) {                                                              
Outer.cl_PlayPawnEffect(0);                                               
if (Outer.IsLocalPlayer()) {                                              
Controller = Game_PlayerController(Outer.Controller);                   
Game_Desktop(Controller.Player.GUIDesktop).OnLevelUp(aNewLevel);        
Game_PlayerConversation(Controller.ConversationControl).cl_RefreshTopics();
}
}
}
native function DecreasePePRank();
native function IncreasePePPoints(int aDelta);
native function IncreaseFamePoints(int aDelta);
native function cl_ClearMayChooseClass();
native function cl_ClearAvailableAttributePoints();
native function sv_UpdateStats();
function cl_OnInit() {
Super.cl_OnInit();                                                          
if (Outer.IsLocalPlayer()) {                                                
SetCharacterClass(Game_Controller(Outer.Controller).DBCharacterSheet.ClassId + 1);
}
}
*/