using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using AegeeWordleStats.Models;
using BindingFlags = System.Reflection.BindingFlags;
using GamesPerDay = (System.DateTime dt, AegeeWordleStats.Models.Game game);
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

        var ctor = gameType.GetConstructor([typeof(string), typeof(string), typeof(DateTime)]);
        var game = ctor.Invoke([gs.gameresult, gs.player, DateTime.Parse(gs.datetime)]) as Game;
        if (game == null) throw new NoGameResultException();

        GamesList.Add(game);
    }

    public static List<GameState> GroupByMessage(string input)
    {
        var i = Regex.Split(input, @"(\d{1,2}\/\d{1,2}\/\d{2}, \d{2}:\d{2}) - (\+(\d|\s)+|(\w|\s)+): ")
            .Where(s => s.Length > 1)
            .Chunk(3);
            return i.Select(strings 
                => new GameState(strings[0], strings[1], strings[2]))
            .ToList();
    }
}

public class NoGameResultException : Exception;