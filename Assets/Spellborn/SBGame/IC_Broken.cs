using System;

namespace SBGame
{
    [Serializable] public class IC_Broken : Item_Component
    {
        public Item_Type Recipe;

        public IC_Broken()
        {
        }
    }
}
/*
final event int GetRecipePrice() {
local export editinline IC_Recipe recipeComp;
if (Recipe != None) {                                                       
recipeComp = IC_Recipe(Recipe.GetComponentByClass(Class'IC_Recipe'));     
if (recipeComp != None
&& recipeComp.ProducedItem != None) {      
return recipeComp.ProducedItem.GetSellValue() * 0.05000000;             
}
}
return 0;                                                                   
}
function Appearance_Base GetAppearance() {
local export editinline IC_Recipe R;
local export editinline IC_Appearance A;
if (Recipe != None) {                                                       
R = IC_Recipe(Recipe.GetComponentByClass(Class'IC_Recipe'));              
if (R != None && R.ProducedItem != None) {                                
A = IC_Appearance(R.ProducedItem.GetComponentByClass(Class'IC_Appearance'));
if (A != None) {                                                        
return A.Appearance;                                                  
}
}
}
return None;                                                                
}
*/