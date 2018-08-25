using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class SBDialogWindowTrigger : Trigger
    {
        [FoldoutGroup("SBDialogWindowTrigger")]
        public byte windowToTrigger;

        public SBDialogWindowTrigger()
        {
        }

        public enum windowType
        {
            SBDWT_EnterArena,
        }
    }
}
/*
function Touch(Actor Other) {
local Game_PlayerController touchingPlayer;
Super.Touch(Other);                                                         
if (IsServer()) {                                                           
touchingPlayer = Game_PlayerController(Pawn(Other).Controller);           
if (Pawn(Other) != None && touchingPlayer != None) {                      
switch (windowToTrigger) {                                              
case 0 :                                                              
touchingPlayer.GUI.sv2cl_ShowEnterArena_CallStub();                 
break;                                                              
default:                                                              
}
}
}
}
*/