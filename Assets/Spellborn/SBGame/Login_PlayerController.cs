using System;
using System.Collections.Generic;
using SBBase;

namespace SBGame
{
    [Serializable] public class Login_PlayerController : Base_Controller
    {
        public List<UniverseInfo> mUniverses = new List<UniverseInfo>();

        [Serializable] public struct UniverseInfo
        {
            public int Id;

            public string Name;

            public string Language;

            public string Type;

            public string Population;
        }

        public override void WriteLoginStream(IPacketWriter packetWriter)
        {
            throw new NotImplementedException();
        }
    }
}
/*
delegate HandleUniverseSelectionResult(bool aSuccess,int aResult);
delegate HandleLoginResult(bool aSuccess,int aResult);
*/