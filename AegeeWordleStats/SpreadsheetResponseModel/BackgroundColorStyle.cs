    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class BackgroundColorStyle
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }