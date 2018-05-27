using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Engine;
using Framework.Attributes;
using TCosReborn;
using UnityEngine;
using Fasterflect;

namespace Framework.PackageExtractor
{
    static class ReflectionHelper
    {
        static readonly List<Type> cachedTypes = new List<Type>();

        static readonly Dictionary<string, Type> indexedTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        static readonly Dictionary<string, Type> typesByName = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        static readonly Dictionary<string, Type> typesByFullName = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        static readonly HashSet<string> sbNamespaces = new HashSet<string>()
        {
            "Engine",
            "Gameplay",
            "SBAI",
            "SBAIScripts",
            "SBBase",
            "SBGame",
            "SBGamePlay",
            "SBMiniGames"
        };

        static readonly HashSet<string> skippableTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "SBEditor.GraphState",
            "Engine.Sound",
            "Engine.Shader",
            "Engine.Emitter",
            "Engine.SkeletalMesh",
            "Engine.Material",
            "Engine.TexPanner",
            "Engine.Combiner",
            "Engine.SBFogMaterial",
            "Engine.Camera",
            "Engine.SBLightColorMaterial",
            "Engine.SBFogColorMaterial",
            "Engine.SkyZoneInfo",
            "Gameplay.RockingSkyZoneInfo",
            "Gameplay.Sunlight",
            "Engine.ConstantColor",
            "Engine.BeamEmitter",
            "Engine.VertexColor",
            "Engine.xWeatherEffect",
            "Engine.Light",
            //"Engine.LevelInfo",
            "Engine.SBSunlight",
            "Engine.SpriteEmitter",
            "Engine.MeshEmitter",
            "Engine.Projector",
            "Engine.SBProjector",
            "Engine.Texture",
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

        static ReflectionHelper()
        {
            CacheAssemblyTypes();
        }

        static void CacheAssemblyTypes()
        {
            var types = Assembly.GetAssembly(typeof(GameEngine)).GetTypes();
            cachedTypes.Clear();
            cachedTypes.AddRange(types.Where(type => sbNamespaces.Contains(type.Namespace)));
            for (var i = 0; i < types.Length; i++)
            {
                var tName = string.Format("{0}.{1}", types[i].Namespace, types[i].Name);
                indexedTypes[tName] = types[i];
                typesByName[types[i].Name] = types[i];
                if (!string.IsNullOrEmpty(types[i].FullName)) typesByFullName[types[i].FullName] = types[i];
            }
        }

        public static FieldInfo FindField(object target, string fieldName)
        {
            var type = target.GetType();
            var field = type.Field(fieldName, Flags.InstanceAnyVisibility);
            if (field == null)
            {
                field = type.Field(fieldName, Flags.InstanceAnyVisibility | Flags.IgnoreCase);
            }
            return field;
        }

