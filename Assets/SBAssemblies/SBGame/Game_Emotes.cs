﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGame
{
    
    
    [System.Serializable] public class Game_Emotes : Base_Component
    {
        
        public List<Game_Emote> EmoteMappings = new List<Game_Emote>();
        
        public float TimeBetweenSoundsFactor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float SoundTimer;
        
        public Game_Emotes()
        {
        }
        
        [System.Serializable] public struct EmoteMapping
        {
            
            public string Command;
            
            public int AnimIndex;
            
            public byte SoundIndex;
        }
    }
}
/*
protected final function InitSoundTimer(float aBaseTime) {
SoundTimer = aBaseTime * TimeBetweenSoundsFactor;                           
}
protected final function bool CanPlaySound() {
return SoundTimer < 0.01000000;                                             
}
protected native function sv2cl_Emote_CallStub();
protected final event sv2cl_Emote(byte aEmote) {
PlayLocalEmote(aEmote);                                                     
}
protected native function sv2rel_Emote_CallStub();
protected final event sv2rel_Emote(byte aEmote) {
PlayLocalEmote(aEmote);                                                     
}
protected final event sv_Emote(byte aEmote) {
if (Outer.IsDead()) {                                                       
return;                                                                   
}
EmoteMappings[aEmote].OnServerExecute(Outer);                               
}
protected native function cl2sv_Emote_CallStub();
protected final event cl2sv_Emote(byte aEmote) {
if (Outer.IsDead()) {                                                       
return;                                                                   
}
sv2rel_Emote_CallStub(aEmote);                                              
sv_Emote(aEmote);                                                           
}
final event PlayLocalEmote(byte aEmote) {
if (Outer.IsDead()) {                                                       
return;                                                                   
}
if (EmoteMappings[aEmote].AnimIndex >= 0) {                                 
Outer.Emote(EmoteMappings[aEmote].AnimIndex,1.00000000);                  
}
if (EmoteMappings[aEmote].SoundIndex != 80) {                               
if (CanPlaySound()) {                                                     
InitSoundTimer(Outer.StaticPlaySound(EmoteMappings[aEmote].SoundIndex,2048.00000000));
}
}
EmoteMappings[aEmote].OnClientExecute(Outer);                               
}
final native event sv_PlayContentEmote(byte aEmote);
final native event bool cl_PerformEmote(string anEmote);
event cl_OnFrame(float aDeltaTime) {
if (SoundTimer > 0.00000000) {                                              
SoundTimer -= aDeltaTime;                                                 
}
}
*/
