using System;

namespace Engine
{
    [Serializable] public class NameProperty
    {
        public string Value;

        public NameProperty(string value)
        {
            Value = value;
        }

        public static implicit operator string(NameProperty value)
        {
            return value.ToString();
        }

        public static implicit operator NameProperty(string value)
        {
            return new NameProperty(value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}