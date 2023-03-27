using System.Text;

namespace ToTitle;
public static class StringExtension
{
    public static string ToTitle(this string text)
    {
        if (text.Length == 0)
            throw new ArgumentException("Text cannot be empty", nameof(text));
        
        StringBuilder returnValue = new();
        returnValue.Append(text[0].ToString().ToUpper());

        if (text.Length == 1)
        {
            return returnValue.ToString();
        }
        
        returnValue.Append(text[1..].ToLower());
        return returnValue.ToString();
    }
}
