namespace Server.Forms
{
    partial class FrmChat
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
            rTB_chat = new RichTextBox();
            lab_chat = new Label();
            rTB_message = new RichTextBox();
            SuspendLayout();
            // 
            // rTB_chat
            // 
            rTB_chat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_chat.BackColor = Color.FromArgb(224, 224, 224);
            rTB_chat.BorderStyle = BorderStyle.None;
            rTB_chat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rTB_chat.ForeColor = Color.Black;
            rTB_chat.Location = new Point(12, 37);
            rTB_chat.Name = "rTB_chat";
            rTB_chat.ReadOnly = true;
            rTB_chat.Size = new Size(570, 531);
            rTB_chat.TabIndex = 0;
            rTB_chat.Text = "";
            // 
            // lab_chat
            // 
            lab_chat.AutoSize = true;
            lab_chat.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lab_chat.ForeColor = Color.Black;
            lab_chat.Location = new Point(10, 9);
            lab_chat.Name = "lab_chat";
            lab_chat.Size = new Size(51, 25);
            lab_chat.TabIndex = 4;
            lab_chat.Text = "Chat";
            // 
            // rTB_message
            // 
            rTB_message.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_message.BackColor = Color.FromArgb(224, 224, 224);
            rTB_message.BorderStyle = BorderStyle.None;
            rTB_message.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rTB_message.ForeColor = Color.Black;
            rTB_message.Location = new Point(10, 619);
            rTB_message.Multiline = false;
            rTB_message.Name = "rTB_message";
            rTB_message.Size = new Size(572, 33);
            rTB_message.TabIndex = 5;
            rTB_message.Text = "";
            rTB_message.KeyDown += rTB_message_KeyDown;
            // 
            // FrmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(594, 675);
            Controls.Add(rTB_message);
            Controls.Add(lab_chat);
            Controls.Add(rTB_chat);
            Name = "FrmChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            FormClosing += FrmChat_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rTB_chat;
        private Label lab_chat;
        private RichTextBox rTB_message;
    }
}