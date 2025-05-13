    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class RowMetadata
    {
        [JsonPropertyName("pixelSize")]
        public string? PixelSize { get; set; }
    }