using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class IC_Resource : Item_Component
    {
        [FoldoutGroup("Key")]
        [FieldConst()]
        public byte ResourceType;

        public IC_Resource()
        {
        }

        public enum EResourceType
        {
            ERT_Wood,

            ERT_Metal,
        }
    }
}