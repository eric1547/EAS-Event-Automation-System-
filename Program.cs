using System;

public class Program
{
    public static void Main()
    {
        EventListener listener = new EventListener();
        Email email = new Email("diretoria@empresa.com", "Reunião", "Corpo do e-mail...");
        listener.EventSub(ExampleEvent.exampleEvent);
        listener.EventTrigger(email);
        listener.EventUnsub(ExampleEvent.exampleEvent);
    }
}