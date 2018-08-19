using System;

namespace SBGame
{
    [Serializable]
    public class Game_GameMasterController: Game_PlayerController
    {
        public int mAuthorityLevel;

        public Game_PropertyEditor PropertyEditor;

        private bool mIsVisibleInRelevance;

        private int mSpeedBoosts;

        private bool mShield;

        public override int GetAuthorityLevel()
        {
            return mAuthorityLevel;
        }
        public void SetAuthorityLevel(int aLevel)
        {
            mAuthorityLevel = aLevel;
        }
    }
}
/*

event cl_OnInit() {
local int Index;
local int helpSpeed;
Super.cl_OnInit();                                                          
Player.Console.MakeCSConsole();                                             
if (mIsVisibleInRelevance) {                                                
} else {                                                                    
}
helpSpeed = mSpeedBoosts;                                                   
mSpeedBoosts = 0;                                                           
Index = 0;                                                                  
while (Index < helpSpeed) {                                                 
Index++;                                                                  
}
if (mShield) {                                                              
} else {                                                                    
}
}
protected native function sv2cl_SetShield_CallStub();
event sv2cl_SetShield(bool aValue) {
mShield = aValue;                                                           
SaveConfig();                                                               
}
protected native function sv2cl_ResetSpeedBoost_CallStub();
event sv2cl_ResetSpeedBoost() {
mSpeedBoosts = 0;                                                           
SaveConfig();                                                               
}
protected native function sv2cl_AddSpeedBoost_CallStub();
event sv2cl_AddSpeedBoost() {
mSpeedBoosts++;                                                             
SaveConfig();                                                               
}
protected native function sv2cl_SetVisibleInRelevance_CallStub();
event sv2cl_SetVisibleInRelevance(bool aValue) {
mIsVisibleInRelevance = aValue;                                             
SaveConfig();                                                               
}
event OnCreateComponents() {
Super.OnCreateComponents();                                                 
PropertyEditor = new (self) Class'Game_PropertyEditor';                     
SpwnieControl = new (self) Class'Editor_SpwnieControl';                     
}
*/
