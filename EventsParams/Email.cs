public class Email : EventParams
{
    public string Sender { get; }
    public string Subject { get; }
    // This is the constructor of the sub class. It firsts sets the constructor method
    // of the EmailEvent class. Then calls the parent constructor method setting the origin
    // to sender, and Content to body.
    public Email(string sender, string subject, string body) : base(sender, body)
    {
        Sender = sender;
        Subject = subject;
    }

    // Email is the concrete event type, so it passes itself to VisitAsync(Email).
    // This lets the visitor use Email-specific data such as Sender and Subject.
    public override Task AcceptAsync(IEventVisitor visitor) => visitor.VisitAsync(this);
}