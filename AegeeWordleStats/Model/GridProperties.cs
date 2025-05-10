    using System.Text.Json.Serialization;

    public class GridProperties
    {
        [JsonPropertyName("rowCount")]
        public string? RowCount { get; set; }

        [JsonPropertyName("columnCount")]
        public string? ColumnCount { get; set; }
    }
