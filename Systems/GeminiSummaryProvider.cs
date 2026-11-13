using System.Net.Http.Json;

public class GeminiSummaryProvider : ISummaryProvider
{
    private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash-lite:generateContent?key=";

    public async Task<string?> SummarizeAsync(string content)
    {
        using HttpClient client = new();
        object requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = $"Resuma este para min: \n {content}" }
                    }
                }
            }
        };

        using HttpResponseMessage response = await client.PostAsJsonAsync($"{ApiUrl}{File.ReadAllText("gemini_secrets.txt")}", requestBody);
        GeminiResponse result = await response.Content.ReadFromJsonAsync<GeminiResponse>();
        return result?.Candidates[0].Content.Parts[0].Text;
    }
}
