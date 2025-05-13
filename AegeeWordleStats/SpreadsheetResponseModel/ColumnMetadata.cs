    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class ColumnMetadata
    {
        [JsonPropertyName("pixelSize")]
        public string? PixelSize { get; set; }
    }