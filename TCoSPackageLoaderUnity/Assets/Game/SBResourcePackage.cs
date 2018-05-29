using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace TCosReborn
{
    [System.Serializable] public class SBResourcePackage: UObject
    {
        [HideInInspector]
        public List<UObject> Resources = new List<UObject>();
    }
}
