using System;

public class EventListener
{
    // Creates the event
    private EventHandler<EventParams>? _onEventTrigger;
    // This method subs a "result" to the event
    public void EventSub(EventHandler<EventParams> eventResult)
    {
        _onEventTrigger += eventResult;
    }
    // Method for unsubing
    public void EventUnsub(EventHandler<EventParams> eventResult)
    {
        _onEventTrigger -= eventResult;
    }
    // Method for triggering the event. This will trigger all the results subbed to the event
    public void EventTrigger(EventParams eventParams){
        // It recives an event params that will be sent to the event result to be processed
        // by the event result.
        _onEventTrigger?.Invoke(this, eventParams);
    }
}