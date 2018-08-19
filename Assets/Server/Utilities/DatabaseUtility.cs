using System;

namespace Utilities
{
    public static class DatabaseUtility
    {
        public static int GetUnixTimestamp(DateTime time)
        {
            return (int)time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
