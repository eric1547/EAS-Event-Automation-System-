using System;

public abstract class Event
{
    public string Origin { get; }
    public string Content { get; }
    public DateTime RecivedIn { get; }

    protected Event(string origin, string content)
    {
        Origin = origin;
        Content = content;
        RecivedIn = DateTime.Now;
    }
}