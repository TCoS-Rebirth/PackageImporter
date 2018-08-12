using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class PlayerStart : SmallNavigationPoint
    {
        [FoldoutGroup("PlayerStart")]
        public byte TeamNumber;

        [FoldoutGroup("PlayerStart")]
        public bool bSinglePlayerStart;

        [FoldoutGroup("PlayerStart")]
        public bool bCoopStart;

        [FoldoutGroup("PlayerStart")]
        public bool bEnabled;

        [FoldoutGroup("PlayerStart")]
        public bool bPrimaryStart;

        [FoldoutGroup("PlayerStart")]
        public string NavigationTag = string.Empty;

        void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Destination.psd", true);
        }
    }
}