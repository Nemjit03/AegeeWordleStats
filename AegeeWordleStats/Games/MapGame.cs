namespace AegeeWordleStats.Games;

public class MapGame : Game
{
   public MapGameStats Stats;
   public MapGame(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
   {
      Stats.FinalScore = int.Parse(FinalScore.GetStr(toParse).Replace(",","").Replace(".",""));
      ScoreOf1000 = Stats.FinalScore / 100;
      Stats.Time = Time.GetInt(toParse);
   }

   public static bool IsMatch(string toMatch)
   {
      return Time.IsMatch(toMatch)
             && FinalScore.IsMatch(toMatch)
             && Attempts.IsMatch(toMatch)
             && Link.IsMatch(toMatch);
   }

   private static readonly SingleRegex Time = new(@"Found the country in (\d+) seconds!");
   private static readonly SingleRegex FinalScore = new(@"Score: ([\d|,|.]+) 💎");
   private static readonly SingleRegex Attempts = new(@".");
   private static readonly SingleRegex Link = new(@"https://mapgame\.net");

   public override List<string> ToRow()
   {
      List<string> baseRow = base.ToRow();
      baseRow.AddRange(Stats.Time.ToString(), Stats.FinalScore.ToString());
      return baseRow;
   }
}
public struct MapGameStats
{
   public int Time;
   public int Attempts;
   public int FinalScore;
}
/*
   #MapGame 617:
   Found the country in 20 seconds!
   Score: 80,010 💎
   ✅
   ✅✅
   ✅✅✅
   ✅✅❌❌
   ✅✅✅✅❌
   ✅✅❌✅❌✅
   ✅✅✅✅✅✅✅
   
   https://mapgame.net
*/