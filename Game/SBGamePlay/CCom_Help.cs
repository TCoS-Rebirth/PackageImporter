﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using SBGame;


namespace SBGamePlay
{


    public class CCom_Help : Game_ConsoleCommand
    {
        
        public CCom_Help()
        {
        }
    }
}
/*
function bool Execute(Game_Pawn aPawn,array<string> Params,Game_Pawn aTarget) {
local string output;
local Game_ConsoleCommand comObj;
if (Params.Length >= 2) {                                                   
foreach AllObjects(Class'Game_ConsoleCommand',comObj) {                   
if (comObj.Matches("/" $ Params[1])) {                                  
output = comObj.Command;                                              
if (comObj.Alias != "") {                                             
}
if (comObj.HelpText.Text != "") {                                     
} else {                                                              
}
ChatResponse(aPawn,output);                                           
return True;                                                          
}
}
ChatResponse(aPawn,Class'SBGamePlayStrings'.default.No_help_found.Text);  
return True;                                                              
goto jl014E;                                                              
}
foreach AllObjects(Class'Game_ConsoleCommand',comObj) {                     
}
ChatResponse(aPawn,output);                                                 
return True;                                                                
}
*/
