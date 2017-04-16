﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;


namespace Engine
{


    public class Texture : BitmapMaterial
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Texture")]
        public Palette Palette;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Texture")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Material Detail;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Texture")]
        public float DetailScale;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color MipZero;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Color MaxColor;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public int[] InternalTime = new int[0];
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Texture DetailTexture;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Texture EnvironmentMap;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte EnvMapTransformType;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float Specular;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Surface")]
        public bool bMasked;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Surface")]
        public bool bAlphaTexture;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Surface")]
        public bool bTwoSided;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Quality")]
        private bool bHighColorQuality;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Quality")]
        private bool bHighTextureQuality;
        
        private bool bRealtime;
        
        private bool bParametric;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private bool bRealtimeChanged;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        private bool bHasComp;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Texture")]
        public byte LODSet;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Texture")]
        public int NormalLOD;
        
        public int MinLOD;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int MaxLOD;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        public Texture AnimNext;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Texture AnimCurrent;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        public byte PrimeCount;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte PrimeCurrent;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        public float MinFrameRate;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Animation")]
        public float MaxFrameRate;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float Accumulator;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        private List<int> Mips = new List<int>();
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public byte CompFormat;
        
        public byte PS2FirstMip;
        
        public byte PS2NumMips;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int RenderInterface;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=2)]
        public int[] @__LastUpdateTime = new int[0];
        
        public Texture()
        {
        }
        
        public enum ELODSet
        {
            
            LODSET_None ,
            
            LODSET_World ,
            
            LODSET_PlayerSkin ,
            
            LODSET_WeaponSkin ,
            
            LODSET_Terrain ,
            
            LODSET_Interface ,
            
            LODSET_RenderMap ,
            
            LODSET_Lightmap,
        }
        
        public enum EEnvMapTransformType
        {
            
            EMTT_ViewSpace ,
            
            EMTT_WorldSpace ,
            
            EMTT_LightSpace,
        }
    }
}
/*
native function Color GetPalColorAtIndex(byte PixelIndex);
*/
