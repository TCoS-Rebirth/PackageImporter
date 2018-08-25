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
    
    
    [System.Serializable] public class MGame_Chess_Config : MGame_Config
    {
        
        public const int MGAME_CHESS_CONFIG_CASTLING = 5;
        
        public const int MGAME_CHESS_CONFIG_ENPASSANT = 4;
        
        public const int MGAME_CHESS_CONFIG_COUNT = 3;
        
        public const int MGAME_CHESS_CONFIG_TIME = 2;
        
        public const int MGAME_CHESS_CONFIG_PLAYER2_COLOR = 1;
        
        public const int MGAME_CHESS_CONFIG_PLAYER1_COLOR = 0;
        
        public const int MGAME_CHESS_ENABLED = 1;
        
        public const int MGAME_CHESS_DISABLED = 0;
        
        public const int MGAME_CHESS_COLOR_BLACK = 1;
        
        public const int MGAME_CHESS_COLOR_WHITE = 0;
        
        public const int MGAME_CHESS_TIME_30_MINUTES = 3;
        
        public const int MGAME_CHESS_TIME_15_MINUTES = 2;
        
        public const int MGAME_CHESS_TIME_10_MINUTES = 1;
        
        public const int MGAME_CHESS_TIME_5_MINUTES = 0;
        
        public MGame_Chess_Config()
        {
        }
    }
}
/*
function Initialize() {
Super.Initialize();                                                         
SetConfigCount(3);                                                          
SetConfig(0,0);                                                             
SetConfig(1,1);                                                             
SetConfig(2,0);                                                             
SetConfig(4,1);                                                             
SetConfig(5,1);                                                             
}
*/
