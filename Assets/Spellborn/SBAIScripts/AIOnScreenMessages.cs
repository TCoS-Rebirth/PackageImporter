using System;
using Engine;
using SBAI;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIOnScreenMessages : AI_Script
    {
        [FoldoutGroup("AIOnScreenMessages")]
        public LocalizedString Message;

        public AIOnScreenMessages()
        {
        }
    }
}
/*
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerController lPlayer;
foreach AllActors(Class'Game_PlayerController',lPlayer) {                   
lPlayer.Chat.sv2cl_SendOnScreenMessage_CallStub(Message.Id);              
}
}
*/