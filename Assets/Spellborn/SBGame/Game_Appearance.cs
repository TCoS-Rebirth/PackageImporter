using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_Appearance: Base_Component
    {
        [NonSerialized] public Content_API.NPCRace mRace;
        [NonSerialized] public Content_API.NPCGender mGender;
        [NonSerialized] public Content_API.NPCBodytype mBody;
        [NonSerialized] public byte mVoice;
        [NonSerialized] public float mScale;
        [NonSerialized] public int mStatue;
        [NonSerialized] public int mGhost;
        [NonSerialized] public bool mClientInitialized;
        private string mVoicePackage = string.Empty;

        public enum EPreviewCamera
        {
            PC_COMPLETE_FRONT,
            PC_COMPLETE_FRONT_2,
            PC_HEAD,
            PC_HEAD_CLOSEUP,
            PC_TATTOOS,
        }

        public override void Initialize(Actor outer)
        {
            base.Initialize(outer);
            mClientInitialized = true;
        }

        public virtual void Apply()
        {
            Debug.LogWarning("Game_Appearance.Apply() should be implemented");
        }

        public bool GetStatue()
        {
            return mStatue > 0;
        }

        public void SetStatue(bool aOn)
        {
            if (aOn) mStatue++;
            else mStatue--;
        }

        public bool GetGhost()
        {
            return mGhost > 0;
        }

        public void SetGhost(bool aOn)
        {
            if (aOn) mGhost++;
            else if (mGhost > 0) mGhost--;
        }

        public float GetScale()
        {
            return mScale;
        }

        public Content_API.NPCBodytype GetBody()
        {
            return mBody;
        }

        public Content_API.NPCGender GetGender()
        {
            return mGender;
        }

        public Content_API.NPCRace GetRace()
        {
            return mRace;
        }

        public void SetScale(float aNewVal)
        {
            mScale = aNewVal;
        }

        public void SetBody(Content_API.NPCBodytype aNewVal)
        {
            mBody = aNewVal;
        }

        public void SetGender(Content_API.NPCGender aNewVal)
        {
            mGender = aNewVal;
            mVoicePackage = "";
        }

        public void SetRace(Content_API.NPCRace aNewVal)
        {
            mRace = aNewVal;
        }

        public bool Check()
        {
            return true;
        }

        public bool IsNPC()
        {
            return !IsKid() && !IsPlayer();
        }

        public bool IsPlayer()
        {
            return (Outer is Game_PlayerPawn) || (Outer is Character_Pawn);
        }

        public bool IsKid()
        {
            return mBody == (Content_API.NPCBodytype)4;
        }

        public byte GetVoice()
        {
            return mVoice;
        }

        public void SetVoice(byte aNewVal)
        {
            mVoice = aNewVal;
            mVoicePackage = "";
        }

        public virtual bool ApplyToPawn(Game_Pawn aPawn) { throw new NotImplementedException(); }
    }
}
