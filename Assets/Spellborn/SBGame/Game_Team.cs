using System;
using System.Collections.Generic;
using Engine;
using UnityEngine;

namespace SBGame
{
    [Serializable] public class Game_Team : UObject
    {
        public List<Game_Pawn> mMembers = new List<Game_Pawn>();

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int ExCleanIndex;

        public Game_Team()
        {
        }
    }
}
/*
function int Members() {
return mMembers.Length;                                                     
}
event RemoveMember(Game_Pawn aMember) {
local int i;
if (aMember != None) {                                                      
i = 0;                                                                    
while (i < mMembers.Length) {                                             
if (mMembers[i] == aMember) {                                           
mMembers.Remove(i,1);                                                 
if (aMember.Controller != None
&& Game_PlayerController(aMember.Controller) != None) {
Game_PlayerController(aMember.Controller).GroupingTeams.mTeam = None;
}
return;                                                               
}
i++;                                                                    
}
}
}
function AddMember(Game_Pawn aMember) {
local int i;
if (aMember != None) {                                                      
i = 0;                                                                    
while (i < mMembers.Length) {                                             
if (mMembers[i] == aMember) {                                           
return;                                                               
}
i++;                                                                    
}
if (aMember.Controller != None
&& Game_PlayerController(aMember.Controller) != None) {
Game_PlayerController(aMember.Controller).GroupingTeams.mTeam = self;   
}
mMembers[mMembers.Length] = aMember;                                      
}
}
native function bool IsMember(Game_Pawn aMember);
*/