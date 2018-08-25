using System;

namespace SBGame
{
    [Serializable]
    public class Game_GameMasterController: Game_PlayerController
    {
        [NonSerialized] public int mAuthorityLevel = 2;
        [NonSerialized] public Game_PropertyEditor PropertyEditor;
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

        public override void Initialize()
        {
            base.Initialize();
            PropertyEditor = gameObject.AddComponent<Game_PropertyEditor>();
        }
    }
}
/*
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
*/
