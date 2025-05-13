namespace AegeeWordleStats.Games;

public abstract class Game
{
    protected Game(string toParse, string player, DateTime datetime)
    {
        Player = player;
        DateTime = datetime;
        // input = input.Select(i => i.Trim());
    }

    public static Type? GetType(string input)
    {
        if (MapTap.IsMatch(input)) return typeof(MapTap);
        if (TimeGuessr.IsMatch(input)) return typeof(TimeGuessr);
        if (Travle.IsMatch(input)) return typeof(Travle);
        if (BracketCity.IsMatch(input)) return typeof(BracketCity);
        if (MapGame.IsMatch(input)) return typeof(MapGame);
        if (Wordle.IsMatch(input)) return typeof(Wordle);
        // if (Strands.IsMatch(input)) return typeof(Strands);
        // if (Connections.IsMatch(input)) return typeof(Connections);

        return null;
    }

    public virtual List<string> ToRow()
    {
        return [Player, DateTime.ToString("d/M/yyyy HH:mm")];
    }

    public string Player { get; set; }
    public DateTime DateTime { get; set; }
    public int ScoreOf1000 { get; set; }
    public int LocalScore { get; set; }
}

// TODO: Tradle & Foodguessr?