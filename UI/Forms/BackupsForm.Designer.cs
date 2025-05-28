namespace Warehouse.UI.Forms
{
    partial class BackupsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupsForm));
            comboBoxDatabases = new ComboBox();
            label1 = new Label();
            RestoreBtn = new Button();
            BackupAllBtn = new Button();
            SuspendLayout();
            // 
            // comboBoxDatabases
            // 
            comboBoxDatabases.Font = new Font("Segoe UI", 10.8F);
            comboBoxDatabases.FormattingEnabled = true;
            comboBoxDatabases.Location = new Point(23, 62);
            comboBoxDatabases.Name = "comboBoxDatabases";
            comboBoxDatabases.Size = new Size(181, 33);
            comboBoxDatabases.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(23, 26);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 1;
            label1.Text = "Database";
            // 
            // RestoreBtn
            // 
            RestoreBtn.BackColor = Color.PaleTurquoise;
            RestoreBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            RestoreBtn.Location = new Point(225, 62);
            RestoreBtn.Name = "RestoreBtn";
            RestoreBtn.Size = new Size(94, 34);
            RestoreBtn.TabIndex = 2;
            RestoreBtn.Text = "Restore";
            RestoreBtn.UseVisualStyleBackColor = false;
            RestoreBtn.Click += RestoreBtn_Click;
            // 
            // BackupAllBtn
            // 
            BackupAllBtn.BackColor = Color.Coral;
            BackupAllBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BackupAllBtn.Location = new Point(23, 114);
            BackupAllBtn.Name = "BackupAllBtn";
            BackupAllBtn.Size = new Size(94, 34);
            BackupAllBtn.TabIndex = 2;
            BackupAllBtn.Text = "Backup All";
            BackupAllBtn.UseVisualStyleBackColor = false;
            BackupAllBtn.Click += BackupAllBtn_Click;
            // 
            // BackupsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(352, 172);
            Controls.Add(BackupAllBtn);
            Controls.Add(RestoreBtn);
            Controls.Add(label1);
            Controls.Add(comboBoxDatabases);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BackupsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Backups";
            Load += BackupsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxDatabases;
        private Label label1;
        private Button RestoreBtn;
        private Button BackupAllBtn;
    }
}