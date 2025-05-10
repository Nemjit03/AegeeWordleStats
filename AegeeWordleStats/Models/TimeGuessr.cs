using System.Net.Sockets;
using System.Text.RegularExpressions;
using Score = (int place, int time);

namespace AegeeWordleStats.Models;

public partial class TimeGuessr : Game
{
   public TimeGuessrStats Stats;
   public TimeGuessr(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
   {
      Stats.FinalScore = int.Parse(FinalScore.GetStr(toParse).Replace(",","").Replace(".",""));
      ScoreOf1000 = Stats.FinalScore / 50;
      Stats.Scores = [];
      // MatchCollection matches = Scores().Matches(toParse);
      // if (matches.Count != 5) throw new Exception("incorrect format");
      // Stats.Scores = matches.Select(match =>
      // {
      //    match.Groups[0].Value
      // })
   }

   public static bool IsMatch(string toMatch)
   {
      return FinalScore.IsMatch(toMatch)
             && Link.IsMatch(toMatch);
   }
   
   private static readonly SingleRegex FinalScore = new(@"TimeGuessr #\d+ ([\d|,|.]+)/50[,|.]000");
   private static readonly SingleRegex Link = new(@"https://timeguessr\.com");

   [GeneratedRegex(@"🌎([🟩|⬛️|🟨]+) 📅([🟩|⬛️|🟨]+)")]
   private static partial Regex Scores();

   public override List<string> ToRow()
   {
      List<string> baseRow = base.ToRow();
      baseRow.Add(Stats.FinalScore.ToString());
      // baseRow.AddRange(
         // Stats.Scores.Select(s => $"{s.place} & {s.time}"));
      return baseRow;
   }
}
public struct TimeGuessrStats
{
   public Score[] Scores;
   public int FinalScore;
}
/*
   TimeGuessr #706 34,943/50,000
   🌎🟩🟩🟨 📅🟩🟩🟨
   🌎🟩⬛️⬛️ 📅⬛️⬛️⬛️
   🌎🟩🟩🟨 📅⬛️⬛️⬛️
   🌎🟩🟩🟨 📅🟩⬛⬛
   🌎🟩🟨⬛️ 📅🟩🟩🟨
   https://timeguessr.com
*/