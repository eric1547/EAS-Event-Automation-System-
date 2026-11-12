using System.Net.Http.Json;

public class GeminiConection
{
    private static string ApiKey = File.ReadAllText("gemini_secrets.txt");
    private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash-lite:generateContent?key=";

    public static async Task ResumeMaking(string email)
    {
        string Prompt = $"Resuma este email para min: \n {email}";

        using HttpClient client = new();

        object requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new {text = Prompt}
                    }
                }
            }
        };

        var response = await client.PostAsJsonAsync($"{ApiUrl}{ApiKey}", requestBody);
        var response2 = await response.Content.ReadFromJsonAsync<GeminiResponse>();
        Console.WriteLine("Respostaaaaaaaaaaa");
        Console.WriteLine(response2?.Candidates[0].Content.Parts[0].Text);
    }
}