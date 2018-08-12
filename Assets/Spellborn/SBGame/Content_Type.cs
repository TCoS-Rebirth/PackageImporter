using System;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Content_Type : Content_API
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        //[TCosReborn.Framework.Attributes.System.NonSerializedAttribute()]
        //[TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        //public int ResourceId;

        public Content_Type()
        {
        }

        public enum EContentHook
        {
            ECH_None,

            ECH_Kill,

            ECH_Defeat,

            ECH_Interact,

            ECH_Converse,

            ECH_Trigger,

            ECH_Eradicate,

            ECH_Loot,

            ECH_Death,

            ECH_Aggro,

            ECH_Timer,

            ECH_Killed,

            ECH_QuestFinished,

            ECH_Script,

            ECH_Spotted,

            ECH_PvPKill,

            ECH_InventoryUpdate,
        }
    }
}
/*
final native function sv_RemoveHooks(Game_Pawn aPawn);
final native function sv_OnHook(Game_PlayerPawn aPlayerPawn,byte aHookType,Object aObjParam,int aNumParam);
final native function sv_Detach(Game_Pawn aPawn);
final native function sv_Attach(Game_Pawn aPawn);
final function int GetResourceId() {
return ResourceId;                                                          
}
*/