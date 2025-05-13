    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class Color
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }