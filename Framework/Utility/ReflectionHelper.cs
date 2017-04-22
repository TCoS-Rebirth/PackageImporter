using System;
using System.Collections.Generic;
using System.Reflection;
using Engine;
using TCosReborn.Application;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;

namespace TCosReborn.Framework.Utility
{
    static class ReflectionHelper
    {
        #region PackageTypeReflection

        static readonly List<Type> cachedTypes = new List<Type>();

        static readonly Dictionary<string, Type> indexedTypes = new Dictionary<string, Type>();

        static readonly HashSet<string> skippableObjects = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "SBEditor.GraphState",
            "Engine.TerrainInfo",
            "Engine.Shader",
            "Engine.ActionMoveCamera",
            "Engine.ActionPause",
            "Engine.TerrainSector",
            "Engine.Emitter",
            "Engine.SkeletalMesh",
            "Engine.Material",
            "Engine.TexPanner",
            "Engine.Combiner",
            //"Engine.SBMover",
            "Engine.BeamEmitter",
            "Engine.xProcMesh",
            "Engine.xWeatherEffect",
            "Engine.StaticMeshActor",
            "Engine.StaticMeshInstance",
            "Engine.Light",
            //"Engine.LevelInfo",
            "Engine.SubActionSceneSpeed",
            "Engine.SBSunlight",
            "Engine.Polys",
            "Engine.SpriteEmitter",
            "Engine.MeshEmitter",
            "Engine.Projector",
            "Engine.SBProjector",
            "Engine.Texture",
            "Engine.Model",
            "Engine.StaticMesh",
            "Engine.Camera",
            "SBGamePlay.TooltipActor",
            //"Gameplay.WaterVolume",
            "Engine.SBAudioPlayer",
            "SBGamePlay.SBAudioPlayer",
            "SBGamePlay.SBAudioDamper",
            //"SBParticles.TopicFinishEmitter",
            //"SBParticles.Fire_calm_orange_xl_a",
            //"SBParticles.Fire_wild_orange_xl_b",
            //"SBParticles.Fire_calm_orange_s",
            //"SBParticles.Fire_calm_orange_xs",
            //"SBParticles.Fire_wild_orange_xs",
            //"SBParticles.Fire_calm_blue_s",
            //"SBParticles.Fire_calm_orange_l_a",
            //"SBParticles.Fire_wild_orange_s",
            //"SBParticles.Fire_calm_orange_xxl_a",
            //"SBParticles.Fire_calm_orange_m_a",
            //"SBParticles.GreenSmokePuffEmitter",
            //"SBParticles.ExplosionLargeEmitter",
            "Engine.AntiPortalActor",
            //"SBParticles.Fire_calm_orange_m_c",
            "SBGamePlay.SBInfluenceCapsule",
            "SBGamePlay.SBInfluenceSphere",
            //"SBParticles.AshadoriaSpirit_Floating_Emitter",
            //"SBParticles.Fire_calm_yellow_xs",
            //"SBParticles.Fire_calm_yellow_s",
            //"SBParticles.Fire_calm_blue_l_a",
            //"SBParticles.Fire_calm_orange_l_b",
            //"SBParticles.Fire_calm_orange_x_b",
            //"SBParticles.Fire_calm_orange_xl_b",
            //"SBParticles.Fire_calm_orange_m_b",
            //"SBParticles.Fire_calm_orange_xxl_b",
            //"SBParticles.Fire_wild_orange_m_a",
            "Engine.MaterialSwitch",
            "SBGame.DayNightCycleKeyframe"
        };

        public static bool CanBeSkipped(string packageTypeName)
        {
            return skippableObjects.Contains(packageTypeName);
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
                if (t.IsSubclassOf(typeof(object)))
                {
                    pType = PropertyType.ObjectProperty;
                    insideName = t.Name;
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

        public static Type GetTypeFromName(string typeName, object parentObject = null)
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
                    //if (type.IsNested && parentObject != null && parentObject.GetType().Namespace != type.Namespace) continue;
                    if (!type.IsValueType)
                    {
                        bool breakHere = true;
                    }
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
