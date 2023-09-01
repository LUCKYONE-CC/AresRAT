using Server.Models;

namespace Server.CrossThreading
{
    public class UIAccesses
    {
        public static void UpdateProtocolBox(string message)
        {
            try
            {
                RichTextBox rTB_chatBox = Application.OpenForms["Form1"].Controls["rTB_chatBox"] as RichTextBox;
                if (rTB_chatBox.InvokeRequired)
                {
                    rTB_chatBox.Invoke(new Action<string>(UpdateProtocolBox), message);
                    return;
                }
                rTB_chatBox.Text += message + "\n";
            }
            catch (Exception ex)
            {

            }
        }

        public static void UpdateChatBox(string message)
        {
            try
            {
                RichTextBox rTB_chatBox = Application.OpenForms["FrmChat"].Controls["rTB_chat"] as RichTextBox;
                if (rTB_chatBox.InvokeRequired)
                {
                    rTB_chatBox.Invoke(new Action<string>(UpdateChatBox), message);
                    return;
                }
                rTB_chatBox.Text += message;
            }
            catch (Exception ex)
            {

            }
        }

        public static void UpdateClientDataGridView(ClientInfo client, bool remove = false)
        {
            try
            {
                DataGridView dGV_clients = Application.OpenForms["Form1"].Controls["dGV_clients"] as DataGridView;
                if (remove)
                {
                    RemoveClientFromClientDataGridView(client, dGV_clients);
                    return;
                }

                // Fügen Sie den Client zur Thread-sicheren Liste hinzu
                Communication.Network.clientListForDataGridView.Add(client);

                // Aktualisieren Sie die DataSource innerhalb des UI-Threads
                dGV_clients.Invoke((MethodInvoker)delegate {
                    dGV_clients.DataSource = null;
                    dGV_clients.DataSource = Communication.Network.clientListForDataGridView.ToList();
                });
            }
            catch (Exception ex)
            {

            }
        }

        private static void RemoveClientFromClientDataGridView(ClientInfo client, DataGridView dataGridView)
        {
            try
            {
                if (Communication.Network.clientListForDataGridView.TryTake(out ClientInfo removedClient))
                {
                    dataGridView.Invoke((MethodInvoker)delegate {
                        dataGridView.DataSource = null;
                        dataGridView.DataSource = Communication.Network.clientListForDataGridView.ToList();
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
