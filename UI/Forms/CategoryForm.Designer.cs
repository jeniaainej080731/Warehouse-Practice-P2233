namespace Warehouse.UI.Forms
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            label1 = new Label();
            CategoriesCb = new ComboBox();
            label2 = new Label();
            DescriptionTxt = new TextBox();
            AddBtn = new Button();
            DeleteBtn = new Button();
            CloseBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(48, 30);
            label1.Name = "label1";
            label1.Size = new Size(108, 28);
            label1.TabIndex = 0;
            label1.Text = "Categories";
            // 
            // CategoriesCb
            // 
            CategoriesCb.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CategoriesCb.FormattingEnabled = true;
            CategoriesCb.Location = new Point(48, 61);
            CategoriesCb.Name = "CategoriesCb";
            CategoriesCb.Size = new Size(216, 33);
            CategoriesCb.TabIndex = 1;
            CategoriesCb.SelectedIndexChanged += CategoriesCb_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(48, 144);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 0;
            label2.Text = "Description";
            // 
            // DescriptionTxt
            // 
            DescriptionTxt.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            DescriptionTxt.Location = new Point(48, 175);
            DescriptionTxt.Multiline = true;
            DescriptionTxt.Name = "DescriptionTxt";
            DescriptionTxt.ReadOnly = true;
            DescriptionTxt.ScrollBars = ScrollBars.Vertical;
            DescriptionTxt.Size = new Size(216, 195);
            DescriptionTxt.TabIndex = 2;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.DarkGreen;
            AddBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(48, 100);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(54, 29);
            AddBtn.TabIndex = 3;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.DarkRed;
            DeleteBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DeleteBtn.ForeColor = Color.White;
            DeleteBtn.Location = new Point(108, 100);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(62, 29);
            DeleteBtn.TabIndex = 3;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = SystemColors.ControlDark;
            CloseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CloseBtn.Location = new Point(48, 376);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(94, 29);
            CloseBtn.TabIndex = 4;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(311, 413);
            Controls.Add(CloseBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(AddBtn);
            Controls.Add(DescriptionTxt);
            Controls.Add(CategoriesCb);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Categories";
            Load += CategoryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox CategoriesCb;
        private Label label2;
        private TextBox DescriptionTxt;
        private Button AddBtn;
        private Button DeleteBtn;
        private Button CloseBtn;
    }
}