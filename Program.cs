using System;

public class Program
{
    public static void Main()
    {
        EventListener listener = new EventListener();
        Email email = new Email("diretoria@empresa.com", "Reunião", "Corpo do e-mail...");
        // Normaly we would sub a function direcly. But, because we need to PASS the result
        // to the event listener, we need to envolve the result func on a eventHandler var
        // (making it a event, that is also a result functions)
        listener.EventSub(ExampleEvent.exampleEvent);
        listener.EventTrigger(email);
        listener.EventUnsub(ExampleEvent.exampleEvent);
    }
}