    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class TextFormat
    {
        [JsonPropertyName("foregroundColor")]
        public ForegroundColor ForegroundColor { get; set; }

        [JsonPropertyName("fontFamily")]
        public string FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public string? FontSize { get; set; }

        [JsonPropertyName("bold")]
        public bool? Bold { get; set; }

        [JsonPropertyName("italic")]
        public bool? Italic { get; set; }

        [JsonPropertyName("strikethrough")]
        public bool? Strikethrough { get; set; }

        [JsonPropertyName("underline")]
        public bool? Underline { get; set; }

        [JsonPropertyName("foregroundColorStyle")]
        public ForegroundColorStyle ForegroundColorStyle { get; set; }
    }