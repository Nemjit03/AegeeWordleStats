using System.Reflection;
using System.Text.RegularExpressions;
using AegeeWordleStats.Games;

namespace AegeeWordleStats;

public class Parser
{
    public List<Game> GamesList = [];

    public bool TryParse(GameState gs)
    {
        try
        {
            Parse(gs);
        }
        catch (NoGameResultException)
        {
            return false;
        }
        return true;
    }
    public void Parse(GameState gs)
    {
        Type? gameType = Game.GetType(gs.gameresult);
        if (gameType == null) throw new NoGameResultException();

        ConstructorInfo? ctor = gameType.GetConstructor([typeof(string), typeof(string), typeof(DateTime)]);
        if (ctor.Invoke([gs.gameresult, gs.player, gs.datetime]) is not Game game) throw new NoGameResultException();

        GamesList.Add(game);
    }

    public static List<GameState> GroupByMessage(string input)
    {
        var i = Regex.Split(input, @"(\d{1,2}\/\d{1,2}\/\d{2,4}, \d{2}:\d{2}) - (\+(\d|\s)+|(\w|\s)+): ")
            .Where(s => s.Length > 1)
            .Chunk(3);
            return i.Select(strings 
                => new GameState(DateTime.Parse(strings[0]), strings[1], strings[2]))
            .ToList();
    }

    public void ParseList(string lines)
    {
        foreach (GameState i1 in GroupByMessage(lines)) TryParse(i1);
    }
}

public class NoGameResultException : Exception;