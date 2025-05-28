namespace Warehouse
{
    partial class TestOutProductsTableForm
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            loadEmpBtn = new Button();
            loadCatbutton = new Button();
            loadAuditsbutton = new Button();
            button2 = new Button();
            SupplierCard = new Panel();
            InfoPanel = new Panel();
            ShowMoreLbl = new Label();
            ContactInfoLbl = new Label();
            FullNameLbl = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SupplierCard.SuspendLayout();
            InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(537, 338);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(33, 12);
            button1.Name = "button1";
            button1.Size = new Size(145, 29);
            button1.TabIndex = 1;
            button1.Text = "Load Products";
            button1.UseVisualStyleBackColor = true;
            button1.Click += loadProductsBtn_Click;
            // 
            // loadEmpBtn
            // 
            loadEmpBtn.Location = new Point(184, 12);
            loadEmpBtn.Name = "loadEmpBtn";
            loadEmpBtn.Size = new Size(145, 29);
            loadEmpBtn.TabIndex = 1;
            loadEmpBtn.Text = "Load Employees";
            loadEmpBtn.UseVisualStyleBackColor = true;
            loadEmpBtn.Click += loadEmpBtn_Click;
            // 
            // loadCatbutton
            // 
            loadCatbutton.Location = new Point(335, 12);
            loadCatbutton.Name = "loadCatbutton";
            loadCatbutton.Size = new Size(145, 29);
            loadCatbutton.TabIndex = 1;
            loadCatbutton.Text = "Load Categories";
            loadCatbutton.UseVisualStyleBackColor = true;
            loadCatbutton.Click += loadCatbutton_Click;
            // 
            // loadAuditsbutton
            // 
            loadAuditsbutton.Location = new Point(486, 12);
            loadAuditsbutton.Name = "loadAuditsbutton";
            loadAuditsbutton.Size = new Size(145, 29);
            loadAuditsbutton.TabIndex = 1;
            loadAuditsbutton.Text = "Load Audits";
            loadAuditsbutton.UseVisualStyleBackColor = true;
            loadAuditsbutton.Click += loadAuditsbutton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(386, 65);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SupplierCard
            // 
            SupplierCard.Controls.Add(InfoPanel);
            SupplierCard.Controls.Add(pictureBox1);
            SupplierCard.Location = new Point(720, 65);
            SupplierCard.Name = "SupplierCard";
            SupplierCard.Size = new Size(261, 358);
            SupplierCard.TabIndex = 3;
            // 
            // InfoPanel
            // 
            InfoPanel.Controls.Add(ShowMoreLbl);
            InfoPanel.Controls.Add(ContactInfoLbl);
            InfoPanel.Controls.Add(FullNameLbl);
            InfoPanel.Dock = DockStyle.Bottom;
            InfoPanel.Location = new Point(0, 270);
            InfoPanel.Name = "InfoPanel";
            InfoPanel.Size = new Size(261, 88);
            InfoPanel.TabIndex = 2;
            // 
            // ShowMoreLbl
            // 
            ShowMoreLbl.AutoSize = true;
            ShowMoreLbl.Cursor = Cursors.Hand;
            ShowMoreLbl.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline);
            ShowMoreLbl.Location = new Point(85, 61);
            ShowMoreLbl.Name = "ShowMoreLbl";
            ShowMoreLbl.Size = new Size(79, 20);
            ShowMoreLbl.TabIndex = 2;
            ShowMoreLbl.Text = "Show More";
            // 
            // ContactInfoLbl
            // 
            ContactInfoLbl.AutoSize = true;
            ContactInfoLbl.Location = new Point(98, 24);
            ContactInfoLbl.Name = "ContactInfoLbl";
            ContactInfoLbl.Size = new Size(15, 20);
            ContactInfoLbl.TabIndex = 2;
            ContactInfoLbl.Text = "-";
            // 
            // FullNameLbl
            // 
            FullNameLbl.AutoSize = true;
            FullNameLbl.Location = new Point(98, 4);
            FullNameLbl.Name = "FullNameLbl";
            FullNameLbl.Size = new Size(15, 20);
            FullNameLbl.TabIndex = 2;
            FullNameLbl.Text = "-";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.plug;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(316, 519);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // TestOutProductsTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 450);
            Controls.Add(SupplierCard);
            Controls.Add(button2);
            Controls.Add(loadAuditsbutton);
            Controls.Add(loadCatbutton);
            Controls.Add(loadEmpBtn);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "TestOutProductsTableForm";
            Text = "TestOutProductsTableForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            SupplierCard.ResumeLayout(false);
            InfoPanel.ResumeLayout(false);
            InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button loadEmpBtn;
        private Button loadCatbutton;
        private Button loadAuditsbutton;
        private Button button2;
        private Panel SupplierCard;
        private Panel InfoPanel;
        private Label ShowMoreLbl;
        private Label ContactInfoLbl;
        private Label FullNameLbl;
        private PictureBox pictureBox1;
    }
}