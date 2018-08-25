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
    
    
    [System.Serializable] public class MGame_BoardGame : MGame_MiniGame
    {
        
        public const int PIECE_COLOR_BLACK = 0;
        
        public const int PIECE_COLOR_WHITE = 128;
        
        public List<byte> BoardData = new List<byte>();
        
        //public delegate<OnUpdateBoardSquare> @__OnUpdateBoardSquare__Delegate;
        
        //public delegate<OnMove> @__OnMove__Delegate;
        
        public MGame_BoardGame()
        {
        }
        
        [System.Serializable] public struct ExecuteMove
        {
            
            public int Source;
            
            public int Target;
            
            public int Capture;
            
            public int SourceValue;
        }
    }
}
/*
function FinishMove(ExecuteMove aMove) {
}
function RemoveSquare(int Source) {
}
function bool ValidMove(int originX,int originY,int destinationX,int destinationY,optional bool noFeedback) {
return False;                                                               
}
function int MakeMove(int originX,int originY,int destinationX,int destinationY,optional bool Update) {
return -1;                                                                  
}
delegate OnMove(int sx,int sy,int tx,int ty,int cX,int cY);
delegate OnUpdateBoardSquare(int sx,int sy);
*/
