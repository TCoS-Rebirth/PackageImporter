using System;
using System.ComponentModel;
using UnityEngine;

namespace Engine
{
    [Serializable, TypeConverter(typeof(LocalizedStringConverter))]
    public class LocalizedString
    {
        [SerializeField] int id;

        public LocalizedString()
        {
            id = 0;
        }

        public LocalizedString(int id)
        {
            this.id = id;
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
