using System;

public class ExampleEvent
{
        // Normaly we would sub a function direcly. But, because we need to PASS the result
        // to the event listener, we need to envolve the result func on a eventHandler var
        // (making it a event, that is also a result functions)

    // This is where the process will occor, and a "result" will be sent
    public static EventHandler<EventParams> exampleEvent = (sender, email) => {
        Console.WriteLine($"Testando um evento dora do script Program {email.Origin}");
    };
}