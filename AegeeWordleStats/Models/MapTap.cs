using System.Text.RegularExpressions;

namespace AegeeWordleStats.Models;

public class MapTap : Game
{
   public MapTapStats Stats;
   public MapTap(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
   {
      ScoreOf1000 = Stats.FinalScore = FinalScore.GetInt(toParse);
      Match m1 = FiveScores.Match(toParse);
      Stats.Scores = m1.Groups.Cast<Group>().Skip(1).Select(group => int.Parse(group.Value)).ToArray();
   }

   public static bool IsMatch(string toMatch)
   {
      return FiveScores.IsMatch(toMatch)
         && FinalScore.IsMatch(toMatch)
         && MapTapGg.IsMatch(toMatch);
   }

   public override List<string> ToRow()
   {
      List<string> baseRow = base.ToRow();
      baseRow.AddRange(Stats.Scores.Select(i => i.ToString()));
      baseRow.Add(Stats.FinalScore.ToString());
      return baseRow;
   }

    private static readonly SingleRegex FiveScores = new(@"\s*(\d{1,3}).{2}\s(\d{1,3}).{2}\s(\d{1,3}).{2}\s(\d{1,3}).{2}\s(\d{1,3}).{2}\s*");
    private static readonly SingleRegex FinalScore = new(@"Final score: (\d{1,4})", RegexOptions.Multiline);
    private static readonly SingleRegex MapTapGg = new(@"www\.MapTap\.gg");
}
public struct MapTapStats
{
   public int[] Scores;
   public int FinalScore;
}
/*
   www.MapTap.gg May 9 
   94🏅 97🔥 93🏆 81🌟 44😨
   Final score: 752
*/