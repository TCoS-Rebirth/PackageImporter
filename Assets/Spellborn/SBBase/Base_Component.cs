using System;
using Engine;
using UnityEngine;

namespace SBBase
{
#pragma warning disable 414   

    [Serializable]
    public abstract class Base_Component: UObject
    {
        [NonSerialized] public bool ComponentInitialized;

        public virtual void Initialize(Actor outer)
        {
            Outer = outer;
            ComponentInitialized = true;
        }

        public bool IsPawnComponent()
        {
            return Outer is Base_Pawn;
        }

        public bool IsControllerComponent()
        {
            return Outer is Base_Controller;
        }

        public virtual void Shutdown()
        {
            Outer = null;
            ComponentInitialized = false;
        }

        public bool sv_CanReplicate()
        {
            throw new NotImplementedException();
        }

        public virtual void cl_OnGroupChange(int newGroupFlags)
        {
            throw new NotImplementedException();
        }

        public virtual void cl_OnUpdate()
        {
            throw new NotImplementedException();
        }

    }
}
