    using System.Text.Json.Serialization;

    namespace AegeeWordleStats.SpreadsheetResponseModel;

    public class UserEnteredValue
    {
        [JsonPropertyName("numberValue")]
        public string? NumberValue { get; set; }

        [JsonPropertyName("formulaValue")]
        public string FormulaValue { get; set; }
    }