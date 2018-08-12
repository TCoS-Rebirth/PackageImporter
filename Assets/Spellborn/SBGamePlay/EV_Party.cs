using System;
using System.Collections.Generic;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class EV_Party : Content_Event
    {
        [FoldoutGroup("Action")]
        [FieldConst()]
        public float Range;

        [FoldoutGroup("Action")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();

        [FoldoutGroup("Action")]
        [FieldConst()]
        public Content_Event PartyAction;

        public EV_Party()
        {
        }
    }
}
/*
protected function bool MeetsRequirements(Game_Pawn aPawn) {
local int ri;
ri = 0;                                                                     
while (ri < Requirements.Length) {                                          
if (Requirements[ri] != None
&& !Requirements[ri].CheckPawn(aPawn)) {
return False;                                                           
}
ri++;                                                                     
}
return True;                                                                
}
function sv_Execute(Game_Pawn aObject,Game_Pawn aSubject) {
local Game_Team team;
local Game_Pawn teamMember;
local int ti;
if (MeetsRequirements(aSubject)) {                                          
PartyAction.sv_Execute(aObject,aSubject);                                 
}
team = aSubject.GetTeam();                                                  
if (team != None) {                                                         
ti = 0;                                                                   
while (ti < team.mMembers.Length) {                                       
teamMember = team.mMembers[ti];                                         
if (teamMember != aSubject
&& (Range < 0
|| VSize(teamMember.Location - aSubject.Location) <= Range)
&& MeetsRequirements(teamMember)
&& PartyAction.sv_CanExecute(aObject,aSubject)) {
PartyAction.sv_Execute(aObject,teamMember);                           
}
ti++;                                                                   
}
}
}
function bool sv_CanExecute(Game_Pawn aObject,Game_Pawn aSubject) {
if (PartyAction == None) {                                                  
return False;                                                             
}
if (aSubject == None) {                                                     
return False;                                                             
}
if (!PartyAction.sv_CanExecute(aSubject,aObject)) {                         
return False;                                                             
}
return True;                                                                
}
*/