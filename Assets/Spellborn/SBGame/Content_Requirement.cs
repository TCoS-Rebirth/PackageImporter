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

        public Content_Requirement()
        {
        }
    }
}
/*
event string ToString();
native function GetActorRelations(Actor aSource,out array<ActorRelation> oRelations);
final native function bool cl_IsValidFor(Game_Pawn aPawn);
final native function bool CheckPawn(Game_Pawn aPawn);
*/