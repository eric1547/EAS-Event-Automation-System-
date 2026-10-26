using System.Net.Http.Json;

public class OnEmailRecived
{
    private const string ApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash-lite:generateContent?key=";

    public static AsyncEventHandler<EventParams> onEmailRecived = async (sender, email) => {
        // This is a http client that allows us to send and recive
        using HttpClient client = new();
        // this is a anonimous obj. It emulates a json string (yes, string, not fille :( ))
        object requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new {text = $"Resuma este para min: \n {email.Content}"}
                    }
                }
            }
        };

        HttpResponseMessage response = await client.PostAsJsonAsync($"{ApiUrl}{File.ReadAllText("gemini_secrets.txt")}", requestBody);
        Console.WriteLine(email.Content);
        // The sistem breakes if not dynamic type var (the mail client closes to early, dntknw why tough)
        var response2 = await response.Content.ReadFromJsonAsync<GeminiResponse>();
        Console.WriteLine($"De: {email.Origin}\n");
        Console.WriteLine($"Em: {email.RecivedIn}\n");
        Console.WriteLine(response2?.Candidates[0].Content.Parts[0].Text);
    };
}