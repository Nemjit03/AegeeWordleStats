    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class GridProperties
    {
        [JsonPropertyName("rowCount")]
        public string? RowCount { get; set; }

        [JsonPropertyName("columnCount")]
        public string? ColumnCount { get; set; }
    }