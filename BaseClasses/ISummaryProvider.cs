// This allows me to change the API provider for the summery without changing the logic of the summary.
// In other terms, ITS THE LEFT SIDE OF THE BRIDGE!!!
public interface ISummaryProvider
{
    Task<string?> SummarizeAsync(string content);
}
