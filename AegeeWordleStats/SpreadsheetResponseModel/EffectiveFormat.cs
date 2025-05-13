    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class EffectiveFormat
    {
        [JsonPropertyName("backgroundColor")]
        public BackgroundColor BackgroundColor { get; set; }

        [JsonPropertyName("padding")]
        public Padding Padding { get; set; }

        [JsonPropertyName("horizontalAlignment")]
        public string HorizontalAlignment { get; set; }

        [JsonPropertyName("verticalAlignment")]
        public string VerticalAlignment { get; set; }

        [JsonPropertyName("wrapStrategy")]
        public string WrapStrategy { get; set; }

        [JsonPropertyName("textFormat")]
        public TextFormat TextFormat { get; set; }

        [JsonPropertyName("hyperlinkDisplayType")]
        public string HyperlinkDisplayType { get; set; }

        [JsonPropertyName("backgroundColorStyle")]
        public BackgroundColorStyle BackgroundColorStyle { get; set; }
    }