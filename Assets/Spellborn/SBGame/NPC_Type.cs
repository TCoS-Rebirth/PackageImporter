using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class NPC_Type : Content_Type
    {
        [FoldoutGroup("Basics")]
        [FieldConst()]
        public bool ShowNameAboveHeads;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public LocalizedString LongName;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public LocalizedString ShortName;

        //Custom addition
        public LocalizedString Name;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public string Note = string.Empty;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public byte Category;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public float CorpseTimeout;

        [FoldoutGroup("Combat")]
        [FieldConst()]
        public bool Invulnerable;

        [FoldoutGroup("Sheet")]
        [FieldConst()]
        public int FameLevel;

        [FoldoutGroup("Sheet")]
        [FieldConst()]
        public int PePRank;

        [FoldoutGroup("Sheet")]
        [FieldConst()]
        public float CreditMultiplier;

        [FoldoutGroup("Combat")]
        public byte NPCClassClassification;

        [FoldoutGroup("Combat")]
        public NPC_SkillDeck SkillDeck;

        [FoldoutGroup("Combat")]
        public NPC_AttackSheet AttackSheet;

        [FoldoutGroup("Sheet")]
        public NPC_StatTable Stats;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public byte Movement;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float AccelRate = 500;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float JumpSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float GroundSpeed = 320;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float CombatSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float StrollSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float WaterSpeed = 200;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float AirSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float AirControl = 0.05f;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float AirMinSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float ClimbSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float TurnSpeed;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public float TerminalVelocity;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool CanStrafe;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool CanRest;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool CanWalkBackwards;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bAlignToFloor;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool bAlignToFloorRoll;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool bAlignToFloorPitch;

        [FoldoutGroup("Movement")]
        [FieldConst()]
        public bool bForceAttachmentUpdates;

        [FoldoutGroup("Spawning")]
        [FieldConst()]
        [TypeProxyDefinition(TypeName = "Game_NPCPawn")]
        public Type PawnType;

        [FoldoutGroup("Spawning")]
        [FieldConst()]
        public int BossPriority;

        [FoldoutGroup("Appearance")]
        [FieldConst()]
        public NPC_Appearance Appearance;

        [FoldoutGroup("Appearance")]
        [FieldConst()]
        public NPC_Effects Effects;

        [FoldoutGroup("Items")]
        [FieldConst()]
        public NPC_Equipment Equipment;

        [FoldoutGroup("Items")]
        [FieldConst()]
        public Content_Inventory Inventory;

        [FoldoutGroup("Items")]
        [FieldConst()]
        public List<LootTable> Loot = new List<LootTable>();

        [FoldoutGroup("Items")]
        [FieldConst()]
        public bool IndividualKillCredit;

        [FoldoutGroup("Conversations")]
        [FieldConst()]
        public List<Conversation_Topic> Topics = new List<Conversation_Topic>();

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Conversation_Topic> QuestTopics = new List<Conversation_Topic>();

        public bool TriggersKilledHook;

        [FoldoutGroup("Faction")]
        public NPC_Taxonomy TaxonomyFaction;

        [FoldoutGroup("Services")]
        [FieldConst()]
        public bool Travel;

        [FoldoutGroup("Services")]
        [FieldConst()]
        public bool Arena;

        [FoldoutGroup("Services")]
        [FieldConst()]
        public Shop_Base Shop;

        public NPC_Type()
        {
        }

        public enum ENPC_Category
        {
            ENPC_Human,

            ENPC_Wildlife,

            ENPC_Boss,
        }
    }
}
/*
final native function cl_CreateQuestsTopics(Game_NPCPawn aPawn);
event InitializeStats(int aFameLevel,int aPePRank,out int oMaxHp,out int oLevelHp,out int oBody,out int oMind,out int oFocus,out float oRuneResistance,out float oSpiritResistance,out float oSoulResistance) {
if (Stats != None) {                                                        
oMaxHp = Stats.GetBaseHitpoints(aFameLevel);                              
oLevelHp = Stats.GetHitpointsPerLevel(aFameLevel);                        
oBody = Stats.GetBody(aFameLevel);                                        
oMind = Stats.GetMind(aFameLevel);                                        
oFocus = Stats.GetFocus(aFameLevel);                                      
} else {                                                                    
oMaxHp = 100;                                                             
oLevelHp = 10;                                                            
oBody = 7 + aFameLevel / 9;                                               
oMind = 7 + aFameLevel / 9;                                               
oFocus = 7 + aFameLevel / 9;                                              
}
}
function NPC_Taxonomy GetFaction() {
return TaxonomyFaction;                                                     
}
native function int GetClassRank();
native function float CalcRequestedClassMatch(array<byte> ForbiddenClassTypes);
native function bool CalcForbiddenClassMatch(array<byte> ForbiddenClassTypes);
event string GetActiveText(Game_ActiveTextItem aItem) {
if (aItem == None || aItem.Tag == "N") {                                    
return GetShortName();                                                    
} else {                                                                    
if (aItem.Tag == "F") {                                                   
return GetLongName();                                                   
} else {                                                                  
return Super.GetActiveText(aItem);                                      
}
}
}
native function float GetCollisionRadius();
native function float GetCollisionHeight();
function string GetLongName() {
if (Len(LongName.Text) > 0) {                                               
return LongName.Text;                                                     
}
return GetShortName();                                                      
}
function string GetShortName() {
if (Len(ShortName.Text) > 0) {                                              
return ShortName.Text;                                                    
} else {                                                                    
return "NPC";                                                             
}
}
event cl_OnInit(Game_NPCPawn aPawn) {
aPawn.Appearance.InstallBaseAppearance(self);                               
if (Effects != None) {                                                      
Effects.Apply(aPawn);                                                     
}
InitMovement(aPawn);                                                        
}
event sv_OnInit(Game_NPCPawn aPawn) {
aPawn.Appearance.InstallBaseAppearance(self);                               
aPawn.bInvulnerable = Invulnerable;                                         
InitMovement(aPawn);                                                        
if (SkillDeck != None) {                                                    
Game_NPCSkills(aPawn.Skills).sv_SetSkilldeck(SkillDeck,Equipment);        
}
if (Inventory != None) {                                                    
GiveItems(aPawn,Inventory);                                               
}
}
event InitMovement(Game_Pawn aPawn) {
aPawn.SetPhysics(Movement);                                                 
aPawn.GroundSpeed = GroundSpeed;                                            
aPawn.bCanWalk = GroundSpeed > 0.00000000;                                  
aPawn.AirSpeed = AirSpeed;                                                  
aPawn.bCanFly = AirSpeed > 0.00000000;                                      
aPawn.MinFlySpeed = AirMinSpeed;                                            
aPawn.AirControl = AirControl;                                              
aPawn.bCanStrafe = CanStrafe;                                               
aPawn.bCanRest = CanRest;                                                   
aPawn.bCanWalkBackwards = CanWalkBackwards;                                 
if (aPawn.bCanFly) {                                                        
aPawn.CharacterStats.mBaseMovementSpeed = AirSpeed;                       
} else {                                                                    
aPawn.CharacterStats.mBaseMovementSpeed = GroundSpeed;                    
}
if (CombatSpeed >= 0.00000000) {                                            
aPawn.CharacterStats.mMovementSpeedMultiplier[1] = CombatSpeed / GroundSpeed;
}
if (GroundSpeed >= 1.00000000) {                                            
aPawn.WalkingPct = StrollSpeed / GroundSpeed;                             
}
aPawn.WaterSpeed = WaterSpeed;                                              
aPawn.bCanSwim = WaterSpeed > 0.00000000;                                   
aPawn.JumpZ = JumpSpeed;                                                    
aPawn.bCanJump = JumpSpeed > 0.00000000;                                    
aPawn.LadderSpeed = ClimbSpeed;                                             
aPawn.bCanClimbLadders = ClimbSpeed > 0.00000000;                           
aPawn.AccelRate = AccelRate;                                                
aPawn.RotationRate.Yaw = TurnSpeed;                                         
aPawn.RotationRate.Pitch = TurnSpeed;                                       
aPawn.RotationRate.Roll = TurnSpeed;                                        
aPawn.bAlignToFloor = bAlignToFloor;                                        
aPawn.bAlignToFloorRoll = bAlignToFloorRoll;                                
aPawn.bAlignToFloorPitch = bAlignToFloorPitch;                              
aPawn.bForceSkelUpdate = bForceAttachmentUpdates;                           
aPawn.SetCollisionSize(GetCollisionRadius(),GetCollisionHeight());          
aPawn.mMaxDamageFallSpeed = TerminalVelocity;                               
aPawn.mMinDamageFallSpeed = TerminalVelocity * 0.75000000;                  
if (Movement == 4) {                                                        
aPawn.bCanFly = True;                                                     
}
}
native function sv_OnSpawn(Game_NPCPawn aPawn);
*/