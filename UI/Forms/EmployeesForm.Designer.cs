namespace Warehouse.UI.Forms
{
    partial class EmployeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            crudPanel = new Panel();
            ExitBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            pictureBox1 = new PictureBox();
            SearchField = new TextBox();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            AddBtn = new Guna.UI2.WinForms.Guna2Button();
            pictureBox2 = new PictureBox();
            SearchTxt = new TextBox();
            MainPanel = new Panel();
            EmployeeCard = new Panel();
            InfoPanel = new Panel();
            ShowMoreLbl = new Label();
            RoleLbl = new Label();
            FullNameLbl = new Label();
            pictureBox3 = new PictureBox();
            crudPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            MainPanel.SuspendLayout();
            EmployeeCard.SuspendLayout();
            InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // crudPanel
            // 
            crudPanel.BackColor = Color.FromArgb(138, 124, 156);
            crudPanel.Controls.Add(ExitBtn);
            crudPanel.Controls.Add(pictureBox1);
            crudPanel.Controls.Add(SearchField);
            crudPanel.Controls.Add(ExitFormBtn);
            crudPanel.Controls.Add(AddBtn);
            crudPanel.Controls.Add(pictureBox2);
            crudPanel.Controls.Add(SearchTxt);
            crudPanel.Dock = DockStyle.Top;
            crudPanel.Location = new Point(0, 0);
            crudPanel.Name = "crudPanel";
            crudPanel.Size = new Size(912, 59);
            crudPanel.TabIndex = 3;
            // 
            // ExitBtn
            // 
            ExitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExitBtn.BackColor = Color.Transparent;
            ExitBtn.BackgroundImageLayout = ImageLayout.Stretch;
            ExitBtn.CheckedState.ImageSize = new Size(64, 64);
            ExitBtn.HoverState.ImageSize = new Size(26, 26);
            ExitBtn.Image = (Image)resources.GetObject("ExitBtn.Image");
            ExitBtn.ImageOffset = new Point(0, 0);
            ExitBtn.ImageRotate = 0F;
            ExitBtn.ImageSize = new Size(24, 24);
            ExitBtn.IndicateFocus = true;
            ExitBtn.Location = new Point(862, 13);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.PressedState.ImageSize = new Size(27, 27);
            ExitBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ExitBtn.Size = new Size(32, 32);
            ExitBtn.TabIndex = 13;
            ExitBtn.UseTransparentBackground = true;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(780, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // SearchField
            // 
            SearchField.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchField.Location = new Point(608, 15);
            SearchField.Name = "SearchField";
            SearchField.PlaceholderText = "Search";
            SearchField.Size = new Size(166, 27);
            SearchField.TabIndex = 11;
            SearchField.TextChanged += SearchTxt_TextChanged;
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
            ExitFormBtn.Location = new Point(1580, 13);
            ExitFormBtn.Name = "ExitFormBtn";
            ExitFormBtn.PressedState.ImageSize = new Size(27, 27);
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ExitFormBtn.Size = new Size(32, 32);
            ExitFormBtn.TabIndex = 10;
            ExitFormBtn.UseTransparentBackground = true;
            // 
            // AddBtn
            // 
            AddBtn.Animated = true;
            AddBtn.BorderColor = Color.RosyBrown;
            AddBtn.BorderRadius = 1;
            AddBtn.BorderThickness = 1;
            AddBtn.CustomizableEdges = customizableEdges3;
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
            AddBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            AddBtn.Size = new Size(143, 41);
            AddBtn.TabIndex = 9;
            AddBtn.Text = "Add Employee";
            AddBtn.Click += AddBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1498, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // SearchTxt
            // 
            SearchTxt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchTxt.Location = new Point(1326, 15);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.PlaceholderText = "Search";
            SearchTxt.Size = new Size(166, 27);
            SearchTxt.TabIndex = 1;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BackColor = Color.FromArgb(197, 192, 201);
            MainPanel.Controls.Add(EmployeeCard);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 59);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(912, 444);
            MainPanel.TabIndex = 4;
            MainPanel.Resize += MainPanel_Resize;
            // 
            // EmployeeCard
            // 
            EmployeeCard.BorderStyle = BorderStyle.FixedSingle;
            EmployeeCard.Controls.Add(InfoPanel);
            EmployeeCard.Controls.Add(pictureBox3);
            EmployeeCard.Location = new Point(27, 26);
            EmployeeCard.Name = "EmployeeCard";
            EmployeeCard.Size = new Size(273, 406);
            EmployeeCard.TabIndex = 5;
            EmployeeCard.Visible = false;
            // 
            // InfoPanel
            // 
            InfoPanel.BorderStyle = BorderStyle.FixedSingle;
            InfoPanel.Controls.Add(ShowMoreLbl);
            InfoPanel.Controls.Add(RoleLbl);
            InfoPanel.Controls.Add(FullNameLbl);
            InfoPanel.Dock = DockStyle.Bottom;
            InfoPanel.Location = new Point(0, 301);
            InfoPanel.Name = "InfoPanel";
            InfoPanel.Size = new Size(271, 103);
            InfoPanel.TabIndex = 2;
            // 
            // ShowMoreLbl
            // 
            ShowMoreLbl.Anchor = AnchorStyles.Bottom;
            ShowMoreLbl.AutoSize = true;
            ShowMoreLbl.Cursor = Cursors.Hand;
            ShowMoreLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 204);
            ShowMoreLbl.Location = new Point(89, 74);
            ShowMoreLbl.Name = "ShowMoreLbl";
            ShowMoreLbl.Size = new Size(90, 23);
            ShowMoreLbl.TabIndex = 2;
            ShowMoreLbl.Text = "Show More";
            // 
            // RoleLbl
            // 
            RoleLbl.Anchor = AnchorStyles.Top;
            RoleLbl.AutoSize = true;
            RoleLbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            RoleLbl.Location = new Point(17, 35);
            RoleLbl.Name = "RoleLbl";
            RoleLbl.Size = new Size(19, 25);
            RoleLbl.TabIndex = 2;
            RoleLbl.Text = "-";
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
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(265, 292);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(MainPanel);
            Controls.Add(crudPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Employees";
            WindowState = FormWindowState.Maximized;
            Load += EmployeesForm_Load;
            crudPanel.ResumeLayout(false);
            crudPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            MainPanel.ResumeLayout(false);
            EmployeeCard.ResumeLayout(false);
            InfoPanel.ResumeLayout(false);
            InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel crudPanel;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
        private Guna.UI2.WinForms.Guna2Button AddBtn;
        private PictureBox pictureBox2;
        private TextBox SearchTxt;
        private Guna.UI2.WinForms.Guna2ImageButton ExitBtn;
        private PictureBox pictureBox1;
        private TextBox SearchField;
        private Panel MainPanel;
        private Panel EmployeeCard;
        private Panel InfoPanel;
        private Label ShowMoreLbl;
        private Label FullNameLbl;
        private PictureBox pictureBox3;
        private Label RoleLbl;
    }
}