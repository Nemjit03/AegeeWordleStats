    using System.Text.Json.Serialization;

    public class Color
    {
        [JsonPropertyName("rgbColor")]
        public RgbColor RgbColor { get; set; }
    }
