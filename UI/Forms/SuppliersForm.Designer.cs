namespace Warehouse.UI.Forms
{
    partial class SuppliersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuppliersForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            MainPanel = new Panel();
            SupplierCard = new Panel();
            InfoPanel = new Panel();
            ShowMoreLbl = new Label();
            FullNameLbl = new Label();
            pictureBox1 = new PictureBox();
            crudPanel = new Panel();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            AddBtn = new Guna.UI2.WinForms.Guna2Button();
            pictureBox2 = new PictureBox();
            SearchTxt = new TextBox();
            MainPanel.SuspendLayout();
            SupplierCard.SuspendLayout();
            InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            crudPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BackColor = Color.FromArgb(197, 192, 201);
            MainPanel.Controls.Add(SupplierCard);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 59);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(912, 444);
            MainPanel.TabIndex = 0;
            MainPanel.Resize += MainPanel_Resize;
            // 
            // SupplierCard
            // 
            SupplierCard.BorderStyle = BorderStyle.FixedSingle;
            SupplierCard.Controls.Add(InfoPanel);
            SupplierCard.Controls.Add(pictureBox1);
            SupplierCard.Location = new Point(27, 26);
            SupplierCard.Name = "SupplierCard";
            SupplierCard.Size = new Size(273, 375);
            SupplierCard.TabIndex = 4;
            SupplierCard.Visible = false;
            // 
            // InfoPanel
            // 
            InfoPanel.BorderStyle = BorderStyle.FixedSingle;
            InfoPanel.Controls.Add(ShowMoreLbl);
            InfoPanel.Controls.Add(FullNameLbl);
            InfoPanel.Dock = DockStyle.Bottom;
            InfoPanel.Location = new Point(0, 301);
            InfoPanel.Name = "InfoPanel";
            InfoPanel.Size = new Size(271, 72);
            InfoPanel.TabIndex = 2;
            // 
            // ShowMoreLbl
            // 
            ShowMoreLbl.Anchor = AnchorStyles.Bottom;
            ShowMoreLbl.AutoSize = true;
            ShowMoreLbl.Cursor = Cursors.Hand;
            ShowMoreLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 204);
            ShowMoreLbl.Location = new Point(89, 43);
            ShowMoreLbl.Name = "ShowMoreLbl";
            ShowMoreLbl.Size = new Size(90, 23);
            ShowMoreLbl.TabIndex = 2;
            ShowMoreLbl.Text = "Show More";
            // 
            // FullNameLbl
            // 
            FullNameLbl.Anchor = AnchorStyles.Top;
            FullNameLbl.AutoSize = true;
            FullNameLbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FullNameLbl.Location = new Point(17, 10);
            FullNameLbl.Name = "FullNameLbl";
            FullNameLbl.Size = new Size(19, 25);
            FullNameLbl.TabIndex = 2;
            FullNameLbl.Text = "-";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 292);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // crudPanel
            // 
            crudPanel.BackColor = Color.FromArgb(138, 124, 156);
            crudPanel.Controls.Add(ExitFormBtn);
            crudPanel.Controls.Add(AddBtn);
            crudPanel.Controls.Add(pictureBox2);
            crudPanel.Controls.Add(SearchTxt);
            crudPanel.Dock = DockStyle.Top;
            crudPanel.Location = new Point(0, 0);
            crudPanel.Name = "crudPanel";
            crudPanel.Size = new Size(912, 59);
            crudPanel.TabIndex = 2;
            // 
            // ExitFormBtn
            // 
            ExitFormBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExitFormBtn.BackColor = Color.Transparent;
            ExitFormBtn.BackgroundImageLayout = ImageLayout.Stretch;
            ExitFormBtn.CheckedState.ImageSize = new Size(64, 64);
            ExitFormBtn.HoverState.ImageSize = new Size(26, 26);
            ExitFormBtn.Image = (Image)resources.GetObject("ExitFormBtn.Image");
            ExitFormBtn.ImageOffset = new Point(0, 0);
            ExitFormBtn.ImageRotate = 0F;
            ExitFormBtn.ImageSize = new Size(24, 24);
            ExitFormBtn.IndicateFocus = true;
            ExitFormBtn.Location = new Point(868, 13);
            ExitFormBtn.Name = "ExitFormBtn";
            ExitFormBtn.PressedState.ImageSize = new Size(27, 27);
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ExitFormBtn.Size = new Size(32, 32);
            ExitFormBtn.TabIndex = 10;
            ExitFormBtn.UseTransparentBackground = true;
            ExitFormBtn.Click += ExitFormBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.Animated = true;
            AddBtn.BorderColor = Color.RosyBrown;
            AddBtn.BorderRadius = 1;
            AddBtn.BorderThickness = 1;
            AddBtn.CustomizableEdges = customizableEdges2;
            AddBtn.DisabledState.BorderColor = Color.DarkGray;
            AddBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            AddBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            AddBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            AddBtn.FillColor = Color.FromArgb(77, 63, 114);
            AddBtn.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            AddBtn.ForeColor = Color.White;
            AddBtn.HoverState.FillColor = Color.FromArgb(111, 90, 165);
            AddBtn.Location = new Point(16, 8);
            AddBtn.Name = "AddBtn";
            AddBtn.PressedColor = Color.FromArgb(64, 52, 95);
            AddBtn.PressedDepth = 10;
            AddBtn.ShadowDecoration.Color = Color.White;
            AddBtn.ShadowDecoration.CustomizableEdges = customizableEdges3;
            AddBtn.Size = new Size(143, 41);
            AddBtn.TabIndex = 9;
            AddBtn.Text = "Add Supplier";
            AddBtn.Click += AddBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(786, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // SearchTxt
            // 
            SearchTxt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchTxt.Location = new Point(614, 15);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search";
            SearchTxt.Size = new Size(166, 27);
            SearchTxt.TabIndex = 1;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(MainPanel);
            Controls.Add(crudPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(930, 550);
            Name = "SuppliersForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suppliers";
            WindowState = FormWindowState.Maximized;
            Load += SuppliersForm_Load;
            MainPanel.ResumeLayout(false);
            SupplierCard.ResumeLayout(false);
            InfoPanel.ResumeLayout(false);
            InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            crudPanel.ResumeLayout(false);
            crudPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Panel SupplierCard;
        private Panel InfoPanel;
        private Label ShowMoreLbl;
        private Label FullNameLbl;
        private PictureBox pictureBox1;
        private Panel crudPanel;
        private Button button2;
        private TextBox SearchTxt;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button AddBtn;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
    }
}