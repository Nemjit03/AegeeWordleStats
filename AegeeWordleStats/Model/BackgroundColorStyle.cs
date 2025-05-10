    using System.Text.Json.Serialization;

    public class BackgroundColorStyle
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }
