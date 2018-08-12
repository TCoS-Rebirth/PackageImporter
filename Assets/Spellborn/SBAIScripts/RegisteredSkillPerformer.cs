using System;
using Engine;

namespace SBAIScripts
{
    [Serializable] public class RegisteredSkillPerformer : RegisteredAI
    {
        public bool Performing;

        public Vector StartLocation;

        public bool Returning;

        public float TickTimer;

        public bool StartWeaponDrawn;

        public RegisteredSkillPerformer()
        {
        }
    }
}