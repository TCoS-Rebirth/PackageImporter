using System;
using System.Collections.Generic;
using Engine;
using Sirenix.OdinInspector;

namespace SBGame
{
    [Serializable] public class Quest_Chain : Content_Type
    {
        [FoldoutGroup("Chain")]
        public LocalizedString Name;

        [FoldoutGroup("Chain")]
        public byte QuestArea;

        [FoldoutGroup("Chain")]
        public List<Quest_Type> Quests = new List<Quest_Type>();

        public Quest_Chain()
        {
        }
    }
}
/*
function bool ContainsQuest(export editinline Quest_Type aQuest) {
local int i;
if (aQuest == None) {                                                       
return False;                                                             
}
i = 0;                                                                      
while (i < Quests.Length) {                                                 
if (Quests[i] == aQuest) {                                                
return True;                                                            
}
i++;                                                                      
}
return False;                                                               
}
*/