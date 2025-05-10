    using System.Text.Json.Serialization;

    public class RowData
    {
        [JsonPropertyName("values")]
        public List<Value> Values { get; set; }
    }
