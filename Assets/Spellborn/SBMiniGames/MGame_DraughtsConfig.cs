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
    
    
    [System.Serializable] public class MGame_DraughtsConfig : MGame_Config
    {
        
        public const int MGAME_DRAUGHTS_CONFIG_COUNT = 3;
        
        public const int MGAME_DRAUGHTS_CONFIG_TIME = 2;
        
        public const int MGAME_DRAUGHTS_CONFIG_PLAYER2_COLOR = 1;
        
        public const int MGAME_DRAUGHTS_CONFIG_PLAYER1_COLOR = 0;
        
        public MGame_DraughtsConfig()
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
}
*/
