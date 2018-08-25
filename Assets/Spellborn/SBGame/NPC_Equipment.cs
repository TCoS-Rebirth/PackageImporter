using System;

namespace SBGame
{
    [Serializable]
    public class NPC_Equipment: Content_API
    {
        public virtual void ApplyToAppearance(Game_EquippedAppearance app) { throw new NotImplementedException(); }

        public virtual void Apply(Game_Pawn aPawn)
        {
            throw new NotImplementedException();
        }
    }
}