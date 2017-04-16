using System;
using System.ComponentModel;
using Engine;
using TCosReborn.Framework.Attributes;
using TCosReborn.Framework.Internal;

namespace TCosReborn.Framework.Common
{
    [Serializable, TypeConverter(typeof(SerializableTypeProxyConverter))]
    public class SerializableTypeProxy
    {
        [SerializeField, Attributes.ReadOnly] string name = string.Empty;
        [SerializeField, HideInInspector] string assemblyQualifiedName = string.Empty;

        public SerializableTypeProxy(Type type)
        {
            name = type.Name;
            assemblyQualifiedName = type.AssemblyQualifiedName;
        }

        public SerializableTypeProxy(string typeName)
        {
            if (typeName.Contains("."))
            {
                var len = typeName.LastIndexOf(".", StringComparison.Ordinal) + 1;
                typeName = typeName.Substring(len, typeName.Length - len);
            }
            name = typeName;
        }

        public Type RetrieveType()
        {
            return Type.GetType(string.IsNullOrEmpty(assemblyQualifiedName) ? name : assemblyQualifiedName);
        }

        public bool IsValid()
        {
            var t = RetrieveType();
            return t != null && t.IsSubclassOf(typeof (UObject));
        }

        public UObject CreateInstanceFromType()
        {
            var t = RetrieveType();
            if (t != null && t.IsSubclassOf(typeof(UObject)))
            {
                return Activator.CreateInstance(t) as UObject;
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }

}
