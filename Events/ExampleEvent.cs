using System;

public class ExampleEvent
{
    // This is where the process will occor, and a "result" will be sent
    public static EventHandler<EventParams> exampleEvent = (sender, email) => {
        Console.WriteLine($"Testando um evento dora do script Program {email.Origin}");
    };
}