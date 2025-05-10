    using System.Text.Json.Serialization;

    public class Properties
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("autoRecalc")]
        public string AutoRecalc { get; set; }

        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; }

        [JsonPropertyName("defaultFormat")]
        public DefaultFormat DefaultFormat { get; set; }

        [JsonPropertyName("spreadsheetTheme")]
        public SpreadsheetTheme SpreadsheetTheme { get; set; }

        [JsonPropertyName("sheetId")]
        public string? SheetId { get; set; }

        [JsonPropertyName("index")]
        public string? Index { get; set; }

        [JsonPropertyName("sheetType")]
        public string SheetType { get; set; }

        [JsonPropertyName("gridProperties")]
        public GridProperties GridProperties { get; set; }
    }
