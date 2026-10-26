// Chnaged from event to elegate. This way the events can be awaited
public delegate Task AsyncEventHandler<TEventArgs>(object? sender, TEventArgs eventArgs);

public class EventListener
{
    // The static property creates one shared listener when the type is first used.
    // The private constructor prevents other classes from creating separate listeners.
    // Code that needs the listener accesses this same object through EventListener.Instance.
    public static EventListener Instance { get; } = new();

    private EventListener() { }

    // Creates the event
    private AsyncEventHandler<EventParams>? _onEventTrigger;
    // This method subs a "result" to the event
    public void EventSub(AsyncEventHandler<EventParams> eventResult)
    {
        _onEventTrigger += eventResult;
    }
    // Method for unsubing
    public void EventUnsub(AsyncEventHandler<EventParams> eventResult)
    {
        _onEventTrigger -= eventResult;
    }
    // Method for triggering the event. This will trigger all the results subbed to the event
    public async Task EventTrigger(EventParams eventParams){
        // It recives an event params that will be sent to the event result to be processed
        // by the event result.
        await _onEventTrigger(this, eventParams);
    }
}