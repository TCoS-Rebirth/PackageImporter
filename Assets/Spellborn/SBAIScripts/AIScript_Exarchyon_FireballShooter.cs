using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_Exarchyon_FireballShooter : AI_Script
    {
        [FoldoutGroup("FireballShooter")]
        public FSkill_Type FireballSkill;

        [FoldoutGroup("FireballShooter")]
        public float DefaultReloadtime;

        [FoldoutGroup("FireballShooter")]
        public float ShotDuration;

        [FoldoutGroup("FireballShooter")]
        public bool StartActive;

        [FoldoutGroup("FireballShooter")]
        public List<FireballTarget> Targets = new List<FireballTarget>();

        public byte FireballShooterState;

        public float FireballTimeOut;

        public bool Triggered;

        public int CurrentTarget;

        public AIScript_Exarchyon_FireballShooter()
        {
        }

        [Serializable] public struct FireballTarget
        {
            public Actor Target;

            public string TrailEmitterTag;

            public float ReloadTime;
        }

        public enum EFireballShooterState
        {
            STATE_RELOADING,

            STATE_SHOOTING,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
local int i;
i = 0;                                                                      
while (i < Targets.Length) {                                                
GetTaggedRelations(Targets[i].TrailEmitterTag,static.RGB(100,100,255),"trail " @ string(i),oRelations);
if (Targets[i].Target != None) {                                          
newRelation.mActor = Targets[i].Target;                                 
newRelation.mDescription = "Target" @ string(i);                        
newRelation.mColour = static.RGB(100,255,100);                          
oRelations[oRelations.Length] = newRelation;                            
}
i++;                                                                      
}
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
Triggered = False;                                                          
FireballTimeOut = 0.00000000;                                               
FireballShooterState = 0;                                                   
}
event Trigger(Actor Other,Pawn EventInstigator) {
Triggered = True;                                                           
FireballTimeOut = 0.00000000;                                               
FireballShooterState = 0;                                                   
}
function DoExplosion(Game_AIController aController) {
PerformSkill(aController,FireballSkill,Targets[CurrentTarget].Target.Location);
FireballShooterState = 0;                                                   
if (Targets[CurrentTarget].ReloadTime > 0) {                                
FireballTimeOut = Targets[CurrentTarget].ReloadTime;                      
} else {                                                                    
FireballTimeOut = DefaultReloadtime;                                      
}
}
function Fire(Game_AIController aController) {
CurrentTarget++;                                                            
if (CurrentTarget == Targets.Length) {                                      
CurrentTarget = 0;                                                        
}
FireballTimeOut = ShotDuration;                                             
AllPlayerClientTrigger(Game_Pawn(aController.Pawn),Targets[CurrentTarget].TrailEmitterTag);
FireballShooterState = 1;                                                   
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (Triggered) {                                                            
FireballTimeOut -= DeltaTime;                                             
if (FireballTimeOut <= 0) {                                               
switch (FireballShooterState) {                                         
case 0 :                                                              
Fire(aController);                                                  
break;                                                              
case 1 :                                                              
DoExplosion(aController);                                           
break;                                                              
default:                                                              
}
}
}
return Super.OnTick(aController,DeltaTime);                                 
}
function OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
PauseAI(aController);                                                       
DrawWeapon(aController);                                                    
Triggered = StartActive;                                                    
}
*/