﻿using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Move : Interaction_Component
    {
        [FoldoutGroup("Interaction_Move")]
        [FieldConst()]
        public Vector Movement;

        [FoldoutGroup("Interaction_Move")]
        [FieldConst()]
        public Rotator Rotation;

        [FoldoutGroup("Interaction_Move")]
        [FieldConst()]
        public float TimeSec;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Vector OriginalPosition;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Rotator OriginalOrientation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float mTimer;

        public Interaction_Move()
        {
        }
    }
}
/*
function ClOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnEnd(aOwner,aInstigator,aReverse);                                 
if (!aReverse) {                                                            
if (TimeSec > 0.00000000) {                                               
aOwner.Velocity = vect(0.000000, 0.000000, 0.000000);                   
aOwner.RotationRate.Yaw = 0;                                            
aOwner.RotationRate.Pitch = 0;                                          
aOwner.RotationRate.Roll = 0;                                           
aOwner.SetLocation(OriginalPosition + Movement);                        
aOwner.SetRotation(OriginalOrientation + Rotation);                     
aOwner.SetPhysics(0);                                                   
}
}
}
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
if (!aReverse) {                                                            
if (TimeSec > 0.00000000) {                                               
OriginalPosition = aOwner.Location;                                     
OriginalOrientation = aOwner.Rotation;                                  
aOwner.Velocity = Movement / TimeSec;                                   
aOwner.RotationRate = Rotation / TimeSec;                               
aOwner.SetPhysics(7);                                                   
} else {                                                                  
aOwner.SetLocation(aOwner.Location + Movement);                         
aOwner.SetRotation(OriginalOrientation + Rotation);                     
}
} else {                                                                    
aOwner.Velocity = vect(0.000000, 0.000000, 0.000000);                     
aOwner.RotationRate.Yaw = 0;                                              
aOwner.RotationRate.Pitch = 0;                                            
aOwner.RotationRate.Roll = 0;                                             
aOwner.SetLocation(OriginalPosition);                                     
aOwner.SetRotation(OriginalOrientation);                                  
}
}
function SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
ile.SetLocation(OriginalPosition + Movement);                           
ile.SetRotation(OriginalOrientation + Rotation);                        
mTimer = TimeSec;                                                       
if (TimeSec > 0.00000000) {                                             
ile.sv_EndClientSubAction();                                          
}
}
}
Super.SvOnEnd(aOwner,aInstigator,aReverse);                                 
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,optional bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator);                                        
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
OriginalPosition = ile.Location;                                        
OriginalOrientation = ile.Rotation;                                     
mTimer = 0.00000000;                                                    
ile.sv_StartClientSubAction();                                          
} else {                                                                  
ile.SetLocation(OriginalPosition);                                      
ile.SetRotation(OriginalOrientation);                                   
ile.sv_StartClientSubAction();                                          
}
}
}
*/