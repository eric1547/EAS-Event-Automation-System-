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
}