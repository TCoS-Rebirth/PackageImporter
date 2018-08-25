using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Content_Requirement : Content_Type
    {
        public int ControlLocationX;

        public int ControlLocationY;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ControlRef;

        public bool ValidForPlayer;

        public bool ValidForRelevant;

        public virtual bool cl_IsValidFor(Game_Pawn aPawn)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckPawn(Game_Pawn aPawn)
        {
            throw new NotImplementedException();
        }
    }
}
/*
native function GetActorRelations(Actor aSource,out array<ActorRelation> oRelations);
*/