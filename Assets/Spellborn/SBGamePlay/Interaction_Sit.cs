using System;
using Engine;
using SBGame;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class Interaction_Sit : Interaction_Component
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private float mSitTimer;

        public Interaction_Sit()
        {
        }
    }
}
/*
function SvOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
Super.SvOnCancel(aOwner,aInstigator);                                       
}
function SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,optional bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
mSitTimer = 0.00000000;                                                     
if (aInstigator != None) {                                                  
if (aInstigator.CharacterStats != None) {                                 
aInstigator.CharacterStats.FreezeMovementTimed(1.20000005);             
mSitTimer = 1.20000005;                                                 
}
aInstigator.sv_Sit(!aReverse,True);                                       
}
}
*/