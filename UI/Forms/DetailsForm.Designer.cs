namespace Warehouse.UI.Forms
{
    partial class DetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsForm));
            label1 = new Label();
            ProductNameTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            PriceTxt = new TextBox();
            label5 = new Label();
            label6 = new Label();
            EmployeeTxt = new TextBox();
            CancelBtn = new Button();
            EditBtn = new Button();
            CategoryTxt = new TextBox();
            QuantityTxt = new TextBox();
            SupplierTxt = new TextBox();
            DeleteBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(17, 16);
            label1.Name = "label1";
            label1.Size = new Size(83, 28);
            label1.TabIndex = 0;
            label1.Text = "Product";
            // 
            // ProductNameTxt
            // 
            ProductNameTxt.Font = new Font("Segoe UI", 10.8F);
            ProductNameTxt.Location = new Point(17, 47);
            ProductNameTxt.Name = "ProductNameTxt";
            ProductNameTxt.ReadOnly = true;
            ProductNameTxt.Size = new Size(217, 31);
            ProductNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(17, 91);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 0;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(17, 166);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 0;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(17, 239);
            label4.Name = "label4";
            label4.Size = new Size(56, 28);
            label4.TabIndex = 0;
            label4.Text = "Price";
            // 
            // PriceTxt
            // 
            PriceTxt.Font = new Font("Segoe UI", 10.8F);
            PriceTxt.Location = new Point(17, 270);
            PriceTxt.Name = "PriceTxt";
            PriceTxt.ReadOnly = true;
            PriceTxt.Size = new Size(217, 31);
            PriceTxt.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(17, 311);
            label5.Name = "label5";
            label5.Size = new Size(87, 28);
            label5.TabIndex = 0;
            label5.Text = "Supplier";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(17, 387);
            label6.Name = "label6";
            label6.Size = new Size(101, 28);
            label6.TabIndex = 0;
            label6.Text = "Employee";
            // 
            // EmployeeTxt
            // 
            EmployeeTxt.Font = new Font("Segoe UI", 10.8F);
            EmployeeTxt.Location = new Point(17, 418);
            EmployeeTxt.Name = "EmployeeTxt";
            EmployeeTxt.ReadOnly = true;
            EmployeeTxt.Size = new Size(217, 31);
            EmployeeTxt.TabIndex = 1;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(140, 501);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 38);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.BackColor = Color.Transparent;
            EditBtn.FlatAppearance.BorderSize = 0;
            EditBtn.FlatStyle = FlatStyle.Flat;
            EditBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            EditBtn.ForeColor = Color.White;
            EditBtn.Image = (Image)resources.GetObject("EditBtn.Image");
            EditBtn.Location = new Point(52, 474);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(48, 48);
            EditBtn.TabIndex = 5;
            EditBtn.TextAlign = ContentAlignment.MiddleRight;
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // CategoryTxt
            // 
            CategoryTxt.Font = new Font("Segoe UI", 10.8F);
            CategoryTxt.Location = new Point(17, 125);
            CategoryTxt.Name = "CategoryTxt";
            CategoryTxt.ReadOnly = true;
            CategoryTxt.Size = new Size(217, 31);
            CategoryTxt.TabIndex = 1;
            // 
            // QuantityTxt
            // 
            QuantityTxt.Font = new Font("Segoe UI", 10.8F);
            QuantityTxt.Location = new Point(17, 197);
            QuantityTxt.Name = "QuantityTxt";
            QuantityTxt.ReadOnly = true;
            QuantityTxt.Size = new Size(217, 31);
            QuantityTxt.TabIndex = 1;
            // 
            // SupplierTxt
            // 
            SupplierTxt.Font = new Font("Segoe UI", 10.8F);
            SupplierTxt.Location = new Point(17, 342);
            SupplierTxt.Name = "SupplierTxt";
            SupplierTxt.ReadOnly = true;
            SupplierTxt.Size = new Size(217, 31);
            SupplierTxt.TabIndex = 4;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.Red;
            DeleteBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DeleteBtn.ForeColor = Color.White;
            DeleteBtn.Location = new Point(140, 457);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(94, 38);
            DeleteBtn.TabIndex = 5;
            DeleteBtn.Text = "Send";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(267, 551);
            Controls.Add(DeleteBtn);
            Controls.Add(EditBtn);
            Controls.Add(CancelBtn);
            Controls.Add(SupplierTxt);
            Controls.Add(PriceTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(EmployeeTxt);
            Controls.Add(QuantityTxt);
            Controls.Add(CategoryTxt);
            Controls.Add(ProductNameTxt);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ProductNameTxt;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox PriceTxt;
        private Label label5;
        private Label label6;
        private TextBox EmployeeTxt;
        private Button CancelBtn;
        private Button EditBtn;
        private TextBox CategoryTxt;
        private TextBox QuantityTxt;
        private TextBox SupplierTxt;
        private Button DeleteBtn;
    }
}