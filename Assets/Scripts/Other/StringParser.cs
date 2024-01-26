public class StringParser
{ 
    public string HasValue(string text,string searchingValue)
    {
        if (text.Contains(searchingValue))
            return text;
        return null;
    }
}
