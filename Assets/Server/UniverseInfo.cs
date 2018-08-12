using System;

[Serializable]
public class UniverseInfo
{
    public string Name { get; private set; }
    public string Language { get; private set; }
    public string Type { get; private set; }

    public UniverseInfo(string uname, string ulanguage, string utype)
    {
        Name = uname;
        Language = ulanguage;
        Type = utype;
    }

    public override string ToString()
    {
        return string.Format("{0} (language:{1}, type:{2})", Name, Language, Type);
    }
}