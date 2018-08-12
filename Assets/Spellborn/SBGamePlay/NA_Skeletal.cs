using System;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NA_Skeletal : NA_RaceBodyGender
    {
        [FoldoutGroup("Modifiers")]
        public bool Ghostly;

        [FoldoutGroup("Modifiers")]
        public bool Statue;

        [FoldoutGroup("Modifiers")]
        public float Scale;

        public NA_Skeletal()
        {
        }
    }
}
/*
function Game_Appearance CreateAppearance(Game_Pawn aPawn,export editinline Game_Appearance aAppearance,bool aShifting) {
local export editinline Game_SkeletalAppearance pawnAppearance;
aAppearance = ForceAppearanceClass(aPawn,aAppearance,Class'Game_SkeletalAppearance');
aAppearance = Super.CreateAppearance(aPawn,aAppearance,aShifting);          
pawnAppearance = Game_SkeletalAppearance(aAppearance);                      
pawnAppearance.SkeletalMesh = SkeletalMesh;                                 
pawnAppearance.SkeletalMeshAddition = SkeletalMeshAddition;                 
pawnAppearance.SkinTexture = SkinTexture;                                   
pawnAppearance.SetScale(Scale);                                             
if (Statue) {                                                               
pawnAppearance.SetStatue(True);                                           
}
if (Ghostly) {                                                              
pawnAppearance.SetGhost(True);                                            
}
pawnAppearance.SetRace(Race);                                               
pawnAppearance.SetGender(Gender);                                           
pawnAppearance.SetBody(Bodytype);                                           
pawnAppearance.CollisionRadius = GetCollisionRadius();                      
pawnAppearance.CollisionHeight = GetCollisionHeight();                      
pawnAppearance.SkillRadius = GetSkillRadius();                              
return aAppearance;                                                         
}
*/