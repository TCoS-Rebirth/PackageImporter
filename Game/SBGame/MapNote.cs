﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using Engine;
using TCosReborn.Framework.Common;


namespace SBGame
{


    public class MapNote : SBPackageResource
    {
        
        public const int MAX_TARGETS_SIZE = 8;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=8)]
        public Material[] mTargetMaterials = new Material[0];
        
        public LocalizedString Title;
        
        public LocalizedString Level;
        
        public LocalizedString Information;
        
        public byte Target;
        
        public float X;
        
        public float Y;
        
        public int Id;
        
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=8)]
        public LocalizedString[] TargetTexts = new LocalizedString[0];
        
        public MapNote()
        {
        }
        
        public enum MapNoteTargetEnum
        {
            
            MNTE_NPC ,
            
            MNTE_HostileNPC ,
            
            MNTE_Structure ,
            
            MNTE_Resource ,
            
            MNTE_Custom1 ,
            
            MNTE_Custom2 ,
            
            MNTE_Custom3 ,
            
            MNTE_Custom4,
        }
    }
}
