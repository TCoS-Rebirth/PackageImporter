using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class WorldResourceManager : Actor
    {
        [FoldoutGroup("WorldResourceManager")]
        public int MaxActive;

        [FoldoutGroup("WorldResourceManager")]
        public float RespawnTime;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<RegisteredResource> ManagedResources = new List<RegisteredResource>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float RespawnTimer;

        public WorldResourceManager()
        {
        }

        [Serializable] public struct RegisteredResource
        {
            public WorldResource Resource;

            public float Timer;
        }
    }
}
/*
function DisableResource(WorldResource aResource) {
local int ri;
ri = 0;                                                                     
while (ri < ManagedResources.Length) {                                      
if (ManagedResources[ri].Resource == aResource) {                         
ManagedResources[ri].Timer = Level.TimeSeconds;                         
ManagedResources[ri].Resource.sv_SetEnabled(False);                     
if (RespawnTimer < 0.00000000) {                                        
RespawnTimer = RespawnTime;                                           
}
}
ri++;                                                                     
}
}
*/