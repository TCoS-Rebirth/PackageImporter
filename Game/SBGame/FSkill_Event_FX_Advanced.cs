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


namespace SBGame
{


    public class FSkill_Event_FX_Advanced : FSkill_Event_FX
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="FX")]
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public List<AdvancedEmitter> Emitters = new List<AdvancedEmitter>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        private List<FX_RunData> AdvRunData = new List<FX_RunData>();
        
        private int EmittersLeftToStart;
        
        public FSkill_Event_FX_Advanced()
        {
        }
        
        public struct AdvancedEmitter
        {
            
            public FSkill_EffectClass_AudioVisual_Emitter Emitter;
            
            public float Delay;
            
            public byte Location;
        }
    }
}
