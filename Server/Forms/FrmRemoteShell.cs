

using Server.Models;
using System.Diagnostics;

namespace Server.Forms
{
    public partial class FrmRemoteShell : Form
    {
        public FrmRemoteShell()
        {
            InitializeComponent();

            // Erstellen Sie eine neue Instanz der Process-Klasse
            //Process cmdProcess = new Process();

            // Konfigurieren Sie die Startinfo, um cmd.exe zu starten


            // Senden Sie Befehle an die Shell
            //cmdProcess.StandardInput.WriteLine("dir");
            //cmdProcess.StandardInput.WriteLine("echo Hello World");

            // Lesen Sie die Ausgabe der Shell
            //string output = cmdProcess.StandardOutput.ReadToEnd();

            // Geben Sie die Ausgabe in Ihrer Forms-Anwendung aus
            //textBox1.Text = output;

            // Beenden Sie den Prozess
            //cmdProcess.StandardInput.WriteLine("exit");
            //cmdProcess.WaitForExit();
        }

        private void FrmRemoteShell_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void rTB_command_KeyDown(object sender, KeyEventArgs e)
        {
            // Überprüfen, ob die Enter-Taste gedrückt wurde
            if (e.KeyCode == Keys.Enter)
            {
                if (rTB_command.Text != null)
                {

                }
                else
                {
                    MessageBox.Show("The messagebox is empty");
                }
            }
        }
    }
}
