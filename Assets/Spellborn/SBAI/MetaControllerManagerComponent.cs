using System;
using System.Collections.Generic;
using SBBase;

namespace SBAI
{
#pragma warning disable 414   

    [Serializable] public class MetaControllerManagerComponent : Base_Component
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