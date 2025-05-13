    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class ForegroundColorStyle
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }