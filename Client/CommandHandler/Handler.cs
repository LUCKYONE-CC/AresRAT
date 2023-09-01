using Client.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.CommandHandler
{
    public static class Handler
    {
        public static void CheckMessageForCommands(string message)
        {
            switch (message)
            {
                case string s when s.Contains("CLIENTINITIALIZE"):
                    // Sucht nach dem Index des verschlüsselten Passwort-Strings
                    int startIndex = "CLIENTINITIALIZE".Length;
                    int encryptedPasswordStartIndex = startIndex;
                    int encryptedPasswordEndIndex = message.IndexOf("!!!");

                    // Extrahiert den verschlüsselten Passwort-String
                    string encryptedPassword = message.Substring(encryptedPasswordStartIndex, encryptedPasswordEndIndex - encryptedPasswordStartIndex);

                    // Extrahiert die Client-ID
                    int clientIdStartIndex = encryptedPasswordEndIndex + "!!!".Length;
                    string clientId = message.Substring(clientIdStartIndex);

                    //converting rsaPubKeyString back to RSAParameter
                    RSAParameters rsaPubKey = Communication.Encryption.RSA.ConvertRSAKeyToRSAParameters(Program.privKeyString);
                    string plainSymPassword = Communication.Encryption.RSA.Decrypt(rsaPubKey, encryptedPassword);
                    ClientInfo.clientInfoModel.SymKey = plainSymPassword;
                    ClientInfo.clientInfoModel.Id = Int32.Parse(clientId);
                    if (clientId != null && encryptedPassword != null)
                    {
                        Program.canNowSendSymEncrypted = true;
                    }
                    else
                    {
                        Communication.Network.Send(clientId, "encryptionfailed");
                        Console.WriteLine("Encryption failed. Please try again.");
                    }
                    break;

                case string s when s.Contains("CHATFROMSERVER"):
                    string encryptedMessageFromServer = message.Replace("CHATFROMSERVER", "");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown: " + Communication.Encryption.AES.Decrypt(ClientInfo.clientInfoModel.SymKey, encryptedMessageFromServer));
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case string s when s.Contains("STOPCHATTHREAD"):
                    Helper.ThreadStopFlags.STOPCHAT = true;
                    break;

                case string s when s.Contains("STARTCHAT"):
                    Thread chatThread = new Thread(() =>
                    {
                        Console.Clear();
                        Console.WriteLine("You can write from now on");
                        while (Helper.ThreadStopFlags.STOPCHAT == false)
                        {
                            string messageFromClient = Console.ReadLine();
                            Communication.Network.Send(messageFromClient, "chatmessagefromclient");
                        }
                        Helper.ThreadStopFlags.STOPCHAT = false;
                    });
                    chatThread.Start();
                    break;

                case string s when s.Contains("REMOTESHELL"):
                    // Erstellen Sie eine neue Instanz der Process-Klasse
                    Process cmdProcess = new Process();

                    // Konfigurieren Sie die Startinfo, um cmd.exe zu starten
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "cmd.exe";
                    startInfo.RedirectStandardInput = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    // Starten Sie den Prozess
                    cmdProcess.StartInfo = startInfo;
                    cmdProcess.Start();

                    // Senden Sie Befehle an die Shell
                    cmdProcess.StandardInput.WriteLine("dir");
                    cmdProcess.StandardInput.WriteLine("echo Hello World");

                    // Lesen Sie die Ausgabe der Shell
                    string output = cmdProcess.StandardOutput.ReadToEnd();

                    // Geben Sie die Ausgabe in Ihrer Forms-Anwendung aus
                    Console.WriteLine(output);

                    // Beenden Sie den Prozess
                    cmdProcess.StandardInput.WriteLine("exit");
                    cmdProcess.WaitForExit();
                    break;

                default:
                    break;
            }
        }
    }
}
