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
    
    
    [System.Serializable] public class MGame_Chess : MGame_BoardGame
    {
        
        public const int MOVE_HISTORY_LENGTH = 5;
        
        public const int CANT_CASTLE_BLACK = 12;
        
        public const int CANT_CASTLE_BLACK_LONG = 8;
        
        public const int CANT_CASTLE_BLACK_SHORT = 4;
        
        public const int CANT_CASTLE_WHITE = 3;
        
        public const int CANT_CASTLE_WHITE_LONG = 2;
        
        public const int CANT_CASTLE_WHITE_SHORT = 1;
        
        public const int BOARD_G8 = 6;
        
        public const int BOARD_E8 = 4;
        
        public const int BOARD_C8 = 2;
        
        public const int BOARD_G1 = 62;
        
        public const int BOARD_E1 = 60;
        
        public const int BOARD_C1 = 58;
        
        public const int PIECE_CHESS_TYPE_KING = 32;
        
        public const int PIECE_CHESS_TYPE_QUEEN = 16;
        
        public const int PIECE_CHESS_TYPE_ROOK = 8;
        
        public const int PIECE_CHESS_TYPE_BISHOP = 4;
        
        public const int PIECE_CHESS_TYPE_KNIGHT = 2;
        
        public const int PIECE_CHESS_TYPE_PAWN = 1;
        
        public const int PIECE_CHESS_TYPE_EMPTY = 0;
        
        public const int CHESS_PIECE_COLOR = 128;
        
        public const int CHESS_PIECE_TYPE = 63;
        
        public byte Status;
        
        public int LastPawnTarget;
        
        public int EnPassantTarget;
        
        public bool MovesPossible;
        
        public bool WhiteIsMoving;
        
        public bool CheckMate;
        
        public bool StallMate;
        
        public List<Move> moveHistory = new List<Move>();
        
        public MGame_Chess()
        {
        }
        
        [System.Serializable] public struct BoardPosition
        {
            
            public int X;
            
            public int Y;
            
            public int t;
        }
        
        [System.Serializable] public struct Move
        {
            
            public BoardPosition Source;
            
            public int sourceType;
            
            public int sourceColor;
            
            public BoardPosition Target;
            
            public int TargetType;
            
            public int targetColor;
            
            public bool White;
            
            public int Status;
            
            public int LastPawnTarget;
            
            public int EnPassantTarget;
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
while (Y < 8) {                                                             
boardLine = "";                                                           
X = 0;                                                                    
while (X < 8) {                                                           
Value = BoardData[X + (Y << 3)];                                        
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
function bool IsValidKingMove(Move Move) {
local bool check1;
local bool check2;
local bool check3;
local bool check4;
local bool check5;
check1 = BaseCheck(Move);                                                   
check2 = Abs(Move.Source.X - Move.Target.X) <= 1;                           
check3 = Abs(Move.Source.Y - Move.Target.Y) <= 1;                           
check4 = IsValidCastleLong(Move);                                           
check5 = IsValidCastleShort(Move);                                          
return check1
&& (check2 && check3 || check4 || check5);              
}
function bool IsValidCastleLong(Move Move) {
if (Move.White) {                                                           
return Move.Source.t == 60 && Move.Target.t == 58
&& (Status & 2) == 0
&& IsClearPathCoords(4,7,0,7)
&& !AttackedByBlack(4,7) && !AttackedByBlack(3,7)
&& !AttackedByBlack(2,7);
} else {                                                                    
return Move.Source.t == 4 && Move.Target.t == 2
&& (Status & 8) == 0
&& IsClearPathCoords(4,0,0,0)
&& !AttackedByWhite(4,0) && !AttackedByWhite(3,0)
&& !AttackedByWhite(2,0);
}
}
function bool IsValidCastleShort(Move Move) {
local bool check1;
local bool check2;
local bool check3;
local bool check4;
local bool check5;
if (Move.White) {                                                           
check1 = Move.Source.t == 60;                                             
check2 = Move.Target.t == 62;                                             
check3 = (Status & 1) == 0;                                               
check4 = IsClearPathCoords(4,7,7,7);                                      
check5 = !AttackedByBlack(4,7) && !AttackedByBlack(5,7)
&& !AttackedByBlack(6,7);
return check1 && check2 && check3 && check4
&& check5;            
} else {                                                                    
return Move.Source.t == 4 && Move.Target.t == 6
&& (Status & 4) == 0
&& IsClearPathCoords(4,0,7,0)
&& !AttackedByWhite(4,0) && !AttackedByWhite(5,0)
&& !AttackedByWhite(6,0);
}
}
function bool IsValidQueenMove(Move Move) {
return BaseCheck(Move)
&& (Move.Source.X == Move.Target.X || Move.Source.Y == Move.Target.Y
|| Abs(Move.Source.X - Move.Target.X) == Abs(Move.Source.Y - Move.Target.Y))
&& IsClearPath(Move.Source,Move.Target);
}
function bool IsValidRookMove(Move Move) {
local bool check1;
local bool check2;
local bool check3;
local bool check4;
local bool Result;
check1 = BaseCheck(Move);                                                   
if (!check1) {                                                              
}
check2 = Move.Source.X == Move.Target.X;                                    
check3 = Move.Source.Y == Move.Target.Y;                                    
if (check2 && !check3 || !check2 && check3) {                               
check4 = IsClearPath(Move.Source,Move.Target);                            
} else {                                                                    
check4 = False;                                                           
}
Result = check1 && (check2 || check3) && check4;                            
return Result;                                                              
}
function bool IsValidBishopMove(Move Move) {
return BaseCheck(Move)
&& Abs(Move.Source.X - Move.Target.X) == Abs(Move.Source.Y - Move.Target.Y)
&& IsClearPath(Move.Source,Move.Target);
}
function bool IsValidKnightMove(Move Move) {
return BaseCheck(Move) && Move.Source.Y != Move.Target.Y
&& Move.Source.X != Move.Target.X
&& Abs(Move.Source.X - Move.Target.X) + Abs(Move.Source.Y - Move.Target.Y) == 3;
}
function bool IsValidPawnMove(Move Move) {
local bool result1;
local bool result2;
local bool result3;
local bool result4;
if (Move.White) {                                                           
result1 = Move.Target.t == Move.Source.t - 8
&& IsEmpty(Move.Target.t);
result2 = Move.Target.Y == Move.Source.Y - 1
&& Abs(Move.Target.X - Move.Source.X) == 1
&& IsColor(Move.Target.t,0);
result3 = Move.Source.Y == 6 && Move.Target.Y == 4
&& Move.Source.X == Move.Target.X
&& IsEmpty(Move.Source.t - 8)
&& IsEmpty(Move.Target.t);
result4 = Move.Target.t == EnPassantTarget
&& Abs(Move.Source.X - Move.Target.X) == 1
&& Move.Source.Y == 3;
return result1 || result2 || result3 || result4;                          
} else {                                                                    
return Move.Target.t == Move.Source.t + 8
&& BoardData[Move.Target.t] == 0
|| Move.Target.Y == Move.Source.Y + 1
&& Abs(Move.Target.X - Move.Source.X) == 1
&& IsColor(Move.Target.t,128)
|| Move.Source.Y == 1 && Move.Target.Y == 3
&& Move.Source.X == Move.Target.X
&& IsEmpty(Move.Source.t + 8)
&& IsEmpty(Move.Target.t)
|| Move.Target.t == EnPassantTarget
&& Abs(Move.Source.X - Move.Target.X) == 1
&& Move.Source.Y == 4;
}
}
function bool BaseCheck(Move Move) {
local bool Empty;
local bool oppositeColor;
Empty = IsEmpty(Move.Target.t);                                             
oppositeColor = IsOppositeColor(Move);                                      
return Empty || oppositeColor;                                              
}
function bool IsClearPathCoords(int sx,int sy,int tx,int ty) {
local int colDiff;
local int rowDiff;
local int col;
local int row;
local int pos;
colDiff = Sign(tx - sx);                                                    
rowDiff = Sign(ty - sy);                                                    
col = sx + colDiff;                                                         
row = sy + rowDiff;                                                         
while ((col != tx || row != ty) && col >= 0
&& col < 8
&& row >= 0
&& row < 8) {
pos = col + (row << 3);                                                   
if (pos >= BoardData.Length || pos < 0) {                                 
return False;                                                           
}
if (BoardData[pos] != 0) {                                                
return False;                                                           
}
col += colDiff;                                                           
row += rowDiff;                                                           
}
return True;                                                                
}
function bool IsClearPath(BoardPosition Source,BoardPosition Target) {
return IsClearPathCoords(Source.X,Source.Y,Target.X,Target.Y);              
}
function int Sign(int X) {
return X / Abs(X);                                                          
}
function bool AttackedByBlack(int tx,int ty) {
local int X;
local int Y;
Y = 0;                                                                      
while (Y < 8) {                                                             
X = 0;                                                                    
while (X < 8) {                                                           
if (IsColor(X + (Y << 3),0) && IsAttacking(X,Y,tx,ty,True)) {           
return True;                                                          
}
X++;                                                                    
}
Y++;                                                                      
}
return False;                                                               
}
function bool AttackedByWhite(int tx,int ty) {
local int X;
local int Y;
Y = 0;                                                                      
while (Y < 8) {                                                             
X = 0;                                                                    
while (X < 8) {                                                           
if (IsColor(X + (Y << 3),128) && IsAttacking(X,Y,tx,ty,True)) {         
return True;                                                          
}
X++;                                                                    
}
Y++;                                                                      
}
return False;                                                               
}
function bool IsAttacking(int sx,int sy,int tx,int ty,optional bool noKingCheck) {
local int PieceType;
local int PieceColor;
local int RequiredOpponentColor;
PieceType = GetPieceType(sx,sy);                                            
PieceColor = GetPieceColor(sx,sy);                                          
if (PieceColor == 128) {                                                    
RequiredOpponentColor = 0;                                                
} else {                                                                    
RequiredOpponentColor = 128;                                              
}
switch (PieceType) {                                                        
case 1 :                                                                  
if (PieceColor == 128) {                                                
return ty == sy - 1 && Abs(tx - sx) == 1
&& IsColor(tx + (ty << 3),0);
} else {                                                                
return ty == sy + 1 && Abs(tx - sx) == 1
&& IsColor(tx + (ty << 3),128);
}
case 32 :                                                                 
return (IsEmpty(tx + (ty << 3))
|| GetPieceColor(tx,ty) == RequiredOpponentColor)
&& Abs(sy - ty) <= 1 && Abs(sx - tx) <= 1;
default:                                                                  
if (noKingCheck) {                                                      
return ValidPieceMove(sx,sy,tx,ty,True);                              
} else {                                                                
return ValidMove(sx,sy,tx,ty,True);                                   
}
}
}
}
function bool HasValidDiagonalMove(int sx,int sy) {
local int Y;
local int X;
local int startX1;
local int startX2;
local int StartY;
startX1 = sx - Min(sx,sy);                                                  
startX2 = sx + Min(7 - sx,sy);                                              
StartY = sy - Min(sx,sy);                                                   
Y = StartY;                                                                 
X = startX1;                                                                
while (Y < 7 && X < 7) {                                                    
if (ValidMove(sx,sy,X,Y,True)) {                                          
return True;                                                            
}
Y += 1;                                                                   
X += 1;                                                                   
}
Y = StartY;                                                                 
X = startX2;                                                                
while (Y < 7 && X >= 0) {                                                   
if (ValidMove(sx,sy,X,Y,True)) {                                          
return True;                                                            
}
Y += 1;                                                                   
X -= 1;                                                                   
}
return False;                                                               
}
function bool HasValidVerticalMove(int sx,int sy) {
local int tx;
tx = 0;                                                                     
while (tx < 8) {                                                            
if (ValidMove(sx,sy,tx,sy,True)) {                                        
return True;                                                            
}
tx++;                                                                     
}
return False;                                                               
}
function bool HasValidHorizontalMove(int sx,int sy) {
local int ty;
ty = 0;                                                                     
while (ty < 8) {                                                            
if (ValidMove(sx,sy,sx,ty,True)) {                                        
return True;                                                            
}
ty++;                                                                     
}
return False;                                                               
}
function bool HasValidKingMove(int sx,int sy) {
local int X;
local int Y;
Y = -1;                                                                     
while (Y <= 1) {                                                            
X = -1;                                                                   
while (X <= 1) {                                                          
if ((X != 0 || Y != 0) && sx + X >= 0
&& sx + X < 8
&& sy + Y >= 0
&& sy + Y < 8) {
if (ValidMove(sx,sy,sx + X,sy + Y,True)) {                            
return True;                                                        
}
}
X++;                                                                    
}
Y++;                                                                      
}
if ((Status & 4) == 0) {                                                    
if (ValidMove(sx,sy,sx + 2,sy,True)) {                                    
return True;                                                            
}
if (ValidMove(sx,sy,sx - 2,sy,True)) {                                    
return True;                                                            
}
}
}
function bool HasValidPawnMove(int sx,int sy) {
local int Color;
Color = GetPieceColor(sx,sy);                                               
if (Color == 0) {                                                           
if (sy < 7 && sx > 0
&& ValidMove(sx,sy,sx - 1,sy + 1,True)) {    
return True;                                                            
}
if (sy < 7
&& ValidMove(sx,sy,sx,sy + 1,True)) {                  
return True;                                                            
}
if (sy < 7 && sx < 7
&& ValidMove(sx,sy,sx + 1,sy + 1,True)) {    
return True;                                                            
}
if (sy == 1
&& ValidMove(sx,sy,sx,sy + 2,True)) {                 
return True;                                                            
}
} else {                                                                    
if (Color == 128) {                                                       
if (ValidMove(sx,sy,sx - 1,sy - 1,True)) {                              
return True;                                                          
}
if (ValidMove(sx,sy,sx,sy - 1,True)) {                                  
return True;                                                          
}
if (ValidMove(sx,sy,sx + 1,sy - 1,True)) {                              
return True;                                                          
}
if (sy == 6
&& ValidMove(sx,sy,sx,sy - 2,True)) {             
return True;                                                          
}
}
}
}
function bool HasValidMove(int sx,int sy) {
local int tx;
local int ty;
local int sourceType;
sourceType = GetPieceType(sx,sy);                                           
switch (sourceType) {                                                       
case 1 :                                                                  
return HasValidPawnMove(sx,sy);                                         
break;                                                                  
case 8 :                                                                  
return HasValidHorizontalMove(sx,sy) || HasValidVerticalMove(sx,sy);    
break;                                                                  
case 4 :                                                                  
return HasValidDiagonalMove(sx,sy);                                     
break;                                                                  
case 16 :                                                                 
return HasValidDiagonalMove(sx,sy) || HasValidHorizontalMove(sx,sy)
|| HasValidVerticalMove(sx,sy);
break;                                                                  
case 32 :                                                                 
return HasValidKingMove(sx,sy);                                         
break;                                                                  
default:                                                                  
ty = 0;                                                                 
while (ty < 8) {                                                        
tx = 0;                                                               
while (tx < 8) {                                                      
if (ValidMove(sx,sy,tx,ty,True)) {                                  
return True;                                                      
}
tx++;                                                               
}
ty++;                                                                 
}
break;                                                                  
}
return False;                                                               
}
function GenerateMoves() {
local int sx;
local int sy;
MovesPossible = False;                                                      
sy = 0;                                                                     
while (sy < 8) {                                                            
sx = 0;                                                                   
while (sx < 8) {                                                          
if (WhiteIsMoving && IsColor(sx + (sy << 3),128)) {                     
if (HasValidMove(sx,sy)) {                                            
MovesPossible = True;                                               
return;                                                             
}
} else {                                                                
if (!WhiteIsMoving && IsColor(sx + (sy << 3),0)) {                    
if (HasValidMove(sx,sy)) {                                          
MovesPossible = True;                                             
return;                                                           
}
}
}
sx++;                                                                   
}
sy++;                                                                     
}
}
function bool ValidPieceMove(int sx,int sy,int tx,int ty,bool noFeedback) {
local Move Move;
Move.Source.X = sx;                                                         
Move.Source.Y = sy;                                                         
Move.Source.t = sx + (sy << 3);                                             
Move.Target.X = tx;                                                         
Move.Target.Y = ty;                                                         
Move.Target.t = tx + (ty << 3);                                             
Move.White = (BoardData[Move.Source.t] & 128) == 128;                       
Move.sourceType = BoardData[Move.Source.t] & 63;                            
switch (Move.sourceType) {                                                  
case 1 :                                                                  
if (!IsValidPawnMove(Move)) {                                           
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
case 2 :                                                                  
if (!IsValidKnightMove(Move)) {                                         
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
case 4 :                                                                  
if (!IsValidBishopMove(Move)) {                                         
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
case 8 :                                                                  
if (!IsValidRookMove(Move)) {                                           
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
case 16 :                                                                 
if (!IsValidQueenMove(Move)) {                                          
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
case 32 :                                                                 
if (!IsValidKingMove(Move)) {                                           
if (!noFeedback) {                                                    
}
return False;                                                         
}
break;                                                                  
default:                                                                  
}
return True;                                                                
}
function bool ValidMove(int sx,int sy,int tx,int ty,optional bool noFeedback) {
local bool White;
local int MoveCount;
if (!ValidPieceMove(sx,sy,tx,ty,noFeedback)) {                              
return False;                                                             
}
White = (BoardData[sx + (sy << 3)] & 128) == 128;                           
if (!noFeedback) {                                                          
}
MoveCount = MakeMove(sx,sy,tx,ty);                                          
if (White) {                                                                
if (!noFeedback) {                                                        
}
if (IsWhiteInCheck()) {                                                   
RevertMove(MoveCount);                                                  
if (!noFeedback) {                                                      
}
return False;                                                           
} else {                                                                  
if (!noFeedback) {                                                      
}
}
} else {                                                                    
if (!noFeedback) {                                                        
}
if (IsBlackInCheck()) {                                                   
if (!noFeedback) {                                                      
}
RevertMove(MoveCount);                                                  
return False;                                                           
} else {                                                                  
if (!noFeedback) {                                                      
}
}
}
RevertMove(MoveCount);                                                      
return True;                                                                
}
function bool IsBlackInCheck() {
local int KingPos;
KingPos = GetPiecePosition(32 | 0);                                         
return AttackedByWhite(KingPos % 8,KingPos / 8);                            
}
function bool IsWhiteInCheck() {
local int KingPos;
KingPos = GetPiecePosition(32 | 128);                                       
return AttackedByBlack(KingPos % 8,KingPos / 8);                            
}
function FinishMove(ExecuteMove aMove) {
local int moveColor;
moveColor = aMove.SourceValue & 128;                                        
if (!IsColor(aMove.Target,moveColor)) {                                     
BoardData[aMove.Target] = aMove.SourceValue;                              
}
OnUpdateBoardSquare(aMove.Target % 8,aMove.Target / 8);                     
}
function RemoveSquare(int Source) {
BoardData[Source] = 0;                                                      
OnUpdateBoardSquare(Source % 8,Source / 8);                                 
}
private function SetMove(int sx,int sy,int tx,int ty,optional bool Update) {
if (Update) {                                                               
OnMove(sx,sy,tx,ty,-1,-1);                                                
} else {                                                                    
BoardData[tx + (ty << 3)] = BoardData[sx + (sy << 3)];                    
BoardData[sx + (sy << 3)] = 0;                                            
}
}
function int MakeMove(int sx,int sy,int tx,int ty,optional bool Update) {
local int sourceType;
local int sourceColor;
local int MoveCount;
local int Source;
local int Target;
Source = sx + (sy << 3);                                                    
Target = tx + (ty << 3);                                                    
MoveCount = 0;                                                              
sourceType = GetPieceType(sx,sy);                                           
sourceColor = GetPieceColor(sx,sy);                                         
PushHistory(sx,sy,tx,ty);                                                   
SetMove(sx,sy,tx,ty,Update);                                                
MoveCount++;                                                                
switch (sourceType) {                                                       
case 1 :                                                                  
if (EnPassantTarget == Target) {                                        
BoardData[LastPawnTarget] = 0;                                        
if (Update) {                                                         
OnUpdateBoardSquare(LastPawnTarget % 8,LastPawnTarget / 8);         
}
}
LastPawnTarget = Target;                                                
if (Abs(ty - sy) == 2) {                                                
EnPassantTarget = sx + (sy + (ty - sy) / 2 << 3);                     
} else {                                                                
EnPassantTarget = -1;                                                 
}
break;                                                                  
case 32 :                                                                 
if (sourceColor == 128) {                                               
Status = Status | 3;                                                  
if (Source == 60 && Target == 62) {                                   
MoveCount++;                                                        
PushHistory(7,7,5,7);                                               
SetMove(7,7,5,7,Update);                                            
} else {                                                              
if (Source == 60 && Target == 58) {                                 
MoveCount++;                                                      
PushHistory(0,7,3,7);                                             
SetMove(0,7,3,7,Update);                                          
}
}
} else {                                                                
Status = Status | 12;                                                 
if (Source == 4 && Target == 6) {                                     
MoveCount++;                                                        
PushHistory(7,0,5,0);                                               
SetMove(7,0,5,0,Update);                                            
} else {                                                              
if (Source == 4 && Target == 2) {                                   
MoveCount++;                                                      
PushHistory(0,0,3,0);                                             
SetMove(0,0,3,0,Update);                                          
}
}
}
break;                                                                  
case 8 :                                                                  
if (sx == 0 && sy == 7) {                                               
Status = Status | 2;                                                  
} else {                                                                
if (sx == 7 && sy == 7) {                                             
Status = Status | 1;                                                
} else {                                                              
if (sx == 0 && sy == 0) {                                           
Status = Status | 8;                                              
} else {                                                            
if (sx == 7 && sy == 0) {                                         
Status = Status | 4;                                            
}
}
}
}
break;                                                                  
default:                                                                  
}
return MoveCount;                                                           
}
function RevertMove(int Count) {
local Move Move;
while (Count > 0) {                                                         
Move = PopHistory();                                                      
Status = Move.Status;                                                     
LastPawnTarget = Move.LastPawnTarget;                                     
EnPassantTarget = Move.EnPassantTarget;                                   
BoardData[Move.Source.t] = Move.sourceType | Move.sourceColor;            
BoardData[Move.Target.t] = Move.TargetType | Move.targetColor;            
Count--;                                                                  
}
}
function MakePromotion(int X,int Y,int aPiece,bool aUpdate) {
BoardData[X + (Y << 3)] = aPiece;                                           
if (aUpdate) {                                                              
OnUpdateBoardSquare(X,Y);                                                 
}
}
function int GetPiecePosition(int piece) {
local int X;
local int Y;
X = 0;                                                                      
while (X < 8) {                                                             
Y = 0;                                                                    
while (Y < 8) {                                                           
if (BoardData[X + (Y << 3)] == piece) {                                 
return X + (Y << 3);                                                  
}
Y++;                                                                    
}
X++;                                                                      
}
}
function bool IsOppositeColor(Move Move) {
if (Move.White) {                                                           
return (BoardData[Move.Target.t] & 128) == 0;                             
} else {                                                                    
return (BoardData[Move.Target.t] & 128) == 128;                           
}
}
function bool IsColor(int pos,int Color) {
local bool occupied;
occupied = !IsEmpty(pos);                                                   
return occupied
&& (BoardData[pos] & 128) == Color;                   
}
function bool IsEmpty(int pos) {
return (BoardData[pos] & 63) == 0;                                          
}
function int GetPieceColor(int X,int Y) {
return BoardData[X + (Y << 3)] & 128;                                       
}
function int GetPieceType(int X,int Y) {
return BoardData[X + (Y << 3)] & 63;                                        
}
function Start() {
Super.Start();                                                              
if (Config.GetConfig(Class'MGame_ChessConfig'.0) == Class'MGame_ChessConfig'.0) {
SetPlayerTurnID(0);                                                       
} else {                                                                    
SetPlayerTurnID(1);                                                       
}
}
function SwitchTurn() {
WhiteIsMoving = !WhiteIsMoving;                                             
SetPlayerTurnID((GetPlayerTurnID() + 1) % 2);                               
GenerateMoves();                                                            
if (!MovesPossible) {                                                       
if (WhiteIsMoving) {                                                      
if (IsWhiteInCheck()) {                                                 
CheckMate = True;                                                     
}
} else {                                                                  
if (IsBlackInCheck()) {                                                 
CheckMate = True;                                                     
}
}
StallMate = !CheckMate;                                                   
}
if (CheckMate) {                                                            
} else {                                                                    
if (StallMate) {                                                          
}
}
}
private function ResetBoard() {
Status = 0;                                                                 
EnPassantTarget = -1;                                                       
WhiteIsMoving = True;                                                       
CheckMate = False;                                                          
StallMate = False;                                                          
ThinkTimeOut = False;                                                       
moveHistory.Length = 0;                                                     
InitializeBoardLayout();                                                    
}
native function InitializeBoardLayout();
function bool IsValidPromotionMove(int sx,int sy,int tx,int ty) {
if (GetPieceColor(sx,sy) == 0) {                                            
return GetPieceType(sx,sy) == 1 && sy == 6
&& ty == 7;            
} else {                                                                    
return GetPieceType(sx,sy) == 1 && sy == 1
&& ty == 0;            
}
}
function Move PopHistory() {
local Move Move;
if (moveHistory.Length > 0) {                                               
Move = moveHistory[moveHistory.Length - 1];                               
moveHistory.Length = moveHistory.Length - 1;                              
}
return Move;                                                                
}
function PushHistory(int sx,int sy,int tx,int ty) {
local Move Move;
Move.Source.X = sx;                                                         
Move.Source.Y = sy;                                                         
Move.Source.t = sx + (sy << 3);                                             
Move.Target.X = tx;                                                         
Move.Target.Y = ty;                                                         
Move.Target.t = tx + (ty << 3);                                             
Move.White = (BoardData[Move.Source.t] & 128) == 128;                       
Move.sourceType = BoardData[Move.Source.t] & 63;                            
Move.TargetType = BoardData[Move.Target.t] & 63;                            
Move.sourceColor = BoardData[Move.Source.t] & 128;                          
Move.targetColor = BoardData[Move.Target.t] & 128;                          
Move.Status = Status;                                                       
Move.LastPawnTarget = LastPawnTarget;                                       
Move.EnPassantTarget = EnPassantTarget;                                     
if (moveHistory.Length > 5) {                                               
moveHistory.Remove(0,1);                                                  
}
moveHistory[moveHistory.Length] = Move;                                     
}
function int GetMiniGameTime() {
return Config.GetTime(Config.GetConfig(Class'MGame_ChessConfig'.2));        
}
function Initialize() {
Config = new Class'MGame_ChessConfig';                                      
BoardData.Length = 64;                                                      
ResetBoard();                                                               
Super.Initialize();                                                         
}
*/
