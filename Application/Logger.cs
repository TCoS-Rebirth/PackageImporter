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
            Log(obj == null ? "null" : obj.ToString());
        }

        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Log(message);
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log(message);
        }
    }
}
