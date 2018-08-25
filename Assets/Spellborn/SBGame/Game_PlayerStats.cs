using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_PlayerStats: Game_CharacterStats
    {
        [NonSerialized] public int mFamePoints;
        [NonSerialized] public int mPePPoints;
        [NonSerialized] public bool mMayChooseClass;
        [NonSerialized] public byte mAvailableAttributePoints;

        public override void WriteLoginStream(IPacketWriter writer)
        {
            writer.WriteFloat(mFamePoints);
            writer.WriteFloat(mPePPoints);
            writer.WriteInt32(0); //mMayChooseClass ? (bitfield):0
            writer.WriteByte(mAvailableAttributePoints);
            writer.WriteFloat(mHealth);
            writer.WriteByte(0); //Camera mode (?)
            writer.WriteInt32(mMovementSpeed);
            writer.Write(mRecord);
            writer.WriteInt32(mStateRankShift);
            writer.WriteInt32(mExtraBodyPoints);//not sure
            writer.WriteInt32(mExtraMindPoints);//not sure
            writer.WriteInt32(mExtraFocusPoints);//not sure
        }

        public void DecreasePePRank()
        {
            throw new NotImplementedException();
        }

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            var pawn = outer as Game_Pawn;
            var controller = pawn.Controller as Game_Controller;
            SetCharacterClass((Content_API.EContentClass)(controller.DBCharacterSheet.ClassId + 1));
            mFamePoints = (int)controller.DBCharacterSheet.FamePoints;
            mPePPoints = (int)controller.DBCharacterSheet.PepPoints;
            mHealth = controller.DBCharacterSheet.Health;
            mRecord.CopyHealth = mHealth;
            mRecord.FameLevel = SBDBSync.GetFameLevelByPoints(mFamePoints);
            mRecord.PePRank = SBDBSync.GetPepRankByPoints(mPePPoints);
            mExtraBodyPoints = controller.DBCharacterSheet.ExtraBodyPoints;
            mExtraMindPoints = controller.DBCharacterSheet.ExtraMindPoints;
            mExtraFocusPoints = controller.DBCharacterSheet.ExtraFocusPoints;
        }

        public void sv_SetClass(Content_API.EContentClass aClass)
        {
            SetCharacterClass(aClass);
            sv_UpdateStats();
            sv2cl_SetClass_CallStub(aClass);
            SBDBAsync.SetCharacterClass((Outer as Game_Pawn), (Outer as Game_Pawn).GetCharacterID(), (byte)aClass - 1);
            if ((Outer as Game_Pawn).BodySlots != null)
            {
                (Outer as Game_Pawn).BodySlots.sv_SetMode((Outer as Game_Pawn).BodySlots.GetBodySlotModeByClass());
            }
            SetClassToUniverse(aClass);
        }

        void sv_UpdateStats()
        {
            throw new NotImplementedException();
        }

        void SetClassToUniverse(Content_API.EContentClass aClass)
        {
            throw new NotImplementedException();
        }

        void sv2cl_SetClass(Content_API.EContentClass aClass)
        {
            SetCharacterClass(aClass);
        }

        void sv2cl_SetClass_CallStub(Content_API.EContentClass aClass /*added*/)
        {
            throw new NotImplementedException();
        }

        void cl2sv_SetClass_CallStub(Content_API.EContentClass aClass /*added*/)
        {
            throw new NotImplementedException();
        }

        public void IncreasePePPoints(int aDelta)
        {
            mPePPoints += aDelta;
            Debug.LogWarning("TODO check for maximum");
        }

        public void IncreaseFamePoints(int aDelta)
        {
            mFamePoints += aDelta;
            Debug.LogWarning("TODO check for maximum");
        }

        int GetMaximumPePRank()
        {
            throw new NotImplementedException();
        }

        int GetMinimumPePRank()
        {
            throw new NotImplementedException();
        }

        int GetMaximumFameLevel()
        {
            throw new NotImplementedException();
        }

        int GetMinimumFameLevel()
        {
            throw new NotImplementedException();
        }

        public void sv2clrel_OnLevelUp(int aNewLevel)
        {
            //Game_PlayerController Controller;
            bool levelUp = aNewLevel > mRecord.FameLevel;
            mRecord.FameLevel = aNewLevel;
            if (levelUp)
            {
                (Outer as Game_Pawn).cl_PlayPawnEffect(0);
                //if (Outer.IsLocalPlayer())
                //{
                //    Controller = Game_PlayerController(Outer.Controller);
                //    Game_Desktop(Controller.Player.GUIDesktop).OnLevelUp(aNewLevel);
                //    Game_PlayerConversation(Controller.ConversationControl).cl_RefreshTopics();
                //}
            }
        }

        public void sv2clrel_OnUpdatePePRank(int aNewPePRank)
        {
            if (aNewPePRank > mRecord.PePRank)
            {
                (Outer as Game_Pawn).cl_PlayPawnEffect((Game_Pawn.EPawnEffectType)1);
            }
            mRecord.PePRank = aNewPePRank;
        }
    }
}
/*
protected native function sv2cl_UpdateFocusAndSoulAffinity_CallStub();
protected native event sv2cl_UpdateFocusAndSoulAffinity(int aFocus,float aSoulAffinity);
protected native function sv2cl_UpdateMindAndSpiritAffinity_CallStub();
protected native event sv2cl_UpdateMindAndSpiritAffinity(int aMind,float aSpiritAffinity);
protected native function sv2cl_UpdateBodyAndRuneAffinity_CallStub();
protected native event sv2cl_UpdateBodyAndRuneAffinity(int aBody,float aRuneAffinity);
protected native function sv2cl_UpdateUpgradeInfo_CallStub();
protected native event sv2cl_UpdateUpgradeInfo(bool aMayChooseClass,byte aAvailableAttributePoints);
protected native function sv2cl_UpdatePePPoints_CallStub();
protected native event sv2cl_UpdatePePPoints(float aPePPoints);
protected native function sv2cl_UpdateFamePoints_CallStub();
protected native event sv2cl_UpdateFamePoints(float aFamePoints);
event cl2sv_SetClass(byte aClass) {
sv_SetClass(aClass);                                                        
}
native event int GetNextPePRankPoints(int rank);
protected native function sv2clrel_OnUpdatePePRank_CallStub();
protected native function sv2clrel_OnLevelUp_CallStub();
native function cl_ClearMayChooseClass();
native function cl_ClearAvailableAttributePoints();
*/
