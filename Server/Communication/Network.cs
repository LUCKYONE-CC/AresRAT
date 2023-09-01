using System.Net.Sockets;
using System.Net;
using System.Text;
using Server.Models;
using System.Collections.Concurrent;
using Newtonsoft.Json;
using Server.CrossThreading;

namespace Server.Communication
{
    public static class Network
    {
        public static List<Client> clientsList = new List<Client>();
        // Erstellen einer Thread-sichere Liste für die DataGridView
        public static ConcurrentBag<ClientInfo> clientListForDataGridView = new ConcurrentBag<ClientInfo>();

        public static void Listen()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1234);
            server.Start();
            //UpdateChatBox("Server has started on 127.0.0.1:8888");

            Thread acceptThread = new Thread(() =>
            {
                while (true)
                {
                    Client client = new Client();
                    client.TcpClient = server.AcceptTcpClient();

                    clientsList.Add(client);

                    Thread clientThread = new Thread(() =>
                    {
                        NetworkStream stream = client.TcpClient.GetStream();
                        while (true)
                        {
                            byte[] messageBytes = new byte[1024];
                            int bytesRead = 0;
                            try
                            {
                                bytesRead = stream.Read(messageBytes, 0, messageBytes.Length);
                            }
                            catch
                            {
                                break;
                            }
                            if (bytesRead == 0)
                            {
                                break;
                            }
                            string message = Encoding.ASCII.GetString(messageBytes, 0, bytesRead);

                            //Messageprocessing
                            CommandHandler.Handler.CheckMessageForCommands(message, client);
                        }
                        clientsList.Remove(client);
                        UIAccesses.UpdateClientDataGridView(client.ClientInfo, true);
                        UIAccesses.UpdateProtocolBox("A client disconnected.");
                    });
                    clientThread.Start();
                }
            });
            acceptThread.Start();
        }

        public static void Send(int id, string message, bool sendSymEncrypted = true, string flag = "")
        {
            if(sendSymEncrypted)
            {
                string symPassword = clientsList.FirstOrDefault(x => x.ClientInfo.Id == id).ClientInfo.SymKey;
                if(symPassword == null)
                {
                    //Client muss Disconnected werden, da Verschlüsselung nicht gewährleistet werden kann
                }

                //Message wird symmetrisch verschlüsselt
                message = Communication.Encryption.AES.Encrypt(symPassword, message);

                //Add flag
                message = flag + message;
            }
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            var client = clientsList.FirstOrDefault(x => x.ClientInfo.Id == id);
            if (client == null)
            {
                return;
            }
            NetworkStream cStream = client.TcpClient.GetStream();
            cStream.Write(messageBytes, 0, messageBytes.Length);
        }
    }
}
