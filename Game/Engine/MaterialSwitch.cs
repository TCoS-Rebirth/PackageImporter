﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;


namespace Engine
{


    public class MaterialSwitch : Modifier
    {
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="MaterialSwitch")]
        [TCosReborn.Framework.Attributes.IgnoreFieldExtractionAttribute()]
        [TCosReborn.Framework.Attributes.FieldTransientAttribute()]
        public int CurrentMaterialIndex;
        
        [TCosReborn.Framework.Attributes.FieldCategoryAttribute(Category="MaterialSwitch")]
        public List<Material> Materials = new List<Material>();
        
        public MaterialSwitch()
        {
        }
    }
}
/*
function Trigger(Actor Other,Actor EventInstigator) {
CurrentMaterialIndex++;                                                     
if (CurrentMaterialIndex >= Materials.Length) {                             
CurrentMaterialIndex = 0;                                                 
}
if (Materials.Length > 0) {                                                 
Material = Materials[CurrentMaterialIndex];                               
} else {                                                                    
Material = None;                                                          
}
if (Material != None) {                                                     
Material.Trigger(Other,EventInstigator);                                  
}
if (FallbackMaterial != None) {                                             
FallbackMaterial.Trigger(Other,EventInstigator);                          
}
}
function Reset() {
CurrentMaterialIndex = 0;                                                   
if (Materials.Length > 0) {                                                 
Material = Materials[0];                                                  
} else {                                                                    
Material = None;                                                          
}
if (Material != None) {                                                     
Material.Reset();                                                         
}
if (FallbackMaterial != None) {                                             
FallbackMaterial.Reset();                                                 
}
}
*/