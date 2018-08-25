﻿using System;
using System.Collections.Generic;
using Engine;
using SBAI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_6_Neighbours : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_6_Neighbours")]
        [FieldConst()]
        public List<string> NeighbourTags = new List<string>();

        [FoldoutGroup("AIScript_TotA_6_Neighbours")]
        [FieldConst()]
        public string SpawnerTag = string.Empty;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool IsActivated;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool HasSpawned;

        public AIScript_TotA_6_Neighbours()
        {
        }
    }
}
/*
protected event GetActorRelations(out array<ActorRelation> oRelations) {
local int i;
Super.GetActorRelations(oRelations);                                        
i = 0;                                                                      
while (i < NeighbourTags.Length) {                                          
GetTaggedRelations(NeighbourTags[i],static.RGB(200,100,255),"Neighbour (" $ string(i) $ ")",oRelations);
i++;                                                                      
}
GetTaggedRelations(SpawnerTag,static.RGB(100,100,255),"Spawn",oRelations);  
}
event UnTrigger(Actor Other,Pawn EventInstigator) {
if (IsActivated) {                                                          
IsActivated = False;                                                      
HasSpawned = False;                                                       
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local int i;
if (!IsActivated) {                                                         
if (Other.IsA('AIScript_TotA_6_Neighbours')
&& !HasSpawned) {     
Debug("Spawn:" @ SpawnerTag);                                           
TriggerEvent(name(SpawnerTag),self,EventInstigator);                    
HasSpawned = True;                                                      
} else {                                                                  
if (Other.IsA('NPC_Spawner')) {                                         
Debug("Activat Neighbours");                                          
i = 0;                                                                
while (i < NeighbourTags.Length) {                                    
if (NeighbourTags[i] != "" && NeighbourTags[i] != "None") {         
TriggerEvent(name(NeighbourTags[i]),self,EventInstigator);        
}
i++;                                                                
}
IsActivated = True;                                                   
} else {                                                                
if (Other.IsA('AIScript_TotA_6_Sequence')) {                          
IsActivated = True;                                                 
}
}
}
}
}
*/