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

        public virtual void sv_OnHook(Game_PlayerPawn aPlayerPawn, EContentHook aHookType, object aObjParam, int aNumParam)
        {
            throw new NotImplementedException();
        }

        public int GetResourceId() { return ResourceID; }
    }
}
/*
final native function sv_RemoveHooks(Game_Pawn aPawn);
final native function sv_Detach(Game_Pawn aPawn);
final native function sv_Attach(Game_Pawn aPawn);
*/