﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class ProceduralSound : Sound
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Sound BaseSound;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float PitchModification;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float VolumeModification;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float PitchVariance;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float VolumeVariance;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float RenderedPitchModification;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float RenderedVolumeModification;
        
        public ProceduralSound()
        {
        }
    }
}