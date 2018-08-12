using System;
using Engine;

namespace SBGame
{
    [Serializable] public class StaticPawnSounds : UObject
    {
        public StaticPawnSounds()
        {
        }
    }
}
/*
static native function StopSound(Game_Pawn aPawn,byte ASound);
static native function float PlayDamageSound(Game_Pawn aPawn,float aDamage,float aRadius);
static native function float PlaySoundEx(Game_Pawn aPawn,byte ASound,float aRadius,float aVolume,float aPitch);
static native function float PlaySound(Game_Pawn aPawn,byte ASound,float aRadius);
*/