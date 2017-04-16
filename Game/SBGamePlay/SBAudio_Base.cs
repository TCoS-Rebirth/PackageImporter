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
using System.Collections.Generic;


namespace SBGamePlay
{


    public class SBAudio_Base : Actor
    {
        
        public const float SB_AUDIO_INACTIVE_UPDATE_FREQY = 2.3F;
        
        public const float SB_AUDIO_ACTIVE_UPDATE_FREQY = 15F;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="DefaultVolume")]
        public float MaximumRadius;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="DefaultVolume")]
        public float HotspotFactor;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="DefaultVolume")]
        public bool AlwaysUseDefault;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public SBInfluenceVolume DefaultVolume;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Trigger")]
        public byte TriggeredOn;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Trigger")]
        public float TriggerTimer;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Trigger")]
        public float UnTriggerTimer;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float CurrentTriggerTimer;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Influences")]
        public List<string> InfluenceVolumeTags = new List<string>();
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public List<SBInfluenceVolume> InfluenceVolumes = new List<SBInfluenceVolume>();
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="Influences")]
        public bool ShowInfluenceBounds;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Actor LocalListener;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public Box InfluenceBoundingBox;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float TimeToNextUpdate;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public float UpdateTimeDelta;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public byte CurrentState;
        
        public SBAudio_Base()
        {
        }
        
        public enum SBAudioState
        {
            
            SBAudioState_Idle ,
            
            SBAudioState_Active ,
            
            SBAudioState_Dead,
        }
        
        public enum SBAudioInitializer
        {
            
            SBAudioInit_Proximity ,
            
            SBAudioInit_Event ,
            
            SBAudioInit_Timer,
        }
    }
}
/*
event UnTrigger(Actor Other,Pawn EventInstigator) {
AudioUntrigger(Other,EventInstigator);                                      
}
event Trigger(Actor Other,Pawn EventInstigator) {
AudioTrigger(Other,EventInstigator);                                        
}
final native function AudioUntrigger(Actor Other,Pawn EventInstigator);
final native function AudioTrigger(Actor Other,Pawn EventInstigator);
*/
