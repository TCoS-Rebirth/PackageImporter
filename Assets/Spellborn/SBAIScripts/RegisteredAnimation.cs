using System;

namespace SBAIScripts
{
    [Serializable] public class RegisteredAnimation : RegisteredAI
    {
        public bool IsAnimating;

        public bool HadWeaponDrawn;

        public bool InCorrectCombatMode;

        public int AnimationCount;

        public float Timeout;

        public RegisteredAnimation()
        {
        }
    }
}