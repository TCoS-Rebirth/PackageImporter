using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Ormoburu_Lured : AI_Script
    {
        [FoldoutGroup("Ormoburu")]
        public string SpawnEvent = string.Empty;

        [FoldoutGroup("Ormoburu")]
        public Range SpawnInterval;

        public Game_AIController OrmoController;

        public float SpawnTimeout;

        public bool MoveOn;

        public AIScript_AQOrmo_Ormoburu_Lured()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(SpawnEvent,static.RGB(100,100,255),"SpawnEvent:" @ SpawnEvent,oRelations);
}
event Trigger(Actor Other,Pawn EventInstigator) {
SetFreeze(Game_Pawn(OrmoController.Pawn),False,True,False,False);           
MoveOn = True;                                                              
}
event bool OnTick(Game_AIController aController,float DeltaTime) {
local Game_PlayerController lController;
if (!MoveOn) {                                                              
SpawnTimeout -= DeltaTime;                                                
if (SpawnTimeout <= 0) {                                                  
foreach AllActors(Class'Game_PlayerController',lController) {           
TriggerEvent(name(SpawnEvent),self,aController.Pawn);                 
}
SpawnTimeout = RandomFloat(SpawnInterval.Min,SpawnInterval.Max);        
}
}
return Super.OnTick(aController,DeltaTime);                                 
}
event bool AnnotationDone(Game_AIController aController) {
return True;                                                                
}
event OnDetach(Game_AIController aController,AIPoint aPoint) {
Super.OnDetach(aController,aPoint);                                         
}
event OnBegin(Game_AIController aController) {
Super.OnBegin(aController);                                                 
MoveOn = False;                                                             
SetFreeze(Game_Pawn(OrmoController.Pawn),True,True,False,False);            
}
*/