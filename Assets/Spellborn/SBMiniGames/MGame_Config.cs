

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
    
    [System.Serializable] public class MGame_Config : UObject
    {
        
        public const int MGAME_CONFIG_ENABLED = 1;
        
        public const int MGAME_CONFIG_DISABLED = 0;
        
        public const int MGAME_CONFIG_COLOR_BLACK = 1;
        
        public const int MGAME_CONFIG_COLOR_WHITE = 0;
        
        public const int MGAME_CONFIG_TIME_30_MINUTES = 3;
        
        public const int MGAME_CONFIG_TIME_15_MINUTES = 2;
        
        public const int MGAME_CONFIG_TIME_10_MINUTES = 1;
        
        public const int MGAME_CONFIG_TIME_5_MINUTES = 0;
        
        private List<int> mTimeConfig = new List<int>();
        
        private List<int> mConfigValues = new List<int>();
        
        public MGame_Config()
        {
        }
    }
}
/*
function int GetTime(int aTimeIndex) {
return mTimeConfig[aTimeIndex];                                             
}
function int GetConfig(int aSetting) {
return mConfigValues[aSetting];                                             
}
function SetConfig(int aSetting,int aValue) {
mConfigValues[aSetting] = aValue;                                           
}
function SetConfigCount(int aConfigCount) {
mConfigValues.Length = aConfigCount;                                        
}
function Initialize() {
}
*/
