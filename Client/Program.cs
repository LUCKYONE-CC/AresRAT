

using System.Diagnostics;

namespace Client
{
    public static class Program
    {
        private static string[] keys = Communication.Encryption.RSA.GenerateKeys();
        public static readonly string pubKeyString = keys[0];
        public static readonly string privKeyString = keys[1];
        public static bool canNowSendSymEncrypted = false;
        public static readonly List<string> reservedKeywords = new List<string>() { "ENCRYPTIONFAILED", "CLIENTINITIALIZE", "ENCRYPTEDMESSAGE", "CHATFROMSERVER", "STOPCHATTHREAD", "STARTCHAT" };
        static void Main(string[] args)
        {
            Communication.Network.Listen();
        }
    }
}