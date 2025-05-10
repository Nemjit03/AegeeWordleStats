    using System.Text.Json.Serialization;

    public class Value
    {
        [JsonPropertyName("userEnteredValue")]
        public UserEnteredValue UserEnteredValue { get; set; }

        [JsonPropertyName("effectiveValue")]
        public EffectiveValue EffectiveValue { get; set; }

        [JsonPropertyName("formattedValue")]
        public string FormattedValue { get; set; }

        [JsonPropertyName("effectiveFormat")]
        public EffectiveFormat EffectiveFormat { get; set; }
    }
