﻿using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Character_GameInfo : Game_GameInfo
    {
        public const int MAX_CHARACTERS_PER_UNIVERSE = 7;

        public ECharacterCreationState mState;

        [FieldConst()]
        [ArraySizeForExtraction(Size = 12)]
        public int[] mMaxHealthDefaults = new int[0];

        [FieldConst()]
        public float FreeToPlayMaxFamePoints;

        //public delegate<HandleCharacterCreationResult> @__HandleCharacterCreationResult__Delegate;

        //public delegate<HandleCharacterDeletionResult> @__HandleCharacterDeletionResult__Delegate;

        //public delegate<HandleCharacterSelectionResult> @__HandleCharacterSelectionResult__Delegate;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mServerCharacters;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        private int mClientCharacters;

        public Character_GameInfo()
        {
        }

        public enum ECharacterCreationState
        {
            CCS_SELECT_CHARACTER,

            CCS_CREATE_CHARACTER,

            CCS_ENTER_WORLD,

            CCS_PREPARE_UNIVERSE_ENTRY,
        }
    }
}
/*
final native function Character_Pawn cl_GetFirstCharacter();
final native function int cl_GetCharacterCount();
final native function cl_SelectCharacter(int aCharacterId);
final native function cl_DeleteCharacter(int aCharacterId,string aPassword);
final native function cl_CreateCharacter(array<byte> aLOD0,array<byte> aLOD1,array<byte> aLOD2,array<byte> aLOD3,string aName,int aArchetype,int aSkillID1,int aSkillID2,int aSkillID3,int aSkillID4,int aSkillID5,int aRangedWeaponID);
final function cl_GotoCharacterCreation() {
cl_SetState(1);                                                             
}
final function cl_GotoCharacterSelection() {
cl_SetState(0);                                                             
}
private final event cl_SetState(byte aNewState) {
local Game_Desktop desktop;
mState = aNewState;                                                         
desktop = cl_GetDesktop();                                                  
desktop.HideAllWindows();                                                   
switch (mState) {                                                           
case 1 :                                                                  
desktop.ShowStdWindow(Class'GUI_BaseDesktop'.25,Class'GUI_BaseDesktop'.1);
desktop.UpdateStdWindow(Class'GUI_BaseDesktop'.25,0,None,"");           
break;                                                                  
case 0 :                                                                  
desktop.ShowStdWindow(Class'GUI_BaseDesktop'.22,Class'GUI_BaseDesktop'.1);
desktop.ShowStdWindow(Class'GUI_BaseDesktop'.25,Class'GUI_BaseDesktop'.2);
desktop.UpdateStdWindow(Class'GUI_BaseDesktop'.22,0,None,"",0);         
break;                                                                  
case 2 :                                                                  
break;                                                                  
case 3 :                                                                  
break;                                                                  
default:                                                                  
}
}
private final function PreloadItems() {
Class'Item_Type'.LoadAllItems();                                            
}
private final native function sv_CleanUpServerCharacters(int aAccountID);
event cl_OnInit() {
Super.cl_OnInit();                                                          
PreloadItems();                                                             
}
event sv_OnLogout(int aAccountID,Base_Pawn aPawn) {
sv_CleanUpServerCharacters(aAccountID);                                     
Super.sv_OnLogout(aAccountID,aPawn);                                        
}
event sv_OnInit() {
Super.sv_OnInit();                                                          
PreloadItems();                                                             
}
delegate HandleCharacterSelectionResult(bool aSuccess,string Message);
delegate HandleCharacterDeletionResult(bool aSuccess,string Message);
delegate HandleCharacterCreationResult(bool aSuccess,string Message);
*/