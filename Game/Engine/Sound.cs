﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using TCosReborn.Framework.Common;


namespace Engine
{


    public class Sound : SBPackageResource
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float Likelihood;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=48)]
        public byte[] Data = new byte[0];
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public string FileType = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public string fileName = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int OriginalSize;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float Duration;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int Handle;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int flags;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int VoiceCodec;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public float InitialSeekTime;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float BaseRadius;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Sound")]
        public float VelocityScale;
        
        public Sound()
        {
        }
    }
}