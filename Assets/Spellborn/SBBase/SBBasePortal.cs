using System;
using Engine;
using Sirenix.OdinInspector;

namespace SBBase
{
    [Serializable] public class SBBasePortal : Trigger
    {
        [FoldoutGroup("SBBasePortal")]
        public string NavigationTag = string.Empty;

        public SBBasePortal()
        {
        }
    }
}