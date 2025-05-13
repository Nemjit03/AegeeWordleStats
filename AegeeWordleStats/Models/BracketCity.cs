using System.Text.RegularExpressions;

namespace AegeeWordleStats.Models;

public class BracketCity : Game
{
    public BracketCityStats Stats;

    public BracketCity(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
    {
        Stats.FinalScore = Convert.ToInt32(Math.Round(Convert.ToDecimal(FinalScore.GetStr(toParse))));
        ScoreOf1000 = Stats.FinalScore * 10;

        if (Peeks.IsMatch(toParse)) Stats.WrongGuesses = WrongGuesses.GetInt(toParse);
        if (Peeks.IsMatch(toParse)) Stats.Peeks = Peeks.GetInt(toParse);
        if (AnswersRevealed.IsMatch(toParse)) Stats.AnswersRevealed = AnswersRevealed.GetInt(toParse);
        Stats.MinimalKeyStrokes = MinimalKeyStrokes.IsMatch(toParse);
    }

    public static bool IsMatch(string toMatch)
    {
        return WrongGuesses.IsMatch(toMatch)
               && FinalScore.IsMatch(toMatch)
               && Link.IsMatch(toMatch);
    }

    private static readonly SingleRegex WrongGuesses = new(@"Wrong guesses: (\d+)");
    private static readonly SingleRegex Peeks = new(@"Peeks: (\d+)");
    private static readonly SingleRegex AnswersRevealed = new(@"Answers Revealed: (\d+)");
    private static readonly SingleRegex FinalScore = new(@"Total Score: (\d{1,3}\.\d)");
    private static readonly SingleRegex MinimalKeyStrokes = new(@".+ Total Keystrokes: \d+.+\s+.+ Minimum Required: \d+", RegexOptions.Multiline);
    private static readonly SingleRegex Link = new(@"https://www\.theatlantic\.com/games/bracket-city/");
    

    public override List<string> ToRow()
    {
        List<string> baseRow = base.ToRow();
        baseRow.AddRange([Stats.WrongGuesses.ToString(), Stats.Peeks.ToString(), Stats.AnswersRevealed.ToString(), Stats.MinimalKeyStrokes.ToString(), Stats.FinalScore.ToString()]);
        return baseRow;
    }
}

public struct BracketCityStats
{
    public int WrongGuesses;
    public int Peeks;
    public int AnswersRevealed;
    public int FinalScore;
    public bool MinimalKeyStrokes;
}
/*
   [Bracket City]
   May 7, 2025

   https://www.theatlantic.com/games/bracket-city/

   Rank: 🏠 (Resident)
   ❌ Wrong guesses: 3
   👀 Peeks: 4
   🛟 Answers Revealed: 2

   Total Score: 44.0
   🟨🟨🟨🟨⬜⬜⬜⬜⬜⬜
*/


//// PERFECT MET MINIMAL KEYSTROKES
/* [Bracket City]
May 11, 2025

https://www.theatlantic.com/games/bracket-city/

Rank: 🔮 (Puppet Master)
🎹 Total Keystrokes: 70
🎯 Minimum Required: 70

Total Score: 100.0
🟪🟪🟪🟪🟪🟪🟪🟪🟪🟪
*/