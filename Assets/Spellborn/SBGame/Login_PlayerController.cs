using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
    [Serializable] public class Login_PlayerController : Base_Controller
    {
        public List<UniverseInfo> mUniverses = new List<UniverseInfo>();

        public Login_PlayerController()
        {
        }

        [Serializable] public struct UniverseInfo
        {
            public int Id;

            public string Name;

            public string Language;

            public string Type;

            public string Population;
        }
    }
}
/*
delegate HandleUniverseSelectionResult(bool aSuccess,int aResult);
delegate HandleLoginResult(bool aSuccess,int aResult);
*/