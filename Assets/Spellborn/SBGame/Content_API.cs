using System;
using Engine;

namespace SBGame
{
    [Serializable] public class Content_API : UObject
    {
        public Content_API()
        {
        }

        public enum EContentEmote
        {
            ECE_None = 0,

            ECE_wave = 1,

            ECE_salute = 2,

            ECE_great = 3,

            ECE_lol = 4,

            ECE_huh = 5,

            ECE_dance = 6,

            ECE_enemies = 7,

            ECE_getready = 8,

            ECE_charge = 9,

            ECE_attack = 10,

            ECE_retreat = 11,

            ECE_follow = 12,

            ECE_wait = 13,

            ECE_comeon = 14,

            ECE_assistance = 15,

            ECE_overhere = 16,

            ECE_backoff = 17,

            ECE_north = 18,

            ECE_east = 19,

            ECE_west = 20,

            ECE_south = 21,

            ECE_flank = 22,

            ECE_goround = 23,

            ECE_no = 24,

            ECE_yes = 25,

            ECE_greet = 26,

            ECE_bye = 27,

            ECE_thanks = 28,

            ECE_pony = 29,

            ECE_pwnie = 30,

            ECE_trade = 31,

            ECE_excuse = 32,

            ECE_waitup = 33,

            ECE_veto = 34,

            ECE_sarcasm = 35,

            ECE_hey = 36,

            ECE_oldskool = 37,

            ECE_outfit = 38,

            ECE_fashionpolice = 39,

            ECE_jazz = 40,

            ECE_clap = 41,

            ECE_kiss = 42,

            ECE_sigh = 43,

            ECE_bored = 44,

            ECE_pain = 45,

            ECE_pst = 46,

            ECE_angry = 47,

            ECE_cry = 48,

            ECE_maniacal = 49,

            ECE_laugh = 50,

            ECE_cough = 51,

            ECE_cheer = 52,

            ECE_whistlehappy = 53,

            ECE_whistleattention = 54,

            ECE_whistlemusic = 55,

            ECE_whistlenote = 56,

            ECE_ahh = 57,

            ECE_gasp = 58,

            ECE_stretch = 59,

            ECE_huf = 60,

            ECE_bah = 61,

            ECE_oracle = 62,

            ECE_battle = 63,

            ECE_praise = 64,

            ECE_mock = 65,

            ECE_attention = 66,

            ECE_death = 67,

            ECE_stop = 68,

            ECE_admireroom = 69,

            ECE_victory = 70,

            ECE_survive = 71,

            ECE_again = 72,

            ECE_try = 73,

            ECE_letsgo = 74,

            ECE_rtfm = 75,

            ECE_unique = 76,
        }

        public enum EContentOperator
        {
            ECO_Equals = 0,

            ECO_NotEquals = 1,

            ECO_Less = 2,

            ECO_More = 3,

            ECO_EqualOrLess = 4,

            ECO_EqualOrMore = 5,

            ECO_Mask = 6,

            ECO_NotMask = 7,
        }

        public enum NPCBodytype
        {
            ENB_Skinny = 0,

            ENB_Athletic = 1,

            ENB_Fat = 2,

            ENB_Hulky = 3,

            ENB_Child = 4,

            ENB_Monstrous = 5,
        }

        public enum NPCRace
        {
            ENR_Human = 0,

            ENR_Daevi = 1,

            ENR_Monster = 2,

            ENR_Arionite = 3,

            ENR_SpeyrFolk = 4,

            ENR_DemonArmy = 5,

            ENR_BotG = 6,

            ENR_ForgeOfWisdom = 7,

            ENR_Ousted = 8,

            ENR_Urvhail = 9,

            ENR_Vhuul = 10,

            ENR_Urgarut = 11,

            ENR_Shunned = 12,
        }

        public enum NPCGender
        {
            ENG_Male = 0,

            ENG_Female = 1,

            ENG_Neuter = 2,

            ENG_Hermaphrodite = 3,
        }

        public enum ENPCClassType
        {
            CT_HeavyMelee = 0,

            CT_HeavyRanged = 1,

            CT_ModerateMelee = 2,

            CT_ModerateRanged = 3,

            CT_LightMelee = 4,

            CT_LightRanged = 5,

            CT_DOT = 6,

            CT_Healer = 7,

            CT_Slower = 8,

            CT_Buffer = 9,

            CT_Alerter = 10,

            CT_Supporter = 11,

            CT_Rezzer = 12,

            CT_Debuffer = 13,

            CT_Blinder = 14,
        }

        public enum EContentClass
        {
            ECC_NoClass = 0,

            ECC_Rogue = 1,

            ECC_Warrior = 2,

            ECC_Spellcaster = 3,

            ECC_Trickster = 4,

            ECC_SkinShifter = 5,

            ECC_DeathHand = 6,

            ECC_Bloodwarrior = 7,

            ECC_FuryHammer = 8,

            ECC_WrathGuard = 9,

            ECC_RuneMage = 10,

            ECC_VoidSeer = 11,

            ECC_AncestralMage = 12,

            ECC_Gadgeteer = 13,

            ECC_Entertainer = 14,

            ECC_Assassin = 15,

            ECC_ShapeChanger = 16,

            ECC_Consumer = 17,

            ECC_Alchemist = 18,

            ECC_Bodyguard = 19,

            ECC_Flagellant = 20,

            ECC_Visionary = 21,

            ECC_MartialArtist = 22,

            ECC_PossessedOne = 23,

            ECC_FrontMan = 24,

            ECC_Nuker = 25,

            ECC_RuneMaster = 26,

            ECC_Priest = 27,

            ECC_AntiMage = 28,

            ECC_Summoner = 29,

            ECC_Infuser = 30,

            ECC_AnyClass = 31,
        }
    }
}
/*
final native function int GetPersistentVariable(Game_Pawn aPawn,int aId);
function SetPersistentVariable(Game_Pawn aPawn,int aId,int aValue) {
local Game_Controller cont;
cont = Game_Controller(aPawn.Controller);                                   
if (cont != None) {                                                         
cont.sv_SetPersistentVariable(0,aId,aValue);                              
}
}
final native function bool LearnSkill(Game_Pawn aPawn,export editinline FSkill_Type aSkill);
final native function bool CanLearnSkill(Game_Pawn aPawn,export editinline FSkill_Type aSkill);
function bool RemoveMoney(Game_Pawn aPawn,int aAmount) {
local SBDBAsyncCallback callback;
local export editinline Game_PlayerItemManager itemManager;
if (aPawn.itemManager != None && aAmount >= 0) {                            
itemManager = Game_PlayerItemManager(aPawn.itemManager);                  
if (itemManager != None
&& itemManager.sv_UpdateMoney(-aAmount,callback)) {
ApiTrace("Attempted to remove" @ string(aAmount)
@ "money from"
@ GetCharacterName(aPawn));
return True;                                                            
}
}
ApiTrace("Couldn't remove" @ string(aAmount)
@ "money from"
@ GetCharacterName(aPawn));
return False;                                                               
}
final native function bool GiveMoney(Game_Pawn aPawn,int aAmount);
final native function int GetMoney(Game_Pawn aPawn);
function bool RemoveItems(Game_Pawn aPawn,Content_Inventory aItems,optional SBDBAsyncCallback callback) {
if (aPawn.itemManager != None && aItems != None
&& !aItems.Empty()) { 
return aItems.RemoveFromInventory(aPawn,callback);                        
} else {                                                                    
ApiTrace("Couldn't remove" @ aItems.Description()
@ "from"
@ GetCharacterName(aPawn));
return False;                                                             
}
}
final native function bool GiveItems(Game_Pawn aPawn,Content_Inventory aItems);
event bool CanReceiveItems(Game_Pawn aPawn,Content_Inventory aItems) {
local int inv;
local int Count;
if (aPawn.itemManager == None) {                                            
ApiTrace(GetCharacterName(aPawn) @ "has no ItemManager");                 
return False;                                                             
}
Count = aItems.SlotCount();                                                 
inv = aPawn.itemManager.GetFreeSlots(1);                                    
if (Count > inv) {                                                          
ApiTrace(GetCharacterName(aPawn) @ "has only"
@ string(inv)
@ "inventory slots available for"
@ string(Count)
@ "items");
return False;                                                             
}
ApiTrace(GetCharacterName(aPawn) @ "has an"
@ string(inv)
@ "inventory slots available for"
@ string(Count)
@ "items");
return True;                                                                
}
final native function int CountItems(Game_Pawn aPawn,export editinline Item_Type aItem);
function bool HasItems(Game_Pawn aPawn,Content_Inventory aItems) {
if (aPawn.itemManager != None && !aItems.Empty()) {                         
if (aItems.HasItemsInInventory(aPawn)) {                                  
return True;                                                            
}
}
ApiTrace(GetCharacterName(aPawn) @ "doesn't have"
@ aItems.Description());
return False;                                                               
}
final native function bool HasTargetActive(Game_Pawn aPawn,export editinline Quest_Target aTarget);
function bool HasFailedTarget(Game_Pawn aPawn,export editinline Quest_Target aTarget) {
local Game_PlayerPawn playerPawn;
playerPawn = Game_PlayerPawn(aPawn);                                        
if (playerPawn != None && aTarget != None) {                                
if (aTarget.Failed(playerPawn.questLog.GetTargetProgress(aTarget.GetQuest(),aTarget.GetIndex()))) {
ApiTrace(GetCharacterName(aPawn) @ "has failed target"
@ string(aTarget));
return True;                                                            
}
}
ApiTrace(GetCharacterName(aPawn) @ "hasn't failed target"
@ string(aTarget));
return False;                                                               
}
function bool HasCompletedTarget(Game_Pawn aPawn,export editinline Quest_Target aTarget) {
local Game_PlayerPawn playerPawn;
playerPawn = Game_PlayerPawn(aPawn);                                        
if (playerPawn != None && aTarget != None) {                                
if (aTarget.Check(playerPawn.questLog.GetTargetProgress(aTarget.GetQuest(),aTarget.GetIndex()))) {
ApiTrace(GetCharacterName(aPawn) @ "has completed target"
@ string(aTarget));
return True;                                                            
}
}
ApiTrace(GetCharacterName(aPawn) @ "hasn't completed target"
@ string(aTarget));
return False;                                                               
}
final native function int TimesQuestFinished(Game_Pawn aPawn,export editinline Quest_Type aQuest);
final native function bool FinishQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest);
final native function bool HasFailedQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest);
final native function bool HasCompletedQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest,optional bool aNearly);
final native function bool HasQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest);
function bool ObtainQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest) {
local Game_PlayerPawn playerPawn;
playerPawn = Game_PlayerPawn(aPawn);                                        
if (playerPawn != None && aQuest != None
&& playerPawn.questLog != None) {
if (playerPawn.questLog.sv_AcceptQuest(aQuest)) {                         
ApiTrace(GetCharacterName(aPawn) @ "got quest"
@ string(aQuest));
return True;                                                            
} else {                                                                  
ApiTrace(GetCharacterName(aPawn) @ "couldn't accept quest"
@ string(aQuest));
return False;                                                           
}
} else {                                                                    
ApiTrace(GetCharacterName(aPawn) @ "didn't get quest"
@ string(aQuest));
return False;                                                             
}
}
final native function bool MeetsRequirementsQuest(Game_Pawn aPawn,export editinline Quest_Type aQuest);
final native function int GetPeP(Game_Pawn aPawn);
final native function int GetLevel(Game_Pawn aPawn);
function Game_NPCPawn FindNPC(Game_Pawn aFrom,export editinline NPC_Type aType,float aRadius) {
local Game_Pawn foundPawn;
local Game_NPCPawn foundNPC;
foreach aFrom.RadiusActors(Class'Game_Pawn',foundPawn,aRadius) {            
foundNPC = Game_NPCPawn(foundPawn);                                       
if (foundNPC != None && foundNPC.NPCType == aType) {                      
ApiTrace("Found NPC" @ string(aType) @ string(foundNPC)
@ "within"
@ string(aRadius)
@ "of"
@ GetCharacterName(aFrom));
return foundNPC;                                                        
}
}
ApiTrace("Didn't find NPC" @ string(aType)
@ "within"
@ string(aRadius)
@ "of"
@ GetCharacterName(aFrom));
return None;                                                                
}
function bool ClaustroportPawn(Game_Pawn aPawn,Vector Location,Rotator Rotation) {
local Game_PlayerController PlayerController;
PlayerController = Game_PlayerController(aPawn.Controller);                 
if (aPawn.sv_TeleportTo(Location,Rotation)) {                               
ApiTrace("Teleporting" @ GetCharacterName(aPawn)
@ "to location"
@ string(Location));
} else {                                                                    
ApiTrace("Failed to teleport" @ GetCharacterName(aPawn)
@ "to location"
@ string(Location));
}
return True;                                                                
}
function bool TeleportPawn(Game_Pawn aPawn,int aWorld,bool Instance,string aStart) {
local Game_PlayerController PlayerController;
local Game_GameServer Engine;
PlayerController = Game_PlayerController(aPawn.Controller);                 
Engine = Game_GameServer(Class'Actor'.static.GetGameEngine());              
if (PlayerController != None) {                                             
ApiTrace("Teleporting" @ GetCharacterName(aPawn)
@ "to world"
@ string(aWorld)
@ "at"
@ aStart);
Engine.LoginToWorldByID(aWorld,PlayerController.CharacterID,aStart,"");   
return True;                                                              
} else {                                                                    
ApiTrace("Not teleporting non-player controlled"
@ GetCharacterName(aPawn));
return False;                                                             
}
}
function FindRadiusActors(class<Actor> aClass,Actor aOrigin,float aRange,name aTag,out array<Actor> oActors) {
local Actor someActor;
ApiTrace("Finding actors of type" @ string(aClass)
@ "with tag '"
$ string(aTag)
$ "' within"
@ string(aRange)
$ "uu of "
@ string(aOrigin));
foreach aOrigin.RadiusActors(aClass,someActor,aRange) {                     
if (string(aTag) == "None" || someActor.Tag == aTag) {                    
oActors[oActors.Length] = someActor;                                    
}
}
}
function Actor FindClosestActor(class<Actor> aClass,Actor aOrigin,name aTag) {
local float closestDistance;
local Actor closestActor;
local float Distance;
local Actor someActor;
ApiTrace("Finding the of type" @ string(aClass)
@ "and tag '"
$ string(aTag)
$ "' closest to"
@ string(aOrigin));
foreach aOrigin.AllActors(aClass,someActor) {                               
if (string(aTag) == "None" || someActor.Tag == aTag) {                    
Distance = VSize(aOrigin.Location - someActor.Location);                
if (closestActor == None || Distance < closestDistance) {               
closestDistance = Distance;                                           
closestActor = someActor;                                             
}
}
}
return closestActor;                                                        
}
static native function Vector RandomRadiusLocation(Actor aOrigin,float aRadius,float aHeight,bool aLoSSpawning,Vector aExtent,bool aOnGround);
static native function Vector NearestValidLocation(Actor RefActor,Vector aLocation,Vector aExtent,bool aOnGround);
static native function bool ValidLocation(Actor RefActor,Vector aLocation,Vector aExtent);
static native function Vector ProjectLocationOnGround(Actor aActor,Vector aOrigin,optional Vector aExtent);
final native function int GetWorld(Game_Pawn aPawn);
final native function bool Compare(int aValue,byte aOp,int aTarget);
function string OperatorToString(byte aOp) {
switch (aOp) {                                                              
case 0 :                                                                  
return "==";                                                            
case 1 :                                                                  
return "!=";                                                            
case 2 :                                                                  
return "<";                                                             
case 3 :                                                                  
return ">";                                                             
case 4 :                                                                  
return "<=";                                                            
case 5 :                                                                  
return ">=";                                                            
case 6 :                                                                  
return "&";                                                             
case 7 :                                                                  
return "!&";                                                            
default:                                                                  
return "INVALID";                                                       
}
}
}
function string GetTimeText(int aSeconds) {
local string ret;
if (Abs(aSeconds) > 60) {                                                   
ret = string(aSeconds / 60)
@ Class'StringReferences'.default.minStr.Text;
} else {                                                                    
ret = string(aSeconds)
@ Class'StringReferences'.default.sec.Text;
}
return ret;                                                                 
}
function string GetMoneyText(int aMoney) {
local int coins0;
local int coins1;
local int coins2;
local string ret;
coins0 = aMoney % 100;                                                      
coins1 = aMoney / 100 % 100;                                                
coins2 = aMoney / 10000;                                                    
if (aMoney > 0) {                                                           
if (coins0 > 1) {                                                         
ret = string(coins0) @ GetCoinName(0,True)
@ ret;             
} else {                                                                  
if (coins0 == 1) {                                                      
ret = string(coins0) @ GetCoinName(0,False)
@ ret;        
}
}
if (coins1 > 1) {                                                         
ret = string(coins1) @ GetCoinName(1,True)
@ ret;             
} else {                                                                  
if (coins1 == 1) {                                                      
ret = string(coins1) @ GetCoinName(1,False)
@ ret;        
}
}
if (coins2 > 1) {                                                         
ret = string(coins2) @ GetCoinName(2,True)
@ ret;             
} else {                                                                  
if (coins2 == 1) {                                                      
ret = string(coins2) @ GetCoinName(2,False)
@ ret;        
}
}
} else {                                                                    
ret = "0" @ GetCoinName(0,True);                                          
}
return ret;                                                                 
}
native function string GetCoinName(int aLevel,bool aPlural);
function string ParseText(string aActiveText,Object aSpeaker,Object aSubject,Object aTarget) {
local Game_Controller PlayerController;
PlayerController = GetPlayer();                                             
if (PlayerController.SBRole == 4) {                                         
return Game_PlayerController(PlayerController).TextParser.Parse(aActiveText,aSpeaker,aSubject,aTarget,0);
} else {                                                                    
return aActiveText;                                                       
}
}
native function Game_Controller GetPlayer();
event string GetActiveText(Game_ActiveTextItem aItem) {
return "???";                                                               
}
final native function string GetCharacterName(Game_Pawn aPawn);
function ApiTrace(string aText) {
if (ApiTracing()) {                                                         
}
}
function bool ApiTracing() {
return False;                                                               
}
*/