using System;
using SBBase;

namespace SBGame
{
#pragma warning disable 414   

    [Serializable]
    public class Game_Appearance: Base_Component
    {
        public const int RACE_DAEVIE = 1;

        public const int RACE_HUMAN = 0;

        public byte mRace;

        public byte mGender;

        public byte mBody;

        public byte mVoice;

        public float mScale;

        public int mStatue;

        public int mGhost;

        private int mErrors;

        private Game_Pawn mWorkPawn;

        public bool mClientInitialized;

        private string mVoicePackage = string.Empty;

        public enum EPreviewCamera
        {
            PC_COMPLETE_FRONT,

            PC_COMPLETE_FRONT_2,

            PC_HEAD,

            PC_HEAD_CLOSEUP,

            PC_TATTOOS,
        }

        public override void cl_OnInit()
        {
            base.cl_OnInit();
            mClientInitialized = true;
        }
        
        public virtual void cl_OnFrame(float DeltaTime) { throw new NotImplementedException(); }
        public virtual void OnConstruct() { throw new NotImplementedException(); }

        protected virtual void Apply() { throw new NotImplementedException(); }

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
        public byte GetBody()
        {
            return mBody;
        }
        public byte GetGender()
        {
            return mGender;
        }
        public byte GetRace()
        {
            return mRace;
        }
        public void SetScale(float aNewVal)
        {
            mScale = aNewVal;
        }
        public void SetBody(byte aNewVal)
        {
            mBody = aNewVal;
        }
        public void SetGender(byte aNewVal)
        {
            mGender = aNewVal;
            mVoicePackage = "";
        }
        public void SetRace(byte aNewVal)
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
            return mBody == 4;
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
/*
protected native function string cl_GetHexAddress(Object aObject);
protected function cl_ConsoleMessage(string aString) {
PlayerController(Outer.Controller).Player.Console.Message(aString,0.00000000);
}
native function GetPreviewCamera(byte aPreviewCamera,out Vector Translation,out Rotator Rotation);
function app(int A) {
if (A == 0) {                                                               
cl_ConsoleMessage("Current appearance overview:");                        
cl_ConsoleMessage("----------------------------");                        
cl_ConsoleMessage("Appearance == " $ cl_GetHexAddress(self));             
cl_ConsoleMessage("mClientInitialized == " $ string(mClientInitialized)); 
}
}

event string GetVoicePackage() {
if (mVoice < 255) {                                                         
if (Len(mVoicePackage) == 0 && mGender <= 1) {                            
mVoicePackage = "voice_";                                               
if (mGender == 0) {                                                     
} else {                                                                
}
if (IsPlayer()) {                                                       
} else {                                                                
if (IsKid()) {                                                        
} else {                                                              
if (mVoice >= Class'NPC_Appearance'.9) {                            
} else {                                                            
}
}
}
}
} else {                                                                    
mVoicePackage = "";                                                       
}
return mVoicePackage;                                                       
}
function bool IsFullDetail() {
return True;                                                                
}
*/
