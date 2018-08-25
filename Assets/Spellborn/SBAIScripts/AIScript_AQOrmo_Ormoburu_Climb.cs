﻿using System;
using Engine;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Ormoburu_Climb : AI_Script
    {
        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public OrmoAnim ClimbUpAnim;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public OrmoAnim ClimbDownAnim;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Actor StartLocation;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Actor EndLocation;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Actor StartOrientation;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public Actor EndOrientation;

        [FoldoutGroup("Ormoburu")]
        [FieldConst()]
        public FSkill_EffectClass_AudioVisual TransparentEffect;

        public Game_AIController OrmoController;

        public float Timeout;

        public byte ClimbingState;

        public int EffectHandle;

        public AIScript_AQOrmo_Ormoburu_Climb()
        {
        }

        [Serializable] public struct OrmoAnim
        {
            public float Duration;

            public byte variation;

            public byte flag1;

            public byte flag2;

            public byte flag3;
        }

        public enum EOrmoclimbState
        {
            STATE_MOVING_TO_STARTLOCATION,

            STATE_CLIMBINGUP,

            STATE_WAITFORTELEPORT,

            STATE_CLIMBINGDOWN,
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local ActorRelation newRelation;
Super.GetActorRelations(oRelations);                                        
if (StartLocation != None) {                                                
newRelation.mActor = StartLocation;                                       
newRelation.mDescription = "Start";                                       
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
if (EndLocation != None) {                                                  
newRelation.mActor = EndLocation;                                         
newRelation.mDescription = "End";                                         
newRelation.mColour = static.RGB(100,255,100);                            
oRelations[oRelations.Length] = newRelation;                              
}
}
event bool OnArrived(Game_AIController aController,SBPoint aControlPoint,SBPoint aDestinationPoint,Vector aLocation) {
local Vector loc2dCurr;
local Vector loc2dDest;
loc2dCurr = aController.Pawn.Location;                                      
loc2dCurr.Z = 0.00000000;                                                   
loc2dDest = StartLocation.Location;                                         
loc2dDest.Z = 0.00000000;                                                   
if (ClimbingState == 0) {                                                   
if (VSize(loc2dCurr - loc2dDest) > 20.00000000) {                         
return Super.OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
SetControllerLocation(aController,StartLocation.Location);                
LookAt(aController,StartOrientation.Location);                            
StopMovement(aController);                                                
ClimbingState = 1;                                                        
Timeout = ClimbUpAnim.Duration;                                           
PlayControllerAnimation(aController,ClimbUpAnim.variation,ClimbUpAnim.flag1,ClimbUpAnim.flag2,ClimbUpAnim.flag3);
goto jl011F;                                                              
}
return Super.OnArrived(aController,aControlPoint,aDestinationPoint,aLocation);
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
if (ClimbingState != 0) {                                                   
Timeout -= DeltaTime;                                                     
if (Timeout <= 0) {                                                       
switch (ClimbingState) {                                                
case 2 :                                                              
PlayControllerAnimation(aController,ClimbDownAnim.variation,ClimbDownAnim.flag1,ClimbDownAnim.flag2,ClimbDownAnim.flag3);
RemoveAudioVisualEffect(Game_Pawn(aController.Pawn),EffectHandle);  
ClimbingState = 3;                                                  
Timeout = ClimbDownAnim.Duration;                                   
break;                                                              
case 1 :                                                              
SetControllerLocation(aController,EndLocation.Location);            
LookAt(aController,EndOrientation.Location);                        
EffectHandle = ApplyAudioVisualEffect(Game_Pawn(aController.Pawn),TransparentEffect);
ClimbingState = 2;                                                  
Timeout = 1.00000000;                                               
break;                                                              
case 3 :                                                              
ContinueAI(aController);                                            
ChangeToNextScript(aController);                                    
TriggerEvent(Event,self,aController.Pawn);                          
break;                                                              
default:                                                              
}
}
goto jl0150;                                                              
}
return Super.OnTick(aController,DeltaTime);                                 
}
event OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
ClimbingState = 0;                                                          
PauseAI(aController);                                                       
OrmoController = aController;                                               
MoveTo(aController,StartLocation.Location);                                 
}
*/