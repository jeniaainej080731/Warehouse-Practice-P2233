namespace Warehouse.UI.Forms
{
    partial class EditProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProductForm));
            PriceTxt = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label6 = new Label();
            label5 = new Label();
            EmployeeTxt = new TextBox();
            ProductNameTxt = new TextBox();
            label1 = new Label();
            CategoriesCb = new ComboBox();
            QuantityNud = new NumericUpDown();
            SuppliersCb = new ComboBox();
            CancelBtn = new Button();
            SaveBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)QuantityNud).BeginInit();
            SuspendLayout();
            // 
            // PriceTxt
            // 
            PriceTxt.Font = new Font("Segoe UI", 10.8F);
            PriceTxt.Location = new Point(23, 263);
            PriceTxt.Name = "PriceTxt";
            PriceTxt.Size = new Size(196, 31);
            PriceTxt.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(23, 232);
            label4.Name = "label4";
            label4.Size = new Size(56, 28);
            label4.TabIndex = 5;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(23, 158);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 6;
            label3.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(23, 90);
            label2.Name = "label2";
            label2.Size = new Size(94, 28);
            label2.TabIndex = 7;
            label2.Text = "Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(23, 367);
            label6.Name = "label6";
            label6.Size = new Size(101, 28);
            label6.TabIndex = 8;
            label6.Text = "Employee";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(23, 300);
            label5.Name = "label5";
            label5.Size = new Size(87, 28);
            label5.TabIndex = 9;
            label5.Text = "Supplier";
            // 
            // EmployeeTxt
            // 
            EmployeeTxt.Font = new Font("Segoe UI", 10.8F);
            EmployeeTxt.Location = new Point(23, 398);
            EmployeeTxt.Name = "EmployeeTxt";
            EmployeeTxt.ReadOnly = true;
            EmployeeTxt.Size = new Size(196, 31);
            EmployeeTxt.TabIndex = 11;
            // 
            // ProductNameTxt
            // 
            ProductNameTxt.Font = new Font("Segoe UI", 10.8F);
            ProductNameTxt.Location = new Point(23, 54);
            ProductNameTxt.Name = "ProductNameTxt";
            ProductNameTxt.Size = new Size(196, 31);
            ProductNameTxt.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(83, 28);
            label1.TabIndex = 10;
            label1.Text = "Product";
            // 
            // CategoriesCb
            // 
            CategoriesCb.Font = new Font("Segoe UI", 10.8F);
            CategoriesCb.FormattingEnabled = true;
            CategoriesCb.Location = new Point(23, 122);
            CategoriesCb.Name = "CategoriesCb";
            CategoriesCb.Size = new Size(196, 33);
            CategoriesCb.TabIndex = 17;
            // 
            // QuantityNud
            // 
            QuantityNud.Font = new Font("Segoe UI", 10.8F);
            QuantityNud.Location = new Point(23, 189);
            QuantityNud.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            QuantityNud.Name = "QuantityNud";
            QuantityNud.Size = new Size(122, 31);
            QuantityNud.TabIndex = 18;
            // 
            // SuppliersCb
            // 
            SuppliersCb.Font = new Font("Segoe UI", 10.8F);
            SuppliersCb.FormattingEnabled = true;
            SuppliersCb.Location = new Point(23, 331);
            SuppliersCb.Name = "SuppliersCb";
            SuppliersCb.Size = new Size(196, 33);
            SuppliersCb.TabIndex = 17;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(125, 435);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 38);
            CancelBtn.TabIndex = 19;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.DarkGreen;
            SaveBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(23, 435);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 38);
            SaveBtn.TabIndex = 19;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // EditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(244, 483);
            Controls.Add(SaveBtn);
            Controls.Add(CancelBtn);
            Controls.Add(QuantityNud);
            Controls.Add(SuppliersCb);
            Controls.Add(CategoriesCb);
            Controls.Add(PriceTxt);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(EmployeeTxt);
            Controls.Add(ProductNameTxt);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Product";
            ((System.ComponentModel.ISupportInitialize)QuantityNud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox PriceTxt;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label5;
        private TextBox EmployeeTxt;
        private TextBox ProductNameTxt;
        private Label label1;
        private ComboBox CategoriesCb;
        private NumericUpDown QuantityNud;
        private ComboBox SuppliersCb;
        private Button CancelBtn;
        private Button SaveBtn;
    }
}