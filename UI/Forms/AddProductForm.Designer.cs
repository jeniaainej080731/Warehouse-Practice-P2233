namespace Warehouse.UI.Forms
{
    partial class AddProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductForm));
            CategoriesCbox = new ComboBox();
            ProductNameTxtb = new TextBox();
            label1 = new Label();
            label2 = new Label();
            PriceTxtb = new TextBox();
            label3 = new Label();
            QuantityNumeric = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            PerformedEmpTxtb = new TextBox();
            SuppliersCb = new ComboBox();
            AddBtn = new Button();
            CancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)QuantityNumeric).BeginInit();
            SuspendLayout();
            // 
            // CategoriesCbox
            // 
            CategoriesCbox.Font = new Font("Segoe UI", 10.8F);
            CategoriesCbox.FormattingEnabled = true;
            CategoriesCbox.Location = new Point(19, 50);
            CategoriesCbox.Name = "CategoriesCbox";
            CategoriesCbox.Size = new Size(187, 33);
            CategoriesCbox.TabIndex = 1;
            // 
            // ProductNameTxtb
            // 
            ProductNameTxtb.Font = new Font("Segoe UI", 10.8F);
            ProductNameTxtb.Location = new Point(19, 122);
            ProductNameTxtb.Name = "ProductNameTxtb";
            ProductNameTxtb.Size = new Size(187, 31);
            ProductNameTxtb.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(18, 19);
            label1.Name = "label1";
            label1.Size = new Size(94, 28);
            label1.TabIndex = 2;
            label1.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(18, 91);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 2;
            label2.Text = "Product Name";
            // 
            // PriceTxtb
            // 
            PriceTxtb.Font = new Font("Segoe UI", 10.8F);
            PriceTxtb.Location = new Point(19, 280);
            PriceTxtb.Name = "PriceTxtb";
            PriceTxtb.Size = new Size(136, 31);
            PriceTxtb.TabIndex = 4;
            PriceTxtb.TextChanged += PriceTxtb_TextChanged;
            PriceTxtb.KeyPress += PriceTxtb_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(18, 166);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 2;
            label3.Text = "Quantity";
            // 
            // QuantityNumeric
            // 
            QuantityNumeric.Font = new Font("Segoe UI", 10.8F);
            QuantityNumeric.Location = new Point(20, 197);
            QuantityNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            QuantityNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            QuantityNumeric.Name = "QuantityNumeric";
            QuantityNumeric.Size = new Size(135, 31);
            QuantityNumeric.TabIndex = 3;
            QuantityNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(18, 249);
            label4.Name = "label4";
            label4.Size = new Size(56, 28);
            label4.TabIndex = 2;
            label4.Text = "Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(18, 332);
            label5.Name = "label5";
            label5.Size = new Size(87, 28);
            label5.TabIndex = 2;
            label5.Text = "Supplier";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(19, 413);
            label6.Name = "label6";
            label6.Size = new Size(136, 28);
            label6.TabIndex = 2;
            label6.Text = "Performed by";
            // 
            // PerformedEmpTxtb
            // 
            PerformedEmpTxtb.Font = new Font("Segoe UI", 10.8F);
            PerformedEmpTxtb.Location = new Point(20, 444);
            PerformedEmpTxtb.Name = "PerformedEmpTxtb";
            PerformedEmpTxtb.ReadOnly = true;
            PerformedEmpTxtb.Size = new Size(186, 31);
            PerformedEmpTxtb.TabIndex = 0;
            // 
            // SuppliersCb
            // 
            SuppliersCb.Font = new Font("Segoe UI", 10.8F);
            SuppliersCb.FormattingEnabled = true;
            SuppliersCb.Location = new Point(20, 363);
            SuppliersCb.Name = "SuppliersCb";
            SuppliersCb.Size = new Size(186, 33);
            SuppliersCb.TabIndex = 5;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.DarkGreen;
            AddBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(12, 508);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(94, 33);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_ClickAsync;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(112, 508);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 33);
            CancelBtn.TabIndex = 7;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(241, 553);
            Controls.Add(CancelBtn);
            Controls.Add(AddBtn);
            Controls.Add(SuppliersCb);
            Controls.Add(QuantityNumeric);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(PerformedEmpTxtb);
            Controls.Add(PriceTxtb);
            Controls.Add(label1);
            Controls.Add(ProductNameTxtb);
            Controls.Add(CategoriesCbox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)QuantityNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CategoriesCbox;
        private TextBox ProductNameTxtb;
        private Label label1;
        private Label label2;
        private TextBox PriceTxtb;
        private Label label3;
        private NumericUpDown QuantityNumeric;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox PerformedEmpTxtb;
        private ComboBox SuppliersCb;
        private Button AddBtn;
        private Button CancelBtn;
    }
}