using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SBGamePlay
{
    [Serializable] public class SBAudioDamper : SBAudio_Base
    {
        [FoldoutGroup("Damping")]
        public float DampFactor;

        [FoldoutGroup("Damping")]
        public float TimeToDamp;

        [FoldoutGroup("Damping")]
        public List<AudioTypeDamper> AudioTypes = new List<AudioTypeDamper>();

        [FoldoutGroup("Damping")]
        public List<AudioNameDamper> ActorName = new List<AudioNameDamper>();

        [FoldoutGroup("Damping")]
        public List<ExemptActors> Exemptions = new List<ExemptActors>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bIsDamping;

        public SBAudioDamper()
        {
        }

        [Serializable] public struct ExemptActors
        {
            public NameProperty ActorTagName;
        }

        [Serializable] public struct DamperInfo
        {
            public bool Initialized;

            public int FaderID;
        }

        [Serializable] public struct AudioTypeDamper
        {
            public byte AudioType;

            public DamperInfo Info;
        }

        [Serializable] public struct AudioNameDamper
        {
            public NameProperty ActorTagName;

            public DamperInfo Info;
        }
    }
}