#pragma warning disable 414
using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using TCosReborn.Framework.Attributes;

namespace TCosReborn.Framework.Common
{
    public class AppearanceSets : UObject
    {
        public List<AppearanceSet> sets = new List<AppearanceSet>();

        static AppearanceSets instance;

        public static AppearanceSets Instance
        {
            get
            {
                Debug.LogError("fixit!");
                //if (instance != null) return instance;
                //instance = Resources.Load<AppearanceSets>("AppearanceSets");
                //if (instance != null) return instance;
                //Debug.LogError("AppearanceSets could not be loaded");
                //instance = CreateInstance<AppearanceSets>();
                return instance;
            }
        }

        public int GetSetIndex(int resourceID)
        {
            for (var i = 0; i < sets.Count; i++)
            {
                for (var j = 0; j < sets[i].items.Count; j++)
                {
                    if (sets[i].items[j].ItemID == resourceID) return sets[i].items[j].index;
                }
            }
            return 0;
        }

        public int GetSetIndex(int resourceID, SBGameEnums.EquipmentSlot slot)
        {
            for (var i = 0; i < sets.Count; i++)
            {
                if (sets[i].slot != slot) continue;
                for (var j = 0; j < sets[i].items.Count; j++)
                {
                    if (sets[i].items[j].ItemID == resourceID) return sets[i].items[j].index;
                }
                return 0;
            }
            return 0;
        }

        public int GetItemIDFromSetIndex(int setIndex, SBGameEnums.EquipmentSlot slot)
        {
            for (int i = 0; i < sets.Count; i++)
            {
                if (sets[i].slot != slot) continue;
                for (int j = 0; j < sets[i].items.Count; j++)
                {
                    if (sets[i].items[j].index == setIndex)
                    {
                        return sets[i].items[j].ItemID;
                    }
                }
            }
            return 0;
        }

        public void LoadIDs()
        {
            var pkgs = new List<SBResourcePackage>();
            Debug.LogError("fixit! load packages first");
            Func<string, SBPackageResource> FindResource = name =>
            {
                for (int i = 0; i < pkgs.Count; i++)
                {
                    var obj = pkgs[i].FindResource(name, string.Empty);
                    if (obj != null) return obj;
                }
                return null;
            };
            foreach (var set in sets)
            {
                if (set.slot == SBGameEnums.EquipmentSlot.ES_HELMETDETAIL) continue;
                foreach (var setItem in set.items)
                {
                    var parts = setItem.temporaryAppearanceName.Split('.');
                    if (parts.Length > 1)
                    {
                        var race = parts[0].Replace("AppearanceGP", string.Empty);
                        var part = parts[parts.Length - 1];
                        var res = FindResource(string.Format("{0}_{1}", race, part));
                        if (res != null)
                        {
                            setItem.ItemID = res.ResourceID;
                        }
                        else
                        {
                            Debug.Log("Item not found: " + race + "_" + part);
                        }
                    }
                }
            }
        }

        [Serializable]
        public class AppearanceSet
        {
            public List<SetItem> items = new List<SetItem>();

            [SerializeField, HideInInspector] string name = "Set"; //only visual (Inspector)

            public SBGameEnums.EquipmentSlot slot;

            public AppearanceSet()
            {
            }

            public AppearanceSet(SBGameEnums.EquipmentSlot slot)
            {
                this.slot = slot;
                name = slot.ToString();
            }
        }

        [Serializable]
        public class SetItem
        {
            public int index;
            public int ItemID;
            public string temporaryAppearanceName;

            public SetItem(int index, string temporaryName)
            {
                this.index = index;
                temporaryAppearanceName = temporaryName;
            }
        }
    }
}