﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------



namespace Engine
{


    public class PLSParser : PlaylistParserBase
    {
        
        public PLSParser()
        {
        }
    }
}
/*
function ParseLines() {
local int i;
Super.ParseLines();                                                         
if (Lines.Length == 0) {                                                    
return;                                                                   
}
i = 0;                                                                      
while (i < Lines.Length) {                                                  
if (Left(Lines[i],1) == "[" || Lines[i] == "") {                          
} else {                                                                  
if (PlaylistName == ""
&& Left(Lines[i],InStr(Lines[i],"=")) ~= "PlaylistName") {
PlaylistName = GetValue(Lines[i],True);                               
goto jl00EA;                                                          
}
if (Left(Lines[i],4) ~= "File") {                                       
Paths[Paths.Length] = GetValue(Lines[i],True);                        
}
}
i++;                                                                      
}
}
*/