using System;

public class StringParser
{ 
    public string HasValue(string text,string searchingValue)
    {
        if (text.Contains(searchingValue))
            return text;
        return null;
    }
    public string GetStringFromEnum(Enum enumName)
    {
        return enumName.ToString().ToLower();
    }
}
