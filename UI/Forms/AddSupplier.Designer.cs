namespace Warehouse.UI.Forms
{
    partial class AddSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSupplier));
            NameTxt = new TextBox();
            label1 = new Label();
            AddressTxt = new TextBox();
            label2 = new Label();
            PhoneTxt = new TextBox();
            label3 = new Label();
            EmailTxt = new TextBox();
            label4 = new Label();
            AddBtn = new Button();
            CancelBtn = new Button();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            ChoosePhotoBtn = new Button();
            photoPathLbl = new TextBox();
            SuspendLayout();
            // 
            // NameTxt
            // 
            NameTxt.Font = new Font("Segoe UI", 10.8F);
            NameTxt.Location = new Point(47, 64);
            NameTxt.Name = "NameTxt";
            NameTxt.Size = new Size(227, 31);
            NameTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(47, 33);
            label1.Name = "label1";
            label1.Size = new Size(66, 28);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // AddressTxt
            // 
            AddressTxt.Font = new Font("Segoe UI", 10.8F);
            AddressTxt.Location = new Point(47, 135);
            AddressTxt.Name = "AddressTxt";
            AddressTxt.Size = new Size(227, 31);
            AddressTxt.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(47, 104);
            label2.Name = "label2";
            label2.Size = new Size(85, 28);
            label2.TabIndex = 1;
            label2.Text = "Address";
            // 
            // PhoneTxt
            // 
            PhoneTxt.Font = new Font("Segoe UI", 10.8F);
            PhoneTxt.Location = new Point(47, 205);
            PhoneTxt.Name = "PhoneTxt";
            PhoneTxt.Size = new Size(227, 31);
            PhoneTxt.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(47, 174);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 1;
            label3.Text = "Phone";
            // 
            // EmailTxt
            // 
            EmailTxt.Font = new Font("Segoe UI", 10.8F);
            EmailTxt.Location = new Point(47, 275);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(227, 31);
            EmailTxt.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(47, 244);
            label4.Name = "label4";
            label4.Size = new Size(60, 28);
            label4.TabIndex = 1;
            label4.Text = "Email";
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.DarkGreen;
            AddBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(27, 440);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(94, 36);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(127, 440);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 36);
            CancelBtn.TabIndex = 7;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(47, 319);
            label5.Name = "label5";
            label5.Size = new Size(67, 28);
            label5.TabIndex = 1;
            label5.Text = "Photo";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "ChoosePhoto";
            // 
            // ChoosePhotoBtn
            // 
            ChoosePhotoBtn.FlatStyle = FlatStyle.Popup;
            ChoosePhotoBtn.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            ChoosePhotoBtn.Location = new Point(63, 350);
            ChoosePhotoBtn.Name = "ChoosePhotoBtn";
            ChoosePhotoBtn.Size = new Size(188, 29);
            ChoosePhotoBtn.TabIndex = 5;
            ChoosePhotoBtn.Text = "Choose a photo";
            ChoosePhotoBtn.UseVisualStyleBackColor = true;
            ChoosePhotoBtn.Click += ChoosePhotoBtn_Click;
            // 
            // photoPathLbl
            // 
            photoPathLbl.Font = new Font("Segoe UI", 10.8F);
            photoPathLbl.Location = new Point(47, 385);
            photoPathLbl.Name = "photoPathLbl";
            photoPathLbl.ReadOnly = true;
            photoPathLbl.ScrollBars = ScrollBars.Horizontal;
            photoPathLbl.Size = new Size(227, 31);
            photoPathLbl.TabIndex = 8;
            // 
            // AddSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 488);
            Controls.Add(ChoosePhotoBtn);
            Controls.Add(CancelBtn);
            Controls.Add(AddBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(photoPathLbl);
            Controls.Add(EmailTxt);
            Controls.Add(PhoneTxt);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(AddressTxt);
            Controls.Add(NameTxt);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSupplier";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Supplier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTxt;
        private Label label1;
        private TextBox AddressTxt;
        private Label label2;
        private TextBox PhoneTxt;
        private Label label3;
        private TextBox EmailTxt;
        private Label label4;
        private Button AddBtn;
        private Button CancelBtn;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private Button ChoosePhotoBtn;
        private TextBox photoPathLbl;
    }
}