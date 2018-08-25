using System;
using Engine;
using SBGame;
using Sirenix.OdinInspector;

namespace SBGamePlay
{
    [Serializable] public class NA_RaceBodyGender : NPC_Appearance
    {
        [FoldoutGroup("Basics")]
        [FieldConst()]
        public byte Gender;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public byte Race;

        [FoldoutGroup("Basics")]
        [FieldConst()]
        public byte Bodytype;

        public NA_RaceBodyGender()
        {
        }
    }
}
/*
event byte GetGender() {
return Gender;                                                              
}
event EditorVerify() {
local bool CheckForFemaleHulky;
local bool CheckForMaleHulky;
local bool CheckForMaleSkinny;
local bool CheckForNonNormalBodyTypes;
local bool CheckForNonNormalGender;
local bool CheckForNonSkinny;
local bool CheckForNonMale;
local bool CheckForNonNormalBodyTypesPlusChild;
switch (Race) {                                                             
case 0 :                                                                  
case 6 :                                                                  
case 7 :                                                                  
case 8 :                                                                  
CheckForFemaleHulky = True;                                             
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
break;                                                                  
case 1 :                                                                  
CheckForFemaleHulky = True;                                             
CheckForMaleHulky = True;                                               
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
break;                                                                  
case 2 :                                                                  
break;                                                                  
case 3 :                                                                  
CheckForFemaleHulky = True;                                             
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
break;                                                                  
case 4 :                                                                  
CheckForFemaleHulky = True;                                             
CheckForMaleSkinny = True;                                              
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
break;                                                                  
case 5 :                                                                  
CheckForFemaleHulky = True;                                             
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
break;                                                                  
case 9 :                                                                  
CheckForNonNormalBodyTypes = True;                                      
CheckForNonNormalGender = True;                                         
CheckForNonSkinny = True;                                               
break;                                                                  
case 10 :                                                                 
CheckForNonMale = True;                                                 
break;                                                                  
case 11 :                                                                 
CheckForNonMale = True;                                                 
CheckForNonNormalBodyTypesPlusChild = True;                             
break;                                                                  
case 12 :                                                                 
CheckForNonMale = True;                                                 
CheckForNonNormalBodyTypes = True;                                      
break;                                                                  
default:                                                                  
}
if (CheckForFemaleHulky && Gender == 1
&& Bodytype == 3) {            
Bodytype = 2;                                                             
}
if (CheckForMaleHulky && Gender == 0
&& Bodytype == 3) {              
Bodytype = 2;                                                             
}
if (CheckForMaleSkinny && Gender == 0
&& Bodytype == 0) {             
Bodytype = 2;                                                             
}
if (CheckForNonNormalBodyTypes && Bodytype >= 4) {                          
Bodytype = 2;                                                             
}
if (CheckForNonNormalGender && Gender >= 2) {                               
Gender = 0;                                                               
}
if (CheckForNonSkinny && Bodytype != 0) {                                   
Bodytype = 0;                                                             
}
if (CheckForNonMale && Gender != 0) {                                       
Gender = 0;                                                               
}
if (CheckForNonNormalBodyTypesPlusChild
&& Bodytype > 4) {            
Bodytype = 2;                                                             
}
}
*/