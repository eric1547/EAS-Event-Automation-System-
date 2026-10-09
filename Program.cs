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
        EventHandler<EventParams> eventResult = (sender, email) => // As we cans see, pure c# has arrow funcs
        {
            Console.WriteLine($"Testing {email.Origin}");
        };
        listener.EventSub(eventResult);
        listener.EventTrigger(email);
    }
}