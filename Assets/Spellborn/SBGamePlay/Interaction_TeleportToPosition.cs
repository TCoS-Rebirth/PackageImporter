using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_TeleportToPosition : Interaction_Component
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector originalLocation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator OriginalOrientation;

        public Interaction_TeleportToPosition()
        {
        }
    }
}
/*
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local Vector Position;
local Rotator Orientation;
local float turntimer;
local float MoveTimer;
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (aInstigator != None && ile != None) {                                   
if (!aReverse) {                                                          
Position = ile.AbsPosition;                                             
Orientation = ile.AbsRotation;                                          
MoveTimer = VSize(Position - aInstigator.Location) / aInstigator.GroundSpeed;
turntimer = (Orientation - aInstigator.Rotation).Yaw / aInstigator.RotationRate.Yaw;
originalLocation = aInstigator.Location;                                
OriginalOrientation = aInstigator.Rotation;                             
aInstigator.sv_TeleportTo(Position,Orientation);                        
} else {                                                                  
aInstigator.sv_TeleportTo(originalLocation,OriginalOrientation);        
}
}
}
*/