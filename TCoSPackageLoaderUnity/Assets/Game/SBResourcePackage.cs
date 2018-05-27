using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace TCosReborn
{
    [System.Serializable] public class SBResourcePackage: UObject
    {
        //public Dictionary<string, UObject> Resources = new Dictionary<string, UObject>(StringComparer.OrdinalIgnoreCase);
        [HideInInspector]
        public List<UObject> Resources = new List<UObject>();
    }
}
