using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class NavigationPoint : Actor
    {
        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bEndPoint;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public bool bTransientEndPoint;

        [FoldoutGroup("NavigationPoint")]
        public bool bOneWayPath;

        [FieldConst()]
        public List<ReachSpec> PathList = new List<ReachSpec>();

        [FoldoutGroup("NavigationPoint")]
        [ArraySizeForExtraction(Size = 4)]
        public NameProperty[] ProscribedPaths = new NameProperty[0];

        [FoldoutGroup("NavigationPoint")]
        [ArraySizeForExtraction(Size = 4)]
        public NameProperty[] ForcedPaths = new NameProperty[0];

        public NavigationPoint()
        {
        }
    }
}
/*
function PlayerToucherDied(Pawn P);
function MoverClosed();
function MoverOpened();
function bool ProceedWithMove(Pawn Other) {
return True;                                                                
}
event bool SuggestMovePreparation(Pawn Other) {
return False;                                                               
}
event float DetourWeight(Pawn Other,float PathWeight);
event bool Accept(Actor Incoming,Actor Source) {
taken = Incoming.SetLocation(Location);                                     
if (taken) {                                                                
Incoming.Velocity = vect(0.000000, 0.000000, 0.000000);                   
Incoming.SetRotation(Rotation);                                           
}
Incoming.PlayTeleportEffect(True,False);                                    
TriggerEvent(Event,self,Pawn(Incoming));                                    
return taken;                                                               
}
event int SpecialCost(Pawn Seeker,ReachSpec Path);
function SetBaseVisibility(int BaseNum) {
local NavigationPoint N;
BaseVisible[BaseNum] = 1;                                                   
N = Level.NavigationPointList;                                              
while (N != None) {                                                         
if (N.BaseVisible[BaseNum] == 0
&& FastTrace(N.Location + (88 - 2 * N.CollisionHeight) * vect(0.000000, 0.000000, 1.000000),Location + (88 - 2 * N.CollisionHeight) * vect(0.000000, 0.000000, 1.000000))) {
N.BaseVisible[BaseNum] = 1;                                             
}
N = N.nextNavigationPoint;                                                
}
}
final native function SetBaseDistance(int BaseNum);
function PostBeginPlay() {
local int i;
ExtraCost = Max(ExtraCost,0);                                               
i = 0;                                                                      
while (i < PathList.Length) {                                               
MaxPathSize.X = FMax(MaxPathSize.X,PathList[i].CollisionRadius);          
MaxPathSize.Z = FMax(MaxPathSize.Z,PathList[i].CollisionHeight);          
i++;                                                                      
}
MaxPathSize.Y = MaxPathSize.X;                                              
Super.PostBeginPlay();                                                      
}
*/