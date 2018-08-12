using System;

namespace Engine
{
#pragma warning disable 414   

    [Serializable] public class EnvironmentManager : Actor
    {
        public EnvironmentManager()
        {
        }
    }
}
/*
final native function SetDefaultHUDColor(Color aColor);
event PostBeginPlay() {
if (IsServer() || IsEditor()) {                                             
return;                                                                   
}
SetDrawType(0);                                                             
BuildListOfEnvironmentActors();                                             
}
final native function AddEffect(EnvironmentEffect effect);
final native function BuildListOfEnvironmentActors();
*/