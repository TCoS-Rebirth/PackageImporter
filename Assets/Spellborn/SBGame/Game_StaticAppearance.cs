using System;

namespace SBGame
{
    [Serializable] public class Game_StaticAppearance : Game_Appearance
    {
        public float CollisionRadius;

        public float CollisionHeight;

        public float SkillRadius;

        public Game_StaticAppearance()
        {
        }
    }
}
/*
function app(int A) {
Super.app(0);                                                               
if (A == 0) {                                                               
cl_ConsoleMessage("StaticMesh == " $ string(StatMesh));                   
}
}
function bool Check() {
return StatMesh != None;                                                    
}
*/