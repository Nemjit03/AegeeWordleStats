    using System.Text.Json.Serialization;

    public class RowMetadata
    {
        [JsonPropertyName("pixelSize")]
        public string? PixelSize { get; set; }
    }
