    using System.Text.Json.Serialization;

    public class ColumnMetadata
    {
        [JsonPropertyName("pixelSize")]
        public string? PixelSize { get; set; }
    }
