using System;
using System.Collections;
using System.Reflection;

namespace TCosReborn.Framework.PackageExtractor
{
    public class ImportLink
    {
        public object targetReference;
        public FieldInfo fieldReference;
        public Array arrayReference;
        public IList listReference;
        public int indexReference;
        public string AbsoluteObjectReference;
        public Action<object> Link;
        public bool IsTypeReference;
        public string SkipTestClassReference = string.Empty;

        public ImportLink(string objectRef, Action<object> link)
        {
            AbsoluteObjectReference = objectRef;
            Link = link;
        }
    }
}
