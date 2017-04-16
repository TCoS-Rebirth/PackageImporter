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
using TCosReborn.Framework.Common;


namespace Engine
{


    public class StreamBase : SBPackageResource
    {
        
        public StreamBase()
        {
        }
        
        public struct ID3Field
        {
            
            public int Reference;
            
            public string FieldName;
            
            public string FieldValue;
            
            public byte FieldID;
            
            public byte[] Code;
        }
        
        public struct FilePath
        {
            
            public string FullPath;
            
            public string Directory;
            
            public string fileName;
            
            public string Extension;
            
            public List<string> DirectoryParts;
        }
        
        public enum EStreamPlaylistType
        {
            
            SPT_None ,
            
            SPT_M3U ,
            
            SPT_PLS ,
            
            SPT_B4S,
        }
        
        public enum EFileType
        {
            
            FILE_None ,
            
            FILE_Directory ,
            
            FILE_Log ,
            
            FILE_Ini ,
            
            FILE_Stream ,
            
            FILE_Playlist ,
            
            FILE_Music ,
            
            FILE_Map ,
            
            FILE_Texture ,
            
            FILE_Animation ,
            
            FILE_Static ,
            
            FILE_XML ,
            
            FILE_HTML ,
            
            FILE_Sound ,
            
            FILE_Demo ,
            
            FILE_DivX ,
            
            FILE_Content,
        }
    }
}
/*
function bool HandleDebugExec(string Command,string Param) {
return False;                                                               
}
static function bool CompareNames(string NameA,string NameB) {
if (static.IsCaseSensitive()) {                                             
return NameA == NameB;                                                    
}
return NameA ~= NameB;                                                      
}
final static event byte ConvertToFileType(string Extension) {
local string Ext;
if (Extension == "") {                                                      
return 0;                                                                 
}
Ext = static.ParseExtension(Extension);                                     
if (Ext == "") {                                                            
Ext = Extension;                                                          
}
Ext = Locs(Ext);                                                            
switch (Ext) {                                                              
case "mp3" :                                                              
case "ogg" :                                                              
return 4;                                                               
case "wav" :                                                              
case "umx" :                                                              
return 6;                                                               
case "sbw" :                                                              
return 7;                                                               
case "sba" :                                                              
return 9;                                                               
case "sbs" :                                                              
return 13;                                                              
case "sbt" :                                                              
return 8;                                                               
case "dem" :                                                              
return 14;                                                              
case "sbm" :                                                              
return 10;                                                              
case "ini" :                                                              
return 3;                                                               
case "log" :                                                              
return 2;                                                               
case "avi" :                                                              
return 15;                                                              
case "xml" :                                                              
return 11;                                                              
case "html" :                                                             
case "htm" :                                                              
return 12;                                                              
case "m3u" :                                                              
case "b4s" :                                                              
case "pls" :                                                              
return 5;                                                               
case "sbg" :                                                              
return 16;                                                              
default:                                                                  
return 0;                                                               
}
}
}
final static event string ConvertToFileExtension(byte Type) {
switch (Type) {                                                             
case 2 :                                                                  
return ".log";                                                          
case 3 :                                                                  
return ".ini";                                                          
case 5 :                                                                  
return ".m3u;.pls;.b4s";                                                
case 6 :                                                                  
return ".umx";                                                          
case 7 :                                                                  
return ".sbw";                                                          
case 8 :                                                                  
return ".sbt";                                                          
case 9 :                                                                  
return ".sba";                                                          
case 10 :                                                                 
return ".sbm";                                                          
case 11 :                                                                 
return ".xml";                                                          
case 12 :                                                                 
return ".html;.htm";                                                    
case 13 :                                                                 
return ".sbs";                                                          
case 14 :                                                                 
return ".DEMO4";                                                        
case 15 :                                                                 
return ".avi";                                                          
case 4 :                                                                  
return ".mp3;.ogg";                                                     
case 16 :                                                                 
return ".sbg";                                                          
default:                                                                  
return "";                                                              
}
}
}
final static function string FormatTimeDisplay(coerce float Seconds) {
local int i;
local string TimeString;
i = Seconds / 3600;                                                         
if (i > 0) {                                                                
TimeString = string(i) $ ":";                                             
}
i = Seconds / 60;                                                           
if (TimeString != "" && i < 10) {                                           
}
i = Seconds % 60;                                                           
if (i < 10) {                                                               
}
return TimeString;                                                          
}
final static function int RevInStr(string src,string match) {
local int pos;
local int i;
local string s;
if (src == "" || match == "") {                                             
return -1;                                                                
}
s = src;                                                                    
i = InStr(s,match);                                                         
pos += i;                                                                   
s = Mid(src,pos + 1);                                                       
i = InStr(s,match) + 1;                                                     
if (!i == 0) goto jl003D;                                                   
return pos;                                                                 
}
final static event array<string> ParseDirectories(out string InPath) {
local array<string> Directories;
local string root;
root = static.GetPathRoot(InPath);                                          
Split(InPath,static.GetPathSeparator(),Directories);                        
InPath = "";                                                                
if (root != "") {                                                           
Directories.Insert(0,1);                                                  
Directories[0] = root;                                                    
}
if (static.HasExtension(Directories[Directories.Length - 1])) {             
InPath = Directories[Directories.Length - 1];                             
Directories.Length = Directories.Length - 1;                              
}
return Directories;                                                         
}
final static event string ParseExtension(out string FileNameWithExtension) {
local int i;
local string Ext;
if (FileNameWithExtension == "") {                                          
return "";                                                                
}
i = static.RevInStr(FileNameWithExtension,".");                             
if (i >= 0) {                                                               
Ext = Mid(FileNameWithExtension,i + 1);                                   
}
if (static.ConvertToFileType(Ext) != 0) {                                   
FileNameWithExtension = Left(FileNameWithExtension,i);                    
return Locs(Ext);                                                         
}
return "";                                                                  
}
final static event bool ParsePath(string InPath,out FilePath ParsedPath) {
local int i;
if (InPath == "") {                                                         
return False;                                                             
}
ParsedPath.FullPath = InPath;                                               
i = static.RevInStr(InPath,static.GetPathSeparator());                      
if (i != -1) {                                                              
ParsedPath.Directory = Left(InPath,i + 1);                                
}
ParsedPath.DirectoryParts = static.ParseDirectories(InPath);                
ParsedPath.Extension = static.ParseExtension(InPath);                       
ParsedPath.fileName = InPath;                                               
return ParsedPath.DirectoryParts.Length > 0
|| ParsedPath.Extension != "" && ParsedPath.fileName != "";
}
final static event bool HasExtension(string Test) {
return static.ParseExtension(Test) != "";                                   
}
final static event string GetPathRoot(out string InPath) {
local int i;
local string root;
i = InStr(InPath,static.GetPathSeparator() $ static.GetPathSeparator());    
if (i == -1) {                                                              
i = InStr(InPath,":" $ static.GetPathSeparator());                        
}
if (i != -1) {                                                              
root = Left(InPath,i + 1);                                                
InPath = Mid(InPath,i + 2);                                               
}
return root;                                                                
}
final static native function bool IsCaseSensitive();
final static native function string GetPathSeparator();
final static native operator(44) string *=(out string A,coerce string B);
final static native operator(40) string *(coerce string A,coerce string B);
*/
