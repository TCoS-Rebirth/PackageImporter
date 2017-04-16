using System;
using System.ComponentModel;
using System.Globalization;
using Engine;
using TCosReborn.Framework.Common;

namespace TCosReborn.Framework.Internal
{
    public class LocalizedStringConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string) | sourceType == typeof(int))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string) | destinationType == typeof(int))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                int val;
                if (int.TryParse((string)value, out val))
                {
                    return new LocalizedString(val);
                }
            }
            if (value is int)
            {
                return new LocalizedString((int)value);
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((LocalizedString)value).ToString();
            }
            if (destinationType == typeof(int))
            {
                return ((LocalizedString)value).GetID();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}