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

        SerializableTypeProxy()
        {

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


        public static implicit operator string(SerializableTypeProxy value)
        {
            return value.assemblyQualifiedName;
        }
        public static implicit operator SerializableTypeProxy(string value)
        {
            return new SerializableTypeProxy() { name = value, assemblyQualifiedName = value };
        }

        public static implicit operator Type(SerializableTypeProxy value)
        {
            return value.RetrieveType();
        }

        public static implicit operator SerializableTypeProxy(Type value)
        {
            return new SerializableTypeProxy(value);
        }

        public Type RetrieveType()
        {
            return Type.GetType(assemblyQualifiedName);
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
