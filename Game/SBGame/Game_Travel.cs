﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBBase;


namespace SBGame
{


    public class Game_Travel : Base_Component
    {
        
        public int mTravelTimeOut;
        
        //public delegate<OnTravelResult> @__OnTravelResult__Delegate;
        
        public Game_Travel()
        {
        }
        
        public struct TravelDestination
        {
            
            public string RouteName;
            
            public string ShardName;
            
            public string ExteriorMesh;
            
            public bool AllowRentACabin;
            
            public int CrewCost;
            
            public int CabinCost;
        }
    }
}
/*
private final native function bool sv_CheckRequirements(array<Content_Requirement> aRequirement,Game_Pawn aPawn);
private event bool cl_CheckRequirements(array<Content_Requirement> aRequirement,Game_Pawn aPawn) {
local int i;
i = 0;                                                                      
while (i < aRequirement.Length) {                                           
if (aRequirement[i] != None
&& aRequirement[i].cl_IsValidFor(aPawn)
&& !aRequirement[i].CheckPawn(aPawn)) {
return False;                                                           
}
i++;                                                                      
}
return True;                                                                
}
protected native function sv2cl_TravelResult_CallStub();
event sv2cl_TravelResult(int Reason) {
OnTravelResult(Reason);                                                     
}
protected native function cl2sv_CancelTravel_CallStub();
native event cl2sv_CancelTravel(string npcName,string Destination);
protected native function cl2sv_TravelTo_CallStub();
native event cl2sv_TravelTo(string npcName,string Destination,bool joinCrew);
native function cl_GetDestinations(string npcName,out array<TravelDestination> Destinations);
protected native function sv2cl_UpdateTimeOut_CallStub();
native event sv2cl_UpdateTimeOut(int travelTimeOut);
delegate OnTravelResult(int Reason);
*/
