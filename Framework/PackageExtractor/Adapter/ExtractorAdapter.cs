using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Engine;
using TCosReborn.Framework.Common;
using LocalizedString = TCosReborn.Framework.Common.LocalizedString;

namespace TCosReborn.Framework.PackageExtractor.Adapter
{
    public abstract class ExtractorAdapter
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        static readonly char[] commaSplit = { ',' };
        static readonly char[] dotSplit = { '.' };

        protected void Log(string msg)
        {
            Debug.Log(msg);
        }

        #region Tests     
        /*
        protected bool TestPackage(PackageWrapper wrapper, bool allowActors = false)
        {
            Log("Testing: " + wrapper.Name, Color.white);
            if (!TestClassAvailability(wrapper, allowActors))
            {
                Log(string.Format("Package {0} is missing classes", wrapper.Name), Color.red);
                return false;
            }
            foreach (var wpo in wrapper.IterateObjects())
            {
                if (!TestFields(wpo))
                {
                    Log(string.Format("Class {0} is missing fields", wpo.Name), Color.red);
                    return false;
                }
            }
            return true;
        }

        protected bool TestFields(WrappedPackageObject wpo)
        {
            var type = GetTypeFromName(GetClassName(wpo));
            var valid = true;
            var fieldInfos = new List<FieldInfo>(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy));
            foreach (var prop in wpo.sbObject.IterateProperties())
            {
                var propName = prop.Name.Replace("\0", string.Empty);
                var found = false;
                foreach (var fieldInfo in fieldInfos)
                {
                    if (fieldInfo.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Log(string.Format("Class: {0} is missing field: {1}", GetClassName(wpo), propName), Color.red);
                    valid = false;
                }
            }
            return valid;
        }

        protected bool TestClassAvailability(PackageWrapper wrapper, bool allowActors = false)
        {
            foreach (var wpo in wrapper.IterateObjects())
            {
                var cName = GetClassName(wpo);
                var type = GetTypeFromName(cName);
                if (type == null)
                {
                    Log(string.Format("Class '{0}' not found", cName), Color.red);
                    return false;
                }
                if (!type.IsSubclassOf(typeof(SBPackageResource))) //base objects have to be sbresource type
                {
                    if (allowActors && type.IsSubclassOf(typeof (Actor)))
                    {
                        continue;
                    }
                    Log(string.Format("Class {0} is not a subclass of {1}", cName, typeof(SBPackageResource).Name), Color.red);
                    return false;
                }
            }
            return true;
        }*/

        #endregion

        
        #region Helper

            protected static string GetClassName(SBObject sbo)
        {
            var cName = sbo.ClassName.Replace("\0", string.Empty);
            if (cName.Contains("."))
            {
                var lastStart = cName.LastIndexOf(".", StringComparison.Ordinal) + 1;
                cName = cName.Substring(lastStart, cName.Length - lastStart);
            }
            return cName;
        }

       
        static string[] packageNames =
        {
            "AppearanceSetGP","ArioniteAppearanceGP","BotGAppearanceGP","DaeviAppearanceGP","DemonArmyAppearanceGP","ForgeOfWisdomAppearanceGP","GuildAppearanceGP",
            "HumanAppearanceGP","NPCAppearanceGP","OustedAppearanceGP","ShunnedAppearanceGP","SpeyrFolkAppearanceGP","UrgarutAppearanceGP","UrvhailAppearanceGP",
            "VhuulAppearanceGP","ArioniteClassesGP","ArioniteSkilldeckGP","Art_Test_NPC_nonGP","BrotherhoodClassesGP","BrotherhoodSkilldeckGP","CaverndwellerClassesGP",
            "CaverndwellerSkilldeckGP","CIV_NPCs_DeadspellStormGP","CIV_NPCs_MountOfHeroesGP","CIV_NPCs_ParliamentGP","CIV_NPCs_QuarterstoneGP","CIV_NPCs_RingfellGP",
            "ConversationsGP","DemonarmyforcesClassesGP","DemonarmyforcesSkilldeckGP","EnclaveClassesGP","EnclaveClassesSpiritGP","EnclaveGuardClassesGP",
            "ForgeofwisdomBotenleiClassesGP","ForgeofwisdomClassesGP","ForgeofwisdomGlaspailClassesGP","ForgeofWisdomSkilldeckGP","HouseSkullSpiritsGP",
            "HouseSkullSpiritsSkilldeckGP","HowlerClassesGP","HowlerSkilldeckGP","LowervailyriansClassesGP","LowerVailyriansSkilldeckGP","NPCgroupsGP",
            "NPCSheetsGP","NPCStatsGP","NPCTaxonomyGP","OustedClassesGP","OustedSkilldeckGP","PetClassesGP","PetSkilldecksGP","QuestNPCs_AncestralGP",
            "QuestNPCs_Ancestral_SkilldecksGP","QuestNPCs_CarnyxGP","QuestNPCs_DeadspellStormGP","QuestNPCs_DeadspellStorm_SkilldecksGP","QuestNPCs_MountOfHeroesGP",
            "QuestNPCs_ParliamentGP","QuestNPCs_Parliament_SkilldecksGP","QuestNPCs_QuarterstoneGP","QuestNPCs_Quarterstone_SkilldecksGP","QuestNPCs_RingfellGP",
            "QuestNPCs_Ringfell_SkilldecksGP","QuestNPCs_TechGP","ShunnedClassesGP","ShunnedSkilldeckGP","SpeyrfolkBerserkerClassesGP","SpeyrfolkClassesGP","SpeyrFolkSkilldeckGP",
            "UrvhailClassesGP","UrvhailSkilldeckGP","VhuulClassesGP","VhuulSkilldeckGP","WatercreatureClassesGP","WatercreaturesSkilldeckGP","WildlifeClassesGP",
            "WildLifeSkillldecksGP","ItemsArmorBeltGP","ItemsArmorChestGP","ItemsArmorHeadGearGP","ItemsArmorLeftGauntletGP","ItemsArmorLeftShinGP","ItemsArmorLeftShoulderGP",
            "ItemsArmorLeftThighGP","ItemsArmorRightGauntletGP","ItemsArmorRightShinGP","ItemsArmorRightShoulderGP","ItemsArmorRightThighGP","ItemsBodySlotGP","ItemsBrokenGP",
            "ItemsClothChestGP","ItemsClothLeftGloveGP","ItemsClothPantsGP","ItemsClothRightGloveGP","ItemsClothShoesGP","ItemsConsumableGP","ItemsContainerExtraInventoryGP",
            "ItemsContainerSuitBagGP","ItemsItemTokenGP","ItemsJewelryNecklaceGP","ItemsJewelryQualityTokenGP","ItemsJewelryRingGP","ItemsMiscellaneousKeyGP",
            "ItemsMiscellaneousLabyrinthKeyGP","ItemsMiscellaneousTicketsGP","ItemsQuestItemGP","ItemsRecipeGP","ItemsResourceGP","ItemsSkillTokenGP","ItemsTrophyGP",
            "ItemsWeaponDoublehandedGP","ItemsWeaponDualWieldingGP","ItemsWeaponOneHandedGP","ItemsWeaponQualityTokenGP","ItemsWeaponRangedGP","ItemsWeaponShieldGP",
            "QuestsAncestralGP","QuestsCarnyxGP","QuestsDeadspellStormGP","QuestsMountOfHeroesGP","QuestsParliamentGP","QuestsQuarterstoneGP","QuestsRingfellGP","QuestsTechGP",
            "ShopsGP","EffectsEventAVGP","EffectsEventGP","EffectsItemAVGP","EffectsItemGP","EffectsMiscGP","EffectsNPCAVGP","EffectsNPCGP","EffectsNPCTypeAVGP",
            "EffectsPlayerAVGP","EffectsPlayerGP","EffectsTestAVGP","EffectsTestGP","SkillsComboGP","SkillsEventGP","SkillsItemGP","SkillsNPCGP","SkillsPlayerGP",
            "SkillsTestGP","HelpArticlesGP","TableLootGP","TableScavengeGP","TableShopStockGP"
        };

        protected static string ExtractObjectName(string fullString)
        {
            var lastIndex = fullString.LastIndexOf(".", StringComparison.Ordinal) + 1;
            if (lastIndex == -1)
            {
                return fullString;
            }
            return fullString.Substring(lastIndex);
        }

        protected static string ExtractPackageName(string fullString)
        {
            var lastIndex = fullString.LastIndexOf(".", StringComparison.Ordinal);
            if (lastIndex == -1)
            {
                return fullString;
            }
            return fullString.Substring(0, lastIndex);
        }

