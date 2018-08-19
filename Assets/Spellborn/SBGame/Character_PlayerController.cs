using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Character_PlayerController : Game_PlayerController
    {
        [NonSerialized, HideInInspector]
        private Vector mTargetLocation;
    }
}
/*
event cl_OnShutdown() {
}
event cl_OnPlayerTick(float DeltaTime) {
}
function SetTargetRotation(Rotator aRotation) {
mTargetRotation = aRotation;                                                
}
function SetTargetLocation(Vector aLocation) {
mTargetLocation = aLocation;                                                
}
*/