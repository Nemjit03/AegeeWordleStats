    using System.Text.Json.Serialization;

    public class SpreadsheetTheme
    {
        [JsonPropertyName("primaryFontFamily")]
        public string PrimaryFontFamily { get; set; }

        [JsonPropertyName("themeColors")]
        public List<ThemeColor> ThemeColors { get; set; }
    }
