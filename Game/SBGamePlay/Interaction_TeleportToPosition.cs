﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBGame;


namespace SBGamePlay
{


    public class Interaction_TeleportToPosition : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Vector originalLocation;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
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