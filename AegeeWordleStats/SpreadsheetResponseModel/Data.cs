    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class Data
    {
        [JsonPropertyName("rowData")]
        public List<RowData> RowData { get; set; }

        [JsonPropertyName("rowMetadata")]
        public List<RowMetadata> RowMetadata { get; set; }

        [JsonPropertyName("columnMetadata")]
        public List<ColumnMetadata> ColumnMetadata { get; set; }
    }