using System;

namespace SBGame
{
    [Serializable] public class Game_SkeletalAppearance : Game_Appearance
    {
        public float CollisionRadius;

        public float CollisionHeight;

        public float SkillRadius;

        public Game_SkeletalAppearance()
        {
        }
    }
}
/*
function app(int A) {
Super.app(0);                                                               
if (A == 0) {                                                               
cl_ConsoleMessage("Mesh == " $ string(SkeletalMesh));                     
}
}
function bool Check() {
return SkeletalMesh != None;                                                
}
*/