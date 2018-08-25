using System;
using System.Collections.Generic;

namespace SBGame
{
    [Serializable] public class Game_GameMasterUtils : Game_DebugUtils
    {
        public const string Concentration = "\"c\"";

        public const string Physique = "\"p\"";

        public const string Morale = "\"m\"";

        public const string DISGUISE = "\"disguise\"";

        public const string INVIS = "\"invis\"";

        public const string OFF = "\"off\"";

        public const string On = "\"on\"";

        public List<CommandInfo> mCommandInfos = new List<CommandInfo>();

        public Game_GameMasterController mGameMaster;

        public Game_GameMasterUtils()
        {
        }

        [Serializable] public struct CommandInfo
        {
            public int MinLevel;

            public int selfLevel;

            public string Command;

            public string help;

            public string example;
        }
    }
}
/*
private function Game_Pawn sv_FindPawnByName(string aName) {
local Game_PlayerController GPC;
local string characterName;
local int useLen;
if (aName != "") {                                                          
foreach Outer.AllActors(Class'Game_PlayerController',GPC,'None') {        
characterName = Game_Pawn(GPC.Pawn).GetCharacterName();                 
useLen = Max(Len(characterName),Len(aName));                            
if (StrCmp(aName,characterName,useLen,False) == 0) {                    
return Game_Pawn(GPC.Pawn);                                           
}
}
}
sv2cl_ConsoleLog_CallStub("No player named '" $ aName $ "'.");              
return None;                                                                
}
function PlayerStart sv_FindNearestPlayerstart(Game_Pawn aPlayer) {
local NavigationPoint navpoint;
local PlayerStart curStart;
local int shortestDistance;
local int curLen;
local PlayerStart ret;
shortestDistance = 9999;                                                    
navpoint = Outer.Level.NavigationPointList;                                 
while (navpoint != None) {                                                  
curStart = PlayerStart(navpoint);                                         
if (curStart != None) {                                                   
curLen = VSize(curStart.Location - aPlayer.Location);                   
if (curLen < shortestDistance) {                                        
shortestDistance = curLen;                                            
ret = curStart;                                                       
}
}
navpoint = navpoint.nextNavigationPoint;                                  
}
return ret;                                                                 
}
private function Game_Pawn sv_GetTarget(optional string aPlayer) {
if (aPlayer != "") {                                                        
return sv_FindPawnByName(aPlayer);                                        
} else {                                                                    
return Game_Pawn(mGameMaster.Pawn);                                       
}
}
private function bool sv_HigherLevelThan(Controller aController) {
local Game_GameMasterController GMC;
GMC = Game_GameMasterController(aController);                               
if (GMC == None
|| GMC.GetAuthorityLevel() <= mGameMaster.GetAuthorityLevel()) {
return True;                                                              
} else {                                                                    
sv2cl_ConsoleLog_CallStub("This player is resistent to your commands.");  
return False;                                                             
}
}
private function int GetMinimumLevelFor(string aCommand,optional bool aOnSelf) {
local int Index;
Index = 0;                                                                  
while (Index < mCommandInfos.Length) {                                      
if (Locs(aCommand) == Locs(mCommandInfos[Index].Command)) {               
if (aOnSelf) {                                                          
return mCommandInfos[Index].selfLevel;                                
goto jl0063;                                                          
}
return mCommandInfos[Index].MinLevel;                                   
}
Index++;                                                                  
}
return -1;                                                                  
}
private function bool AuthorizeCommand(string aCommand,optional bool aOnSelf) {
local int MinLevel;
MinLevel = GetMinimumLevelFor(aCommand,aOnSelf);                            
if (MinLevel == -1
|| mGameMaster.GetAuthorityLevel() < MinLevel) {   
if (IsClient()) {                                                         
cl_ConsoleLog("You are not authorized to run this command.");           
} else {                                                                  
sv2cl_ConsoleLog_CallStub("You are not authorized to run this command.");
}
return False;                                                             
}
return True;                                                                
}
private function cl_ConsoleLog(string aLog) {
mGameMaster.Player.Console.Message(aLog,0.00000000);                        
}
protected native function sv2cl_ConsoleLog_CallStub();
private event sv2cl_ConsoleLog(string aLog) {
cl_ConsoleLog(aLog);                                                        
}
native function sv_LogCSCommand(string aCSCommand);
protected native function cl2sv_CSBroadcast_CallStub();
private event cl2sv_CSBroadcast(string aMessage) {
if (AuthorizeCommand("CSBroadcast")) {                                      
sv_LogCSCommand("CSBroadcast" @ aMessage);                                
mGameMaster.Chat.SendMessageToUniverse(8,Game_PlayerPawn(mGameMaster.Pawn).GetCharacterID(),"",aMessage);
}
}
exec function CSBroadcast(string aMessage) {
cl_ConsoleLog("CSBroadcast" @ aMessage);                                    
if (AuthorizeCommand("CSBroadcast")) {                                      
if (aMessage == "") {                                                     
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSBroadcast");                                                  
} else {                                                                  
cl2sv_CSBroadcast_CallStub(aMessage);                                   
}
}
}
exec function CSQuests() {
local int qi;
local int ti;
local int targetProgress;
local export editinline Game_QuestLog questLog;
local export editinline Quest_Type quest;
local array<QuestInventory> QuestInv;
local string Description;
cl_ConsoleLog("CSQuests");                                                  
if (AuthorizeCommand("CSQuests")) {                                         
questLog = Game_PlayerPawn(mGameMaster.Pawn).questLog;                    
if (questLog != None) {                                                   
cl_ConsoleLog("= Active Quests:  ============");                        
qi = 0;                                                                 
while (qi < questLog.Quests.Length) {                                   
quest = questLog.Quests[qi];                                          
cl_ConsoleLog(quest.GetName() @ "-" @ quest.Tag);                     
ti = 0;                                                               
while (ti < quest.Targets.Length) {                                   
targetProgress = questLog.GetTargetProgress(quest,ti);              
Description = quest.ParseText(quest.Targets[ti].GetDescription(targetProgress),quest.Provider,quest.Targets[ti],self);
if (quest.Targets[ti].Check(targetProgress)) {                      
cl_ConsoleLog("* (done)" @ Description);                          
} else {                                                            
if (quest.Targets[ti].Failed(targetProgress)) {                   
cl_ConsoleLog("* (failed)" @ Description);                      
goto jl028D;                                                    
}
if (questLog.GetTargetActivation(quest,ti)) {                     
cl_ConsoleLog("* (" @ string(targetProgress) @ ")"
@ Description);
goto jl028D;                                                    
}
if (questLog.IsTargetVisible(quest,ti)) {                         
cl_ConsoleLog("* (inactive) " @ Description);                   
goto jl028D;                                                    
}
cl_ConsoleLog("* (invisible) " @ Description);                    
}
ti++;                                                               
}
questLog.GetQuestInventory(quest,QuestInv);                           
if (QuestInv.Length > 0) {                                            
cl_ConsoleLog("----------------------------------------");          
ti = 0;                                                             
while (ti < QuestInv.Length) {                                      
cl_ConsoleLog(QuestInv[ti].Item.Name.Text @ "("
$ string(QuestInv[ti].Amount)
$ ")");
ti++;                                                             
}
}
cl_ConsoleLog("----------------------------------------");            
qi++;                                                                 
}
cl_ConsoleLog("========================================");              
}
}
}
private native function bool sv_TeleportToNPC(Game_Pawn aPawn,string npcName);
protected native function cl2sv_CSGotoNPC_CallStub();
private event cl2sv_CSGotoNPC(string npcName,optional string aPlayer) {
local Game_Pawn targetPawn;
if (AuthorizeCommand("CSGotoNPC")) {                                        
sv_LogCSCommand("CSGotoNPC" @ npcName @ aPlayer);                         
targetPawn = sv_GetTarget(aPlayer);                                       
if (targetPawn != None) {                                                 
if (!sv_TeleportToNPC(targetPawn,npcName)) {                            
sv2cl_ConsoleLog_CallStub("Couldn't teleport" @ aPlayer @ "to"
@ npcName);
} else {                                                                
sv2cl_ConsoleLog_CallStub("Teleported" @ aPlayer @ "to" @ npcName);   
}
}
}
}
exec function CSGotoNPC(string npcName,optional string aPlayer) {
cl_ConsoleLog("CSGotoNPC" @ npcName @ aPlayer);                             
if (AuthorizeCommand("CSGotoNPC")) {                                        
if (npcName == "") {                                                      
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGotoNPC");                                                    
} else {                                                                  
cl2sv_CSGotoNPC_CallStub(npcName,aPlayer);                              
}
}
}
protected native function cl2sv_CSGiveFame_CallStub();
private event cl2sv_CSGiveFame(int aFamePoints,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Game_PlayerStats statsComponent;
local int maxPoints;
if (AuthorizeCommand("CSGiveFame")) {                                       
sv_LogCSCommand("CSGiveFame" @ string(aFamePoints)
@ aPlayer);    
if (aPlayer != "") {                                                      
targetPawn = sv_FindPawnByName(aPlayer);                                
} else {                                                                  
targetPawn = Game_Pawn(mGameMaster.Pawn);                               
}
if (targetPawn != None
&& targetPawn.CharacterStats != None) {    
statsComponent = Game_PlayerStats(targetPawn.CharacterStats);           
if (statsComponent != None) {                                           
maxPoints = statsComponent.GetNextFameLevelPoints(49);                
if (statsComponent.mFamePoints + aFamePoints > maxPoints) {           
aFamePoints = maxPoints - statsComponent.mFamePoints;               
} else {                                                              
if (statsComponent.mFamePoints + aFamePoints < 0) {                 
aFamePoints = -statsComponent.mFamePoints;                        
}
}
sv2cl_ConsoleLog_CallStub("CSGiveFame: increasing Fame"
@ string(statsComponent.mFamePoints)
@ "with"
@ string(aFamePoints));
statsComponent.IncreaseFamePoints(aFamePoints);                       
}
}
}
}
exec function CSGiveFame(int aFamePoints,optional string aPlayer) {
cl_ConsoleLog("CSGiveFame" @ string(aFamePoints)
@ aPlayer);          
if (AuthorizeCommand("CSGiveFame")) {                                       
if (aFamePoints == 0) {                                                   
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGiveFame");                                                   
} else {                                                                  
cl2sv_CSGiveFame_CallStub(aFamePoints,aPlayer);                         
}
}
}
protected native function cl2sv_CSGivePep_CallStub();
private event cl2sv_CSGivePep(int aPePPoints,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Game_PlayerStats statsComponent;
local int maxPoints;
if (AuthorizeCommand("CSGivePep")) {                                        
sv_LogCSCommand("CSGivePep" @ string(aPePPoints)
@ aPlayer);      
if (aPlayer != "") {                                                      
targetPawn = sv_FindPawnByName(aPlayer);                                
} else {                                                                  
targetPawn = Game_Pawn(mGameMaster.Pawn);                               
}
if (targetPawn != None
&& targetPawn.CharacterStats != None) {    
statsComponent = Game_PlayerStats(targetPawn.CharacterStats);           
if (statsComponent != None) {                                           
maxPoints = statsComponent.GetNextPePRankPoints(4);                   
if (statsComponent.mPePPoints + aPePPoints > maxPoints) {             
aPePPoints = maxPoints - statsComponent.mPePPoints;                 
} else {                                                              
if (statsComponent.mPePPoints + aPePPoints < 0) {                   
aPePPoints = -statsComponent.mPePPoints;                          
}
}
sv2cl_ConsoleLog_CallStub("CSGivePep: increasing PeP"
@ string(statsComponent.mPePPoints)
@ "with"
@ string(aPePPoints));
statsComponent.IncreasePePPoints(aPePPoints);                         
}
}
}
}
exec function CSGivePep(int aPePPoints,optional string aPlayer) {
cl_ConsoleLog("CSGivePep" @ string(aPePPoints)
@ aPlayer);            
if (AuthorizeCommand("CSGivePep")) {                                        
if (aPePPoints == 0) {                                                    
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGivePep");                                                    
} else {                                                                  
cl2sv_CSGivePep_CallStub(aPePPoints,aPlayer);                           
}
}
}
protected native function cl2sv_CSSetClass_CallStub();
private event cl2sv_CSSetClass(byte aClass,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Game_PlayerStats statsComponent;
if (AuthorizeCommand("CSSetClass")) {                                       
sv_LogCSCommand("CSSetClass" @ string(aClass) @ aPlayer);                 
if (aPlayer != "") {                                                      
targetPawn = sv_FindPawnByName(aPlayer);                                
} else {                                                                  
targetPawn = Game_Pawn(mGameMaster.Pawn);                               
}
if (targetPawn != None
&& targetPawn.CharacterStats != None) {    
statsComponent = Game_PlayerStats(targetPawn.CharacterStats);           
switch (aClass) {                                                       
case 3 :                                                              
case 2 :                                                              
case 1 :                                                              
statsComponent.sv_SetClass(aClass);                                 
sv2cl_ConsoleLog_CallStub("CSSetClass: class set to" @ string(aClass));
break;                                                              
case 4 :                                                              
case 6 :                                                              
case 5 :                                                              
case 7 :                                                              
case 8 :                                                              
case 9 :                                                              
case 10 :                                                             
case 11 :                                                             
case 12 :                                                             
if (statsComponent.mRecord.FameLevel >= 5) {                        
statsComponent.sv_SetClass(aClass);                               
sv2cl_ConsoleLog_CallStub("CSSetClass: class set to" @ string(aClass));
} else {                                                            
sv2cl_ConsoleLog_CallStub("CSSetClass: fame level too low ("
$ string(statsComponent.mRecord.FameLevel)
$ ")");
}
break;                                                              
default:                                                              
sv2cl_ConsoleLog_CallStub("CSSetClass: invalid class specified");   
break;                                                              
}
}
}
}
exec function CSSetClass(optional byte aClass,optional string aPlayer) {
cl_ConsoleLog("CSSetClass" @ string(aClass) @ aPlayer);                     
if (AuthorizeCommand("CSSetClass")) {                                       
switch (aClass) {                                                         
case 3 :                                                                
case 2 :                                                                
case 1 :                                                                
case 4 :                                                                
case 6 :                                                                
case 5 :                                                                
case 7 :                                                                
case 8 :                                                                
case 9 :                                                                
case 10 :                                                               
case 11 :                                                               
case 12 :                                                               
cl2sv_CSSetClass_CallStub(aClass,aPlayer);                            
break;                                                                
default:                                                                
CSHelp("CSSetClass");                                                 
cl_ConsoleLog("CSSetClass: invalid option (" $ string(aClass)
$ "), listing valid options:");
cl_ConsoleLog("  Arche Types:");                                      
cl_ConsoleLog("    ECC_Rogue");                                       
cl_ConsoleLog("    ECC_Spellcaster");                                 
cl_ConsoleLog("    ECC_Warrior");                                     
cl_ConsoleLog("  Classes:");                                          
cl_ConsoleLog("    ECC_Trickster");                                   
cl_ConsoleLog("    ECC_DeathHand");                                   
cl_ConsoleLog("    ECC_SkinShifter");                                 
cl_ConsoleLog("    ECC_Bloodwarrior");                                
cl_ConsoleLog("    ECC_FuryHammer");                                  
cl_ConsoleLog("    ECC_WrathGuard");                                  
cl_ConsoleLog("    ECC_RuneMage");                                    
cl_ConsoleLog("    ECC_VoidSeer");                                    
cl_ConsoleLog("    ECC_AncestralMage");                               
break;                                                                
}
}
}
protected native function cl2sv_CSGiveSkill_CallStub();
private event cl2sv_CSGiveSkill(string aSkillName,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline FSkill_Type Skill;
local array<FSkill_Type> skillTypes;
local int i;
local Object Obj;
local int ResourceId;
local Game_Controller gc;
if (AuthorizeCommand("CSGiveSkill")) {                                      
sv_LogCSCommand("CSGiveSkill" @ aSkillName @ aPlayer);                    
if (aPlayer != "") {                                                      
targetPawn = sv_FindPawnByName(aPlayer);                                
} else {                                                                  
targetPawn = Game_Pawn(mGameMaster.Pawn);                               
}
if (targetPawn != None && targetPawn.Skills != None) {                    
Class'FSkill_Type'.static.GetAllSkills(skillTypes);                     
if (Skill == None) {                                                    
i = 0;                                                                
while (i < skillTypes.Length) {                                       
Obj = skillTypes[i];                                                
if (StrCmp(string(Obj.Name),aSkillName,-1,False) == 0) {            
Skill = skillTypes[i];                                            
goto jl0119;                                                      
}
++i;                                                                
}
}
if (Skill == None) {                                                    
ResourceId = int(aSkillName);                                         
if (ResourceId != 0) {                                                
i = 0;                                                              
while (i < skillTypes.Length) {                                     
if (skillTypes[i].GetResourceId() == ResourceId) {                
Skill = skillTypes[i];                                          
goto jl0190;                                                    
}
++i;                                                              
}
}
}
if (Skill != None) {                                                    
gc = Game_Controller(targetPawn.Controller);                          
i = gc.DBCharacterSkills.Length;                                      
gc.DBCharacterSkills.Length = i + 1;                                  
gc.DBCharacterSkills[i] = Skill.GetResourceId();                      
Game_PlayerSkills(targetPawn.Skills).sv2cl_SetSkills_CallStub(gc.DBCharacterSkills,gc.DBSkilldecks[i].mSkills);
sv2cl_ConsoleLog_CallStub("CSGiveSkill: skill " $ string(Skill)
$ " given to player "
$ targetPawn.GetCharacterName());
} else {                                                                
sv2cl_ConsoleLog_CallStub("CSGiveSkill: couldn't find skill"
@ aSkillName);
}
}
}
}
exec function CSGiveSkill(string aSkillName,optional string aPlayer) {
cl_ConsoleLog("CSGiveSkill" @ aSkillName @ aPlayer);                        
if (AuthorizeCommand("CSGiveSkill")) {                                      
if (Len(aSkillName) == 0) {                                               
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGiveSkill");                                                  
} else {                                                                  
cl2sv_CSGiveSkill_CallStub(aSkillName,aPlayer);                         
}
}
}
protected native function cl2sv_CSGiveMoney_CallStub();
private event cl2sv_CSGiveMoney(int aMoney,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Game_PlayerItemManager itemManager;
local SBDBAsyncCallback callback;
if (AuthorizeCommand("CSGiveMoney")) {                                      
sv_LogCSCommand("CSGiveMoney" @ string(aMoney) @ aPlayer);                
if (aPlayer != "") {                                                      
targetPawn = sv_FindPawnByName(aPlayer);                                
} else {                                                                  
targetPawn = Game_Pawn(mGameMaster.Pawn);                               
}
if (targetPawn != None && targetPawn.itemManager != None) {               
itemManager = Game_PlayerItemManager(targetPawn.itemManager);           
if (itemManager != None) {                                              
itemManager.sv_UpdateMoney(aMoney,callback);                          
}
}
}
}
exec function CSGiveMoney(int aMoney,optional string aPlayer) {
cl_ConsoleLog("CSGiveMoney" @ string(aMoney) @ aPlayer);                    
if (AuthorizeCommand("CSGiveMoney")) {                                      
if (aMoney == 0) {                                                        
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGiveMoney");                                                  
} else {                                                                  
cl2sv_CSGiveMoney_CallStub(aMoney,aPlayer);                             
}
}
}
protected native function cl2sv_CSGiveItem_CallStub();
private event cl2sv_CSGiveItem(int aItemTypeID,byte Color1,byte Color2,byte Amount,optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Item_Type ItemType;
local export editinline Game_PlayerItemManager itemManager;
local SBDBAsyncCallback callback;
if (!AuthorizeCommand("CSGiveItem")) {                                      
return;                                                                   
}
sv_LogCSCommand("CSGiveItem" @ string(aItemTypeID)
@ string(Color1)
@ string(Color2)
@ string(Amount)
@ aPlayer);
if (aPlayer != "") {                                                        
targetPawn = sv_FindPawnByName(aPlayer);                                  
} else {                                                                    
targetPawn = Game_Pawn(mGameMaster.Pawn);                                 
}
if (targetPawn == None || targetPawn.itemManager == None) {                 
return;                                                                   
}
itemManager = Game_PlayerItemManager(targetPawn.itemManager);               
ItemType = Item_Type(Class'SBDBSync'.GetResourceObject(aItemTypeID));       
if (itemManager != None && ItemType != None) {                              
if (Amount == 0) {                                                        
Amount = 1;                                                             
}
if (itemManager.sv_QueueAddItem(ItemType,Amount,0,Color1,Color2)) {       
itemManager.sv_ExecuteAddItems(2,callback);                             
}
}
}
exec function CSGiveItem(int aItemTypeID,optional byte Color1,optional byte Color2,optional byte Amount,optional string aPlayer) {
cl_ConsoleLog("CSGiveItem" @ string(aItemTypeID)
@ string(Color1)
@ string(Color2)
@ string(Amount)
@ aPlayer);
if (AuthorizeCommand("CSGiveItem")) {                                       
if (aItemTypeID == 0) {                                                   
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGiveItem");                                                   
} else {                                                                  
cl2sv_CSGiveItem_CallStub(aItemTypeID,Color1,Color2,Amount,aPlayer);    
}
}
}
protected native function cl2sv_CSLevelUp_CallStub();
private event cl2sv_CSLevelUp(optional string aPlayer) {
local Game_Pawn targetPawn;
local export editinline Game_PlayerStats Stats;
local int nextFamePoints;
if (AuthorizeCommand("CSLevelUp")) {                                        
sv_LogCSCommand("CSLevelUp" @ aPlayer);                                   
targetPawn = sv_GetTarget(aPlayer);                                       
if (targetPawn != None) {                                                 
Stats = Game_PlayerStats(targetPawn.CharacterStats);                    
if (Stats != None) {                                                    
if (Stats.mRecord.FameLevel < 50) {                                   
nextFamePoints = Stats.GetNextFameLevelPoints(Stats.mRecord.FameLevel);
Stats.IncreaseFamePoints(nextFamePoints - Stats.mFamePoints + 1);   
}
}
}
}
}
exec function CSLevelUp(optional string aPlayer) {
cl_ConsoleLog("CSLevelUp" @ aPlayer);                                       
if (AuthorizeCommand("CSLevelUp")) {                                        
cl2sv_CSLevelUp_CallStub(aPlayer);                                        
}
}
protected native function cl2sv_CSQuestObjective_CallStub();
private event cl2sv_CSQuestObjective(string aQuestTag,int aObjective,int aValue,optional string aPlayer) {
local Game_PlayerPawn playerPawn;
local export editinline Quest_Type quest;
if (AuthorizeCommand("CSQuestObjective")) {                                 
sv_LogCSCommand("CSQuestObjective" @ aQuestTag @ string(aObjective)
@ string(aValue)
@ aPlayer);
playerPawn = Game_PlayerPawn(sv_GetTarget(aPlayer));                      
if (playerPawn != None && playerPawn.questLog != None) {                  
foreach AllObjects(Class'Quest_Type',quest) {                           
if (Locs(quest.Tag) == Locs(aQuestTag)) {                             
if (aObjective >= 0
&& aObjective < quest.Targets.Length) {
playerPawn.questLog.sv_SetTargetProgress(quest.Targets[aObjective],aValue,None);
}
}
}
}
}
}
exec function CSQuestObjective(string aQuestTag,int aObjective,int aValue,optional string aPlayer) {
cl_ConsoleLog("CSQuestObjective" @ aQuestTag @ string(aObjective)
@ string(aValue)
@ aPlayer);
if (AuthorizeCommand("CSQuestObjective")) {                                 
if (aQuestTag == "") {                                                    
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSQuestObjective");                                             
} else {                                                                  
cl2sv_CSQuestObjective_CallStub(aQuestTag,aObjective,aValue,aPlayer);   
}
}
}
protected native function cl2sv_CSGiveQuest_CallStub();
private event cl2sv_CSGiveQuest(string aQuestTag,optional string aPlayer) {
local Game_PlayerPawn playerPawn;
local export editinline Quest_Type quest;
if (AuthorizeCommand("CSGiveQuest")) {                                      
sv_LogCSCommand("CSGiveQuest" @ aQuestTag @ aPlayer);                     
playerPawn = Game_PlayerPawn(sv_GetTarget(aPlayer));                      
if (playerPawn != None && playerPawn.questLog != None) {                  
foreach AllObjects(Class'Quest_Type',quest) {                           
if (Locs(quest.Tag) == Locs(aQuestTag)) {                             
if (playerPawn.questLog.HasQuest(quest)) {                          
playerPawn.questLog.sv_AbandonQuest(quest);                       
}
playerPawn.questLog.sv_AcceptQuest(quest);                          
}
}
}
}
}
exec function CSGiveQuest(string aQuestTag,optional string aPlayer) {
cl_ConsoleLog("CSGiveQuest" @ aQuestTag @ aPlayer);                         
if (AuthorizeCommand("CSGiveQuest")) {                                      
if (aQuestTag == "") {                                                    
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSGiveQuest");                                                  
} else {                                                                  
cl2sv_CSGiveQuest_CallStub(aQuestTag,aPlayer);                          
}
}
}
protected native function cl2sv_CSUnMute_CallStub();
private event cl2sv_CSUnMute(string aPlayer,optional string aMessage) {
local Game_Pawn mutePawn;
if (AuthorizeCommand("CSMute")) {                                           
sv_LogCSCommand("CSUnMute" @ aPlayer @ aMessage);                         
mutePawn = sv_FindPawnByName(aPlayer);                                    
if (mutePawn != None) {                                                   
if (sv_HigherLevelThan(mutePawn.Controller)) {                          
if (!mutePawn.IsMuted()) {                                            
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "' is not muted.");       
} else {                                                              
Class'SBDBAsync'.LogCSCommand(mGameMaster.AccountID,Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"CSUnMute",Base_Controller(mutePawn.Controller).AccountID,aPlayer);
mutePawn.sv_Mute(False);                                            
Game_PlayerController(mutePawn.Controller).Chat.sv2cl_OnMessage_CallStub(Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"You have been unmuted: details ("
$ aMessage
$ ").",8);
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "' has been unmuted.");   
}
}
}
}
}
exec function CSUnMute(string aPlayer,optional string aMessage) {
cl_ConsoleLog("CSUnMute" @ aPlayer @ aMessage);                             
if (AuthorizeCommand("CSUnMute")) {                                         
cl2sv_CSUnMute_CallStub(aPlayer,aMessage);                                
}
}
protected native function cl2sv_CSMute_CallStub();
private event cl2sv_CSMute(string aPlayer,string aScope,optional int aMinutes,optional string aReason) {
local Game_Pawn mutePawn;
if (AuthorizeCommand("CSMute")) {                                           
sv_LogCSCommand("CSMute" @ aPlayer @ aScope @ string(aMinutes)
@ aReason);
mutePawn = sv_FindPawnByName(aPlayer);                                    
if (mutePawn != None) {                                                   
if (sv_HigherLevelThan(mutePawn.Controller)) {                          
if (mutePawn.IsMuted()) {                                             
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "' is already muted.");   
} else {                                                              
if (aScope == "") {                                                 
aScope = "all";                                                   
}
Class'SBDBAsync'.LogCSCommand(mGameMaster.AccountID,Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"CSMute",Base_Controller(mutePawn.Controller).AccountID,aPlayer,aReason,"",aScope,aMinutes);
Game_PlayerController(mutePawn.Controller).Chat.sv2cl_OnMessage_CallStub(Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"You have been muted: reason ("
$ aReason
$ ").",8);
mutePawn.sv_Mute(True,aMinutes,aScope);                             
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "' has been muted for"
@ string(aMinutes)
@ "minutes.");
}
}
}
}
}
exec function CSMute(string aPlayer,string aScope,optional int aMinutes,optional string aReason) {
cl_ConsoleLog("CSMute" @ aPlayer @ aScope @ string(aMinutes)
@ aReason);
if (AuthorizeCommand("CSMute")) {                                           
if (aPlayer == "" || aScope == "") {                                      
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSMute");                                                       
} else {                                                                  
cl2sv_CSMute_CallStub(aPlayer,aScope,aMinutes,aReason);                 
}
}
}
protected native function cl2sv_CSTravel_CallStub();
private event cl2sv_CSTravel(int aWorld,optional string aPlayer) {
local Game_Pawn targetPawn;
local Base_Controller Controller;
local Game_GameServer Engine;
if (AuthorizeCommand("CSTravel",aPlayer == "")) {                           
sv_LogCSCommand("CSTravel" @ string(aWorld) @ aPlayer);                   
targetPawn = sv_GetTarget(aPlayer);                                       
if (targetPawn != None && targetPawn.Controller != None) {                
Controller = Base_Controller(targetPawn.Controller);                    
Engine = Game_GameServer(Class'Actor'.static.GetGameEngine());          
if (Engine != None) {                                                   
Engine.LoginToWorldByID(aWorld,Controller.CharacterID,"","");         
sv2cl_ConsoleLog_CallStub("CSTravel: Sending" @ targetPawn.GetCharacterName()
@ "to world"
@ string(aWorld));
}
}
}
}
exec function CSTravel(int aWorld,optional string aPlayer) {
cl_ConsoleLog("CSTravel" @ string(aWorld) @ aPlayer);                       
if (AuthorizeCommand("CSTravel",aPlayer == "")) {                           
cl2sv_CSTravel_CallStub(aWorld,aPlayer);                                  
}
}
protected native function cl2sv_CSStats_CallStub();
private event cl2sv_CSStats(string aPlayer,string aStat,int aValue) {
local Game_Pawn statPawn;
if (AuthorizeCommand("CSStats")) {                                          
sv_LogCSCommand("CSStats" @ aPlayer @ aStat @ string(aValue));            
statPawn = sv_FindPawnByName(aPlayer);                                    
if (statPawn != None) {                                                   
if (sv_HigherLevelThan(statPawn.Controller)) {                          
if (StrCmp(aStat,"m",Len("m"),False) == 0) {                          
statPawn.CharacterStats.SetMorale(aValue);                          
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "'s PHYSIQUE set to"
@ string(statPawn.CharacterStats.mRecord.Morale)
$ ".");
}
if (StrCmp(aStat,"p",Len("p"),False) == 0) {                          
statPawn.CharacterStats.SetPhysique(aValue);                        
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "'s MORALE set to"
@ string(statPawn.CharacterStats.mRecord.Physique)
$ ".");
}
if (StrCmp(aStat,"c",Len("c"),False) == 0) {                          
statPawn.CharacterStats.SetConcentration(aValue);                   
sv2cl_ConsoleLog_CallStub("'" $ aPlayer $ "'s CONCENTRATION set to"
@ string(statPawn.CharacterStats.mRecord.Concentration)
$ ".");
}
}
}
}
}
exec function CSStats(string aPlayer,string aStat,int aValue) {
cl_ConsoleLog("CSStats" @ aPlayer @ aStat @ string(aValue));                
if (AuthorizeCommand("CSStats")) {                                          
if (aPlayer == "" || aStat == "") {                                       
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSStats");                                                      
} else {                                                                  
cl2sv_CSStats_CallStub(aPlayer,aStat,aValue);                           
}
}
}
private native function sv_CSKick(Game_PlayerController aPawn,optional string aMessage);
protected native function cl2sv_CSKick_CallStub();
private event cl2sv_CSKick(string aPlayer,string aMessage) {
local Game_Pawn kickPawn;
if (AuthorizeCommand("CSKick")) {                                           
sv_LogCSCommand("CSKick" @ aPlayer);                                      
kickPawn = sv_FindPawnByName(aPlayer);                                    
if (kickPawn != None) {                                                   
if (sv_HigherLevelThan(kickPawn.Controller)) {                          
sv_CSKick(Game_PlayerController(kickPawn.Controller),aMessage);       
Class'SBDBAsync'.LogCSCommand(mGameMaster.AccountID,Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"CSKick",Base_Controller(kickPawn.Controller).AccountID,aPlayer,aMessage);
sv2cl_ConsoleLog_CallStub("You kicked '" $ aPlayer $ "'.");           
}
}
}
}
exec function CSKick(string aPlayer,string aMessage) {
cl_ConsoleLog("CSKick" @ aPlayer);                                          
if (AuthorizeCommand("CSKick")) {                                           
cl2sv_CSKick_CallStub(aPlayer,aMessage);                                  
}
}
protected native function cl2sv_CSSummon_CallStub();
private event cl2sv_CSSummon(string aPlayer) {
local Game_Pawn targetPawn;
if (AuthorizeCommand("CSSummon")) {                                         
sv_LogCSCommand("CSSummon" @ aPlayer);                                    
targetPawn = sv_FindPawnByName(aPlayer);                                  
if (targetPawn != None) {                                                 
if (sv_HigherLevelThan(targetPawn.Controller)) {                        
targetPawn.sv_TeleportTo(mGameMaster.Pawn.Location,mGameMaster.Pawn.Rotation);
sv2cl_ConsoleLog_CallStub("You have summoned '" @ aPlayer
$ "'.");
}
}
}
}
exec function CSSummon(string aPlayer) {
cl_ConsoleLog("CSSummon" @ aPlayer);                                        
if (AuthorizeCommand("CSSummon")) {                                         
if (aPlayer != "") {                                                      
cl2sv_CSSummon_CallStub(aPlayer);                                       
} else {                                                                  
cl_ConsoleLog("You must specify a player target.");                     
}
}
}
protected native function cl2sv_CSRespawn_CallStub();
private event cl2sv_CSRespawn(optional string aPlayer,optional string aTag) {
local Game_Pawn targetPawn;
local PlayerStart spawnPoint;
if (AuthorizeCommand("CSRespawn",aPlayer == "")) {                          
sv_LogCSCommand("CSRespawn" @ aPlayer @ aTag);                            
targetPawn = sv_FindPawnByName(aPlayer);                                  
if (targetPawn != None) {                                                 
if (targetPawn == mGameMaster.Pawn
|| sv_HigherLevelThan(targetPawn.Controller)) {
if (aTag == "") {                                                     
spawnPoint = sv_FindNearestPlayerstart(targetPawn);                 
} else {                                                              
spawnPoint = Game_GameInfo(targetPawn.GetGameInfo()).sv_GetPlayerStart(aTag);
}
sv2cl_ConsoleLog_CallStub("CSRespawn: Teleported" @ targetPawn.GetCharacterName()
@ "to"
@ string(spawnPoint)
@ "@"
@ string(spawnPoint.Location));
targetPawn.sv_TeleportTo(spawnPoint.Location,spawnPoint.Rotation);    
targetPawn.TriggerEvent(spawnPoint.Event,spawnPoint,targetPawn);      
}
}
}
}
exec function CSRespawn(optional string aPlayer,optional string aTag) {
cl_ConsoleLog("CSRespawn" @ aPlayer @ aTag);                                
if (AuthorizeCommand("CSRespawn",aPlayer == "")) {                          
cl2sv_CSRespawn_CallStub(aPlayer,aTag);                                   
}
}
protected native function cl2sv_CSTeleport_CallStub();
private event cl2sv_CSTeleport(string aPlayerOrX,optional string aY,optional string aZ) {
local Game_Pawn targetPawn;
local Vector TargetLocation;
if (AuthorizeCommand("CSTeleport")) {                                       
sv_LogCSCommand("CSTeleport" @ aPlayerOrX @ aY @ aZ);                     
if (aY == "" && aZ == "") {                                               
targetPawn = sv_FindPawnByName(aPlayerOrX);                             
if (targetPawn != None) {                                               
TargetLocation = targetPawn.Location;                                 
} else {                                                                
sv2cl_ConsoleLog_CallStub("CSTeleport: Couldn't find player"
@ aPlayerOrX);
return;                                                               
}
} else {                                                                  
TargetLocation.X = float(aPlayerOrX);                                   
TargetLocation.Y = float(aY);                                           
TargetLocation.Z = float(aZ);                                           
}
Game_Pawn(mGameMaster.Pawn).sv_TeleportTo(TargetLocation,mGameMaster.Pawn.Rotation);
sv2cl_ConsoleLog_CallStub("CSTeleport: You are teleported to location"
@ string(TargetLocation));
}
}
exec function CSTeleport(string aPlayerOrX,optional string Y,optional string Z) {
cl_ConsoleLog("CSTeleport" @ aPlayerOrX @ Y @ Z);                           
if (AuthorizeCommand("CSTeleport")) {                                       
if (aPlayerOrX == "") {                                                   
cl_ConsoleLog("Missing parameter(s)!:");                                
CSHelp("CSTeleport");                                                   
} else {                                                                  
cl2sv_CSTeleport_CallStub(aPlayerOrX,Y,Z);                              
}
}
}
private function sv_Kill(Game_Pawn aTargetPawn) {
if (aTargetPawn != None
&& (aTargetPawn == mGameMaster.Pawn
|| sv_HigherLevelThan(aTargetPawn.Controller))) {
Class'SBDBAsync'.LogCSCommand(mGameMaster.AccountID,Game_Pawn(mGameMaster.Pawn).GetCharacterName(),"CSKill",Base_Controller(aTargetPawn.Controller).AccountID,aTargetPawn.GetCharacterName());
aTargetPawn.Died(mGameMaster,Class'Burned',vect(0.000000, 0.000000, 0.000000));
sv2cl_ConsoleLog_CallStub("Killed" @ aTargetPawn.GetCharacterName());     
} else {                                                                    
sv2cl_ConsoleLog_CallStub("Not allowed to kill" @ aTargetPawn.GetCharacterName());
}
}
protected native function cl2sv_CSKillPlayer_CallStub();
private event cl2sv_CSKillPlayer(optional string aPlayer) {
local Game_Pawn targetPawn;
if (AuthorizeCommand("CSKillPlayer",aPlayer == "")) {                       
sv_LogCSCommand("CSKillPlayer" @ aPlayer);                                
targetPawn = sv_GetTarget(aPlayer);                                       
if (targetPawn != None) {                                                 
sv_Kill(targetPawn);                                                    
}
}
}
exec function CSKillPlayer(optional string aPlayer) {
cl_ConsoleLog("CSKillPlayer" @ aPlayer);                                    
if (AuthorizeCommand("CSKillPlayer",aPlayer == "")) {                       
cl2sv_CSKillPlayer_CallStub(aPlayer);                                     
}
}
protected native function cl2sv_CSKillMonster_CallStub();
private event cl2sv_CSKillMonster(Game_Pawn aMonster) {
if (AuthorizeCommand("CSKillMonster")) {                                    
sv_LogCSCommand("CSKillMonster");                                         
sv_Kill(aMonster);                                                        
}
}
exec function CSKillMonster() {
local Game_Pawn targetPawn;
cl_ConsoleLog("CSKillMonster");                                             
if (AuthorizeCommand("CSKillMonster")) {                                    
targetPawn = mGameMaster.Input.cl_GetTargetPawn();                        
cl_ConsoleLog("About to kill" @ string(targetPawn));                      
if (targetPawn != None && targetPawn.IsA('Game_NPCPawn')) {               
cl2sv_CSKillMonster_CallStub(targetPawn);                               
} else {                                                                  
cl_ConsoleLog("You don't have a (monster) target.");                    
}
}
}
protected native function cl2sv_CSReset_CallStub();
private event cl2sv_CSReset(optional string invisible,optional string DISGUISE) {
if (AuthorizeCommand("CSReset")) {                                          
sv_LogCSCommand("CSReset" @ invisible @ DISGUISE);                        
sv_Invulnerable(True);                                                    
if (StrCmp(invisible,"invis",Len("invis"),False) == 0) {                  
} else {                                                                  
Game_Pawn(mGameMaster.Pawn).sv_SetVisibleInRelevance(True);             
}
if (StrCmp(invisible,DISGUISE,Len(DISGUISE),False) == 0) {                
}
}
}
exec function CSReset(optional string invisible,optional string DISGUISE) {
cl_ConsoleLog("CSReset" @ invisible @ DISGUISE);                            
if (AuthorizeCommand("CSReset")) {                                          
cl2sv_CSReset_CallStub(invisible,DISGUISE);                               
}
}
protected native function cl2sv_CSSpeed_CallStub();
private event cl2sv_CSSpeed(bool aOnFlag) {
local Game_Pawn gp;
if (AuthorizeCommand("CSSpeed")) {                                          
gp = Game_Pawn(mGameMaster.Pawn);                                         
if (gp == None) {                                                         
return;                                                                 
}
if (aOnFlag) {                                                            
sv_LogCSCommand("CSSpeed on");                                          
gp.sv_SetGroundSpeedModifier(FClamp(gp.GroundSpeedModifier * 1.25000000,1.00000000,10.00000000));
sv2cl_ConsoleLog_CallStub("CSSpeed: Updated SpeedModifier to "
$ string(gp.GroundSpeedModifier));
} else {                                                                  
sv_LogCSCommand("CSSpeed off");                                         
gp.sv_SetGroundSpeedModifier(1.00000000);                               
}
}
}
exec function CSSpeed(string aState) {
cl_ConsoleLog("CSSpeed" @ aState);                                          
if (AuthorizeCommand("CSSpeed")) {                                          
if (aState == "") {                                                       
cl_ConsoleLog("Current speed:"
@ string(Game_Pawn(mGameMaster.Pawn).GroundSpeed));
CSHelp("CSSpeed");                                                      
} else {                                                                  
if (StrCmp(aState,"on",Len("on"),False) != 0
&& StrCmp(aState,"off",Len("off"),False) != 0) {
cl_ConsoleLog("Wrong parameters!:");                                  
CSHelp("CSSpeed");                                                    
} else {                                                                
if (StrCmp(aState,"on",Len("on"),False) == 0) {                       
cl2sv_CSSpeed_CallStub(True);                                       
} else {                                                              
if (StrCmp(aState,"off",Len("off"),False) == 0) {                   
cl2sv_CSSpeed_CallStub(False);                                    
cl_ConsoleLog("CSSpeed reset!");                                  
}
}
}
}
}
}
protected native function cl2sv_CSShield_CallStub();
private event cl2sv_CSShield(string aState) {
if (AuthorizeCommand("CSShield")) {                                         
sv_LogCSCommand("CSShield" @ aState);                                     
if (StrCmp(aState,"on",Len(aState),False) == 0) {                         
sv_Invulnerable(True);                                                  
mGameMaster.sv2cl_SetShield_CallStub(True);                             
sv2cl_ConsoleLog_CallStub("You are invincible!");                       
} else {                                                                  
if (StrCmp(aState,"off",Len(aState),False) == 0) {                      
sv_Invulnerable(False);                                               
mGameMaster.sv2cl_SetShield_CallStub(False);                          
sv2cl_ConsoleLog_CallStub("You are vincible again!");                 
}
}
}
}
exec function CSShield(string aState) {
cl_ConsoleLog("CSShield" @ aState);                                         
if (AuthorizeCommand("CSShield")) {                                         
if (aState == "") {                                                       
cl_ConsoleLog("Current state:"
@ string(Game_Pawn(mGameMaster.Pawn).IsInvulnerable()));
CSHelp("CSShield");                                                     
} else {                                                                  
if (StrCmp(aState,"on",Len(aState),False) != 0
&& StrCmp(aState,"off",Len(aState),False) != 0) {
cl_ConsoleLog("Wrong parameters!:");                                  
CSHelp("CSShield");                                                   
} else {                                                                
cl2sv_CSShield_CallStub(aState);                                      
}
}
}
}
protected native function cl2sv_CSIsVis_CallStub();
private event cl2sv_CSIsVis() {
if (AuthorizeCommand("CSIsVis")) {                                          
sv_LogCSCommand("CSIsVis");                                               
if (Game_Pawn(mGameMaster.Pawn).sv_IsVisibleInRelevance() == True) {      
sv2cl_ConsoleLog_CallStub("Current State : Visible");                   
} else {                                                                  
sv2cl_ConsoleLog_CallStub("Current State : Invisible");                 
}
}
}
exec function CSIsVis() {
cl_ConsoleLog("CSIsVis");                                                   
if (AuthorizeCommand("CSIsVis")) {                                          
cl2sv_CSIsVis_CallStub();                                                 
}
}
protected native function cl2sv_CSVis_CallStub();
private event cl2sv_CSVis() {
if (AuthorizeCommand("CSVis")) {                                            
sv_LogCSCommand("CSVis");                                                 
Game_Pawn(mGameMaster.Pawn).sv_SetVisibleInRelevance(True);               
mGameMaster.sv2cl_SetVisibleInRelevance_CallStub(True);                   
sv2cl_ConsoleLog_CallStub("You are visible!");                            
}
}
exec function CSVis() {
cl_ConsoleLog("CSVis");                                                     
if (AuthorizeCommand("CSVis")) {                                            
cl2sv_CSVis_CallStub();                                                   
}
}
protected native function cl2sv_CSInvis_CallStub();
private event cl2sv_CSInvis() {
if (AuthorizeCommand("CSVis")) {                                            
sv_LogCSCommand("CSInVis");                                               
Game_Pawn(mGameMaster.Pawn).sv_SetVisibleInRelevance(False);              
mGameMaster.sv2cl_SetVisibleInRelevance_CallStub(False);                  
sv2cl_ConsoleLog_CallStub("You are invisible!");                          
}
}
exec function CSInvis() {
cl_ConsoleLog("CSInvis");                                                   
if (AuthorizeCommand("CSInvis")) {                                          
cl2sv_CSInvis_CallStub();                                                 
}
}
protected native function cl2sv_CSLocation_CallStub();
private event cl2sv_CSLocation(string aPlayer) {
local Game_Pawn targetPawn;
if (AuthorizeCommand("CSLocation")) {                                       
targetPawn = sv_FindPawnByName(aPlayer);                                  
if (targetPawn != None) {                                                 
sv2cl_ConsoleLog_CallStub("CSLocation:" @ targetPawn.GetCharacterName()
@ "is located at:"
@ string(targetPawn.Location));
} else {                                                                  
sv2cl_ConsoleLog_CallStub("CSLocation: Couldn't find player"
@ aPlayer);
}
}
}
exec function CSLocation(optional string aPlayer) {
if (AuthorizeCommand("CSLocation")) {                                       
if (aPlayer == "") {                                                      
cl_ConsoleLog("CSLocation:"
@ Game_Pawn(mGameMaster.Pawn).GetCharacterName()
@ "is located at:"
@ string(mGameMaster.Pawn.Location));
} else {                                                                  
cl2sv_CSLocation_CallStub(aPlayer);                                     
}
}
}
exec function CSHelp(optional string aCommand) {
local int Index;
cl_ConsoleLog("CSHelp" @ aCommand);                                         
if (AuthorizeCommand("CSHelp")) {                                           
if (aCommand != "") {                                                     
Index = 0;                                                              
while (Index < mCommandInfos.Length) {                                  
if (StrCmp(aCommand,mCommandInfos[Index].Command,Len(mCommandInfos[Index].Command),False) == 0) {
if (mGameMaster.GetAuthorityLevel() >= mCommandInfos[Index].MinLevel
|| mGameMaster.GetAuthorityLevel() >= mCommandInfos[Index].selfLevel) {
cl_ConsoleLog(mCommandInfos[Index].Command $ ":"
@ mCommandInfos[Index].help);
return;                                                           
}
}
Index++;                                                              
}
cl_ConsoleLog("Unknown command or insufficient privileges; showing possible commands:");
}
Index = 0;                                                                
while (Index < mCommandInfos.Length) {                                    
if (mGameMaster.GetAuthorityLevel() >= mCommandInfos[Index].MinLevel
|| mGameMaster.GetAuthorityLevel() >= mCommandInfos[Index].selfLevel) {
cl_ConsoleLog(mCommandInfos[Index].Command $ ":"
@ mCommandInfos[Index].help);
}
Index++;                                                                
}
}
}
event cl_OnInit() {
Super.cl_OnInit();                                                          
mGameMaster = Game_GameMasterController(Outer);                             
}
*/