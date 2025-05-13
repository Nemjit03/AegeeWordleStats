using System.Text.RegularExpressions;

namespace AegeeWordleStats;

public class SingleRegex(string pattern, RegexOptions options = RegexOptions.None) : Regex(pattern, options)
{
    public int GetInt(string input)
    {
        return int.Parse(GetStr(input));
    }
    
    public string GetStr(string input)
    {
        Match match = Match(input);
        return match.Groups[1].Value;
    }
}