using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NA_Equipped : NA_RaceBodyGender
    {
        [FoldoutGroup("Decoration")]
        [FieldConst()]
        public int Head;

        [FoldoutGroup("Decoration")]
        [FieldConst()]
        public Appearance_Hair Hair;

        [FoldoutGroup("Colour")]
        [FieldConst()]
        public byte BodyColor;

        [FoldoutGroup("Colour")]
        [FieldConst()]
        public byte HairColor;

        [FoldoutGroup("Effects")]
        public bool Ghostly;

        [FoldoutGroup("Effects")]
        public bool Statue;

        public NA_Equipped()
        {
        }
    }
}
/*
event int GetHead() {
return Head;                                                                
}
event SetHead(int NewHead) {
Head = NewHead;                                                             
}
function Game_Appearance CreateAppearance(Game_Pawn aPawn,export editinline Game_Appearance aAppearance,bool aShifting) {
local export editinline Game_EquippedAppearance pawnAppearance;
aAppearance = ForceAppearanceClass(aPawn,aAppearance,Class'Game_EquippedAppearance');
aAppearance = Super.CreateAppearance(aPawn,aAppearance,aShifting);          
pawnAppearance = Game_EquippedAppearance(aAppearance);                      
if (Statue) {                                                               
pawnAppearance.SetStatue(True);                                           
}
if (Ghostly) {                                                              
pawnAppearance.SetGhost(True);                                            
}
pawnAppearance.SetRace(Race);                                               
pawnAppearance.SetGender(Gender);                                           
pawnAppearance.SetBody(Bodytype);                                           
pawnAppearance.SetHead(Head);                                               
pawnAppearance.SetColorValue(21,BodyColor,0);                               
if (Hair != None) {                                                         
pawnAppearance.SetColorValue(18,HairColor,0);                             
pawnAppearance.SetValue(18,Hair._AS_Index);                               
} else {                                                                    
pawnAppearance.SetValue(18,0);                                            
}
return aAppearance;                                                         
}
*/