using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class MusicTrigger : Triggers
    {
        [FoldoutGroup("MusicTrigger")]
        public string Song = string.Empty;

        [FoldoutGroup("MusicTrigger")]
        public float FadeInTime;

        [FoldoutGroup("MusicTrigger")]
        public float FadeOutTime;

        [FoldoutGroup("MusicTrigger")]
        public bool FadeOutAllSongs;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool Triggered;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int SongHandle;

        public MusicTrigger()
        {
        }
    }
}
/*
function Trigger(Actor Other,Pawn EventInstigator) {
if (!Triggered) {                                                           
Triggered = True;                                                         
if (FadeOutAllSongs) {                                                    
StopAllMusic(FadeOutTime);                                              
}
SongHandle = PlayMusic(Song,FadeInTime);                                  
} else {                                                                    
Triggered = False;                                                        
if (SongHandle != 0) {                                                    
StopMusic(SongHandle,FadeOutTime);                                      
} else {                                                                  
Log("WARNING: invalid song handle");                                    
}
}
}
*/