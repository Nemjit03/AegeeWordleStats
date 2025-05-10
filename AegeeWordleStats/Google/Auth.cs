using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace AegeeWordleStats.Google;

public class Auth 
{
  
    public static SheetsService FetchSheetsCredits()
    {
        // Specify the path to your service account JSON key file
        const string jsonKeyFilePath = "/home/nemjit/.keys/aegee-459414-de010dd960fe.json";

        // Load the credentials from the JSON key file and specify the required scope
        GoogleCredential credential;
        using (FileStream stream = new(jsonKeyFilePath, FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(SheetsService.Scope.Spreadsheets);
        }

        // Create the Calendar service
        return new SheetsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "AegeeWordleStats"
        });
    }
}