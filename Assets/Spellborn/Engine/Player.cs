using System;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
    [Serializable] public class Player : UObject
    {
        public const int IDC_WAIT = 6;

        public const int IDC_SIZEWE = 5;

        public const int IDC_SIZENWSE = 4;

        public const int IDC_SIZENS = 3;

        public const int IDC_SIZENESW = 2;

        public const int IDC_SIZEALL = 1;

        public const int IDC_ARROW = 0;

        [FieldConst()]
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public PlayerController Actor;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public InteractionMaster InteractionMaster;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public List<Interaction> LocalInteractions = new List<Interaction>();

        public Player()
        {
        }
    }
}