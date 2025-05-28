namespace Warehouse.UI.Forms
{
    partial class ProductsForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ProgressPanel = new Panel();
            ProgressLbl = new Label();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            ProductsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            FiltersPanel = new Panel();
            AddCategoryBtn = new Button();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            NameRb = new RadioButton();
            CodeRb = new RadioButton();
            CategoriesCb = new ComboBox();
            SearchTxt = new TextBox();
            FiltersCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            LeftSidePanel = new Panel();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            LeftSideCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            ShowDetailsBtn = new Button();
            AddBtn = new Button();
            menuStrip1 = new MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            filtersToolStripMenuItem = new ToolStripMenuItem();
            animationTimer = new System.Windows.Forms.Timer(components);
            ProgressPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).BeginInit();
            FiltersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            LeftSidePanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.Transparent;
            ProgressPanel.Controls.Add(ProgressLbl);
            ProgressPanel.Controls.Add(progressBar1);
            ProgressPanel.Dock = DockStyle.Bottom;
            ProgressPanel.Location = new Point(0, 451);
            ProgressPanel.Name = "ProgressPanel";
            ProgressPanel.Size = new Size(912, 52);
            ProgressPanel.TabIndex = 2;
            // 
            // ProgressLbl
            // 
            ProgressLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressLbl.AutoSize = true;
            ProgressLbl.BackColor = Color.Transparent;
            ProgressLbl.Location = new Point(14, 3);
            ProgressLbl.Name = "ProgressLbl";
            ProgressLbl.Size = new Size(15, 20);
            ProgressLbl.TabIndex = 3;
            ProgressLbl.Text = "-";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(14, 26);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(888, 19);
            progressBar1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(ProductsDataGridView);
            panel1.Controls.Add(FiltersPanel);
            panel1.Controls.Add(LeftSidePanel);
            panel1.Controls.Add(menuStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 451);
            panel1.TabIndex = 3;
            // 
            // ProductsDataGridView
            // 
            ProductsDataGridView.AllowUserToAddRows = false;
            ProductsDataGridView.AllowUserToDeleteRows = false;
            ProductsDataGridView.AllowUserToOrderColumns = true;
            ProductsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(225, 205, 233);
            ProductsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(155, 89, 182);
            dataGridViewCellStyle2.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            ProductsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            ProductsDataGridView.ColumnHeadersHeight = 24;
            ProductsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(235, 221, 240);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(188, 144, 206);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            ProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            ProductsDataGridView.Dock = DockStyle.Fill;
            ProductsDataGridView.GridColor = Color.FromArgb(222, 201, 231);
            ProductsDataGridView.Location = new Point(169, 95);
            ProductsDataGridView.MultiSelect = false;
            ProductsDataGridView.Name = "ProductsDataGridView";
            ProductsDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            ProductsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            ProductsDataGridView.RowHeadersVisible = false;
            ProductsDataGridView.RowHeadersWidth = 51;
            ProductsDataGridView.Size = new Size(743, 356);
            ProductsDataGridView.TabIndex = 3;
            ProductsDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Amethyst;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(225, 205, 233);
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            ProductsDataGridView.ThemeStyle.BackColor = Color.White;
            ProductsDataGridView.ThemeStyle.GridColor = Color.FromArgb(222, 201, 231);
            ProductsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(155, 89, 182);
            ProductsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            ProductsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            ProductsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            ProductsDataGridView.ThemeStyle.HeaderStyle.Height = 24;
            ProductsDataGridView.ThemeStyle.ReadOnly = true;
            ProductsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(235, 221, 240);
            ProductsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ProductsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ProductsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            ProductsDataGridView.ThemeStyle.RowsStyle.Height = 29;
            ProductsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(188, 144, 206);
            ProductsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            ProductsDataGridView.CellDoubleClick += ProductsDataGridView_CellDoubleClick;
            ProductsDataGridView.RowPostPaint += guna2DataGridView1_RowPostPaint;
            // 
            // FiltersPanel
            // 
            FiltersPanel.BackColor = Color.LightCyan;
            FiltersPanel.Controls.Add(AddCategoryBtn);
            FiltersPanel.Controls.Add(pictureBox1);
            FiltersPanel.Controls.Add(groupBox1);
            FiltersPanel.Controls.Add(CategoriesCb);
            FiltersPanel.Controls.Add(SearchTxt);
            FiltersPanel.Controls.Add(FiltersCollapse);
            FiltersPanel.Dock = DockStyle.Top;
            FiltersPanel.Location = new Point(169, 28);
            FiltersPanel.Name = "FiltersPanel";
            FiltersPanel.Size = new Size(743, 67);
            FiltersPanel.TabIndex = 1;
            // 
            // AddCategoryBtn
            // 
            AddCategoryBtn.BackColor = Color.PaleTurquoise;
            AddCategoryBtn.Font = new Font("Showcard Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddCategoryBtn.Image = (Image)resources.GetObject("AddCategoryBtn.Image");
            AddCategoryBtn.Location = new Point(546, 14);
            AddCategoryBtn.Margin = new Padding(0);
            AddCategoryBtn.Name = "AddCategoryBtn";
            AddCategoryBtn.RightToLeft = RightToLeft.No;
            AddCategoryBtn.Size = new Size(32, 32);
            AddCategoryBtn.TabIndex = 8;
            AddCategoryBtn.UseVisualStyleBackColor = false;
            AddCategoryBtn.Click += AddCategoryBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(350, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NameRb);
            groupBox1.Controls.Add(CodeRb);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(6, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(166, 45);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search on";
            // 
            // NameRb
            // 
            NameRb.AutoSize = true;
            NameRb.BackColor = Color.Transparent;
            NameRb.Location = new Point(6, 18);
            NameRb.Name = "NameRb";
            NameRb.Size = new Size(71, 24);
            NameRb.TabIndex = 5;
            NameRb.TabStop = true;
            NameRb.Text = "Name";
            NameRb.UseVisualStyleBackColor = false;
            // 
            // CodeRb
            // 
            CodeRb.AutoSize = true;
            CodeRb.BackColor = Color.Transparent;
            CodeRb.Location = new Point(82, 18);
            CodeRb.Name = "CodeRb";
            CodeRb.Size = new Size(65, 24);
            CodeRb.TabIndex = 5;
            CodeRb.TabStop = true;
            CodeRb.Text = "Code";
            CodeRb.UseVisualStyleBackColor = false;
            // 
            // CategoriesCb
            // 
            CategoriesCb.AutoCompleteMode = AutoCompleteMode.Suggest;
            CategoriesCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CategoriesCb.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CategoriesCb.FormattingEnabled = true;
            CategoriesCb.Location = new Point(389, 17);
            CategoriesCb.Name = "CategoriesCb";
            CategoriesCb.Size = new Size(151, 28);
            CategoriesCb.TabIndex = 4;
            CategoriesCb.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // SearchTxt
            // 
            SearchTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchTxt.Location = new Point(178, 17);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.Size = new Size(166, 27);
            SearchTxt.TabIndex = 3;
            SearchTxt.TextChanged += textBox1_TextChanged;
            // 
            // FiltersCollapse
            // 
            FiltersCollapse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FiltersCollapse.BackColor = Color.Transparent;
            FiltersCollapse.BackgroundImageLayout = ImageLayout.Stretch;
            FiltersCollapse.CheckedState.ImageSize = new Size(64, 64);
            FiltersCollapse.HoverState.ImageSize = new Size(15, 15);
            FiltersCollapse.Image = (Image)resources.GetObject("FiltersCollapse.Image");
            FiltersCollapse.ImageOffset = new Point(0, 0);
            FiltersCollapse.ImageRotate = 0F;
            FiltersCollapse.ImageSize = new Size(15, 15);
            FiltersCollapse.IndicateFocus = true;
            FiltersCollapse.Location = new Point(722, 46);
            FiltersCollapse.Name = "FiltersCollapse";
            FiltersCollapse.PressedState.ImageSize = new Size(15, 15);
            FiltersCollapse.ShadowDecoration.CustomizableEdges = customizableEdges1;
            FiltersCollapse.Size = new Size(15, 15);
            FiltersCollapse.TabIndex = 2;
            FiltersCollapse.UseTransparentBackground = true;
            FiltersCollapse.Click += FiltersCollapse_Click;
            // 
            // LeftSidePanel
            // 
            LeftSidePanel.BackColor = Color.PaleTurquoise;
            LeftSidePanel.Controls.Add(ExitFormBtn);
            LeftSidePanel.Controls.Add(LeftSideCollapse);
            LeftSidePanel.Controls.Add(ShowDetailsBtn);
            LeftSidePanel.Controls.Add(AddBtn);
            LeftSidePanel.Dock = DockStyle.Left;
            LeftSidePanel.Location = new Point(0, 28);
            LeftSidePanel.Name = "LeftSidePanel";
            LeftSidePanel.Size = new Size(169, 423);
            LeftSidePanel.TabIndex = 0;
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
            ExitFormBtn.Location = new Point(126, 9);
            ExitFormBtn.Name = "ExitFormBtn";
            ExitFormBtn.PressedState.ImageSize = new Size(27, 27);
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ExitFormBtn.Size = new Size(32, 32);
            ExitFormBtn.TabIndex = 3;
            ExitFormBtn.UseTransparentBackground = true;
            ExitFormBtn.Click += ExitFormBtn_Click;
            // 
            // LeftSideCollapse
            // 
            LeftSideCollapse.BackColor = Color.Transparent;
            LeftSideCollapse.BackgroundImageLayout = ImageLayout.Stretch;
            LeftSideCollapse.CheckedState.ImageSize = new Size(64, 64);
            LeftSideCollapse.HoverState.ImageSize = new Size(0, 0);
            LeftSideCollapse.Image = (Image)resources.GetObject("LeftSideCollapse.Image");
            LeftSideCollapse.ImageOffset = new Point(0, 0);
            LeftSideCollapse.ImageRotate = 0F;
            LeftSideCollapse.ImageSize = new Size(40, 30);
            LeftSideCollapse.IndicateFocus = true;
            LeftSideCollapse.Location = new Point(10, 9);
            LeftSideCollapse.Name = "LeftSideCollapse";
            LeftSideCollapse.PressedState.ImageSize = new Size(0, 0);
            LeftSideCollapse.ShadowDecoration.CustomizableEdges = customizableEdges3;
            LeftSideCollapse.Size = new Size(30, 30);
            LeftSideCollapse.TabIndex = 3;
            LeftSideCollapse.UseTransparentBackground = true;
            LeftSideCollapse.Click += LeftSideCollapse_Click;
            // 
            // ShowDetailsBtn
            // 
            ShowDetailsBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ShowDetailsBtn.BackColor = Color.MediumTurquoise;
            ShowDetailsBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            ShowDetailsBtn.Image = (Image)resources.GetObject("ShowDetailsBtn.Image");
            ShowDetailsBtn.Location = new Point(14, 128);
            ShowDetailsBtn.Name = "ShowDetailsBtn";
            ShowDetailsBtn.Size = new Size(144, 47);
            ShowDetailsBtn.TabIndex = 2;
            ShowDetailsBtn.Text = "Show Details";
            ShowDetailsBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ShowDetailsBtn.UseVisualStyleBackColor = false;
            ShowDetailsBtn.Click += ShowDetailsBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddBtn.BackColor = Color.MediumTurquoise;
            AddBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            AddBtn.Image = (Image)resources.GetObject("AddBtn.Image");
            AddBtn.Location = new Point(14, 75);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(144, 47);
            AddBtn.TabIndex = 2;
            AddBtn.Text = "Add Product";
            AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Azure;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(912, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filtersToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // filtersToolStripMenuItem
            // 
            filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            filtersToolStripMenuItem.Size = new Size(131, 26);
            filtersToolStripMenuItem.Text = "Filters";
            filtersToolStripMenuItem.Click += filtersToolStripMenuItem_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(panel1);
            Controls.Add(ProgressPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(930, 550);
            Name = "ProductsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Products";
            WindowState = FormWindowState.Maximized;
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).EndInit();
            FiltersPanel.ResumeLayout(false);
            FiltersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            LeftSidePanel.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ProgressPanel;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Panel LeftSidePanel;
        private Panel FiltersPanel;
        private Guna.UI2.WinForms.Guna2ImageButton FiltersCollapse;
        private System.Windows.Forms.Timer animationTimer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView ProductsDataGridView;
        private TextBox SearchTxt;
        private ComboBox CategoriesCb;
        private GroupBox groupBox1;
        private RadioButton NameRb;
        private RadioButton CodeRb;
        private Button AddBtn;
        private Label ProgressLbl;
        private Guna.UI2.WinForms.Guna2ImageButton LeftSideCollapse;
        private PictureBox pictureBox1;
        private Button AddCategoryBtn;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
        private Button ShowDetailsBtn;
    }
}