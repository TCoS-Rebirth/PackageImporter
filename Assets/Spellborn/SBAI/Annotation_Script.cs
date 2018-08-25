using System;

namespace SBAI
{
    [Serializable] public class Annotation_Script : AI_MetaController
    {
        public Annotation_Script()
        {
        }
    }
}
/*
event bool AnnotationDone(Game_AIController aController) {
return True;                                                                
}
event OnDetach(Game_AIController aController,AIPoint aPoint) {
aController.RemoveMetaController(self);                                     
}
event OnAttach(Game_AIController aController,AIPoint aPoint) {
aController.AddMetaController(self);                                        
}
*/