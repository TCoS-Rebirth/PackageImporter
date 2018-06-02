using System;
using Sirenix.OdinInspector;

namespace Framework.Attributes
{
    public class PackageExtractorAttribute : Attribute
    {

    }

    //public class IgnoreFieldExtractionAttribute : PackageExtractorAttribute
    //{

    //}

    public class FieldCategoryAttribute : PackageExtractorAttribute
    {
        public string Category { get; set; }

        public FieldCategoryAttribute(string category)
        {
            Category = category;
        }
    }

    public class FieldConstAttribute : PackageExtractorAttribute
    {

    }

    public class FieldConfigAttribute : PackageExtractorAttribute
    {

    }

    public class FieldGlobalConfigAttribute : PackageExtractorAttribute
    {

    }

    public class FieldTransientAttribute : PackageExtractorAttribute
    {

    }

    public class FieldTravelAttribute : PackageExtractorAttribute
    {

    }

    public class FieldDeprecatedAttribute : PackageExtractorAttribute
    {

    }

    public class ArraySizeForExtractionAttribute : PackageExtractorAttribute
    {
        public int Size { get; set; }
    }

    public class TypeProxyDefinition : PackageExtractorAttribute
    {
        public string TypeName { get; set; }
    }
}
