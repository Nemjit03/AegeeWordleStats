    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class BackgroundColor
    {
        [JsonPropertyName("red")]
        public float? Red { get; set; }

        [JsonPropertyName("green")]
        public float? Green { get; set; }

        [JsonPropertyName("blue")]
        public float? Blue { get; set; }
    }