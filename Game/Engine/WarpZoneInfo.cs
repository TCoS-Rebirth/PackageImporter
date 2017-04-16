﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class WarpZoneInfo : ZoneInfo
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="WarpZoneInfo")]
        public string OtherSideURL = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="WarpZoneInfo")]
        public string ThisTag = string.Empty;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="WarpZoneInfo")]
        public bool bNoTeleFrag;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public int iWarpZone;
        
        [TCosReborn.Framework.Attributes.FieldConstAttribute()]
        public Coords WarpCoords;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public WarpZoneInfo OtherSideActor;
        
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public UObject OtherSideLevel;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="WarpZoneInfo")]
        [TCosReborn.Framework.Attributes.ArraySizeForExtractionAttribute(Size=8)]
        public string[] Destinations = new string[0];
        
        public int numDestinations;
        
        public WarpZoneInfo()
        {
        }
    }
}
/*
event ActorLeaving(Actor Other) {
if (Other.IsA('Pawn')) {                                                    
Pawn(Other).bWarping = False;                                             
}
}
simulated function ActorEntered(Actor Other) {
local Vector L;
local Rotator R;
local Controller P;
if (!Other.bJustTeleported) {                                               
Generate();                                                               
if (OtherSideActor != None) {                                             
Other.Disable('Touch');                                                 
Other.Disable('UnTouch');                                               
L = Other.Location;                                                     
if (Pawn(Other) != None) {                                              
R = Pawn(Other).GetViewRotation();                                    
}
UnWarp(L,Other.Velocity,R);                                             
OtherSideActor.Warp(L,Other.Velocity,R);                                
if (Other.IsA('Pawn')) {                                                
Pawn(Other).bWarping = bNoTeleFrag;                                   
if (Other.SetLocation(L)) {                                           
if (SBRole == 1) {                                                  
P = Level.ControllerList;                                         
while (P != None) {                                               
if (P.Enemy == Other) {                                         
P.LineOfSightTo(Other);                                       
}
P = P.nextController;                                           
}
}
R.Roll = 0;                                                         
Pawn(Other).SetViewRotation(R);                                     
if (Pawn(Other).Controller != None) {                               
Pawn(Other).Controller.MoveTimer = -1.00000000;                   
}
} else {                                                              
GotoState('DelayedWarp');                                           
}
} else {                                                                
Other.SetLocation(L);                                                 
Other.SetRotation(R);                                                 
}
Other.Enable('Touch');                                                  
Other.Enable('UnTouch');                                                
}
}
}
simulated event ForceGenerate() {
if (InStr(OtherSideURL,"/") >= 0) {                                         
OtherSideLevel = None;                                                    
OtherSideActor = None;                                                    
} else {                                                                    
OtherSideLevel = XLevel;                                                  
foreach AllActors(Class'WarpZoneInfo',OtherSideActor) {                   
if (string(OtherSideActor.ThisTag) ~= OtherSideURL
&& OtherSideActor != self) {
} else {                                                                
}
}
}
}
simulated event Generate() {
if (OtherSideLevel != None) {                                               
return;                                                                   
}
ForceGenerate();                                                            
}
function Trigger(Actor Other,Pawn EventInstigator) {
local int nextPick;
if (numDestinations == 0) {                                                 
return;                                                                   
}
nextPick = 0;                                                               
while (nextPick < 8
&& Destinations[nextPick] != OtherSideURL) {      
nextPick++;                                                               
}
nextPick++;                                                                 
if (nextPick > 7 || Destinations[nextPick] == "") {                         
nextPick = 0;                                                             
}
OtherSideURL = Destinations[nextPick];                                      
ForceGenerate();                                                            
}
function PreBeginPlay() {
Super.PreBeginPlay();                                                       
Generate();                                                                 
numDestinations = 0;                                                        
while (numDestinations < 8) {                                               
if (Destinations[numDestinations] != "") {                                
numDestinations++;                                                      
} else {                                                                  
numDestinations = 8;                                                    
}
}
if (numDestinations > 0 && OtherSideURL == "") {                            
OtherSideURL = Destinations[0];                                           
}
}
final native(315) function UnWarp(out Vector loc,out Vector Vel,out Rotator R);
final native(314) function Warp(out Vector loc,out Vector Vel,out Rotator R);
state DelayedWarp {
function Tick(float DeltaTime) {
local Controller P;
local bool bFound;
P = Level.ControllerList;                                               
while (P != None) {                                                     
if (P.Pawn.bWarping && P.Pawn.Region.Zone == self) {                  
bFound = True;                                                      
ActorEntered(P);                                                    
}
P = P.nextController;                                                 
}
if (!bFound) {                                                          
GotoState('None');                                                    
}
}
}
*/
