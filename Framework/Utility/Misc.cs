using System;
using System.Text;
using TCosReborn.Framework.Common;

namespace TCosReborn.Framework.Utility
{
    public static class Misc
    {
        public static bool EnumTryParse<T>(string strType, out T result)
        {
            var strTypeFixed = strType.Replace(' ', '_');
            if (Enum.IsDefined(typeof (T), strTypeFixed))
            {
                result = (T) Enum.Parse(typeof (T), strTypeFixed, true);
                return true;
            }
            foreach (var value in Enum.GetNames(typeof (T)))
            {
                if (!value.Equals(strTypeFixed, StringComparison.OrdinalIgnoreCase)) continue;
                result = (T) Enum.Parse(typeof (T), value);
                return true;
            }
            result = default(T);
            return false;
        }

        public static string ByteArrayToHex(byte[] bytes)
        {
            var result = new StringBuilder(bytes.Length*2);
            const string hexAlphabet = "0123456789ABCDEF";
            foreach (var b in bytes)
            {
                result.Append(hexAlphabet[b >> 4]);
                result.Append(hexAlphabet[b & 0xF]);
            }
            return result.ToString();
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return Mathf.Clamp((value - from1) / (to1 - from1) * (to2 - from2) + from2, from2, to2);
        }
    }
}