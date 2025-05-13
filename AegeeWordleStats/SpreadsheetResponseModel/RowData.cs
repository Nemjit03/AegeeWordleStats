    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class RowData
    {
        [JsonPropertyName("values")]
        public List<Value> Values { get; set; }
    }