using System.Text.Json.Serialization;

namespace AegeeWordleStats.Google;

public class AppendBody
{
    public AppendBody(List<string> valuesIn)
    {
        if (valuesIn.Count > 10) throw new Exception("Please adapt spreadsheet when more than 10 values given");
        values = [valuesIn];
    }
    
    [JsonPropertyName("values")]
    public List<List<string>> values { get; set; }
    
}