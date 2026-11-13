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

    // Accepts `n dispatches the visitor, allowing an operation to handle different event types
    // without putting that operation's logic inside the event data classes.
    public abstract Task AcceptAsync(IEventVisitor visitor);
}