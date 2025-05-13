using System.Globalization;
using AegeeWordleStats.Games;
using AegeeWordleStats.Google;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using GetSpreadsheetResponse = AegeeWordleStats.SpreadsheetResponseModel.GetSpreadsheetResponse;
using Sheet = AegeeWordleStats.SpreadsheetResponseModel.Sheet;

namespace AegeeWordleStats;

class Program
{
    static void Main(string[] args)
    {
        SheetsService service = Google.Auth.FetchSheetsCredits();
        SpreadsheetRequests requests = new(service);
        Spreadsheet spreadsheet = service.Spreadsheets.Get("1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040").Execute();
        // Add(new Sheet()
        // {
        // Data = new List<GridData>
        // {
        // new GridData()
        // {

        // }
        // }
        // })
        HttpClient client = service.HttpClient;


        string lines = File.ReadLines(args[0]).Skip(3).Aggregate((s1, s2) => s1 + Environment.NewLine + s2);
        Parser p = new();
        p.ParseList(lines);

        Database.getDatabase();
        // ClearAndFill(requests, p.GamesList);
        // RepeatFill(p.GamesList, requests);
        // ClearAllGames(requests, p.GamesList);
        // ForEach(p.GamesList, data, requests);
        // ForEach(p.GamesList.FindAll(t => t.GetType() == typeof(TimeGuessr)), data, requests);
    }

    private static void ClearAllGames(SpreadsheetRequests requests, List<Game> games)
    {
        List<(string Name, int Count)> sheets = games.Select(g => (g.GetType().Name, g.ToRow().Count)).Distinct().ToList();
        List<string> gamesNames = sheets.Select(g => g.Name).ToList();
        List<int> gamesRowLength = sheets.Select(g => g.Count).ToList();
        requests.ClearSheets(gamesNames, gamesRowLength);
    }

    private static void ClearAndFill(SpreadsheetRequests requests, List<Game> games)
    {
        ClearAllGames(requests, games);
        Thread.Sleep(1000);
        RepeatFill(games, requests);
    }

    private static void RepeatFill(List<Game> gamesList, SpreadsheetRequests requests)
    {
        try
        {
            ForEach(gamesList, requests);
        }
        catch (QuotaLimitReachedException)
        {
            Console.WriteLine("Quota limit (60 requests/min) reached, trying again in 10 seconds");
            Thread.Sleep(10000);
            RepeatFill(gamesList, requests);
        }
    }

    private static void ForEach(List<Game> gamesList, SpreadsheetRequests requests)
    {
        GetSpreadsheetResponse data = requests.GetSpreadsheet();
        foreach (Game game in gamesList)
        {
            Sheet? sheet = data.GetSheetByName(game.GetType().Name);
            if (sheet == null || sheet.Data[0].RowData.Count <= 1) throw new Exception();
            if (sheet.Data[0].RowData[1..].Any(rowData =>
                {
                    List<string?> formatted = rowData.Values.Select(value => value.FormattedValue).ToList();
                    List<string> rows = game.ToRow();
                    string? datetime = formatted[1];
                    if (datetime == null) return false;
                    return DateTime.Parse(datetime, new CultureInfo("nl-en")) == game.DateTime &&
                           formatted[0] == rows[0];
                })
               )
            {
                Console.WriteLine(
                    $"{game.GetType().Name} played by {game.Player} on {game.DateTime} already have an entry into the google sheets");
                continue;
            }

            string result =
                requests.AppendSpreadsheet(new AppendBody(game.ToRow()), game.GetType().Name, game.ToRow().Count);
            if (result.Contains("Request a higher quota limit."))
                throw new QuotaLimitReachedException();
            Console.WriteLine(result);
        }
    }
}

public class QuotaLimitReachedException : Exception;