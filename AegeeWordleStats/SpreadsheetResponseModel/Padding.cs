    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class Padding
    {
        [JsonPropertyName("top")]
        public string? Top { get; set; }

        [JsonPropertyName("right")]
        public string? Right { get; set; }

        [JsonPropertyName("bottom")]
        public string? Bottom { get; set; }

        [JsonPropertyName("left")]
        public string? Left { get; set; }
    }