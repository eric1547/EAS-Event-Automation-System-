public class OnEmailRecived
{
    // Keep one visitor for this handler and provide it with the summary abstraction.
    // The event handler forwards the received EventParams to AcceptAsync; Email then
    // dispatches to EmailSummaryVisitor.VisitAsync, and the await keeps this work inside
    // the asynchronous event flow.
    private static readonly IEventVisitor Visitor = new EmailSummaryVisitor(
        new EmailSummarizer(new GeminiSummaryProvider()));

    public static AsyncEventHandler<EventParams> onEmailRecived = async (_, eventParams) =>
        await eventParams.AcceptAsync(Visitor);
}
