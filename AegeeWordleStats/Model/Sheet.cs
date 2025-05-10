    using System.Text.Json.Serialization;

    public class Sheet
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("data")]
        public List<Data> Data { get; set; }
    }
