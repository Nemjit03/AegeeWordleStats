using System.Text.RegularExpressions;

namespace AegeeWordleStats.Models;

public class Wordle : Game
{
   public WordleStats Stats;
   public Wordle(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
   {
      Stats.Amount = Amount.GetStr(toParse);
      Stats.Hard = Hard.IsMatch(toParse);
      if (int.TryParse(Stats.Amount, out int amount)) ScoreOf1000 = 1000 - amount * (1000 / 6);
      else ScoreOf1000 = 0;
   }

   public static bool IsMatch(string toMatch)
   {
      return Amount.IsMatch(toMatch)
             && IsWordle.IsMatch(toMatch);
   }

   private static readonly SingleRegex Hard = new(@"Wordle [\d|,|.]+ \d/6\*");
   private static readonly SingleRegex Amount = new(@"Wordle [\d|,|.]+ (\d|X)/6\*?"); 
   private static readonly SingleRegex IsWordle = new(@"Wordle [\d|,|.]+ (\d|X)\/6\*?\s+([🟨|⬜|🟩]+\s+)+([🟨|⬜|🟩]+)");
   public override List<string> ToRow()
   {
      List<string> baseRow = base.ToRow();
      baseRow.AddRange([Stats.Hard.ToString(), Stats.Amount]);
      return baseRow;
   }
}
public struct WordleStats
{
   public string Amount;
   public bool Hard;
}

/*
   Wordle 1,418 4/6
   
   ⬛⬛⬛🟨⬛
   🟨🟨🟨⬛⬛
   🟩🟨🟩🟩🟨
   🟩🟩🟩🟩🟩
*/