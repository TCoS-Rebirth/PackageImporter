using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable]
    public class Game_EquippedAppearance: Game_Appearance
    {
        [NonSerialized] public byte mHead;
        [NonSerialized] public int mChestClothes;
        [NonSerialized] public byte mLeftGlove;
        [NonSerialized] public byte mRightGlove;
        [NonSerialized] public byte mPants;
        [NonSerialized] public byte mShoes;
        [NonSerialized] public byte mHeadGearArmour;
        [NonSerialized] public byte mLeftShoulderArmour;
        [NonSerialized] public byte mRightShoulderArmour;
        [NonSerialized] public byte mLeftGauntlet;
        [NonSerialized] public byte mRightGauntlet;
        [NonSerialized] public byte mChestArmour;
        [NonSerialized] public byte mBelt;
        [NonSerialized] public byte mLeftThigh;
        [NonSerialized] public byte mRightThigh;
        [NonSerialized] public byte mLeftShin;
        [NonSerialized] public byte mRightShin;
        [NonSerialized] public byte mMainWeapon;
        [NonSerialized] public byte mOffhandWeapon;
        [NonSerialized] public byte mHair;
        [NonSerialized] public byte mMainSheath;
        [NonSerialized] public byte mOffhandSheath;
        [NonSerialized] public byte[] mTattoo = new byte[4];
        [NonSerialized] public byte[] mClassTattoo = new byte[4];
        [NonSerialized] public byte mBodyColor;
        [NonSerialized] public byte[] mChestClothesColors = new byte[2];
        [NonSerialized] public byte[] mLeftGloveColors = new byte[2];
        [NonSerialized] public byte[] mRightGloveColors = new byte[2];
        [NonSerialized] public byte[] mPantsColors = new byte[2];
        [NonSerialized] public byte[] mShoesColors = new byte[2];
        [NonSerialized] public byte[] mHeadGearArmourColors = new byte[2];
        [NonSerialized] public byte[] mLeftShoulderArmourColors = new byte[2];
        [NonSerialized] public byte[] mRightShoulderArmourColors = new byte[2];
        [NonSerialized] public byte[] mLeftGauntletColors = new byte[2];
        [NonSerialized] public byte[] mRightGauntletColors = new byte[2];
        [NonSerialized] public byte[] mChestArmourColors = new byte[2];
        [NonSerialized] public byte[] mBeltColors = new byte[2];
        [NonSerialized] public byte[] mLeftThighColors = new byte[2];
        [NonSerialized] public byte[] mRightThighColors = new byte[2];
        [NonSerialized] public byte[] mLeftShinColors = new byte[2];
        [NonSerialized] public byte[] mRightShinColors = new byte[2];
        [NonSerialized] public byte mHairColor;
        [NonSerialized] public bool mDisplayLogo;
        [NonSerialized] public Appearance_Set mAppearanceSet;
        [NonSerialized] public float mFreezeTime;
        [NonSerialized] public float mFreezeStart;
        [NonSerialized] public bool mIgnoreCoversFlags;

        public bool GetDisplayLogo()
        {
            return mDisplayLogo;
        }

        public byte GetHead()
        {
            return mHead;
        }

        public void SetDisplayLogo(bool aNewVal)
        {
            mDisplayLogo = aNewVal;
        }

        public void SetHead(byte aNewVal)
        {
            mHead = aNewVal;
        }

        //public override void cl_OnFrame(float DeltaTime)
        //{
        //    if (mFreezeTime > 0)
        //    {
        //        if (Time.realtimeSinceStartup - mFreezeStart >= mFreezeTime)
        //        {
        //            mFreezeTime = 0f;
        //            (Outer as Game_Pawn).CharacterStats.FreezeMovement(false);
        //        }
        //    }
        //    base.cl_OnFrame(DeltaTime);
        //}
    }
}
/*
protected native function string cl_GetPartName(byte aPart);
native function Texture GetBodyPalette();
native function Object GetAppearanceResource(byte aPartType,int aIndex);
native function bool Compatible(Appearance_Base Base,bool IsCharacterCreation);
native event CheckCompatibility(bool IsCharacterCreation);
native function SetRandom(int aMeshMaterialBits,int aColorBits,bool aFullRandomColors,bool IsCharacterCreation,optional bool LockGloves,optional bool LockGauntlets,optional bool LockShoulderArmour,optional bool LockArmTattoos);
function Appearance_Set GetAppearanceSet() {
return mAppearanceSet;                                                      
}
protected native function sv2rel_SetColorValue_CallStub();
event sv2rel_SetColorValue(byte aPart,byte aNewValue,byte aIndex) {
SetColorValue(aPart,aNewValue,aIndex);                                      
Apply();                                                                    
}
protected native function sv2rel_SetValue_CallStub();
event sv2rel_SetValue(byte aPart,int aNewValue,byte aIndex) {
SetValue(aPart,aNewValue,aIndex);                                           
Apply();                                                                    
}
native event int GetNetMax(byte aPart);
native function int GetMax(byte aPart);
native function byte GetColorValue(byte aPart,byte aIndex);
native function SneakySetColorValue(byte aPart,byte aNewValue,byte aIndex);
native function SetColorValue(byte aPart,byte aNewValue,byte aIndex);
native function int GetValue(byte aPart,optional byte aIndex);
native function SneakySetValue(byte aPart,int aNewValue,optional byte aIndex);
native function SetValue(byte aPart,int aNewValue,optional byte aIndex);

function app(int A) {
local byte appPart;
local int maxIndex;
local int i;
local int j;
local Appearance_Base appBase;
local Object Obj;
local byte val;
Super.app(A);                                                               
cl_ConsoleMessage("----------------------------");                          
appPart = 0;                                                                
while (appPart <= 23) {                                                     
if (A > 0 && A - 1 != appPart) {                                          
} else {                                                                  
if (appPart != 23 && appPart != 24) {                                   
maxIndex = 1;                                                         
} else {                                                                
maxIndex = 4;                                                         
}
i = 0;                                                                  
while (i < maxIndex) {                                                  
val = GetValue(appPart,i);                                            
Obj = GetAppearanceResource(appPart,val);                             
appBase = Appearance_Base(Obj);                                       
cl_ConsoleMessage("Part [Sirenix.OdinInspector.FoldoutGroup(" $ string(1 + appPart) $ "] "
$ cl_GetPartName(appPart)
$ "[Sirenix.OdinInspector.FoldoutGroup("
$ string(i)
$ "]: ("
$ string(val)
$ ") = "
$ string(Obj));
if (appBase != None && A - 1 == appPart) {                            
cl_ConsoleMessage("    Name:        " $ appBase.Name.Text);         
cl_ConsoleMessage("    Description: " $ appBase.Description.Text);  
cl_ConsoleMessage("    Palette1:    " $ string(appBase.Palette1));  
cl_ConsoleMessage("    Palette2:    " $ string(appBase.Palette2));  
cl_ConsoleMessage("    Part:        " $ string(appBase.Part));      
cl_ConsoleMessage("    Excludes:    " $ string(appBase.ExcludeHumans)
@ string(appBase.ExcludeDaevi)
@ string(appBase.ExcludeMale)
@ string(appBase.ExcludeFemale)
@ string(appBase.ExcludeFat)
@ string(appBase.ExcludeSkinny)
@ string(appBase.ExcludeHulk)
@ string(appBase.ExcludeAthletic));
cl_ConsoleMessage("    Item type:   " $ string(appBase._IT));       
cl_ConsoleMessage("    Set Index:   " $ string(appBase._AS_Index)
@ string(appBase._AS_Set));
cl_ConsoleMessage("    Attachments: "
$ string(appBase.Attachments.Length));
j = 0;                                                              
while (j < appBase.Attachments.Length) {                            
cl_ConsoleMessage("        [Sirenix.OdinInspector.FoldoutGroup(" $ string(j) $ "]: "
$ string(appBase.Attachments[j].SocketId)
@ appBase.Attachments[j].MeshGroup);
j++;                                                              
}
}
i++;                                                                  
}
}
appPart = appPart + 1;                                                    
}
}
function bool Check() {
if (GetAppearanceSet() == None) {                                           
return False;                                                             
}
return Super.Check();                                                       
}

event OnConstruct() {
Super.OnConstruct();                                                        
InitAppearanceSet();                                                        
}
protected native function InitAppearanceSet();
*/
