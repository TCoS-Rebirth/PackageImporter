using System;

namespace SBGame
{
    [Serializable] public class Game_NPCCombatStats : Game_CombatStats
    {
        public Game_NPCCombatStats()
        {
        }
    }
}
/*
protected native function bool GetOuterDead();
protected event string GetOuterName() {
return "NPC" @ Outer.Character.sv_GetName();                                
}
function sv_QuestCredit(array<Game_Pawn> Enemies) {
local int enemyI;
local Game_Controller enemyController;
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
enemyController = Game_Controller(Enemies[enemyI].Controller);            
enemyController.sv_FireHook(1,Outer,0);                                   
enemyI++;                                                                 
}
}
*/