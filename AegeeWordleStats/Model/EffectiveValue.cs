    using System.Text.Json.Serialization;

    public class EffectiveValue
    {
        [JsonPropertyName("numberValue")]
        public string? NumberValue { get; set; }
    }
