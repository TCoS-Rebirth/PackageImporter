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
            ECE_None,

            ECE_wave,

            ECE_salute,

            ECE_great,

            ECE_lol,

            ECE_huh,

            ECE_dance,

            ECE_enemies,

            ECE_getready,

            ECE_charge,

            ECE_attack,

            ECE_retreat,

            ECE_follow,

            ECE_wait,

            ECE_comeon,

            ECE_assistance,

            ECE_overhere,

            ECE_backoff,

            ECE_north,

            ECE_east,

            ECE_west,

            ECE_south,

            ECE_flank,

            ECE_goround,

            ECE_no,

            ECE_yes,

            ECE_greet,

            ECE_bye,

            ECE_thanks,

            ECE_pony,

            ECE_pwnie,

            ECE_trade,

            ECE_excuse,

            ECE_waitup,

            ECE_veto,

            ECE_sarcasm,

            ECE_hey,

            ECE_oldskool,

            ECE_outfit,

            ECE_fashionpolice,

            ECE_jazz,

            ECE_clap,

            ECE_kiss,

            ECE_sigh,

            ECE_bored,

            ECE_pain,

            ECE_pst,

            ECE_angry,

            ECE_cry,

            ECE_maniacal,

            ECE_laugh,

            ECE_cough,

            ECE_cheer,

            ECE_whistlehappy,

            ECE_whistleattention,

            ECE_whistlemusic,

            ECE_whistlenote,

            ECE_ahh,

            ECE_gasp,

            ECE_stretch,

            ECE_huf,

            ECE_bah,

            ECE_oracle,

            ECE_battle,

            ECE_praise,

            ECE_mock,

            ECE_attention,

            ECE_death,

            ECE_stop,

            ECE_admireroom,

            ECE_victory,

            ECE_survive,

            ECE_again,

            ECE_try,

            ECE_letsgo,

            ECE_rtfm,

            ECE_unique,
        }

        public enum EContentOperator
        {
            ECO_Equals,

            ECO_NotEquals,

            ECO_Less,

            ECO_More,

            ECO_EqualOrLess,

            ECO_EqualOrMore,

            ECO_Mask,

            ECO_NotMask,
        }

        public enum NPCBodytype
        {
            ENB_Skinny,

            ENB_Athletic,

            ENB_Fat,

            ENB_Hulky,

            ENB_Child,

            ENB_Monstrous,
        }

        public enum NPCRace
        {
            ENR_Human,

            ENR_Daevi,

            ENR_Monster,

            ENR_Arionite,

            ENR_SpeyrFolk,

            ENR_DemonArmy,

            ENR_BotG,

            ENR_ForgeOfWisdom,

            ENR_Ousted,

            ENR_Urvhail,

            ENR_Vhuul,

            ENR_Urgarut,

            ENR_Shunned,
        }

        public enum NPCGender
        {
            ENG_Male,

            ENG_Female,

            ENG_Neuter,

            ENG_Hermaphrodite,
        }

        public enum ENPCClassType
        {
            CT_HeavyMelee,

            CT_HeavyRanged,

            CT_ModerateMelee,

            CT_ModerateRanged,

            CT_LightMelee,

            CT_LightRanged,

            CT_DOT,

            CT_Healer,

            CT_Slower,

            CT_Buffer,

            CT_Alerter,

            CT_Supporter,

            CT_Rezzer,

            CT_Debuffer,

            CT_Blinder,
        }

        public enum EContentClass
        {
            ECC_NoClass,

            ECC_Rogue,

            ECC_Warrior,

            ECC_Spellcaster,

            ECC_Trickster,

            ECC_SkinShifter,

            ECC_DeathHand,

            ECC_Bloodwarrior,

            ECC_FuryHammer,

            ECC_WrathGuard,

            ECC_RuneMage,

            ECC_VoidSeer,

            ECC_AncestralMage,

            ECC_Gadgeteer,

            ECC_Entertainer,

            ECC_Assassin,

            ECC_ShapeChanger,

            ECC_Consumer,

            ECC_Alchemist,

            ECC_Bodyguard,

            ECC_Flagellant,

            ECC_Visionary,

            ECC_MartialArtist,

            ECC_PossessedOne,

            ECC_FrontMan,

            ECC_Nuker,

            ECC_RuneMaster,

            ECC_Priest,

            ECC_AntiMage,

            ECC_Summoner,

            ECC_Infuser,

            ECC_AnyClass,
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