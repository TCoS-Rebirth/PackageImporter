using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class SubActionSubTitle : MatSubAction
    {
        [FoldoutGroup("SubActionSubTitle")]
        public byte SubTitleMode;

        public SubActionSubTitle()
        {
        }
    }
}