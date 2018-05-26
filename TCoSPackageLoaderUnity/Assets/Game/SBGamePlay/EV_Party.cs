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
using SBAI;
using SBAIScripts;
using SBBase;
using SBGame;
using SBGamePlay;
using SBMiniGames;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Attributes;

namespace SBGamePlay
{
    
    
    public class EV_Party : Content_Event
    {
        
        [FieldCategory(Category="Action")]
        [FieldConst()]
        public float Range;
        
        [FieldCategory(Category="Action")]
        [FieldConst()]
        public List<Content_Requirement> Requirements = new List<Content_Requirement>();
        
        [FieldCategory(Category="Action")]
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
