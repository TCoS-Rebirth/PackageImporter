using System;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_OnDeath_Counter : AIScript_Counter
    {
        [FoldoutGroup("Counter")]
        public NPC_Type LimitToNPCType;

        public AIScript_OnDeath_Counter()
        {
        }
    }
}
/*
function bool OnDeath(Game_AIController aController,Actor aCollaborator) {
if (Game_NPCPawn(aController.Pawn).NPCType == LimitToNPCType
|| LimitToNPCType == None) {
DoCount();                                                                
}
return Super.OnDeath(aController,aCollaborator);                            
}
*/