    using System.Text.Json.Serialization;

    public class GetSpreadsheetResponse
    {
        [JsonPropertyName("spreadsheetId")]
        public string SpreadsheetId { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("sheets")]
        public List<Sheet> Sheets { get; set; }

        [JsonPropertyName("spreadsheetUrl")]
        public string SpreadsheetUrl { get; set; }

        public Sheet? GetSheetByName(string name)
        {
            return Sheets.Find(s => s.Properties.Title == name);
        }
    }
