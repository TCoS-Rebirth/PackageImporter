﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class Interaction_Sit : Interaction_Component
    {
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private float mSitTimer;
        
        public Interaction_Sit()
        {
        }
    }
}
/*
function SvOnCancel(Game_Actor aOwner,Game_Pawn aInstigator) {
Super.SvOnCancel(aOwner,aInstigator);                                       
}
function SvOnEnd(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,optional bool aReverse) {
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
mSitTimer = 0.00000000;                                                     
if (aInstigator != None) {                                                  
if (aInstigator.CharacterStats != None) {                                 
aInstigator.CharacterStats.FreezeMovementTimed(1.20000005);             
mSitTimer = 1.20000005;                                                 
}
aInstigator.sv_Sit(!aReverse,True);                                       
}
}
*/