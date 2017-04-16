using Engine;

namespace TCosReborn.Framework.Common
{

    public abstract class UState<T> where T:Actor
    {
        public virtual void BeginState(T stateOwner) { }
        public virtual void EndState(T stateOwner) { }
    }
}
