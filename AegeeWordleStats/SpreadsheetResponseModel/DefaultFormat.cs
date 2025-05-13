    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class DefaultFormat
    {
        [JsonPropertyName("backgroundColor")]
        public BackgroundColor BackgroundColor { get; set; }

        [JsonPropertyName("padding")]
        public Padding Padding { get; set; }

        [JsonPropertyName("verticalAlignment")]
        public string VerticalAlignment { get; set; }

        [JsonPropertyName("wrapStrategy")]
        public string WrapStrategy { get; set; }

        [JsonPropertyName("textFormat")]
        public TextFormat TextFormat { get; set; }

        [JsonPropertyName("backgroundColorStyle")]
        public BackgroundColorStyle BackgroundColorStyle { get; set; }
    }