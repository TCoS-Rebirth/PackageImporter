using System;
using TCosReborn.Framework.Attributes;

namespace TCosReborn.Framework.Common
{
    public class SBPackageResource
    {
        /// <summary>
        /// SBPackageResource - the reference name in the source package
        /// </summary>
        [ReadOnly]
        public string ReferenceObjectName = "";

        /// <summary>
        /// SBPackageResource - the referenced package in the source package
        /// </summary>
        [ReadOnly]
        public string ReferencePackageName= "";

        /// <summary>
        /// SBPackageResource - the ResourceID of this Object
        /// </summary>
        [ReadOnly]
        public int ResourceID = 0;

        /// <summary>
        /// SBPackageResource - determines if this resource is an external UObject that has to be loaded
        /// </summary>
        [ReadOnly, SerializeField, HideInInspector] public bool IsExternalReference = false;

        /// <summary>
        /// This has to be overridden in child classes
        /// </summary>
        protected virtual void CloneProperties()
        {
            throw new NotImplementedException();
        }

        public SBPackageResource Clone(bool cloneSubObjects)
        {
            var clone = Activator.CreateInstance(GetType()) as SBPackageResource;
            if (cloneSubObjects)
            {
                clone.CloneProperties();
            }
            return clone;
        }
    }
}
