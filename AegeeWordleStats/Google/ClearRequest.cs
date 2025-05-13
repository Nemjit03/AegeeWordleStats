using System.Text.Json.Serialization;

namespace AegeeWordleStats.Google;

public class ClearRequest
{
    public ClearRequest(List<string> sheetNames, List<int> amountOfColumns)
    {
        if (sheetNames.Count != amountOfColumns.Count) throw new Exception("Amount of sheets must be equal to amount of Columns");
        
        ranges = [];
        for (int i = 0; i < sheetNames.Count; i++)
        {
            char lastColumn = (char)('A' + amountOfColumns[i] - 1);
            ranges.Add($"'{sheetNames[i]}'!A2:{lastColumn}");
        }
    }
    [JsonPropertyName("ranges")]
    public List<string> ranges { get; set; }
    
}