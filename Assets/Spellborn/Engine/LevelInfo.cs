using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Engine
{
    [Serializable] public class LevelInfo : ZoneInfo
    {
        public static event Action<LevelInfo> OnLevelLoaded;

        public float TimeDilation;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public float TimeSeconds;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Year;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Month;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Day;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int DayOfWeek;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Hour;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Minute;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Second;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public int Millisecond;

        [FieldConst()]
        public float RelativeTimeOfDay;

        [NonSerialized, HideInInspector]
        [FieldTransient()]
        public EnvironmentManager EnvironmentManager;

        [FoldoutGroup("LevelSummary")]
        public string Title = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string Author = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public string Description = string.Empty;

        [FoldoutGroup("LevelSummary")]
        public int IdealPlayerCountMin;

        [FoldoutGroup("LevelSummary")]
        public int IdealPlayerCountMax;

        [FoldoutGroup("LevelSummary")]
        public string ExtraInfo = string.Empty;

        [FoldoutGroup("LevelInfo")]
        public string LevelEnterText = string.Empty;

        public LevelSummary Summary;

        [FieldConst()]
        public NavigationPoint NavigationPointList;

        void Awake()
        {
            if (OnLevelLoaded != null) OnLevelLoaded(this);
        }
    }
}
/*
native function EnvironmentManager GetEnvironmentManager();
function ObjectPool GetObjectPool() {
if (ObjectPool == None) {                                                   
ObjectPool = new (XLevel) Class'ObjectPool';                              
}
return ObjectPool;                                                          
}
native function PlayerController GetLocalPlayerController();
simulated event PreBeginPlay() {
Super.PreBeginPlay();                                                       
ObjectPool = new (XLevel) Class'ObjectPool';                                
}
function Reset() {
DefaultGravity = default.DefaultGravity;                                    
Super.Reset();                                                              
}
function ThisIsNeverExecuted() {
local DefaultPhysicsVolume P;
P = None;                                                                   
}
event ServerTravel(string URL,bool bItems) {
}
native simulated function string GetAddressURL();
final static native function bool IsSoftwareRendering();
final static native function bool IsDemoBuild();
native simulated function string GetLocalURL();
simulated function AddPrecacheStaticMesh(StaticMesh stat) {
local int Index;
if (NetMode == 1) {                                                         
return;                                                                   
}
if (stat == None) {                                                         
return;                                                                   
}
Log("Adding static mesh to precache array: "
$ string(stat));         
Index = Level.PrecacheStaticMeshes.Length;                                  
PrecacheStaticMeshes.Insert(Index,1);                                       
PrecacheStaticMeshes[Index] = stat;                                         
}
simulated function AddPrecacheMaterial(Material mat) {
local int Index;
if (NetMode == 1) {                                                         
return;                                                                   
}
if (mat == None) {                                                          
return;                                                                   
}
Index = Level.PrecacheMaterials.Length;                                     
PrecacheMaterials.Insert(Index,1);                                          
PrecacheMaterials[Index] = mat;                                             
}
simulated event FillPrecacheStaticMeshesArray(bool FullPrecache) {
local Actor A;
if (NetMode == 1) {                                                         
return;                                                                   
}
Log("Starting search for uncached static meshes");                          
foreach AllActors(Class'Actor',A) {                                         
if (!A.bAlreadyPrecachedMeshes || FullPrecache) {                         
A.UpdatePrecacheStaticMeshes();                                         
A.bAlreadyPrecachedMeshes = True;                                       
}
}
Log("Ending search");                                                       
}
simulated function PrecacheAnnouncements();
simulated event FillPrecacheMaterialsArray(bool FullPrecache) {
local Actor A;
if (NetMode == 1) {                                                         
return;                                                                   
}
if (!bSkinsPreloaded || FullPrecache) {                                     
}
foreach AllActors(Class'Actor',A) {                                         
if (!A.bAlreadyPrecachedMaterials || FullPrecache) {                      
A.UpdatePrecacheMaterials();                                            
A.bAlreadyPrecachedMaterials = True;                                    
}
}
}
simulated function PostBeginPlay() {
Super.PostBeginPlay();                                                      
DecalStayScale = Max(DecalStayScale,0);                                     
}
native simulated function PhysicsVolume GetPhysicsVolume(Vector loc);
native simulated function ForceLoadTexture(Texture Texture);
native simulated function UpdateDistanceFogLOD(float LOD);
native simulated function byte GetDetailMode();
native simulated function DetailChange(byte NewDetailMode);
*/