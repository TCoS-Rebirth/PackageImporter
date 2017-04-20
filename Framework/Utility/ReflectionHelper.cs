using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Engine;
using TCosReborn.Framework.Attributes;
using TCosReborn.Framework.Common;
using TCosReborn.Framework.PackageExtractor;
using Console =  System.Console;

namespace TCosReborn.Framework.Utility
{
    static class ReflectionHelper
    {
        #region PackageTypeReflection

        static readonly List<Type> cachedTypes = new List<Type>();

        public static string[] skippableObjects =
        {
            "SBEditor.GraphState",
            "Engine.TerrainInfo",
            "Engine.ActionMoveCamera",
            "Engine.ActionPause",
            "Engine.TerrainSector",
            "Engine.Emitter",
            //"Engine.SBMover",
            "Engine.BeamEmitter",
            "Engine.xProcMesh",
            "Engine.xWeatherEffect",
            "Engine.StaticMeshActor",
            "Engine.StaticMeshInstance",
            "Engine.Light",
            //"Engine.LevelInfo", //HACK reenable once fixed
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
            "Gameplay.WaterVolume",
            "Engine.SBAudioPlayer",
            "SBGamePlay.SBAudioPlayer",
            "SBGamePlay.SBAudioDamper",
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

        public static bool CanBeSkipped(string packageTypeName)
        {
            for (var i = 0; i < skippableObjects.Length; i++)
            {
                if (skippableObjects[i].Equals(packageTypeName, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }

        public static bool CanBeSkipped(Type type)
        {
            var comparableTypeName = string.Format("{0}.{1}", type.Namespace, type.Name);
            for (var i = 0; i < skippableObjects.Length; i++)
            {
                if (skippableObjects[i].Equals(comparableTypeName, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
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

        public static bool ReflectArrayType(string className, string propertyName, out PropertyType pType, out string insideName, object parentObject = null)
        {
            className = className.Replace("\0", string.Empty);
            propertyName = propertyName.Replace("\0", string.Empty);
            var classType = GetTypeFromName(className, parentObject);
            insideName = "";
            if (classType != null)
            {
                var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public);
                for (var i = 0; i < fields.Length; i++)
                {
                    if (!fields[i].Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)) continue;
                    var fType = fields[i].FieldType;
                    Type insideType = null;
                    if (fType.IsArray)
                    {
                        insideType = fType.GetElementType();
                    }
                    else if (fType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        insideType = fType.GetGenericArguments()[0];
                    }
                    if (insideType != null)
                    {
                        return FindInnerType(insideType, out pType, out insideName);
                    }
                    pType = PropertyType.UnknownProperty;
                    return false;
                }
            }
            pType = PropertyType.UnknownProperty;
            return false;
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
                if (t == typeof(SerializableTypeProxy))
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

        public static bool GetFixedArraySize(string className, string propertyName, out int size)
        {
            className = className.Replace("\0", string.Empty);
            propertyName = propertyName.Replace("\0", string.Empty);
            var classType = GetTypeFromName(className);
            if (classType != null)
            {
                var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public);
                for (var i = 0; i < fields.Length; i++)
                {
                    if (!fields[i].Name.Equals(propertyName)) continue;
                    var attributes = fields[i].GetCustomAttributes(typeof(ArraySizeForExtractionAttribute), false);
                    if (attributes.Length > 0)
                    {
                        size = (attributes[0] as ArraySizeForExtractionAttribute).Size;
                        return true;
                    }
                }
            }
            size = 0;
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
            if (parentObject != null)
            {
                var exportedTypes = parentObject.GetType().GetNestedTypes(BindingFlags.Instance|BindingFlags.FlattenHierarchy|BindingFlags.NonPublic|BindingFlags.Public);
                for (var i = 0; i < exportedTypes.Length; i++)
                {
                    if (exportedTypes[i].Name.Equals(typeName, StringComparison.OrdinalIgnoreCase) ||
                        exportedTypes[i].FullName.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                    {
                        return exportedTypes[i];
                    }
                }
            }
            foreach (var type in cachedTypes)
            {
                if (type.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase) || type.FullName.Equals(typeName, StringComparison.OrdinalIgnoreCase))
                {
                    if (type.IsNested && parentObject != null && parentObject.GetType().Namespace != type.Namespace) continue;
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
        }
        #endregion
    }
}
