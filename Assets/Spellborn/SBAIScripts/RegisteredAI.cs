using System;
using SBAI;

namespace SBAIScripts
{
    [Serializable] public class RegisteredAI : AIScriptSubObject
    {
        public Game_AIController Controller;

        public RegisteredAI()
        {
        }
    }
}