using System;

namespace TCosReborn.Application
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Log(object obj)
        {
            Log(ReferenceEquals(obj,null) ? "null" : obj.ToString());
        }

        public static void LogOk(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Log(message);
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message);
            //Console.ReadKey();
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log(message);
        }
    }
}
