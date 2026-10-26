// The Visitor interface declares an operation for each concrete event type it can process.
// EventParams.AcceptAsync dispatches to the matching method; adding another event type
// would require a corresponding Visit method here and an AcceptAsync override on that type.
public interface IEventVisitor
{
    Task VisitAsync(Email email);
}
