using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_AQOrmo_Nuke : AIRegistered
    {
        [FoldoutGroup("AIScript_AQOrmo_Nuke")]
        [FieldConst()]
        public NPC_Type OrmoburuNPC;

        [FoldoutGroup("AIScript_AQOrmo_Nuke")]
        [FieldConst()]
        public string MoverEvent = string.Empty;

        [FoldoutGroup("AIScript_AQOrmo_Nuke")]
        [FieldConst()]
        public float OrmoDespawnTime;

        [FoldoutGroup("AIScript_AQOrmo_Nuke")]
        [FieldConst()]
        public float FallRadius;

        public AIScript_AQOrmo_Nuke()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
Super.GetActorRelations(oRelations);                                        
GetTaggedRelations(MoverEvent,static.RGB(100,100,255),"MoverEvent:" @ MoverEvent,oRelations);
}
function bool OnTimerEnded(Game_AIController aGame_AIController,Actor aInstigator,name aTag) {
if (aTag == 'DespawnOrmo') {                                                
Despawn(aGame_AIController);                                              
TriggerEvent(name(MoverEvent),None,None);                                 
}
return Super.OnTimerEnded(aGame_AIController,aInstigator,aTag);             
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
local Game_Pawn oPawn;
local array<Game_AIController> registeredControllers;
registeredControllers = GetRegistered();                                    
Super.Trigger(Other,EventInstigator);                                       
i = 0;                                                                      
while (i < registeredControllers.Length) {                                  
if (registeredControllers[i].Pawn.IsA('Game_NPCPawn')
&& Game_NPCPawn(registeredControllers[i].Pawn).NPCType == OrmoburuNPC) {
StartTimer(registeredControllers[i],'DespawnOrmo',OrmoDespawnTime);     
if (FallRadius > 0) {                                                   
foreach VisibleCollidingActors(Class'Game_Pawn',oPawn,FallRadius,registeredControllers[i].Pawn.Location) {
if (oPawn != registeredControllers[i].Pawn) {                       
oPawn.SetPhysics(2);                                              
oPawn.SetHealth(0.00000000);                                      
}
}
}
break;                                                                  
}
registeredControllers[i].Pawn.SetHealth(0.00000000);                      
i++;                                                                      
}
}
*/