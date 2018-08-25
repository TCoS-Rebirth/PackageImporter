using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
    [Serializable]
    public class Game_Travel: Base_Component
    {
        [NonSerialized] public int mTravelTimeOut;

        [Serializable]
        public struct TravelDestination
        {
            public string RouteName;
            public string ShardName;
            public string ExteriorMesh;
            public bool AllowRentACabin;
            public int CrewCost;
            public int CabinCost;
        }

        public bool cl_CheckRequirements(List<Content_Requirement> aRequirement, Game_Pawn aPawn)
        {
            for (int i = 0; i < aRequirement.Count; i++)
            {
                if (aRequirement[i] != null && aRequirement[i].cl_IsValidFor(aPawn) && !aRequirement[i].CheckPawn(aPawn))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
/*
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
