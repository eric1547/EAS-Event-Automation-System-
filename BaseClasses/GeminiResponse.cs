// I hate this, but is the solution that I know to desireliaze jsons
public class GeminiResponse
{
    required public Candidate[] Candidates {get; set;}
    public class Candidate
    {
        required public Content Content {get; set;}
    }
            public class Content
        {
            required public Part[] Parts {get; set;}
            public class Part
            {
                required public string Text {get; set;}
            }
        }
}