namespace Server.Forms
{
    partial class FrmRemoteShell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rTB_console = new RichTextBox();
            rTB_command = new RichTextBox();
            SuspendLayout();
            // 
            // rTB_console
            // 
            rTB_console.BackColor = Color.Black;
            rTB_console.Dock = DockStyle.Top;
            rTB_console.ForeColor = Color.FromArgb(0, 192, 0);
            rTB_console.Location = new Point(0, 0);
            rTB_console.Name = "rTB_console";
            rTB_console.Size = new Size(903, 478);
            rTB_console.TabIndex = 0;
            rTB_console.Text = "";
            // 
            // rTB_command
            // 
            rTB_command.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_command.BackColor = Color.Black;
            rTB_command.BorderStyle = BorderStyle.None;
            rTB_command.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rTB_command.ForeColor = Color.White;
            rTB_command.Location = new Point(12, 508);
            rTB_command.Multiline = false;
            rTB_command.Name = "rTB_command";
            rTB_command.Size = new Size(879, 33);
            rTB_command.TabIndex = 6;
            rTB_command.Text = "";
            rTB_command.KeyDown += rTB_command_KeyDown;
            // 
            // FrmRemoteShell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 563);
            Controls.Add(rTB_command);
            Controls.Add(rTB_console);
            Name = "FrmRemoteShell";
            Text = "FrmRemoteShell";
            FormClosing += FrmRemoteShell_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rTB_console;
        private RichTextBox rTB_command;
    }
}