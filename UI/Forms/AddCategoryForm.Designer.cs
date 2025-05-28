namespace Warehouse.UI.Forms
{
    partial class AddCategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategoryForm));
            label1 = new Label();
            CategoryNameTxt = new TextBox();
            label2 = new Label();
            DescriptionTxt = new TextBox();
            SaveBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(28, 23);
            label1.Name = "label1";
            label1.Size = new Size(154, 28);
            label1.TabIndex = 0;
            label1.Text = "Category Name";
            // 
            // CategoryNameTxt
            // 
            CategoryNameTxt.Font = new Font("Segoe UI", 10.8F);
            CategoryNameTxt.Location = new Point(28, 54);
            CategoryNameTxt.Name = "CategoryNameTxt";
            CategoryNameTxt.Size = new Size(258, 31);
            CategoryNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(28, 85);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 0;
            label2.Text = "Description";
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Font = new Font("Segoe UI", 10.2F);
            DescriptionTxt.Location = new Point(28, 116);
            DescriptionTxt.Multiline = true;
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.ScrollBars = ScrollBars.Vertical;
            DescriptionTxt.Size = new Size(258, 135);
            DescriptionTxt.TabIndex = 1;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.DarkGreen;
            SaveBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(28, 259);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(128, 259);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 29);
            CancelBtn.TabIndex = 2;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // AddCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(332, 297);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(DescriptionTxt);
            Controls.Add(label2);
            Controls.Add(CategoryNameTxt);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddCategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Category";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox CategoryNameTxt;
        private Label label2;
        private TextBox DescriptionTxt;
        private Button SaveBtn;
        private Button CancelBtn;
    }
}