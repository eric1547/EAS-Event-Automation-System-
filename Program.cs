using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;

public class Program
{
        static EventListener listener = new();
    public static async Task Main()
    {
        SaslMechanismOAuth2 oauth2 = await MailConection.Auth();
        // using makes so all ressorces are released from memory. That way, this memory can be reused after the operations are
        // done.
        using ImapClient client = new();
        // BTW, the imap cliente is a client conected to the local imap server, the imap is just for reciving emails
        await client.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
        await client.AuthenticateAsync(oauth2);
        // Code goes here
        var inbox = client.Inbox;
        await inbox.OpenAsync(FolderAccess.ReadOnly);
        var firstMasage = await inbox.GetMessageAsync(inbox.Count - 1);
        Console.WriteLine(firstMasage.Subject);
        Console.WriteLine(firstMasage.From);
        //Console.WriteLine(firstMasage.TextBody);
        await GeminiConection.ResumeMaking(firstMasage.TextBody);

        await client.DisconnectAsync(true);

        /*
        Email email = new("diretoria@empresa.com", "Reunião", "Corpo do e-mail..."); 
        listener.EventSub(ExampleEvent.exampleEvent);
        listener.EventTrigger(email);
        listener.EventUnsub(ExampleEvent.exampleEvent);
        await MailConection.Auth();
        */
    }
}