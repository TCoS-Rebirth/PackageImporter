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

namespace SBAI
{
#pragma warning disable 414   
    
    public class MetaControllerManagerComponent : Base_Component
    {
        
        private List<AI_MetaController> mMetaControllers = new List<AI_MetaController>();
        
        public int mControllerMessageMask1;
        
        public int mControllerMessageMask2;
        
        public MetaControllerManagerComponent()
        {
        }
    }
}
/*
protected final native function RecomputeControllerMask();
final native function bool WantMetaControllerMessage(byte aMessage);
function bool HasMetaController(NPC_AI aController) {
local int i;
i = 0;                                                                      
while (i < mMetaControllers.Length) {                                       
if (aController == mMetaControllers[i]) {                                 
return True;                                                            
}
i++;                                                                      
}
return False;                                                               
}
native function RemoveMetaController(AI_MetaController aMetaController);
native function AI_MetaController AddMetaController(AI_MetaController aMetaController);
*/
