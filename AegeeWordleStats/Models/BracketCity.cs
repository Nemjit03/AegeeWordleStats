using System.Text.RegularExpressions;

namespace AegeeWordleStats.Models;

public class BracketCity : Game
{
    public BracketCityStats Stats;

    public BracketCity(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
    {
        Stats.FinalScore = Convert.ToInt32(Math.Round(Convert.ToDecimal(FinalScore.GetStr(toParse))));
        ScoreOf1000 = Stats.FinalScore * 10;

        Stats.WrongGuesses = WrongGuesses.GetInt(toParse);
        Stats.Peeks = Peeks.GetInt(toParse);
        Stats.AnswersRevealed = AnswersRevealed.GetInt(toParse);
    }

    public static bool IsMatch(string toMatch)
    {
        return WrongGuesses.IsMatch(toMatch)
               && Peeks.IsMatch(toMatch)
               && AnswersRevealed.IsMatch(toMatch)
               && FinalScore.IsMatch(toMatch)
               && Link.IsMatch(toMatch);
    }

    private static readonly SingleRegex WrongGuesses = new(@"Wrong guesses: (\d+)");
    private static readonly SingleRegex Peeks = new(@"Peeks: (\d+)");
    private static readonly SingleRegex AnswersRevealed = new(@"Answers Revealed: (\d+)");
    private static readonly SingleRegex FinalScore = new(@"Total Score: (\d{1,3}\.\d)");
    private static readonly SingleRegex Link = new(@"https://www\.theatlantic\.com/games/bracket-city/");

    public override List<string> ToRow()
    {
        List<string> baseRow = base.ToRow();
        baseRow.AddRange([Stats.WrongGuesses.ToString(), Stats.Peeks.ToString(), Stats.AnswersRevealed.ToString(), Stats.FinalScore.ToString()]);
        return baseRow;
    }
}

public struct BracketCityStats
{
    public int WrongGuesses;
    public int Peeks;
    public int AnswersRevealed;
    public int FinalScore;
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