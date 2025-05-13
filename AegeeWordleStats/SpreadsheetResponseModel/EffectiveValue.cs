    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class EffectiveValue
    {
        [JsonPropertyName("numberValue")]
        public string? NumberValue { get; set; }
    }