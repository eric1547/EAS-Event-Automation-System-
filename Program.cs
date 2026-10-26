using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

public class Program
{
    // Use the shared instance so subscriptions and event triggers operate on the same listener.
    // This is the Singleton access point; creating a separate listener here would have separate subscriptions.
    static EventListener listener = EventListener.Instance;
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

        // This one needs so it can be cleared afterwards
        var inbox = client.Inbox;
        await inbox.OpenAsync(FolderAccess.ReadOnly);
        int InboxCount = client.Inbox.Count;

        listener.EventSub(OnEmailRecived.onEmailRecived);
        while (true)
        {
            if (InboxCount != inbox.Count)
            {
                MimeMessage newInboxEmail = inbox.GetMessage(inbox.Count - 1);
                Email newEmail = new(newInboxEmail.From.ToString(), newInboxEmail.Subject, newInboxEmail.TextBody);
                Console.WriteLine("egggggggggggg");
                Console.WriteLine(newEmail.Subject);
                await listener.EventTrigger(newEmail);
                break;
            }
            // I dont like this, but for some reason its the only thing that works for constanly check the email inbox
            inbox = null;
            inbox = client.Inbox;
            await inbox.OpenAsync(FolderAccess.ReadOnly);
        }
        listener.EventUnsub(OnEmailRecived.onEmailRecived);
        await client.DisconnectAsync(true);
    }
}