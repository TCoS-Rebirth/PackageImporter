using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class QT_Escort : Quest_Target
    {
        [FoldoutGroup("Escort")]
        public NameProperty ScriptTag;

        public QT_Escort()
        {
        }
    }
}