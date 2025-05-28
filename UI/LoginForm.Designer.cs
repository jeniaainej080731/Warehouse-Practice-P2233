namespace Warehouse.UI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LoginTxt = new TextBox();
            PasswordTxt = new TextBox();
            EnterBtn = new Button();
            SeePassBtn = new Button();
            SuspendLayout();
            // 
            // LoginTxt
            // 
            LoginTxt.Font = new Font("Segoe UI", 10.8F);
            LoginTxt.Location = new Point(31, 33);
            LoginTxt.Name = "LoginTxt";
            LoginTxt.PlaceholderText = "login";
            LoginTxt.Size = new Size(176, 31);
            LoginTxt.TabIndex = 0;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Font = new Font("Segoe UI", 10.8F);
            PasswordTxt.Location = new Point(31, 89);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = '※';
            PasswordTxt.PlaceholderText = "password";
            PasswordTxt.Size = new Size(176, 31);
            PasswordTxt.TabIndex = 1;
            // 
            // EnterBtn
            // 
            EnterBtn.BackColor = Color.CornflowerBlue;
            EnterBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EnterBtn.Location = new Point(69, 166);
            EnterBtn.Name = "EnterBtn";
            EnterBtn.Size = new Size(94, 38);
            EnterBtn.TabIndex = 2;
            EnterBtn.Text = "Enter";
            EnterBtn.UseVisualStyleBackColor = false;
            EnterBtn.Click += EnterBtn_Click;
            // 
            // SeePassBtn
            // 
            SeePassBtn.FlatAppearance.BorderSize = 0;
            SeePassBtn.FlatStyle = FlatStyle.Flat;
            SeePassBtn.Image = Properties.Resources.dontseepass;
            SeePassBtn.Location = new Point(211, 90);
            SeePassBtn.Name = "SeePassBtn";
            SeePassBtn.Size = new Size(33, 29);
            SeePassBtn.TabIndex = 3;
            SeePassBtn.UseVisualStyleBackColor = true;
            SeePassBtn.Click += SeePassBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(247, 220);
            Controls.Add(SeePassBtn);
            Controls.Add(EnterBtn);
            Controls.Add(PasswordTxt);
            Controls.Add(LoginTxt);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginTxt;
        private TextBox PasswordTxt;
        private Button EnterBtn;
        private Button SeePassBtn;
    }
}