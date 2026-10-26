// Bridge abstraction: EmailSummarizer depends on this interface rather than on Gemini.
// A different service can provide summaries by implementing the same operation, while
// the email summarizing logic remains independent of that provider's API.
public interface ISummaryProvider
{
    Task<string?> SummarizeAsync(string content);
}
