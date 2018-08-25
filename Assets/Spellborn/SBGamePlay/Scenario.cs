

using Engine;
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SBGamePlay
{
#pragma warning disable 414   
    
    [System.Serializable] public class Scenario : Content_Type
    {
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private List<Actor> mParticipants = new List<Actor>();
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        private Actor mOwner;
        
        [Sirenix.OdinInspector.FoldoutGroup("Scenario")]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();
        
        [Sirenix.OdinInspector.FoldoutGroup("Scenario")]
        public List<NameProperty> ParticipantTags = new List<NameProperty>();
        
        public Scenario()
        {
        }
    }
}
/*
event ForwardEvents(Actor anActor) {
local int i;
if (ParticipantTags.Length > 0) {                                           
if (mParticipants.Length <= 0) {                                          
CollectActors(anActor);                                                 
}
i = 0;                                                                    
while (i < mParticipants.Length) {                                        
mParticipants[i].Trigger(anActor,None);                                 
i++;                                                                    
}
}
}
function bool VerifyRequirements(Game_Pawn aContextPawn) {
local int i;
i = 0;                                                                      
while (i < Requirements.Length) {                                           
if (Requirements[i] == None
|| !Requirements[i].CheckPawn(aContextPawn)) {
return False;                                                           
}
i++;                                                                      
}
return True;                                                                
}
final native function CollectActors(Actor anActor);
*/
