// Bridge abstraction: this class defines the summarizing operation used by the event flow.
// It accepts any ISummaryProvider implementation, so email handling can keep using the
// same summarizer if the external service changes from Gemini to another provider.
public class EmailSummarizer(ISummaryProvider provider)
{
    public Task<string?> SummarizeAsync(Email email) => provider.SummarizeAsync(email.Content);
}
