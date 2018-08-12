using System;
using SBGame;

namespace SBAI
{
    [Serializable] public class Meta_CombatStats : Game_CombatStats
    {
        public Meta_CombatStats()
        {
        }
    }
}
/*
protected native function bool GetOuterDead();
protected event string GetOuterName() {
return "MetaController" @ string(Outer);                                    
}
function sv_QuestCredit(array<Game_Pawn> Enemies) {
local int enemyI;
local Game_Controller enemyController;
enemyI = 0;                                                                 
while (enemyI < Enemies.Length) {                                           
enemyController = Game_Controller(Enemies[enemyI].Controller);            
enemyController.sv_FireHook(6,Outer.GetFaction(),0);                      
enemyI++;                                                                 
}
}
event sv_OnEndAggro() {
if (mInCombat) {                                                            
sv_ExitCombat();                                                          
}
}
event sv_OnStartAggro() {
if (!mInCombat) {                                                           
sv_EnterCombat();                                                         
}
}
*/