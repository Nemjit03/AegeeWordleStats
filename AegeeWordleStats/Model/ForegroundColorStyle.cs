    using System.Text.Json.Serialization;

    public class ForegroundColorStyle
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }
