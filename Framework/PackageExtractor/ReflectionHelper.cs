using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Engine;
using TCosReborn.Application;
using TCosReborn.Framework.Attributes;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;

namespace TCosReborn.Framework.Utility
{
    static class ReflectionHelper
    {
        #region PackageTypeReflection

        static readonly List<Type> cachedTypes = new List<Type>();

        static readonly Dictionary<string, Type> indexedTypes = new Dictionary<string, Type>();

        static readonly HashSet<string> skippableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "SBEditor.GraphState",
            //"Engine.TerrainInfo",
            "Engine.Sound",
            "Engine.Shader",
            //"Engine.ActionMoveCamera",
            //"Engine.ActionPause",
            //"Engine.TerrainSector",
            //"Engine.Emitter",
            "Engine.SkeletalMesh",
            "Engine.Material",
            "Engine.TexPanner",
            "Engine.Combiner",
            //"Engine.SBMover",
            //"Engine.BeamEmitter",
            //"Engine.xProcMesh",
            "Engine.xWeatherEffect",
            //"Engine.StaticMeshActor",
            //"Engine.StaticMeshInstance",
            "Engine.Light",
            //"Engine.LevelInfo",
            //"Engine.SubActionSceneSpeed",
            "Engine.SBSunlight",
            //"Engine.Polys",
            "Engine.SpriteEmitter",
            "Engine.MeshEmitter",
            "Engine.Projector",
            "Engine.SBProjector",
            "Engine.Texture",
            //"Engine.Model",
            //"Engine.StaticMesh",
            //"Engine.Camera",
            //"SBGamePlay.TooltipActor",
            //"Gameplay.WaterVolume",
            "Engine.SBAudioPlayer",
            "SBGamePlay.SBAudioPlayer",
            "SBGamePlay.SBAudioDamper",
            "SBParticles.TopicFinishEmitter",
            "SBParticles.Fire_calm_orange_xl_a",
            "SBParticles.Fire_wild_orange_xl_b",
            "SBParticles.Fire_calm_orange_s",
            "SBParticles.Fire_calm_orange_xs",
            "SBParticles.Fire_wild_orange_xs",
            "SBParticles.Fire_calm_blue_s",
            "SBParticles.Fire_calm_orange_l_a",
            "SBParticles.Fire_wild_orange_s",
            "SBParticles.Fire_calm_orange_xxl_a",
            "SBParticles.Fire_calm_orange_m_a",
            "SBParticles.GreenSmokePuffEmitter",
            "SBParticles.ExplosionLargeEmitter",
            "Engine.AntiPortalActor",
            "SBParticles.Fire_calm_orange_m_c",
            "SBGamePlay.SBInfluenceCapsule",
            "SBGamePlay.SBInfluenceSphere",
            "SBParticles.AshadoriaSpirit_Floating_Emitter",
            "SBParticles.Fire_calm_yellow_xs",
            "SBParticles.Fire_calm_yellow_s",
            "SBParticles.Fire_calm_blue_l_a",
            "SBParticles.Fire_calm_orange_l_b",
            "SBParticles.Fire_calm_orange_x_b",
            "SBParticles.Fire_calm_orange_xl_b",
            "SBParticles.Fire_calm_orange_m_b",
            "SBParticles.Fire_calm_orange_xxl_b",
            "SBParticles.Fire_wild_orange_m_a",
            "Engine.MaterialSwitch",
            "SBGame.DayNightCycleKeyframe"
        };

        public static FieldInfo FindField(object target, string fieldName)
        {
            var field = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            if (field == null)
            {
                field = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase);
            }
            return field;
        }

        public static void TrySetFieldValue(object activeObject, FieldInfo targetField, object propValue, int arrayIndex, Action<ImportLink> registerLink)
        {
            var link = propValue as ImportLink;
            if (link != null)
            {
                link.fieldReference = targetField;
                link.targetReference = activeObject;
                link.indexReference = arrayIndex;
                link.SkipTestClassReference = targetField.FieldType.FullName;
                link.Link = obj => { link.fieldReference.SetValue(link.targetReference, obj); };
                if (!PackageImportResolver.ResolveWithoutLogging(link))
                {
                    registerLink(link);
                }
            }
            else
            {
                try
                {
                    targetField.SetValue(activeObject, propValue);
                }
                catch (Exception e)
                {
                    if (targetField.FieldType.IsArray && targetField.FieldType.GetElementType() == propValue.GetType())
                    {
                        try
                        {
                            var arr = targetField.GetValue(activeObject) as Array;
                            if (arr.Length <= arrayIndex)
                            {
                                var arrResized = Array.CreateInstance(targetField.FieldType.GetElementType(), arrayIndex + 1);
                                arr.CopyTo(arrResized, 0);
                                arr = arrResized;
                            }
                            arr.SetValue(propValue, arrayIndex);
                        }
                        catch (Exception ae)
                        {
                            Logger.LogError(ae.Message);
                        }
                    }
                    else
                    {
                        Logger.LogError(e.Message);
                    }
                }
            }
        }

        public static void TrySetArrayValue(Array array, object arrayContent, int arrayIndex, Type arrayContentType, Action<ImportLink> RegisterDelayedLink)
        {
            var link = arrayContent as ImportLink;
            if (link != null)
            {
                link.indexReference = arrayIndex;
                link.SkipTestClassReference = arrayContentType.FullName;
                link.arrayReference = array;
                link.Link = aobj =>
                {
                    link.arrayReference.SetValue(aobj, link.indexReference);
                };
                if (!PackageImportResolver.ResolveWithoutLogging(link))
                {
                    RegisterDelayedLink(link);
                }
            }
            else
            {
                try
                {
                    array.SetValue(arrayContent, arrayIndex);
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                }
            }
        }

        public static void TrySetListValue(IList list, object listContent, Type listContentType, int listIndex, Action<ImportLink> RegisterDelayedLink)
        {
            var link = listContent as ImportLink;
            if (link != null)
            {
                list.Add(null);
                link.indexReference = listIndex;
                link.SkipTestClassReference = listContentType.FullName;
                link.listReference = list;
                link.Link = aobj =>
                {
                    link.listReference[link.indexReference] = aobj;
                };
                if (!PackageImportResolver.ResolveWithoutLogging(link))
                {
                    RegisterDelayedLink(link);
                }
            }
            else
            {
                list[listIndex] = listContent;
            }
        }

        public static bool CanSkipImport(string className)
        {
            return skippableTypes.Contains(className);
        }

        public static bool CanSkipExport(string className)
        {
            if (className.StartsWith("SBEditor")) return true;
            if (className.StartsWith("SBParticles")) return true;

            return false;
        }

        public static bool IsMarkedAsIgnored(FieldInfo field)
        {
            return field.GetCustomAttribute<IgnoreFieldExtractionAttribute>() != null;
        }

        public static PropertyType GetArrayType(object parentObject, string propertyName, out Type arrayType, out Type arrayContentType)
        {
            if (parentObject == null)
            {
                arrayType = null;
                arrayContentType = null;
                return PropertyType.UnknownProperty;
            }
            var field = parentObject.GetType().GetField(propertyName, BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.FlattenHierarchy|BindingFlags.IgnoreCase);
            if (field == null)
            {
                arrayType = null;
                arrayContentType = null;
                return PropertyType.UnknownProperty;
            }
            if (field.FieldType.IsArray)
            {
                arrayType = field.FieldType;
                arrayContentType = arrayType.GetElementType();
                return GetUPropertyType(arrayContentType);
            }
            else if (field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
            {
                arrayType = field.FieldType;
                arrayContentType = arrayType.GetGenericArguments()[0];
                return GetUPropertyType(arrayContentType);
            }
            arrayType = null;
            arrayContentType = null;
            return PropertyType.UnknownProperty;
        }

        static PropertyType GetUPropertyType(Type type)
        {
            PropertyType t;
            string insideName;
            return FindInnerType(type, out t, out insideName) ? t : PropertyType.UnknownProperty;
        }

        static bool FindInnerType(Type t, out PropertyType pType, out string insideName)
        {
            insideName = "";
            if (t.IsClass)
            {
                if (t == typeof(string))
                {
                    pType = PropertyType.StringProperty;
                    return true;
                }
                if (t == typeof(System.Type))
                {
                    pType = PropertyType.ObjectProperty;
                    insideName = t.Name;
                    return true;
                }
                if (t == typeof(NameProperty))
                {
                    pType = PropertyType.NameProperty;
                    insideName = t.Name;
                    return true;
                }
                if (t == typeof(SBResourcePackage))
                {
                    pType = PropertyType.ObjectProperty;
                    insideName = t.Name;
                    return true;
                }
                if (t.IsSubclassOf(typeof(object)))
                {
                    pType = PropertyType.ObjectProperty;
                    insideName = t.Name;
                    return true;
                }
                pType = PropertyType.UnknownProperty; //customStruct?
                insideName = t.Name;
                return false;
            }
            if (t == typeof(int))
            {
                pType = PropertyType.IntegerProperty;
                return true;
            }
            if (t == typeof(float))
            {
                pType = PropertyType.FloatProperty;
                return true;
            }
            if (t == typeof(byte))
            {
                pType = PropertyType.ByteProperty;
                return true;
            }
            if (t.IsEnum)
            {
                pType = PropertyType.ByteProperty;
                insideName = t.Name;
                return true;
            }
            if (t == typeof(bool))
            {
                pType = PropertyType.BooleanProperty;
                return true;
            }
            if (t == typeof(Vector))
            {
                pType = PropertyType.VectorProperty;
                return true;
            }
            if (t == typeof(Rotator))
            {
                pType = PropertyType.RotatorProperty;
                return true;
            }
            if (t.IsValueType & !t.IsPrimitive & !t.IsEnum)
            {
                insideName = t.Name;
                pType = PropertyType.StructProperty;
                return true;
            }
            pType = PropertyType.UnknownProperty;
            return false;
        }

        public static Type GetTypeFromName(string typeName)
        {
            var hardCodedReplacement = CheckReturnHardcodedReplacement(typeName);
            if (hardCodedReplacement != null)
            {
                return hardCodedReplacement;
            }
            if (cachedTypes.Count == 0)
            {
                CacheAssemblyTypes();
            }
            Type indexedResult;
            if (indexedTypes.TryGetValue(typeName, out indexedResult))
            {
                return indexedResult;
            }
            foreach (var type in cachedTypes)
            {
                if (type.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase) || type.FullName.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return null;
        }

        static Type CheckReturnHardcodedReplacement(string lookupName)
        {
            if (lookupName.Equals("Core.Package", StringComparison.OrdinalIgnoreCase)) return typeof(SBResourcePackage);
            return null;
        }

        static void CacheAssemblyTypes()
        {
            var types = Assembly.GetEntryAssembly().GetTypes();
            cachedTypes.Clear();
            cachedTypes.AddRange(types);
            for (var i = 0; i < types.Length; i++)
            {
                var tName = string.Format("{0}.{1}", types[i].Namespace, types[i].Name);
                indexedTypes[tName] = types[i];
            }
        }
        #endregion
    }
}
