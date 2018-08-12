using System;
using Sirenix.OdinInspector;

namespace Engine
{
    [Serializable] public class Note : Actor
    {
        [FoldoutGroup("Note")]
        public string Text = string.Empty;

        public Note()
        {
        }
    }
}