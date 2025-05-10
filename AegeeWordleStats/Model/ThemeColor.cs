    using System.Text.Json.Serialization;

    public class ThemeColor
    {
        [JsonPropertyName("colorType")]
        public string ColorType { get; set; }

        [JsonPropertyName("color")]
        public Color Color { get; set; }
    }
