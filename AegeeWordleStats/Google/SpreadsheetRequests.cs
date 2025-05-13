using System.Text;
using AegeeWordleStats.SpreadsheetResponseModel;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;

namespace AegeeWordleStats.Google;

public class SpreadsheetRequests
{
    private SheetsService _service;

    public SpreadsheetRequests(SheetsService service)
    {
        _service = service;
    }

    public GetSpreadsheetResponse GetSpreadsheet()
    {
        GetSpreadsheetResponse? data = JsonConvert.DeserializeObject<GetSpreadsheetResponse>(
            _service.HttpClient
                .GetAsync(
                    "https://sheets.googleapis.com/v4/spreadsheets/1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040?includeGridData=true")
                .Result.Content.ReadAsStringAsync().Result);
        if (data == null) throw new Exception();

        return data;
    }

    public string AppendSpreadsheet(AppendBody body, string sheetName, int amountOfColumns)
    {
        char lastColumn = (char)('A' + amountOfColumns - 1);

        string bodyJson = JsonConvert.SerializeObject(body);
        return _service.HttpClient
            .PostAsync(
                $"https://sheets.googleapis.com/v4/spreadsheets/1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040/values/'{sheetName}'!A%3A{lastColumn}:append?valueInputOption=USER_ENTERED"
                , new StringContent(bodyJson, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync()
            .Result;
    }

    public string ClearSheets(List<string> sheetNames, List<int> amountOfColumns)
    {
        string bodyJson = JsonConvert.SerializeObject(new ClearRequest(sheetNames, amountOfColumns));

        return _service.HttpClient
            .PostAsync(
                $"https://sheets.googleapis.com/v4/spreadsheets/1vSmFBovA1m9v2ieZ976bORDVgVcPdQlxBAu6yWNY040/values:batchClear"
                , new StringContent(bodyJson, Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync()
            .Result;
    }
}