        protected static bool IsExternalReference(string propValue, out string path)
        {
            var propVal = propValue.Replace("\0", string.Empty);
            if (propVal.Contains("."))
            {
                var splits = propVal.Split(dotSplit, StringSplitOptions.RemoveEmptyEntries);
                foreach (var pn in packageNames)
                {
                    if (splits[0].Equals(pn, StringComparison.OrdinalIgnoreCase))
                    {
                        path = propVal;
                        return true;
                    }
                }
            }
            path = "";
            return false;
        }

        protected static SBObject FindInternalReference(string path)
        {
            //TODO fix
            //foreach (var wpo in wrapper.IterateObjects())
            //{
            //    var searchCompareString =
            //        string.Format("{0}.{1}", wpo.sbObject.Package.Replace("\0", string.Empty), wpo.Name).Replace("null.", string.Empty).Replace("Null.", string.Empty);
            //    if (searchCompareString.Equals(path, StringComparison.OrdinalIgnoreCase))
            //    {
            //        return wpo;
            //    }
            //}
            return null;
        }

        protected static int FindResourceID(SBObject sbo, string packageName, SBResourceListing res)
        {
            var path = string.Format("{0}.{1}.{2}", packageName, sbo.Package.Replace("\0", string.Empty), sbo.Name.Replace("\0", string.Empty)).Replace("null.", string.Empty).Replace("Null.", string.Empty);
            return res.GetResourceID(path);
        }

        /*
       

       protected static bool FindSubPackage(List<SBPackageResource> resList, string name, out SBResourcePackage outpkg)
       {
           foreach (var res in resList)
           {
               var path = string.Format("{0}.{1}", res.ReferencePackageName, res.ReferenceObjectName).Replace("null.", string.Empty).Replace("Null.", string.Empty);
               if (path.Equals(name, StringComparison.OrdinalIgnoreCase))
               {
                   outpkg = res as SBResourcePackage;
                   return true;
               }
           }
           outpkg = null;
           return false;
       }

       protected static string GetClassName(WrappedPackageObject wpo)
       {
           return GetClassName(wpo.sbObject);
       }

       protected void SortObjectsIntoSubPackages(List<SBPackageResource> allRes, bool ignoreNotFoundMessage = false)
       {
           for (var i = allRes.Count; i-- > 0;)
           {
               if (allRes[i].IsExternalReference || string.IsNullOrEmpty(allRes[i].ReferencePackageName) || allRes[i].ReferencePackageName.Equals("null", StringComparison.OrdinalIgnoreCase))
               {
                   continue;
               }
               SBResourcePackage outpkg;
               var subPkg = FindSubPackage(allRes, allRes[i].ReferencePackageName, out outpkg);
               if (subPkg == false)
               {
                   if (!ignoreNotFoundMessage)
                   {
                       Log("SubPackage not found: " + allRes[i].ReferencePackageName, Color.red);
                   }
                   continue;
               }
               if (outpkg != null)
               {
                   outpkg.resources.Add(allRes[i]);
               }
           }
       }

       protected void PrintMissingObjects(List<SBPackageResource> res, PackageWrapper wrapper, bool ignoreActors = false)
       {
           foreach (var o in wrapper.IterateObjects())
           {
               var found = false;
               foreach (var resource in res)
               {
                   if (resource.ReferenceObjectName.Equals(o.Name, StringComparison.OrdinalIgnoreCase))
                   {
                       found = true;
                       break;
                   }
               }
               if (!found)
               {
                   if (ignoreActors)
                   {
                       var type = GetTypeFromName(GetClassName(o.sbObject));
                       if (type.IsSubclassOf(typeof (Actor)))
                       {
                           continue;
                       }
                   }
                   Log("Not extracted: " + o.Name, Color.red);
               }
           }
           foreach (var packageResource in res)
           {
               if (!EditorUtility.IsPersistent(packageResource))
               {
                   Log("Some resources in the package are not persistent!", Color.red);
                   return;
               }
           }
       }
       */
        #endregion


        #region TypeHelper

