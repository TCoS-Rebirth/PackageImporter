using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class FSkill_EffectClass_AudioVisual_Sound : FSkill_EffectClass_AudioVisual
    {
        [FoldoutGroup("Sound")]
        [FieldConst()]
        public string SoundName = string.Empty;

        [FoldoutGroup("Sound")]
        [FieldConst()]
        public float Volume;

        [FoldoutGroup("Sound")]
        [FieldConst()]
        public float Radius;

        [FoldoutGroup("Sound")]
        [FieldConst()]
        public float Pitch;

        [FoldoutGroup("PlayerSound")]
        [FieldConst()]
        public float PlayerSoundRadius;

        [FoldoutGroup("PlayerSound")]
        [FieldConst()]
        public float PlayerSoundVolume;

        [FoldoutGroup("PlayerSound")]
        [FieldConst()]
        public float PlayerSoundPitch;

        [FoldoutGroup("PlayerSound")]
        [FieldConst()]
        public byte PlayerSound;

        public FSkill_EffectClass_AudioVisual_Sound()
        {
        }
    }
}
/*
private final event bool LoadSound() {
if (Len(SoundName) > 0 && (Sound == None || IsEditor())) {                  
if (ReportedMissingSound && !IsEditor()) {                                
return False;                                                           
}
if (InStr(SoundName,".") != -1) {                                         
Sound = Sound(static.DynamicLoadObject(SoundName,Class'Sound',True));   
}
if (Sound == None) {                                                      
Sound = Sound(static.DynamicLoadObject("sfx_skills." $ SoundName,Class'Sound',True));
if (Sound == None) {                                                    
ReportedMissingSound = True;                                          
return False;                                                         
}
}
}
return True;                                                                
}
final event int PlaySound(Game_Pawn aPawn) {
if (PlayerSound != 80) {                                                    
aPawn.StaticPlaySoundEx(PlayerSound,PlayerSoundRadius,PlayerSoundVolume,PlayerSoundPitch);
}
if (LoadSound()) {                                                          
if (Sound != None) {                                                      
return aPawn.PlaySBSound(Sound,Volume,Pitch,Radius,,Class'SBAudioManager'.4);
}
}
return -1;                                                                  
}
*/