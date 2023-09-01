using Server.Models;
using System.Security.Cryptography;

namespace Server.Communication.Encryption
{
    public class FromAsymToSymEncryption
    {
        /// <summary>
        /// Erstellt ein zufälliges Passwort für die Verschlüsselte Kommunikation via Symmetrischer Verschlüsselung und 
        /// verschlüsselt den Key mit dem RSA Public Key des Clients. Zusätzlich speichert die Methode den Sym-Key in dem ClientInfo-Objekt
        /// </summary>
        /// <returns></returns>
        public static string CreateEncryptedSynPassword(ClientInfo clientInfo, string rsaPubKeyString)
        {
            string symPassword = "";

            //Erstellt zufälliges Passwort
            Random random = new Random();
            for (int i = 0; i < 32; i++)
            {
                symPassword += ((char)random.Next(33, 126)).ToString();
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random2 = new Random();
            var result = new string(Enumerable.Repeat(chars, 32).Select(s => s[random2.Next(s.Length)]).ToArray());
            symPassword += result;

            //Speichert den Sym-Key in dem ClientInfo-Objekt
            clientInfo.SymKey = symPassword;

            //converting rsaPubKeyString back to RSAParameter
            RSAParameters rsaPubKey = Communication.Encryption.RSA.ConvertRSAKeyToRSAParameters(rsaPubKeyString);

            return Communication.Encryption.RSA.Encrypt(rsaPubKey, symPassword);
        }
    }
}
