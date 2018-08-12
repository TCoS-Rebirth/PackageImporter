using System;
using SBGame;

namespace SBGamePlay
{
    [Serializable] public class Interaction_ChangeMesh : Interaction_Component
    {
        public Interaction_ChangeMesh()
        {
        }
    }
}
/*
function ClOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
Super.ClOnStart(aOwner,aInstigator,aReverse);                               
if (aInstigator != None) {                                                  
if (!aReverse) {                                                          
originalMesh = aOwner.StaticMesh;                                       
aOwner.SetStaticMesh(Mesh);                                             
} else {                                                                  
aOwner.SetStaticMesh(originalMesh);                                     
}
}
}
function SvOnStart(Game_Actor aOwner,Game_Pawn aInstigator,bool aReverse) {
local InteractiveLevelElement ile;
Super.SvOnStart(aOwner,aInstigator,aReverse);                               
ile = InteractiveLevelElement(aOwner);                                      
if (ile != None) {                                                          
if (!aReverse) {                                                          
originalMesh = aOwner.StaticMesh;                                       
aOwner.SetStaticMesh(Mesh);                                             
ile.sv_StartClientSubAction();                                          
} else {                                                                  
aOwner.SetStaticMesh(originalMesh);                                     
ile.sv_StartClientSubAction();                                          
}
}
}
*/