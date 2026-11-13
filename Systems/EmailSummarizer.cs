// This is the email summerizing logic (I know, it`s as little as a gnome, but I needed to shove this somewhere).
// It recives the summerize provider and uses it to do the summery. In other words, ITS THE RIGHT SIDE OF THE BRIDGE!!!
public class EmailSummarizer(ISummaryProvider provider)
{
    public Task<string?> SummarizeAsync(Email email) => provider.SummarizeAsync(email.Content);
}
