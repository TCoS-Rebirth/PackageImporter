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
using Framework.Attributes;

namespace Engine
{
    
    
    [System.Serializable] public class HUD : Actor
    {
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public PlayerController PlayerOwner;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public Pawn PawnOwner;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public Console PlayerConsole;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color WhiteColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color RedColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color GreenColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color CyanColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color BlueColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color GoldColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color PurpleColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color TurqColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color GrayColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color BlackColor;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public bool bHideHUD;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public bool bShowDebugInfo;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public bool bMessageBeep;
        
        public bool bNoEnemyNames;
        
        public bool bShowLocalStats;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color ConsoleColor;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public string ProgressFontName = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public Font ProgressFontFont;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public string OverrideConsoleFontName = string.Empty;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public Font OverrideConsoleFont;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float ProgressFadeTime;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float HudScale;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float HudOpacity;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float HudCanvasScale;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public int CrosshairStyle;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float CrosshairScale;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float CrosshairOpacity;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        [System.NonSerialized, UnityEngine.HideInInspector]
        public Color CrossHairColor;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float ResScaleX;
        
        [System.NonSerialized, UnityEngine.HideInInspector]
        [FieldTransient()]
        public float ResScaleY;
        
        public int ConsoleMessageCount;
        
        public int ConsoleFontSize;
        
        public int MessageFontOffset;
        
        [ArraySizeForExtraction(Size=8)]
        public ConsoleMessage[] TextMessages = new ConsoleMessage[0];
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float ConsoleMessagePosX;
        
        [Sirenix.OdinInspector.FoldoutGroup("HUD")]
        public float ConsoleMessagePosY;
        
        [ArraySizeForExtraction(Size=9)]
        public string[] FontArrayNames = new string[0];
        
        [ArraySizeForExtraction(Size=9)]
        public Font[] FontArrayFonts = new Font[0];
        
        [ArraySizeForExtraction(Size=9)]
        public int[] FontScreenWidthMedium = new int[0];
        
        [ArraySizeForExtraction(Size=9)]
        public int[] FontScreenWidthSmall = new int[0];
        
        [FieldConst()]
        public float LastVoiceGain;
        
        [FieldConst()]
        public float LastVoiceGainTime;
        
        public int LastPlayerIDTalking;
        
        [FieldConst()]
        public float LastPlayerIDTalkingTime;
        
        public SceneSubtitles SubTitles;
        
        public List<HudOverlay> Overlays = new List<HudOverlay>();
        
        public HUD()
        {
        }
        
        [System.Serializable] public struct ConsoleMessage
        {
            
            public string Text;
            
            public Color TextColor;
            
            public float MessageLife;
        }
    }
}
/*
simulated function RemoveHudOverlay(HudOverlay Overlay) {
local int i;
i = 0;                                                                      
while (i < Overlays.Length) {                                               
if (Overlays[i] == Overlay) {                                             
Overlays.Remove(i,1);                                                   
Overlay.SetOwner(None);                                                 
return;                                                                 
}
i++;                                                                      
}
}
simulated function AddHudOverlay(HudOverlay Overlay) {
local int i;
i = 0;                                                                      
while (i < Overlays.Length) {                                               
if (Overlays[i] == Overlay) {                                             
return;                                                                 
}
i++;                                                                      
}
Overlays[Overlays.Length] = Overlay;                                        
Overlay.SetOwner(self);                                                     
}
function DisplayHit(Vector HitDir,int Damage,class<DamageType> DamageType) {
if (PawnOwner != None && PawnOwner.ShieldStrength > 0) {                    
PlayerOwner.ClientFlash(0.50000000,vect(700.000000, 700.000000, 0.000000));
} else {                                                                    
if (Damage > 1) {                                                         
PlayerOwner.ClientFlash(DamageType.default.FlashScale,DamageType.default.FlashFog);
}
}
}
simulated function DrawTargeting(Canvas C);
event AnnouncementPlayed(name AnnouncerSound,byte Switch);
simulated function Font LoadProgressFont() {
if (ProgressFontFont == None) {                                             
ProgressFontFont = Font(static.DynamicLoadObject(ProgressFontName,Class'Font'));
if (ProgressFontFont == None) {                                           
Log("Warning: " $ string(self)
$ " Couldn't dynamically load font "
$ ProgressFontName);
ProgressFontFont = Font'DefaultFont';                                   
}
}
return ProgressFontFont;                                                    
}
static function Font LargerFontThan(Font aFont) {
local int i;
i = 0;                                                                      
while (i < 7) {                                                             
if (LoadFontStatic(i) == aFont) {                                         
return LoadFontStatic(Max(0,i - 4));                                    
}
i++;                                                                      
}
return LoadFontStatic(5);                                                   
}
function Font GetMediumFont(float Size) {
local int i;
i = 0;                                                                      
while (i < 8) {                                                             
if (default.FontScreenWidthMedium[i] <= Size) {                           
return LoadFontStatic(i);                                               
}
i++;                                                                      
}
return LoadFontStatic(8);                                                   
}
static function Font GetMediumFontFor(Canvas Canvas) {
local int i;
i = 0;                                                                      
while (i < 8) {                                                             
if (default.FontScreenWidthMedium[i] <= Canvas.ClipX) {                   
return LoadFontStatic(i);                                               
}
i++;                                                                      
}
return LoadFontStatic(8);                                                   
}
function Font GetFontSizeIndex(Canvas C,int FontSize) {
if (C.ClipX >= 512) {                                                       
FontSize++;                                                               
}
if (C.ClipX >= 640) {                                                       
FontSize++;                                                               
}
if (C.ClipX >= 800) {                                                       
FontSize++;                                                               
}
if (C.ClipX >= 1024) {                                                      
FontSize++;                                                               
}
if (C.ClipX >= 1280) {                                                      
FontSize++;                                                               
}
if (C.ClipX >= 1600) {                                                      
FontSize++;                                                               
}
return LoadFont(Clamp(8 - FontSize,0,8));                                   
}
static function Font GetConsoleFont(Canvas C) {
local int FontSize;
if (default.OverrideConsoleFontName != "") {                                
if (default.OverrideConsoleFont != None) {                                
return default.OverrideConsoleFont;                                     
}
default.OverrideConsoleFont = Font(static.DynamicLoadObject(default.OverrideConsoleFontName,Class'Font'));
if (default.OverrideConsoleFont != None) {                                
return default.OverrideConsoleFont;                                     
}
Log("Warning: HUD couldn't dynamically load font "
$ default.OverrideConsoleFontName);
default.OverrideConsoleFontName = "";                                     
}
FontSize = default.ConsoleFontSize;                                         
if (C.ClipX < 640) {                                                        
FontSize++;                                                               
}
if (C.ClipX < 800) {                                                        
FontSize++;                                                               
}
if (C.ClipX < 1024) {                                                       
FontSize++;                                                               
}
if (C.ClipX < 1280) {                                                       
FontSize++;                                                               
}
if (C.ClipX < 1600) {                                                       
FontSize++;                                                               
}
return LoadFontStatic(Min(8,FontSize));                                     
}
simulated function Font LoadFont(int i) {
if (FontArrayFonts[i] == None) {                                            
FontArrayFonts[i] = Font(static.DynamicLoadObject(FontArrayNames[i],Class'Font'));
if (FontArrayFonts[i] == None) {                                          
Log("Warning: " $ string(self)
$ " Couldn't dynamically load font "
$ FontArrayNames[i]);
}
}
return FontArrayFonts[i];                                                   
}
static function Font LoadFontStatic(int i) {
if (default.FontArrayFonts[i] == None) {                                    
default.FontArrayFonts[i] = Font(static.DynamicLoadObject(default.FontArrayNames[i],Class'Font'));
if (default.FontArrayFonts[i] == None) {                                  
Log("Warning: " $ string(default.Class)
$ " Couldn't dynamically load font "
$ default.FontArrayNames[i]);
}
}
return default.FontArrayFonts[i];                                           
}
simulated function SetCropping(bool Active);
simulated function DrawCrosshair(Canvas C);
simulated function SetTargeting(bool bShow,optional Vector TargetLocation,optional float Size);
function FadeZoom();
function DisplayMessages(Canvas C) {
local int i;
local int j;
local int XPos;
local int YPos;
local int MessageCount;
local float XL;
local float YL;
i = 0;                                                                      
while (i < ConsoleMessageCount) {                                           
if (TextMessages[i].Text == "") {                                         
break;                                                                  
} else {                                                                  
if (TextMessages[i].MessageLife < Level.TimeSeconds) {                  
TextMessages[i].Text = "";                                            
if (i < ConsoleMessageCount - 1) {                                    
j = i;                                                              
while (j < ConsoleMessageCount - 1) {                               
TextMessages[j] = TextMessages[j + 1];                            
j++;                                                              
}
}
TextMessages[j].Text = "";                                            
break;                                                                
goto jl00DC;                                                          
}
MessageCount++;                                                         
}
i++;                                                                      
}
XPos = ConsoleMessagePosX * HudCanvasScale * C.SizeX + (1.00000000 - HudCanvasScale) / 2.00000000 * C.SizeX;
YPos = ConsoleMessagePosY * HudCanvasScale * C.SizeY + (1.00000000 - HudCanvasScale) / 2.00000000 * C.SizeY;
C.Font = GetConsoleFont(C);                                                 
C.DrawColor = ConsoleColor;                                                 
C.TextSize("A",XL,YL);                                                      
YPos -= YL * MessageCount + 1;                                              
YPos -= YL;                                                                 
i = 0;                                                                      
while (i < MessageCount) {                                                  
if (TextMessages[i].Text == "") {                                         
goto jl02C0;                                                            
}
C.StrLen(TextMessages[i].Text,XL,YL);                                     
C.SetPos(XPos,YPos);                                                      
C.DrawColor = TextMessages[i].TextColor;                                  
C.DrawText(TextMessages[i].Text,False);                                   
YPos += YL;                                                               
i++;                                                                      
}
}
simulated function Message(string Message,optional string sender,optional name Type,optional int Range) {
local int i;
i = 0;                                                                      
while (i < ConsoleMessageCount) {                                           
if (TextMessages[i].Text == "") {                                         
goto jl003A;                                                            
}
i++;                                                                      
}
if (i == ConsoleMessageCount) {                                             
i = 0;                                                                    
while (i < ConsoleMessageCount - 1) {                                     
TextMessages[i] = TextMessages[i + 1];                                  
i++;                                                                    
}
}
}
simulated function LinkActors() {
PlayerOwner = PlayerController(Owner);                                      
if (PlayerOwner == None) {                                                  
PlayerConsole = None;                                                     
PawnOwner = None;                                                         
return;                                                                   
}
if (PlayerOwner.Player != None) {                                           
PlayerConsole = PlayerOwner.Player.Console;                               
} else {                                                                    
PlayerConsole = None;                                                     
}
if (Pawn(PlayerOwner.ViewTarget) != None
&& Pawn(PlayerOwner.ViewTarget).GetHealth() > 0) {
PawnOwner = Pawn(PlayerOwner.ViewTarget);                                 
} else {                                                                    
if (PlayerOwner.Pawn != None) {                                           
PawnOwner = PlayerOwner.Pawn;                                           
} else {                                                                  
PawnOwner = None;                                                       
}
}
}
simulated function DrawTypingPrompt(Canvas C,string Text,optional int pos) {
local float XPos;
local float YPos;
local float XL;
local float YL;
C.Font = GetConsoleFont(C);                                                 
C.Style = 5;                                                                
C.DrawColor = ConsoleColor;                                                 
C.TextSize("A",XL,YL);                                                      
XPos = ConsoleMessagePosX * HudCanvasScale * C.SizeX + (1.00000000 - HudCanvasScale) * 0.50000000 * C.SizeX;
YPos = ConsoleMessagePosY * HudCanvasScale * C.SizeY + (1.00000000 - HudCanvasScale) * 0.50000000 * C.SizeY - YL;
C.SetPos(XPos,YPos);                                                        
C.DrawTextClipped("(>" @ Left(Text,pos) $ Chr(4)
$ Eval(pos < Len(Text),Mid(Text,pos),"_"),True);
}
function bool IsInCinematic();
function DisplayBadConnectionAlert(Canvas C);
function bool DrawLevelAction(Canvas C);
function DrawSpectatingHud(Canvas C);
function DrawHUD(Canvas C);
simulated function DisplayProgressMessages(Canvas C) {
local int i;
local int LineCount;
local float FontDX;
local float FontDY;
local float X;
local float Y;
local int Alpha;
local float TimeLeft;
TimeLeft = PlayerOwner.ProgressTimeOut - Level.TimeSeconds;                 
if (TimeLeft >= ProgressFadeTime) {                                         
Alpha = 255;                                                              
} else {                                                                    
Alpha = 255 * TimeLeft / ProgressFadeTime;                                
}
LineCount = 0;                                                              
i = 0;                                                                      
while (i < 4) {                                                             
if (PlayerOwner.ProgressMessage[i] == "") {                               
} else {                                                                  
LineCount++;                                                            
}
i++;                                                                      
}
C.Font = LoadProgressFont();                                                
C.Style = 5;                                                                
C.TextSize("A",FontDX,FontDY);                                              
X = 0.50000000 * HudCanvasScale * C.SizeX + (1.00000000 - HudCanvasScale) / 2.00000000 * C.SizeX;
Y = 0.50000000 * HudCanvasScale * C.SizeY + (1.00000000 - HudCanvasScale) / 2.00000000 * C.SizeY;
Y -= FontDY * LineCount / 2.00000000;                                       
i = 0;                                                                      
while (i < 4) {                                                             
if (PlayerOwner.ProgressMessage[i] == "") {                               
} else {                                                                  
C.DrawColor = PlayerOwner.ProgressColor[i];                             
C.DrawColor.A = Alpha;                                                  
C.TextSize(PlayerOwner.ProgressMessage[i],FontDX,FontDY);               
C.SetPos(X - FontDX / 2.00000000,Y);                                    
C.DrawText(PlayerOwner.ProgressMessage[i]);                             
Y += FontDY;                                                            
}
i++;                                                                      
}
}
simulated function DrawRoute() {
local int i;
local Controller C;
local Vector Start;
local Vector End;
local Vector RealStart;
local bool bPath;
C = Pawn(PlayerOwner.ViewTarget).Controller;                                
if (C == None) {                                                            
return;                                                                   
}
if (C.CurrentPath != None) {                                                
Start = C.CurrentPath.Start.Location;                                     
} else {                                                                    
Start = PlayerOwner.ViewTarget.Location;                                  
}
RealStart = Start;                                                          
if (C.bAdjusting) {                                                         
Draw3DLine(C.Pawn.Location,C.AdjustLoc,Class'Canvas'.static.MakeColor(255,0,255));
Start = C.AdjustLoc;                                                      
}
if (C == PlayerOwner
|| C.MoveTarget == C.RouteCache[0]
&& C.MoveTarget != None) {
if (C == PlayerOwner
&& C.Destination != vect(0.000000, 0.000000, 0.000000)) {
if (C.PointReachable(C.Destination)) {                                  
Draw3DLine(C.Pawn.Location,C.Destination,Class'Canvas'.static.MakeColor(255,255,255));
return;                                                               
}
C.FindPathTo(C.Destination);                                            
}
i = 0;                                                                    
while (i < 16) {                                                          
if (C.RouteCache[i] == None) {                                          
goto jl029C;                                                          
}
bPath = True;                                                           
Draw3DLine(Start,C.RouteCache[i].Location,Class'Canvas'.static.MakeColor(0,255,0));
Start = C.RouteCache[i].Location;                                       
i++;                                                                    
}
if (bPath) {                                                              
Draw3DLine(RealStart,C.Destination,Class'Canvas'.static.MakeColor(255,255,255));
}
goto jl0339;                                                              
}
if (PlayerOwner.ViewTarget.Velocity != vect(0.000000, 0.000000, 0.000000)) {
Draw3DLine(RealStart,C.Destination,Class'Canvas'.static.MakeColor(255,255,255));
}
if (C == PlayerOwner) {                                                     
return;                                                                   
}
if (C.Focus != None) {                                                      
End = C.Focus.Location;                                                   
} else {                                                                    
End = C.FocalPoint;                                                       
}
Draw3DLine(PlayerOwner.ViewTarget.Location + Pawn(PlayerOwner.ViewTarget).BaseEyeHeight * vect(0.000000, 0.000000, 1.000000),End,Class'Canvas'.static.MakeColor(255,0,0));
}
function CanvasDrawActors(Canvas C,bool bClearedZBuffer) {
}
simulated function SetInstructionKeyText(string Text);
simulated function SetInstructionText(string Text);
simulated function DrawInstructionGfx(Canvas C);
simulated function DrawCinematicHUD(Canvas C) {
local int i;
if (!bHideHUD) {                                                            
return;                                                                   
}
i = 0;                                                                      
while (i < Overlays.Length) {                                               
Overlays[i].Render(C);                                                    
i++;                                                                      
}
}
simulated event PostRender(Canvas Canvas) {
local float XPos;
local float YPos;
local Plane OldModulate;
local Color OldColor;
local int i;
OldModulate = Canvas.ColorModulate;                                         
OldColor = Canvas.DrawColor;                                                
Canvas.ColorModulate.X = 1.00000000;                                        
Canvas.ColorModulate.Y = 1.00000000;                                        
Canvas.ColorModulate.Z = 1.00000000;                                        
Canvas.ColorModulate.W = HudOpacity / 255;                                  
LinkActors();                                                               
ResScaleX = Canvas.SizeX / 640.00000000;                                    
ResScaleY = Canvas.SizeY / 480.00000000;                                    
if (PawnOwner != None) {                                                    
if (!PlayerOwner.bBehindView) {                                           
CanvasDrawActors(Canvas,False);                                         
} else {                                                                  
CanvasDrawActors(Canvas,False);                                         
}
}
if (PawnOwner != None && PawnOwner.bSpecialHUD) {                           
PawnOwner.DrawHUD(Canvas);                                                
}
if (bShowDebugInfo) {                                                       
Canvas.Font = GetConsoleFont(Canvas);                                     
Canvas.Style = 5;                                                         
Canvas.DrawColor = ConsoleColor;                                          
PlayerOwner.ViewTarget.DisplayDebug(Canvas,XPos,YPos);                    
if (PlayerOwner.ViewTarget != PlayerOwner
&& (Pawn(PlayerOwner.ViewTarget) == None
|| Pawn(PlayerOwner.ViewTarget).Controller == None)) {
YPos += XPos * 2;                                                       
Canvas.SetPos(4.00000000,YPos);                                         
Canvas.DrawText("----- VIEWER INFO -----");                             
YPos += XPos;                                                           
Canvas.SetPos(4.00000000,YPos);                                         
PlayerOwner.DisplayDebug(Canvas,XPos,YPos);                             
}
} else {                                                                    
if (!bHideHUD) {                                                          
if (!PawnOwner.bHideRegularHUD) {                                       
DrawHUD(Canvas);                                                      
}
i = 0;                                                                  
while (i < Overlays.Length) {                                           
Overlays[i].Render(Canvas);                                           
i++;                                                                  
}
DisplayMessages(Canvas);                                                
} else {                                                                  
if (PawnOwner != None) {                                                
DrawInstructionGfx(Canvas);                                           
}
}
}
PlayerOwner.RenderOverlays(Canvas);                                         
if (PlayerOwner.IsViewingCinematic()) {                                     
DrawCinematicHUD(Canvas);                                                 
}
if (PlayerConsole != None && PlayerConsole.bTyping) {                       
DrawTypingPrompt(Canvas,PlayerConsole.TypedStr,PlayerConsole.TypedStrPos);
}
Canvas.ColorModulate = OldModulate;                                         
Canvas.DrawColor = OldColor;                                                
}
function GetLocalStatsScreen();
simulated event WorldSpaceOverlays() {
if (bShowDebugInfo
&& Pawn(PlayerOwner.ViewTarget) != None) {         
DrawRoute();                                                              
}
}
simulated event Destroyed() {
Super.Destroyed();                                                          
}
simulated function CreateKeyMenus();
function Reset() {
Super.Reset();                                                              
}
simulated event PostBeginPlay() {
Super.PostBeginPlay();                                                      
LinkActors();                                                               
CreateKeyMenus();                                                           
foreach AllActors(Class'SceneSubtitles',SubTitles) {                        
goto jl0026;                                                              
}
}
final static native function StaticDrawCanvasLine(Canvas C,float X1,float Y1,float X2,float Y2,Color LineColor);
final native function DrawCanvasLine(float X1,float Y1,float X2,float Y2,Color LineColor);
final native function Draw3DLine(Vector Start,Vector End,Color LineColor);
*/
