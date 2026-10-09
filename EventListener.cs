using System;

public class EventListener
{
    // Creates the event
    private EventHandler<Event>? _onEventRecived;
    // Does the ops for the triggers (sub the trigger or unsub it)
    public void EventOperation(EventHandler<Event> handler, string op)
    {
        switch (op)
        {
            case "sub":
            _onEventRecived += handler;
            break;
            case "unsub":
            _onEventRecived -= handler;
            break;
            default:
            Console.WriteLine("Coloque uma operacao valida (sub para subscribe unsub para unsubscribe)");
            break;
        }
    }

    protected virtual void EventReciver(Event evento){
        _onEventRecived?.Invoke(this, evento);
    }
}