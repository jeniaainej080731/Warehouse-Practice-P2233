namespace Warehouse.UI.Forms
{
    partial class EmployeeDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDetailsForm));
            panel1 = new Panel();
            DeleteBtn = new Button();
            EditBtn = new Button();
            InfoTxt = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(DeleteBtn);
            panel1.Controls.Add(EditBtn);
            panel1.Controls.Add(InfoTxt);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 578);
            panel1.TabIndex = 1;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.FromArgb(192, 0, 0);
            DeleteBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            DeleteBtn.ForeColor = Color.White;
            DeleteBtn.Location = new Point(123, 527);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(94, 40);
            DeleteBtn.TabIndex = 2;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.BackColor = Color.Cyan;
            EditBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            EditBtn.Location = new Point(23, 527);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(94, 40);
            EditBtn.TabIndex = 2;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // InfoTxt
            // 
            InfoTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            InfoTxt.Font = new Font("Times New Roman", 14F);
            InfoTxt.Location = new Point(12, 373);
            InfoTxt.Multiline = true;
            InfoTxt.Name = "InfoTxt";
            InfoTxt.ReadOnly = true;
            InfoTxt.Size = new Size(333, 148);
            InfoTxt.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(333, 355);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // EmployeeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 578);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Employee Details";
            Load += EmployeeDetailsForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button DeleteBtn;
        private Button EditBtn;
        private TextBox InfoTxt;
        private PictureBox pictureBox1;
    }
}