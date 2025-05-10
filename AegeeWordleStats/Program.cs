using System.Globalization;
using System.Runtime.Intrinsics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using AegeeWordleStats.Models;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AegeeWordleStats;

class Program
{
    static void Main(string[] args)
    {
        SheetsService service = Google.Auth.FetchSheetsCredits();
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


        


        string lines = File.ReadAllText(args[0]);
        Parser p = new();
        foreach (GameState i1 in Parser.GroupByMessage(lines))
        {
            p.TryParse(i1);
        }

        
        GetSpreadsheetResponse? data = JsonConvert.DeserializeObject<GetSpreadsheetResponse>(
            client
                .GetAsync(
                    "https://sheets.googleapis.com/v4/spreadsheets/1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040?includeGridData=true")
                .Result.Content.ReadAsStringAsync().Result);
        if (data == null) throw new Exception();
        foreach (Game game in p.GamesList[148..150])
        {
            Sheet? sheet = data.GetSheetByName(game.GetType().Name);
            if (sheet == null || sheet.Data[0].RowData.Count <= 1) throw new Exception();
            if (sheet.Data[0].RowData[1..].Any(rowData =>
                {
                    List<string> formatted = rowData.Values.Select(value => value.FormattedValue).ToList();
                    List<string> rows = game.ToRow();
                    if (formatted[1] == null) return false;
                    return DateTime.Parse(formatted[1], new CultureInfo("nl-en")) == game.DateTime && formatted[0] == rows[0];
                })) continue;
            
            // Console.WriteLine($"{game.DateTime}: {game.Player}: {game.GetType().Name}: {game.ScoreOf1000}");

            string body = JsonConvert.SerializeObject(new AppendBody { values = [game.ToRow()] });
            Console.WriteLine(client
                .PostAsync(
                    $"https://sheets.googleapis.com/v4/spreadsheets/1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040/values/'{game.GetType().Name}'!A%3AJ:append?valueInputOption=USER_ENTERED"
                    , new StringContent(body, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync()
                .Result);
        }
    }
}

class AppendBody
{
    [JsonPropertyName("values")]
    public List<List<string>> values { get; set; }
    
}