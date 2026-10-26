public abstract class EventParams
{
    public string Origin { get; }
    public string Content { get; }
    public DateTime RecivedIn { get; }
    // This is the constructor (it sets the values to the variables)
    protected EventParams(string origin, string content)
    {
        Origin = origin;
        Content = content;
        RecivedIn = DateTime.Now;
    }

    // Visitor entry point: each concrete event type implements this method and selects
    // the matching Visit method, allowing an operation to handle different event types
    // without putting that operation's logic inside the event data classes.
    public abstract Task AcceptAsync(IEventVisitor visitor);
}