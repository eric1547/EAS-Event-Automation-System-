using MailKit.Security;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using System.Text.Json;

// Main class
public class MailConection
{
    // Auth func, because of the awaits it needs to be a tastk, and returns a array of objects
    public async static Task<SaslMechanismOAuth2> Auth()
   {
        // Email that it will conect to
        const string GMailAccount = "guga.cunhaoliveira@gmail.com";
        // Makes the json string into the objct (it needs to make it into the parent objct)
        // its yellow, noooo. But its better then needing to use ? alot. This operator checks if its not null before
        // the assigning. It makes things prettier, but it costs cpu.
        Installed ClientObj = JsonSerializer.Deserialize<Installed>(File.ReadAllText("client_secret.json"));
        // Configs the ClientSecreats
        // By declaring de vars direcly (by putting their type as the objc), you dont need the "new xyz". Just
        // use the new {xyz}, make things a little better I think
        ClientSecrets clientSecrets = new(){
            ClientId = ClientObj.installed.client_id,
            ClientSecret = ClientObj.installed.client_secret
        };
        // This sets up all the gig that you would need to do if doing by hand (http protocolls `n stuf)
        // by passing a Initializer, witch is what initializes the gig setup
        GoogleAuthorizationCodeFlow codeFlow = new (new GoogleAuthorizationCodeFlow.Initializer {
            // Cache tokens in ~/.local/share/google-filedatastore/CredentialCacheFolder on Linux/Mac
            DataStore = new FileDataStore ("CredentialCacheFolder", false),
            // Sets the scopes (in this case just the google gmail)
            Scopes = ["https://mail.google.com/"],
            // Sets the client secrets by passing the clientSecrets that were settet up before
            ClientSecrets = clientSecrets,
            // Its the email that will be "watched" by the program (passing the email setted up up on the code)
            LoginHint = GMailAccount
        });

        // Note: For a web app, you'll want to use AuthorizationCodeWebApp instead.
        // This is a local server that will recive the gig to run. This makes so you dont need to set upp a server
        // to do the conection and auth
        LocalServerCodeReceiver codeReceiver = new();
        AuthorizationCodeInstalledApp authCode = new(codeFlow, codeReceiver);
        // Auths the credentials and stores the token
        UserCredential credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);
        // Case token needs refresh, refresshes the token
        switch (credential.Token.IsStale)
        {
            case true:
                await credential.RefreshTokenAsync(CancellationToken.None);
            break;
            default:
            break;
        }
        // Simple Authentication and Security Layer (SASL) is a method of using token auth.
        // Because of the name, I`m lead to belive that its sopoused to be a simple method, tough I dont know
        // how it works in between the lines
        return new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);
    }
}