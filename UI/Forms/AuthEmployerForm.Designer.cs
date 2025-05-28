namespace Warehouse.UI.Forms
{
    partial class AuthEmployerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthEmployerForm));
            label1 = new Label();
            LoginTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            PasswordTxt = new TextBox();
            SaveBtn = new Button();
            CancelBtn = new Button();
            RoleCb = new ComboBox();
            label4 = new Label();
            EmployerTxt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(30, 34);
            label1.Name = "label1";
            label1.Size = new Size(97, 28);
            label1.TabIndex = 1;
            label1.Text = "Employer";
            // 
            // LoginTxt
            // 
            LoginTxt.Font = new Font("Segoe UI", 10.8F);
            LoginTxt.Location = new Point(30, 209);
            LoginTxt.Name = "LoginTxt";
            LoginTxt.Size = new Size(193, 31);
            LoginTxt.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(30, 178);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 1;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(30, 253);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // PasswordTxt
            // 
            PasswordTxt.Font = new Font("Segoe UI", 10.8F);
            PasswordTxt.Location = new Point(30, 284);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(193, 31);
            PasswordTxt.TabIndex = 2;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.Green;
            SaveBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(30, 339);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 35);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ButtonShadow;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(129, 339);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 35);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // RoleCb
            // 
            RoleCb.Font = new Font("Segoe UI", 10.8F);
            RoleCb.FormattingEnabled = true;
            RoleCb.Location = new Point(27, 141);
            RoleCb.Name = "RoleCb";
            RoleCb.Size = new Size(193, 33);
            RoleCb.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(27, 110);
            label4.Name = "label4";
            label4.Size = new Size(51, 28);
            label4.TabIndex = 1;
            label4.Text = "Role";
            // 
            // EmployerTxt
            // 
            EmployerTxt.Font = new Font("Segoe UI", 10.8F);
            EmployerTxt.Location = new Point(27, 65);
            EmployerTxt.Name = "EmployerTxt";
            EmployerTxt.Size = new Size(193, 31);
            EmployerTxt.TabIndex = 2;
            // 
            // AuthEmployerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(266, 386);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(PasswordTxt);
            Controls.Add(EmployerTxt);
            Controls.Add(LoginTxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(RoleCb);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AuthEmployerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Auth Employer";
            Load += AuthEmployerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox LoginTxt;
        private Label label2;
        private Label label3;
        private TextBox PasswordTxt;
        private Button SaveBtn;
        private Button CancelBtn;
        private ComboBox RoleCb;
        private Label label4;
        private TextBox EmployerTxt;
    }
}