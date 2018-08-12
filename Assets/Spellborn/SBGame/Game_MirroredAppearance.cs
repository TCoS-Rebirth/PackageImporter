using System;

namespace SBGame
{
    [Serializable] public class Game_MirroredAppearance : Game_ShiftableAppearance
    {
        private Game_Pawn mReferencedPawn;

        private Game_AppearanceListener mListener;

        public Game_MirroredAppearance()
        {
        }
    }
}
/*
function InstallBaseAppearance(export editinline NPC_Type aNPCType) {
}
event bool sv_UnshiftAppearance() {
return False;                                                               
}
event bool sv_ShiftAppearance(export editinline NPC_Type aOtherNPCType) {
return False;                                                               
}
event NPC_Type GetShiftedNPCType() {
if (mReferencedPawn != None) {                                              
return mReferencedPawn.Appearance.GetShiftedNPCType();                    
} else {                                                                    
return None;                                                              
}
}
event bool IsShifted() {
if (mReferencedPawn != None) {                                              
return mReferencedPawn.Appearance.IsShifted();                            
} else {                                                                    
return False;                                                             
}
}
event Game_Appearance GetBase() {
if (mReferencedPawn != None) {                                              
return mReferencedPawn.Appearance.GetCurrent();                           
} else {                                                                    
return None;                                                              
}
}
event Game_Appearance GetCurrent() {
if (mReferencedPawn != None) {                                              
return mReferencedPawn.Appearance.GetCurrent();                           
} else {                                                                    
return None;                                                              
}
}
event SetReferencedPawn(Game_Pawn aNewReferencedPawn) {
assert(aNewReferencedPawn == None
|| aNewReferencedPawn.Appearance != self);
if (mReferencedPawn == None) {                                              
}
if (mReferencedPawn != aNewReferencedPawn) {                                
if (mReferencedPawn != None) {                                            
assert(mListener != None);                                              
mListener.__OnAppearanceChanged__Delegate = None;                       
assert(mReferencedPawn.Appearance != None);                             
mReferencedPawn.Appearance.UnregisterAppearanceListener(mListener);     
}
mReferencedPawn = aNewReferencedPawn;                                     
if (mReferencedPawn != None) {                                            
if (mListener == None) {                                                
mListener = new Class'Game_AppearanceListener';                       
}
mListener.__OnAppearanceChanged__Delegate = OnReferencedPawnsAppearanceChanged;
assert(mReferencedPawn.Appearance != None);                             
mReferencedPawn.Appearance.RegisterAppearanceListener(mListener);       
DressUp();                                                              
}
}
}
function OnReferencedPawnsAppearanceChanged(Game_Pawn aPawn,export editinline Game_Appearance aAppearance) {
assert(mReferencedPawn != None);                                            
if (aPawn == mReferencedPawn) {                                             
DressUp();                                                                
}
}
*/