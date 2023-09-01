using Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class FrmChat : Form
    {
        private int clientId;
        public FrmChat(int clientId)
        {
            InitializeComponent();
            this.clientId = clientId;

            string code = @"
            using System.Threading;
            using Client.Helper;   
            Thread chatThread = new Thread(() =>
            {
                while (Helper.ThreadStopFlags.STOPCHAT == true)
                {
                    Console.Write("">"");
                    string messageFromClient = Console.ReadLine();
                    Communication.Network.Send(messageFromClient);
                }
                Helper.ThreadStopFlags.STOPCHAT = false;
            });
            chatThread.Start();
            ";

            //Communication.Network.Send(clientId, code);
            Communication.Network.Send(clientId, "", true, "STARTCHAT");
        }

        private void FrmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Communication.Network.Send(clientId, "", true, "STOPCHATTHREAD");
        }

        private void rTB_message_KeyDown(object sender, KeyEventArgs e)
        {
            // Überprüfen, ob die Enter-Taste gedrückt wurde
            if (e.KeyCode == Keys.Enter)
            {
                if (rTB_message.Text != null)
                {
                    rTB_chat.Text += $"You: {rTB_message.Text}\n";
                    Communication.Network.Send(clientId, rTB_message.Text, true, "CHATFROMSERVER");
                    rTB_message.Text = "";
                }
                else
                {
                    MessageBox.Show("The messagebox is empty");
                }
            }
        }
    }
}
