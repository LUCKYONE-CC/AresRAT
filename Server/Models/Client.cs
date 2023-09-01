using System.Net.Sockets;

namespace Server.Models
{
    public class Client
    {
        public Client()
        {
            ClientInfo = new ClientInfo();
        }
        public ClientInfo ClientInfo { get; set; }
        public TcpClient TcpClient { get; set; }
    }
}
