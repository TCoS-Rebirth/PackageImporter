﻿

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

namespace SBMiniGames
{
#pragma warning disable 414   
    
    [System.Serializable] public class MGame_Draughts : MGame_BoardGame
    {
        
        public const int PIECE_DRAUGHTS_TYPE_KING = 2;
        
        public const int PIECE_DRAUGHTS_TYPE_MAN = 1;
        
        public const int PIECE_DRAUGHTS_TYPE_EMPTY = 0;
        
        public const int PIECE_DRAUGHTS_TYPE = 3;
        
        public const int PIECE_DRAUGHTS_UNMARKED = 251;
        
        public const int PIECE_DRAUGHTS_MARKED = 4;
        
        public const int DRAUGHTS_PIECE_COLOR = 128;
        
        public const int DRAUGHTS_PIECE_TYPE = 63;
        
        private List<Neighbours> mNeighbours = new List<Neighbours>();
        
        public List<DraughtsMove> Moves = new List<DraughtsMove>();
        
        private List<Capture> mCurrentCapture = new List<Capture>();
        
        private int mCurrentStartSquare;
        
        private int mCaptureCount;
        
        private int mColorsTurn;
        
        public bool NoMoves;
        
        public MGame_Draughts()
        {
        }
        
        [System.Serializable] public struct Capture
        {
            
            public int Destination;
            
            public int Captured;
        }
        
        [System.Serializable] public struct DraughtsMove
        {
            
            public int StartSquare;
            
            public bool IsCapture;
            
            public List<Capture> Squares;
        }
        
        [System.Serializable] public struct Neighbours
        {
            
            public int[] Square;
        }
    }
}
/*
function Debug() {
local int X;
local int Y;
local int Value;
local string boardLine;
Y = 0;                                                                      
while (Y < 10) {                                                            
boardLine = "";                                                           
X = 0;                                                                    
while (X < 10) {                                                          
Value = BoardData[X + Y * 10];                                          
if (Value < 10) {                                                       
boardLine = boardLine $ " ";                                          
}
if (Value < 100) {                                                      
boardLine = boardLine $ " ";                                          
}
boardLine = boardLine $ string(Value) $ ",";                            
X++;                                                                    
}
Y++;                                                                      
}
}
function FinishMove(ExecuteMove aMove) {
BoardData[aMove.Target] = aMove.SourceValue;                                
if (aMove.Target < 10 && IsColor(aMove.Target,128)) {                       
BoardData[aMove.Target] = 2 | 128;                                        
} else {                                                                    
if (aMove.Target >= 90 && IsColor(aMove.Target,0)) {                      
BoardData[aMove.Target] = 2 | 0;                                        
}
}
OnUpdateBoardSquare(aMove.Target % 10,aMove.Target / 10);                   
if (aMove.Capture > -1) {                                                   
BoardData[aMove.Capture] = 0;                                             
OnUpdateBoardSquare(aMove.Capture % 10,aMove.Capture / 10);               
}
GenerateMoves();                                                            
}
function RemoveSquare(int Source) {
BoardData[Source] = 0;                                                      
OnUpdateBoardSquare(Source % 10,Source / 10);                               
}
function int ValidMoveSequence(int aStartSquare,array<Capture> aMove) {
local int i;
local int j;
local bool Valid;
i = 0;                                                                      
while (i < Moves.Length) {                                                  
if (Moves[i].StartSquare == aStartSquare) {                               
Valid = Moves[i].Squares.Length >= aMove.Length;                        
j = 0;                                                                  
while (j < aMove.Length && Valid) {                                     
Valid = Moves[i].Squares[j].Destination == aMove[j].Destination;      
j++;                                                                  
}
if (Valid) {                                                            
if (Moves[i].Squares.Length == aMove.Length) {                        
return i;                                                           
goto jl00E5;                                                        
}
return -1;                                                            
}
}
i++;                                                                      
}
return -2;                                                                  
}
function bool ValidMove(int aStartSquare,int _na,int aMoveIndex,int _na2,optional bool noFeedback) {
return Moves[aMoveIndex].StartSquare == aStartSquare;                       
}
function int MakeMove(int aStartSquare,int _na,int aMoveIndex,int _na2,optional bool aUpdate) {
local int i;
local int Target;
local int prevStartSquare;
Target = Moves[aMoveIndex].Squares[Moves[aMoveIndex].Squares.Length - 1].Destination;
prevStartSquare = aStartSquare;                                             
if (!aUpdate) {                                                             
BoardData[Target] = BoardData[aStartSquare];                              
BoardData[aStartSquare] = 0;                                              
}
i = 0;                                                                      
while (i < Moves[aMoveIndex].Squares.Length) {                              
if (aUpdate) {                                                            
OnMove(prevStartSquare % 10,prevStartSquare / 10,Moves[aMoveIndex].Squares[i].Destination % 10,Moves[aMoveIndex].Squares[i].Destination / 10,Moves[aMoveIndex].Squares[i].Captured % 10,Moves[aMoveIndex].Squares[i].Captured / 10);
} else {                                                                  
BoardData[Moves[aMoveIndex].Squares[i].Captured] = 0;                   
}
prevStartSquare = Moves[aMoveIndex].Squares[i].Destination;               
i++;                                                                      
}
if (!aUpdate) {                                                             
if (Target < 10 && IsColor(Target,128)) {                                 
BoardData[Target] = 2 | 128;                                            
} else {                                                                  
if (Target >= 90 && IsColor(Target,0)) {                                
BoardData[Target] = 2 | 0;                                            
}
}
}
return -1;                                                                  
}
private function FindMoves(int aFrom) {
local int direction;
local int fromColor;
local int fromType;
local byte Square;
fromColor = BoardData[aFrom] & 128;                                         
fromType = BoardData[aFrom] & 63;                                           
direction = 0;                                                              
while (direction < 4) {                                                     
if (fromColor == 128 && direction < 2
|| fromColor == 0 && direction >= 2
|| fromType == 2) {
Square = aFrom;                                                         
Square = mNeighbours[BoardIDToDamPos(Square)].Square[direction];        
if (Square == 0) {                                                      
goto jl016D;                                                          
}
if ((BoardData[Square] & 63) == 0) {                                    
Moves.Length = Moves.Length + 1;                                      
Moves[Moves.Length - 1].StartSquare = aFrom;                          
Moves[Moves.Length - 1].IsCapture = False;                            
Moves[Moves.Length - 1].Squares.Length = 1;                           
Moves[Moves.Length - 1].Squares[0].Destination = Square;              
} else {                                                                
break;                                                                
}
if (!fromType != 2) goto jl0091;                                        
}
direction++;                                                              
}
}
private function FindCaptures(int aLevel,int aFrom) {
local bool found;
local int i;
local int j;
local int k;
local int direction;
local int fromColor;
local int attacked;
local int jumpTo;
fromColor = BoardData[aFrom] & 128;                                         
direction = 0;                                                              
while (direction < 4) {                                                     
attacked = mNeighbours[BoardIDToDamPos(aFrom)].Square[direction];         
if ((BoardData[aFrom] & 63) == 2) {                                       
while (attacked != 0 && IsEmpty(attacked)) {                            
attacked = mNeighbours[BoardIDToDamPos(attacked)].Square[direction];  
}
}
if (!IsEmpty(attacked) && !IsColor(attacked,fromColor)
&& (BoardData[attacked] & 4) == 0) {
jumpTo = attacked;                                                      
jumpTo = mNeighbours[BoardIDToDamPos(jumpTo)].Square[direction];        
if (jumpTo != 0 && IsEmpty(jumpTo)) {                                   
mCurrentCapture.Length = aLevel + 1;                                  
mCurrentCapture[aLevel].Destination = jumpTo;                         
mCurrentCapture[aLevel].Captured = attacked;                          
BoardData[jumpTo] = BoardData[aFrom];                                 
BoardData[aFrom] = 0;                                                 
BoardData[attacked] = BoardData[attacked] | 4;                        
FindCaptures(aLevel + 1,jumpTo);                                      
BoardData[attacked] = BoardData[attacked] & 251;                      
BoardData[aFrom] = BoardData[jumpTo];                                 
BoardData[jumpTo] = 0;                                                
} else {                                                                
break;                                                                
}
if (!BoardData[aFrom] != (2 | fromColor)) goto jl00EF;                  
}
direction++;                                                              
}
if (aLevel > mCaptureCount) {                                               
mCaptureCount = aLevel;                                                   
Moves.Length = 0;                                                         
}
if (aLevel == mCaptureCount) {                                              
i = 0;                                                                    
while (i < mCaptureCount) {                                               
if (Moves[i].StartSquare == mCurrentStartSquare
&& Moves[i].Squares[aLevel - 1].Destination == aFrom) {
found = False;                                                        
j = 0;                                                                
while (j < Moves[i].Squares.Length) {                                 
k = 0;                                                              
while (k < mCurrentCapture.Length) {                                
found = False;                                                    
if (Moves[i].Squares[j].Captured == mCurrentCapture[k].Captured) {
found = True;                                                   
goto jl0346;                                                    
}
k++;                                                              
}
if (!found) {                                                       
goto jl035E;                                                      
}
j++;                                                                
}
if (found) {                                                          
return;                                                             
}
}
i++;                                                                    
}
Moves.Length = Moves.Length + 1;                                          
Moves[Moves.Length - 1].StartSquare = mCurrentStartSquare;                
Moves[Moves.Length - 1].IsCapture = True;                                 
Moves[Moves.Length - 1].Squares.Length = mCaptureCount;                   
i = 0;                                                                    
while (i < mCaptureCount) {                                               
Moves[Moves.Length - 1].Squares[i] = mCurrentCapture[i];                
i++;                                                                    
}
}
}
function GenerateMoves() {
local int i;
Moves.Length = 0;                                                           
mCurrentCapture.Length = 0;                                                 
mCurrentStartSquare = 0;                                                    
mCaptureCount = 1;                                                          
i = 0;                                                                      
while (i < 99) {                                                            
if ((BoardData[i] & 128) == mColorsTurn
&& (BoardData[i] & 63) != 0) {
mCurrentStartSquare = i;                                                
FindCaptures(0,i);                                                      
}
i++;                                                                      
}
if (Moves.Length == 0) {                                                    
i = 0;                                                                    
while (i < 99) {                                                          
if ((BoardData[i] & 128) == mColorsTurn
&& (BoardData[i] & 63) != 0) {
FindMoves(i);                                                         
}
i++;                                                                    
}
}
}
function bool IsColor(int aPos,int aColor) {
return (BoardData[aPos] & 128) == aColor;                                   
}
function bool IsEmpty(int aPos) {
return (BoardData[aPos] & 63) == 0;                                         
}
private function ResetBoard() {
local int i;
mColorsTurn = 128;                                                          
ThinkTimeOut = False;                                                       
i = 0;                                                                      
while (i < 100) {                                                           
BoardData[i] = 0;                                                         
i++;                                                                      
}
BoardData[1] = 0 | 1;                                                       
BoardData[3] = 0 | 1;                                                       
BoardData[5] = 0 | 1;                                                       
BoardData[7] = 0 | 1;                                                       
BoardData[9] = 0 | 1;                                                       
BoardData[10] = 0 | 1;                                                      
BoardData[12] = 0 | 1;                                                      
BoardData[14] = 0 | 1;                                                      
BoardData[16] = 0 | 1;                                                      
BoardData[18] = 0 | 1;                                                      
BoardData[21] = 0 | 1;                                                      
BoardData[23] = 0 | 1;                                                      
BoardData[25] = 0 | 1;                                                      
BoardData[27] = 0 | 1;                                                      
BoardData[29] = 0 | 1;                                                      
BoardData[30] = 0 | 1;                                                      
BoardData[32] = 0 | 1;                                                      
BoardData[34] = 0 | 1;                                                      
BoardData[36] = 0 | 1;                                                      
BoardData[38] = 0 | 1;                                                      
BoardData[61] = 128 | 1;                                                    
BoardData[63] = 128 | 1;                                                    
BoardData[65] = 128 | 1;                                                    
BoardData[67] = 128 | 1;                                                    
BoardData[69] = 128 | 1;                                                    
BoardData[70] = 128 | 1;                                                    
BoardData[72] = 128 | 1;                                                    
BoardData[74] = 128 | 1;                                                    
BoardData[76] = 128 | 1;                                                    
BoardData[78] = 128 | 1;                                                    
BoardData[81] = 128 | 1;                                                    
BoardData[83] = 128 | 1;                                                    
BoardData[85] = 128 | 1;                                                    
BoardData[87] = 128 | 1;                                                    
BoardData[89] = 128 | 1;                                                    
BoardData[90] = 128 | 1;                                                    
BoardData[92] = 128 | 1;                                                    
BoardData[94] = 128 | 1;                                                    
BoardData[96] = 128 | 1;                                                    
BoardData[98] = 128 | 1;                                                    
GenerateMoves();                                                            
}
function SetTurn(int aColor) {
mColorsTurn = aColor;                                                       
}
function SwitchTurn() {
if (mColorsTurn == 128) {                                                   
SetTurn(0);                                                               
} else {                                                                    
SetTurn(128);                                                             
}
SetPlayerTurnID((GetPlayerTurnID() + 1) % 2);                               
GenerateMoves();                                                            
if (Moves.Length == 0) {                                                    
NoMoves = True;                                                           
}
}
private function int BoardPosToDamPos(int X,int Y) {
if (Y >= 0 && Y < 10 && X >= 0 && X < 10) {                                 
return Y * 5 + (X + 0.50000000) / 2 + 1;                                  
} else {                                                                    
return 0;                                                                 
}
}
private function int BoardIDToDamPos(int Id) {
return BoardPosToDamPos(Id % 10,Id / 10);                                   
}
private function CreateNeighbours() {
local int X;
local int Y;
local int i;
mNeighbours.Length = 51;                                                    
mNeighbours[0].Square[0] = 0;                                               
mNeighbours[0].Square[1] = 0;                                               
mNeighbours[0].Square[2] = 0;                                               
mNeighbours[0].Square[3] = 0;                                               
Y = 0;                                                                      
while (Y < 10) {                                                            
X = 0;                                                                    
while (X < 10) {                                                          
if (Y % 2 == 0 && X % 2 == 1 || Y % 2 == 1 && X % 2 == 0) {             
i = BoardPosToDamPos(X,Y);                                            
mNeighbours[i].Square[0] = GetNeighbour(X - 1,Y - 1);                 
mNeighbours[i].Square[1] = GetNeighbour(X + 1,Y - 1);                 
mNeighbours[i].Square[2] = GetNeighbour(X - 1,Y + 1);                 
mNeighbours[i].Square[3] = GetNeighbour(X + 1,Y + 1);                 
}
X++;                                                                    
}
Y++;                                                                      
}
}
private function int GetNeighbour(int X,int Y) {
if (Y >= 0 && Y < 10 && X >= 0 && X < 10) {                                 
return X + Y * 10;                                                        
} else {                                                                    
return 0;                                                                 
}
}
function int GetMiniGameTime() {
return Config.GetTime(Config.GetConfig(Class'MGame_DraughtsConfig'.2));     
}
function Initialize() {
Config = new Class'MGame_DraughtsConfig';                                   
BoardData.Length = 100;                                                     
CreateNeighbours();                                                         
ResetBoard();                                                               
Super.Initialize();                                                         
}
function Start() {
Super.Start();                                                              
}
*/
