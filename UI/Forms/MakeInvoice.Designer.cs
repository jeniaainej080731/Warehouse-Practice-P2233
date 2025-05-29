namespace Warehouse.UI.Forms
{
    partial class MakeInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MakeInvoice));
            ProductsCb = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            QuantityNud = new NumericUpDown();
            label4 = new Label();
            PriceTxt = new TextBox();
            MakeBtn = new Button();
            CancelBtn = new Button();
            label5 = new Label();
            EmployerTxt = new TextBox();
            CustomerCb = new ComboBox();
            ProductsLb = new ListBox();
            ((System.ComponentModel.ISupportInitialize)QuantityNud).BeginInit();
            SuspendLayout();
            // 
            // ProductsCb
            // 
            ProductsCb.Enabled = false;
            ProductsCb.Font = new Font("Segoe UI", 10.8F);
            ProductsCb.FormattingEnabled = true;
            ProductsCb.Location = new Point(12, 134);
            ProductsCb.Name = "ProductsCb";
            ProductsCb.Size = new Size(194, 33);
            ProductsCb.TabIndex = 2;
            ProductsCb.Visible = false;
            ProductsCb.SelectedIndexChanged += ProductsCb_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(92, 28);
            label1.TabIndex = 1;
            label1.Text = "Products";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 28);
            label2.Name = "label2";
            label2.Size = new Size(87, 28);
            label2.TabIndex = 1;
            label2.Text = "Supplier";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(12, 230);
            label3.Name = "label3";
            label3.Size = new Size(90, 28);
            label3.TabIndex = 1;
            label3.Text = "Quantity";
            // 
            // QuantityNud
            // 
            QuantityNud.Font = new Font("Segoe UI", 10.8F);
            QuantityNud.Location = new Point(12, 261);
            QuantityNud.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            QuantityNud.Name = "QuantityNud";
            QuantityNud.ReadOnly = true;
            QuantityNud.Size = new Size(194, 31);
            QuantityNud.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(12, 306);
            label4.Name = "label4";
            label4.Size = new Size(56, 28);
            label4.TabIndex = 1;
            label4.Text = "Price";
            // 
            // PriceTxt
            // 
            PriceTxt.Font = new Font("Segoe UI", 10.8F);
            PriceTxt.Location = new Point(12, 337);
            PriceTxt.Name = "PriceTxt";
            PriceTxt.ReadOnly = true;
            PriceTxt.Size = new Size(194, 31);
            PriceTxt.TabIndex = 6;
            // 
            // MakeBtn
            // 
            MakeBtn.Anchor = AnchorStyles.Bottom;
            MakeBtn.BackColor = SystemColors.ButtonFace;
            MakeBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            MakeBtn.Location = new Point(12, 467);
            MakeBtn.Name = "MakeBtn";
            MakeBtn.Size = new Size(94, 40);
            MakeBtn.TabIndex = 4;
            MakeBtn.Text = "Make";
            MakeBtn.UseVisualStyleBackColor = false;
            MakeBtn.Click += MakeBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor = AnchorStyles.Bottom;
            CancelBtn.BackColor = SystemColors.ButtonFace;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(112, 467);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 40);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(12, 387);
            label5.Name = "label5";
            label5.Size = new Size(136, 28);
            label5.TabIndex = 1;
            label5.Text = "Performed by";
            // 
            // EmployerTxt
            // 
            EmployerTxt.Font = new Font("Segoe UI", 10.8F);
            EmployerTxt.Location = new Point(12, 418);
            EmployerTxt.Name = "EmployerTxt";
            EmployerTxt.ReadOnly = true;
            EmployerTxt.Size = new Size(194, 31);
            EmployerTxt.TabIndex = 7;
            // 
            // CustomerCb
            // 
            CustomerCb.Font = new Font("Segoe UI", 10.8F);
            CustomerCb.FormattingEnabled = true;
            CustomerCb.Location = new Point(12, 59);
            CustomerCb.Name = "CustomerCb";
            CustomerCb.Size = new Size(194, 33);
            CustomerCb.TabIndex = 1;
            CustomerCb.SelectedIndexChanged += CustomerCb_SelectedIndexChanged;
            // 
            // ProductsLb
            // 
            ProductsLb.Font = new Font("Segoe UI", 10.8F);
            ProductsLb.FormattingEnabled = true;
            ProductsLb.HorizontalScrollbar = true;
            ProductsLb.ItemHeight = 25;
            ProductsLb.Location = new Point(12, 134);
            ProductsLb.Name = "ProductsLb";
            ProductsLb.Size = new Size(194, 104);
            ProductsLb.TabIndex = 8;
            ProductsLb.SelectedIndexChanged += ProductsLb_SelectedIndexChanged;
            // 
            // MakeInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(220, 512);
            Controls.Add(ProductsLb);
            Controls.Add(CancelBtn);
            Controls.Add(MakeBtn);
            Controls.Add(QuantityNud);
            Controls.Add(label3);
            Controls.Add(EmployerTxt);
            Controls.Add(PriceTxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CustomerCb);
            Controls.Add(ProductsCb);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MakeInvoice";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invoice";
            Load += MakeReceipt_Load;
            ((System.ComponentModel.ISupportInitialize)QuantityNud).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ProductsCb;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown QuantityNud;
        private Label label4;
        private TextBox PriceTxt;
        private Button MakeBtn;
        private Button CancelBtn;
        private Label label5;
        private TextBox EmployerTxt;
        private ComboBox CustomerCb;
        private ListBox ProductsLb;
    }
}