        public static void TrySetFieldValue(object activeObject, FieldInfo targetField, object propValue, int arrayIndex, Queue<ImportLink> linkQueue)
        {
            var link = propValue as ImportLink;
            if (link != null)
            {
                link.fieldReference = targetField;
                link.targetReference = activeObject;
                link.indexReference = arrayIndex;
                link.SkipTestClassReference = targetField.FieldType.FullName;
                var isArray = targetField.FieldType.IsArray;
                if (isArray) link.arrayReference = targetField.Get(activeObject) as Array;
                link.Link = obj =>
                {
                    try
                    {
                        if (isArray) link.arrayReference.SetValue(obj, 0);
                        else link.fieldReference.SetValue(link.targetReference, obj);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                };
                if (!CanSkipImport(link.SkipTestClassReference)) linkQueue.Enqueue(link);
            }
            else
            {
                try
                {
                    targetField.SetValue(activeObject, propValue);
                }
                catch (Exception e)
                {
                    if (targetField.FieldType.IsArray)
                    {
                        var elemType = targetField.FieldType.GetElementType();
                        if (elemType == propValue.GetType())
                        {
                            try
                            {
                                var arr = targetField.Get(activeObject) as Array;
                                if (arr.Length <= arrayIndex)
                                {
                                    var arrResized = Array.CreateInstance(elemType, arrayIndex);
                                    arr.CopyTo(arrResized, 0);
                                    arr = arrResized;
                                }
                                arr.SetValue(propValue, arrayIndex);
                            }
                            catch (Exception ae)
                            {
                                Debug.LogException(ae);
                            }
                        }
                        else
                        {
                            Debug.LogException(e);
                        }
                    }
                    else
                    {
                        Debug.Log(string.Format("field: {0} is not an array, unhandled", targetField));
                    }
                }
            }
        }

        public static void TrySetArrayValue(Array array, object arrayContent, int arrayIndex, Type arrayContentType, Queue<ImportLink> linkQueue)
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
                if (!CanSkipImport(link.SkipTestClassReference)) linkQueue.Enqueue(link);
            }
            else
            {
                try
                {
                    array.SetValue(arrayContent, arrayIndex);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public static void TrySetListValue(IList list, object listContent, Type listContentType, int listIndex, Queue<ImportLink> linkQueue)
        {
            var link = listContent as ImportLink;
            if (link != null)
            {
                link.indexReference = listIndex;
                link.SkipTestClassReference = listContentType.FullName;
                link.listReference = list;
                link.Link = aobj =>
                {
                    link.listReference[link.indexReference] = aobj;
                };
                if (!CanSkipImport(link.SkipTestClassReference)) linkQueue.Enqueue(link);
            }
            else
            {
                list[listIndex] = listContent;
            }
        }

        static bool CanSkipImport(string className)
        {
            return skippableTypes.Contains(className);
        }

        public static bool CanSkipExport(string className)
        {
            if (className.StartsWith("SBEditor", StringComparison.Ordinal)) return true;
            if (className.StartsWith("SBParticles", StringComparison.Ordinal)) return true;
            return skippableTypes.Contains(className);
        }

        public static bool IsMarkedAsIgnored(FieldInfo field)
        {
            return field.HasAttribute<IgnoreFieldExtractionAttribute>();
        }

        public static PropertyType GetArrayType(object parentObject, string propertyName, out Type arrayType, out Type arrayContentType)
        {
            if (parentObject == null)
            {
                arrayType = null;
                arrayContentType = null;
                return PropertyType.UnknownProperty;
            }
            var field = parentObject.GetType().Field(propertyName, Flags.InstanceAnyVisibility | Flags.IgnoreCase);
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

        static Dictionary<Type, PropertyType> propertiesByTypeClass = new Dictionary<Type, PropertyType>
        {
            {typeof(string), PropertyType.StringProperty},
            {typeof(Type), PropertyType.ObjectProperty},
            {typeof(NameProperty),PropertyType.NameProperty},
            {typeof(SBResourcePackage), PropertyType.ObjectProperty}
        };

        static Dictionary<Type, bool> useInsideName = new Dictionary<Type, bool>
        {
            {typeof(string), false},
            {typeof(Type), true},
            {typeof(NameProperty), true},
            {typeof(SBResourcePackage), true}
        };

        static Dictionary<Type, PropertyType> propertiesByTypeValue = new Dictionary<Type, PropertyType>()
        {
            {typeof(int), PropertyType.IntegerProperty},
            {typeof(float), PropertyType.FloatProperty},
            {typeof(byte), PropertyType.ByteProperty},
            {typeof(bool), PropertyType.BooleanProperty},
            {typeof(Vector), PropertyType.VectorProperty},
            {typeof(Rotator), PropertyType.RotatorProperty}
        };

        static bool FindInnerType(Type t, out PropertyType pType, out string insideName)
        {
            insideName = "";
            if (t.IsClass)
            {
                if (propertiesByTypeClass.TryGetValue(t, out pType))
                {
                    insideName = useInsideName[t] ? t.Name : string.Empty;
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
            if (propertiesByTypeValue.TryGetValue(t, out pType))
            {
                return true;
            }
            if (t.IsEnum)
            {
                pType = PropertyType.ByteProperty;
                insideName = t.Name;
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
            var type = FindHardcodedReplacement(typeName);
            if (type != null) return type;
            if (indexedTypes.TryGetValue(typeName, out type)) return type;
            if (typesByFullName.TryGetValue(typeName, out type)) return type;
            return typesByName.TryGetValue(typeName, out type) ? type : null;
        }

        public static object CreateInstance(Type t)
        {
            //return t.CreateInstance();
            if (t.IsSubclassOf(typeof(MonoBehaviour)))
            {
                return new GameObject().AddComponent(t);
            }
            return t.CreateInstance();
        }

        static Type FindHardcodedReplacement(string lookupName)
        {
            if (lookupName.Equals("Core.Package", StringComparison.OrdinalIgnoreCase)) return typeof(SBResourcePackage);
            return null;
        }

    }
}
