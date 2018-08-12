using System;
using Engine;
using SBBase;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_PlayerInfo : UObject
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public Game_PlayerController mController;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBWorld mDeathWorld;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public SBPortal mDeathPortal;

        public Game_PlayerInfo()
        {
        }
    }
}
/*
function sv_Teleport(SBWorld world,SBPortal Portal) {
local Game_GameServer Engine;
Engine = Game_GameServer(Class'Actor'.static.GetGameEngine());              
Engine.LoginToWorldByID(world.worldID,mController.CharacterID,Portal.Tag,"");
}
function string sv_GetName() {
return sv_GetPawn().Character.sv_GetName();                                 
}
function Game_Pawn sv_GetPawn() {
return Game_Pawn(mController.Pawn);                                         
}
function Game_PlayerController sv_GetController() {
return mController;                                                         
}
*/