using System;
using System.ComponentModel;
using TCosReborn.Framework.Internal;
using TCosReborn.Framework.Common;

namespace Engine
{
    [Serializable, TypeConverter(typeof(LocalizedStringConverter))]
    public class LocalizedString
    {
        int id;

        public LocalizedString()
        {
            id = 0;
        }

        public LocalizedString(int id)
        {
            this.id = id;
        }

        public string GetText(SBLocalizedStrings stringsDB, SBLanguage lang)
        {
            return stringsDB.GetString(id, lang);
        }

        public override string ToString()
        {
            return id.ToString();
        }

        public int GetID()
        {
            return id;
        }
    }

}