        /// <summary>
        /// returns true if conversion was handled
        /// </summary>
        protected bool CustomConvertType(Type desiredType, string source, out object value)
        {
            if (desiredType == typeof(Vector))
            {
                var splits = source.Split(commaSplit, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Length == 3)
                {
                    var vec = new Vector();
                    float.TryParse(splits[0], out vec.X);
                    float.TryParse(splits[1], out vec.Y);
                    float.TryParse(splits[2], out vec.Z);
                    value = vec;
                    //value = UnitConversion.ToUnity(vec);
                    return true;
                }
                value = new Vector();
                Log("Couldn't correctly convert Vector3: " + source);
                return true;
            }
            if (desiredType == typeof(Rotator))
            {
                var splits = source.Split(commaSplit, StringSplitOptions.RemoveEmptyEntries);
                if (splits.Length == 3)
                {
                    var vec = new Rotator();
                    int.TryParse(splits[0], out vec.Pitch);
                    int.TryParse(splits[1], out vec.Yaw);
                    int.TryParse(splits[2], out vec.Roll);
                    //value = UnitConversion.ToUnity(vec);
                    value = vec;
                    return true;
                }
                value = new Rotator();
                Log("Couldn't correctly convert Rotator: " + source);
                return true;
            }
            value = null;
            return false;
        }

        protected Object CreateInstanceFromType(Type t, ResourceStash saveStash)
        {
            if (t.IsSubclassOf(typeof(SBPackageResource)))
            {
                var ret = Activator.CreateInstance(t) as SBPackageResource;
                var existing = saveStash.Add(ret);
                if (existing != null)
                {
                    Log("this line should not be printed");
                }
                return ret;
            }
            if (t.IsSubclassOf(typeof(MonoBehaviour)))
            {
                Log("Fieldtype (" + t.Name + ") is a subclass of MonoBehaviour, not extractable!");
                return null;
            }
            if (!t.IsSerializable)
            {
                Log("Fieldtype (" + t.Name + ") is not serializable, not extracting!");
                return null;
            }
            return Activator.CreateInstance(t);
        }

        protected Type GetTypeFromName(string name)
        {
            var hardCodedReplacement = CheckReturnHardcodedReplacement(name);
            if (hardCodedReplacement != null)
            {
                return hardCodedReplacement;
            }
            if (cachedTypes.Count == 0)
            {
                CacheAssemblyTypes();
            }
            foreach (var type in cachedTypes)
            {
                if (type.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }

            return null;
        }

        readonly List<Type> cachedTypes = new List<Type>();

        static Type CheckReturnHardcodedReplacement(string lookupName)
        {
            if (lookupName.Equals("Package", StringComparison.OrdinalIgnoreCase)) return typeof(SBResourcePackage);
            return null;
        }


        void CacheAssemblyTypes()
        {
            cachedTypes.Clear();
            cachedTypes.AddRange(Assembly.GetAssembly(typeof(LocalizedString)).GetTypes().Where(type => type.Namespace!="Pathfinding"));
        }
        #endregion

        protected class ResourceStash
        {
            List<SBPackageResource> stash = new List<SBPackageResource>();

            public SBPackageResource Add(SBPackageResource sbp)
            {
                if (sbp.IsExternalReference)
                {
                    stash.Add(sbp);
                }
                else
                {
                    if (sbp.ReferenceObjectName.Length == 0 & sbp.ReferenceObjectName.Length == 0) //subasset
                    {
                        stash.Add(sbp);
                    }
                    else
                    {
                        SBPackageResource existing;
                        if (IsPartOfStash(sbp, out existing))
                        {
                            return existing;
                        }
                        stash.Add(sbp);
                    }
                }
                return null;
            }

            bool IsPartOfStash(SBPackageResource sbp, out SBPackageResource existing)
            {
                for (int i = 0; i < stash.Count; i++)
                {
                    if (stash[i].ReferencePackageName == sbp.ReferencePackageName & stash[i].ReferenceObjectName == sbp.ReferenceObjectName &
                        stash[i].ResourceID == sbp.ResourceID)
                    {
                        //Debug.Log("already part of the stash: " + stash[i].ReferenceObjectName + " / " + stash[i].ReferencePackageName);
                        existing = stash[i];
                        return true;
                    }
                }
                existing = null;
                return false;
            }

            public bool TryGetObject(string name, string package, out SBPackageResource sbp)
            {
                for (int i = 0; i < stash.Count; i++)
                {
                    if (stash[i].IsExternalReference) continue;
                    if (stash[i].ReferencePackageName == package & stash[i].ReferenceObjectName == name)
                    {
                        sbp = stash[i];
                        return true;
                    }
                }
                sbp = null;
                return false;
            }

            public IEnumerable<SBPackageResource> AllObjects()
            {
                foreach (var value in stash)
                {
                    yield return value;
                }
            }
        }

    }

}