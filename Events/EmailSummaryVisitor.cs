// This Visitor contains the email-specific operation instead of placing summary behavior
// in Email itself. It requests the summary through EmailSummarizer and then displays the
// email information and result. The Task lets the event trigger await the full operation.
public class EmailSummaryVisitor(EmailSummarizer summarizer) : IEventVisitor
{
    public async Task VisitAsync(Email email)
    {
        string? summary = await summarizer.SummarizeAsync(email);
        Console.WriteLine(email.Content);
        Console.WriteLine($"De: {email.Origin}\n");
        Console.WriteLine($"Em: {email.RecivedIn}\n");
        Console.WriteLine(summary);
    }
}
