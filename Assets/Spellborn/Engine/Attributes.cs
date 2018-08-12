using System;

namespace Engine
{
    public class PackageObjectPropertyAttribute : Attribute
    {

    }

    //public class ReadOnlyAttribute: PropertyAttribute
    //{
    //}

    public class FieldCategoryAttribute : PackageObjectPropertyAttribute
    {
        public string Category { get; set; }

        public FieldCategoryAttribute(string category)
        {
            Category = category;
        }
    }

    public class FieldConstAttribute : PackageObjectPropertyAttribute
    {

    }

    public class FieldConfigAttribute : PackageObjectPropertyAttribute
    {

    }

    public class FieldGlobalConfigAttribute : PackageObjectPropertyAttribute
    {

    }

    public class FieldTransientAttribute : PackageObjectPropertyAttribute
    {

    }

    public class FieldTravelAttribute : PackageObjectPropertyAttribute
    {

    }

    public class FieldDeprecatedAttribute : PackageObjectPropertyAttribute
    {

    }

    public class ArraySizeForExtractionAttribute : PackageObjectPropertyAttribute
    {
        public int Size { get; set; }
    }

    public class TypeProxyDefinition : PackageObjectPropertyAttribute
    {
        public string TypeName { get; set; }
    }
}
