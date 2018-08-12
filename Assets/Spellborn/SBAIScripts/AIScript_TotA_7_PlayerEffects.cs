using System;
using SBAI;
using SBGame;
using Sirenix.OdinInspector;

namespace SBAIScripts
{
    [Serializable] public class AIScript_TotA_7_PlayerEffects : AI_Script
    {
        [FoldoutGroup("AIScript_TotA_7_PlayerEffects")]
        public FSkill_Type SkillToApply;

        [FoldoutGroup("AIScript_TotA_7_PlayerEffects")]
        public NPC_Type ApplyerNPCType;

        public AIScript_TotA_7_PlayerEffects()
        {
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerPawn playerPawn;
foreach AllActors(Class'Game_PlayerPawn',playerPawn) {                      
RemoveSkillDuffs(playerPawn,SkillToApply);                                
}
}
event Trigger(Actor Other,Pawn EventInstigator) {
local Game_PlayerPawn playerPawn;
local Game_Pawn applyerPawn;
applyerPawn = GetNPC(ApplyerNPCType);                                       
if (applyerPawn != None) {                                                  
foreach AllActors(Class'Game_PlayerPawn',playerPawn) {                    
ApplySkillEffects(SkillToApply,applyerPawn,playerPawn);                 
}
goto jl0046;                                                              
}
}
*/