﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SBGame
{
#pragma warning disable 414     

    [Serializable] public class Character_Pawn : Game_Pawn
    {
        private int mCharacterID;

        [NonSerialized, HideInInspector]
        private int mLastUsedTimestamp;

        public Game_PersistentData mPersistentData;

        public Character_Pawn()
        {
        }
    }
}
/*
event cl_PlayDeleteEmote() {
if (FRand() > 0.30000001) {                                                 
Emotes.PlayLocalEmote(mDeleteEmoteIndices[Rand(mDeleteEmoteIndices.Length)]);
}
}
event cl_PlaySelectEmote() {
if (FRand() > 0.30000001) {                                                 
Emotes.PlayLocalEmote(mSelectEmoteIndices[Rand(mSelectEmoteIndices.Length)]);
}
}
protected function class<Game_HUD> GetGameHUDClass() {
return None;                                                                
}
event cl_OnInit() {
local Game_Controller gc;
Super.cl_OnInit();                                                          
gc = Game_Controller(Controller);                                           
mCharacterID = gc.CharacterID;                                              
mLastUsedTimestamp = gc.DBCharacter.LastUsedTimestamp;                      
mPersistentData.Read();                                                     
}
event OnCreateComponents() {
Super.OnCreateComponents();                                                 
mPersistentData = new (self) Class'Game_PersistentData';                    
CharacterStats.mHealth = 100.00000000;                                      
}
*/