using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class NPC_Spawner : NPC_Habitat
    {
        [FoldoutGroup("Type")]
        [FieldConst()]
        [TypeProxyDefinition(TypeName = "Game_NPCController")]
        public Type controllerType;

        [FoldoutGroup("Policy")]
        [FieldConst()]
        public bool TriggeredSpawn;

        [FoldoutGroup("Policy")]
        [FieldConst()]
        public bool TriggeredRespawn;

        [FoldoutGroup("Policy")]
        [FieldConst()]
        public bool TriggeredDespawn;

        [FoldoutGroup("Policy")]
        [FieldConst()]
        public NameProperty EventOnWiped;

        [FoldoutGroup("Policy")]
        [FieldConst()]
        public NameProperty EventOnSpawn;

        [FoldoutGroup("aI")]
        public List<NPC_AI> Scripts = new List<NPC_AI>();

        [FoldoutGroup("aI")]
        public float ChaseRange;

        [FoldoutGroup("aI")]
        public float VisualRange;

        [FoldoutGroup("aI")]
        public float LineOfSightRange;

        [FoldoutGroup("aI")]
        public float ThreatRange;

        [FoldoutGroup("aI")]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool ShowAIRanges;

        [FoldoutGroup("Hormones")]
        public float AggressionFactor;

        [FoldoutGroup("Hormones")]
        public float FearFactor;

        [FoldoutGroup("Hormones")]
        public float SocialFactor;

        [FoldoutGroup("Hormones")]
        public float BoredomFactor;

        public List<Game_NPCController> Spawns = new List<Game_NPCController>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Triggerers;

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "NpcSpawner.psd", true);
        }
    }
}
/*
final native function int GetSpawnsLeft();
event UnTrigger(Actor Other,Pawn EventInstigator) {
local Actor triggerer;
if (EventInstigator != None) {                                              
triggerer = EventInstigator;                                              
} else {                                                                    
triggerer = Other;                                                        
}
if (TriggeredRespawn) {                                                     
Triggerers--;                                                             
if (Triggerers == 0) {                                                    
} else {                                                                  
if (Triggerers < 0) {                                                   
Triggerers = 0;                                                       
}
}
}
if (TriggeredDespawn) {                                                     
if (!TriggeredRespawn || Triggerers == 0) {                               
sv_Despawn();                                                           
}
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Actor triggerer;
if (EventInstigator != None) {                                              
triggerer = EventInstigator;                                              
} else {                                                                    
triggerer = Other;                                                        
}
if (TriggeredSpawn) {                                                       
if (!TriggeredRespawn || Triggerers == 0) {                               
sv_TriggeredSpawn(triggerer);                                           
}
}
if (TriggeredRespawn) {                                                     
if (Triggerers == 0) {                                                    
}
Triggerers++;                                                             
}
}
event sv_Despawn() {
}
native function sv_TriggeredSpawn(Actor aTriggerer);
*/