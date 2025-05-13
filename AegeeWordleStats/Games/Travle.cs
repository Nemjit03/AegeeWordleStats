namespace AegeeWordleStats.Games;

public class Travle : Game
{
    public TravleStats Stats;

    public Travle(string toParse, string player, DateTime datetime) : base(toParse, player, datetime)
    {
        Stats.Completed = Extra.IsMatch(toParse);
        Stats.Perfect = Perfect.IsMatch(toParse);
        Stats.Away = Away.IsMatch(toParse) ? Away.GetInt(toParse) : 0;
        Stats.Hints = Hints.IsMatch(toParse) ? Hints.GetInt(toParse) : 0;
        Stats.Extra = Extra.GetInt(toParse);

        ScoreOf1000 = 500 + (Stats.Completed ? 400 : 0) + (Stats.Perfect ? 100 : 0) - Stats.Away * 100 - Stats.Hints * 100 - Stats.Extra * 50;
    }

    public static bool IsMatch(string toMatch)
    {
        return Extra.IsMatch(toMatch)
               && Link.IsMatch(toMatch);
    }

    private static readonly SingleRegex Extra = new(@"#travle #\d+ \+(\d+)");
    private static readonly SingleRegex Perfect = new(@"#travle #\d+ \+\d+ \(Perfect\)");
    private static readonly SingleRegex Away = new(@"#travle #\d+ \((\d) away\)");
    private static readonly SingleRegex Hints = new(@"#travle #\d+ (?:\+\d+ )?(?:\(\d away\) )?\((\d) hints?\)");
    private static readonly SingleRegex Link = new(@"https://travle\.earth");

    public override List<string> ToRow()
    {
        List<string> baseRow = base.ToRow();
        baseRow.AddRange(
        [
            Stats.Completed.ToString(),
            Stats.Perfect.ToString(),
            Stats.Away.ToString(),
            Stats.Hints.ToString(),
            Stats.Extra.ToString()
        ]);
        return baseRow;
    }
}

public struct TravleStats
{
    // start at 500
    public bool Perfect; // + 100
    public bool Completed; // + 400
    public int Away; // - 100
    public int Hints; // - 100 
    public int Extra; // - 50
}

/*
#travle #875 +0
✅🟩✅
https://travle.earth

#travle #873 +2 (1 hint)
🟧✅🟧🟩✅
https://travle.earth

#travle #878 (1 away) (2 hints)
🟥🟥🟥🟥🟥🟩✅✅✅✅🟧
https://travle.earth
 */