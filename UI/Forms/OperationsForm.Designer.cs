namespace Warehouse.UI.Forms
{
    partial class OperationsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            menuStrip1 = new MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            filtersToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            OperationsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            FiltersPanel = new Panel();
            TypeGb = new GroupBox();
            OutCb = new CheckBox();
            InCb = new CheckBox();
            FiletersBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            pictureBox1 = new PictureBox();
            SearchGb = new GroupBox();
            EmployeeRb = new RadioButton();
            SupplierRb = new RadioButton();
            ProductRb = new RadioButton();
            SearchTxt = new TextBox();
            FiltersCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            LeftSidePanel = new Panel();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            LeftSideCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            ChartBtn = new Button();
            ShowReportBtn = new Button();
            ProgressPanel = new Panel();
            ProgressLblOperations = new Label();
            progressBar2 = new ProgressBar();
            ProgressLbl = new Label();
            progressBar1 = new ProgressBar();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OperationsDataGridView).BeginInit();
            FiltersPanel.SuspendLayout();
            TypeGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SearchGb.SuspendLayout();
            LeftSidePanel.SuspendLayout();
            ProgressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(912, 28);
            menuStrip1.TabIndex = 0;
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
            // panel1
            // 
            panel1.Controls.Add(OperationsDataGridView);
            panel1.Controls.Add(FiltersPanel);
            panel1.Controls.Add(LeftSidePanel);
            panel1.Controls.Add(ProgressPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 475);
            panel1.TabIndex = 1;
            // 
            // OperationsDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(247, 216, 189);
            OperationsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(230, 126, 34);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            OperationsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            OperationsDataGridView.ColumnHeadersHeight = 24;
            OperationsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(249, 229, 211);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(238, 169, 107);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            OperationsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            OperationsDataGridView.Dock = DockStyle.Fill;
            OperationsDataGridView.GridColor = Color.FromArgb(245, 209, 177);
            OperationsDataGridView.Location = new Point(169, 67);
            OperationsDataGridView.MultiSelect = false;
            OperationsDataGridView.Name = "OperationsDataGridView";
            OperationsDataGridView.ReadOnly = true;
            OperationsDataGridView.RowHeadersVisible = false;
            OperationsDataGridView.RowHeadersWidth = 51;
            OperationsDataGridView.Size = new Size(743, 356);
            OperationsDataGridView.TabIndex = 6;
            OperationsDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Carrot;
            OperationsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(247, 216, 189);
            OperationsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            OperationsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            OperationsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            OperationsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            OperationsDataGridView.ThemeStyle.BackColor = Color.White;
            OperationsDataGridView.ThemeStyle.GridColor = Color.FromArgb(245, 209, 177);
            OperationsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(230, 126, 34);
            OperationsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            OperationsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            OperationsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            OperationsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            OperationsDataGridView.ThemeStyle.HeaderStyle.Height = 24;
            OperationsDataGridView.ThemeStyle.ReadOnly = true;
            OperationsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(249, 229, 211);
            OperationsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            OperationsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            OperationsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            OperationsDataGridView.ThemeStyle.RowsStyle.Height = 29;
            OperationsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(238, 169, 107);
            OperationsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            OperationsDataGridView.RowPostPaint += OperationsDataGridView_RowPostPaint;
            // 
            // FiltersPanel
            // 
            FiltersPanel.BackColor = Color.LightCyan;
            FiltersPanel.Controls.Add(TypeGb);
            FiltersPanel.Controls.Add(FiletersBtn);
            FiltersPanel.Controls.Add(pictureBox1);
            FiltersPanel.Controls.Add(SearchGb);
            FiltersPanel.Controls.Add(SearchTxt);
            FiltersPanel.Controls.Add(FiltersCollapse);
            FiltersPanel.Dock = DockStyle.Top;
            FiltersPanel.Location = new Point(169, 0);
            FiltersPanel.Name = "FiltersPanel";
            FiltersPanel.Size = new Size(743, 67);
            FiltersPanel.TabIndex = 5;
            // 
            // TypeGb
            // 
            TypeGb.Controls.Add(OutCb);
            TypeGb.Controls.Add(InCb);
            TypeGb.Location = new Point(534, 3);
            TypeGb.Name = "TypeGb";
            TypeGb.Size = new Size(167, 45);
            TypeGb.TabIndex = 10;
            TypeGb.TabStop = false;
            TypeGb.Text = "Type";
            // 
            // OutCb
            // 
            OutCb.AutoSize = true;
            OutCb.Location = new Point(83, 19);
            OutCb.Name = "OutCb";
            OutCb.Size = new Size(60, 24);
            OutCb.TabIndex = 0;
            OutCb.Text = "OUT";
            OutCb.UseVisualStyleBackColor = true;
            OutCb.CheckedChanged += OutRb_CheckedChanged;
            // 
            // InCb
            // 
            InCb.AutoSize = true;
            InCb.Location = new Point(31, 19);
            InCb.Name = "InCb";
            InCb.Size = new Size(46, 24);
            InCb.TabIndex = 0;
            InCb.Text = "IN";
            InCb.UseVisualStyleBackColor = true;
            InCb.CheckedChanged += InRb_CheckedChanged;
            // 
            // FiletersBtn
            // 
            FiletersBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FiletersBtn.BackColor = Color.Transparent;
            FiletersBtn.BackgroundImageLayout = ImageLayout.Stretch;
            FiletersBtn.CheckedState.ImageSize = new Size(64, 64);
            FiletersBtn.HoverState.ImageSize = new Size(15, 15);
            FiletersBtn.Image = (Image)resources.GetObject("FiletersBtn.Image");
            FiletersBtn.ImageOffset = new Point(0, 0);
            FiletersBtn.ImageRotate = 0F;
            FiletersBtn.ImageSize = new Size(15, 15);
            FiletersBtn.IndicateFocus = true;
            FiletersBtn.Location = new Point(723, 48);
            FiletersBtn.Name = "FiletersBtn";
            FiletersBtn.PressedState.ImageSize = new Size(15, 15);
            FiletersBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
            FiletersBtn.Size = new Size(15, 15);
            FiletersBtn.TabIndex = 9;
            FiletersBtn.UseTransparentBackground = true;
            FiletersBtn.Click += FiletersBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(485, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // SearchGb
            // 
            SearchGb.Controls.Add(EmployeeRb);
            SearchGb.Controls.Add(SupplierRb);
            SearchGb.Controls.Add(ProductRb);
            SearchGb.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SearchGb.Location = new Point(6, 3);
            SearchGb.Name = "SearchGb";
            SearchGb.Size = new Size(297, 45);
            SearchGb.TabIndex = 6;
            SearchGb.TabStop = false;
            SearchGb.Text = "Search on";
            // 
            // EmployeeRb
            // 
            EmployeeRb.AutoSize = true;
            EmployeeRb.BackColor = Color.Transparent;
            EmployeeRb.Location = new Point(189, 18);
            EmployeeRb.Name = "EmployeeRb";
            EmployeeRb.Size = new Size(97, 24);
            EmployeeRb.TabIndex = 5;
            EmployeeRb.TabStop = true;
            EmployeeRb.Text = "Employee";
            EmployeeRb.UseVisualStyleBackColor = false;
            // 
            // SupplierRb
            // 
            SupplierRb.AutoSize = true;
            SupplierRb.BackColor = Color.Transparent;
            SupplierRb.Location = new Point(96, 18);
            SupplierRb.Name = "SupplierRb";
            SupplierRb.Size = new Size(87, 24);
            SupplierRb.TabIndex = 5;
            SupplierRb.TabStop = true;
            SupplierRb.Text = "Supplier";
            SupplierRb.UseVisualStyleBackColor = false;
            // 
            // ProductRb
            // 
            ProductRb.AutoSize = true;
            ProductRb.BackColor = Color.Transparent;
            ProductRb.Location = new Point(6, 18);
            ProductRb.Name = "ProductRb";
            ProductRb.Size = new Size(84, 24);
            ProductRb.TabIndex = 5;
            ProductRb.TabStop = true;
            ProductRb.Text = "Product";
            ProductRb.UseVisualStyleBackColor = false;
            // 
            // SearchTxt
            // 
            SearchTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchTxt.Location = new Point(313, 16);
            SearchTxt.Name = "SearchTxt";
            SearchTxt.Size = new Size(166, 27);
            SearchTxt.TabIndex = 3;
            SearchTxt.TextChanged += SearchTxt_TextChanged;
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
            FiltersCollapse.Location = new Point(1265, 13);
            FiltersCollapse.Name = "FiltersCollapse";
            FiltersCollapse.PressedState.ImageSize = new Size(15, 15);
            FiltersCollapse.ShadowDecoration.CustomizableEdges = customizableEdges2;
            FiltersCollapse.Size = new Size(15, 15);
            FiltersCollapse.TabIndex = 2;
            FiltersCollapse.UseTransparentBackground = true;
            // 
            // LeftSidePanel
            // 
            LeftSidePanel.BackColor = Color.PaleTurquoise;
            LeftSidePanel.Controls.Add(ExitFormBtn);
            LeftSidePanel.Controls.Add(LeftSideCollapse);
            LeftSidePanel.Controls.Add(ChartBtn);
            LeftSidePanel.Controls.Add(ShowReportBtn);
            LeftSidePanel.Dock = DockStyle.Left;
            LeftSidePanel.Location = new Point(0, 0);
            LeftSidePanel.Name = "LeftSidePanel";
            LeftSidePanel.Size = new Size(169, 423);
            LeftSidePanel.TabIndex = 2;
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
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges3;
            ExitFormBtn.Size = new Size(32, 32);
            ExitFormBtn.TabIndex = 4;
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
            LeftSideCollapse.ShadowDecoration.CustomizableEdges = customizableEdges4;
            LeftSideCollapse.Size = new Size(30, 30);
            LeftSideCollapse.TabIndex = 3;
            LeftSideCollapse.UseTransparentBackground = true;
            LeftSideCollapse.Click += LeftSideCollapse_Click;
            // 
            // ChartBtn
            // 
            ChartBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ChartBtn.BackColor = Color.MediumTurquoise;
            ChartBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            ChartBtn.Image = (Image)resources.GetObject("ChartBtn.Image");
            ChartBtn.Location = new Point(14, 128);
            ChartBtn.Name = "ChartBtn";
            ChartBtn.Size = new Size(144, 47);
            ChartBtn.TabIndex = 2;
            ChartBtn.Text = "Chart";
            ChartBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ChartBtn.UseVisualStyleBackColor = false;
            ChartBtn.Click += ChartBtn_Click;
            // 
            // ShowReportBtn
            // 
            ShowReportBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ShowReportBtn.BackColor = Color.MediumTurquoise;
            ShowReportBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            ShowReportBtn.Image = (Image)resources.GetObject("ShowReportBtn.Image");
            ShowReportBtn.Location = new Point(14, 75);
            ShowReportBtn.Name = "ShowReportBtn";
            ShowReportBtn.Size = new Size(144, 47);
            ShowReportBtn.TabIndex = 2;
            ShowReportBtn.Text = "Report";
            ShowReportBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            ShowReportBtn.UseVisualStyleBackColor = false;
            ShowReportBtn.Click += ShowReportBtn_Click;
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.Transparent;
            ProgressPanel.Controls.Add(ProgressLblOperations);
            ProgressPanel.Controls.Add(progressBar2);
            ProgressPanel.Controls.Add(ProgressLbl);
            ProgressPanel.Controls.Add(progressBar1);
            ProgressPanel.Dock = DockStyle.Bottom;
            ProgressPanel.Location = new Point(0, 423);
            ProgressPanel.Name = "ProgressPanel";
            ProgressPanel.Size = new Size(912, 52);
            ProgressPanel.TabIndex = 3;
            // 
            // ProgressLblOperations
            // 
            ProgressLblOperations.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressLblOperations.AutoSize = true;
            ProgressLblOperations.BackColor = Color.Transparent;
            ProgressLblOperations.Location = new Point(12, 5);
            ProgressLblOperations.Name = "ProgressLblOperations";
            ProgressLblOperations.Size = new Size(15, 20);
            ProgressLblOperations.TabIndex = 5;
            ProgressLblOperations.Text = "-";
            // 
            // progressBar2
            // 
            progressBar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar2.Location = new Point(12, 28);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(888, 19);
            progressBar2.TabIndex = 4;
            // 
            // ProgressLbl
            // 
            ProgressLbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressLbl.AutoSize = true;
            ProgressLbl.BackColor = Color.Transparent;
            ProgressLbl.Location = new Point(14, -45);
            ProgressLbl.Name = "ProgressLbl";
            ProgressLbl.Size = new Size(15, 20);
            ProgressLbl.TabIndex = 3;
            ProgressLbl.Text = "-";
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(14, -22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1600, 19);
            progressBar1.TabIndex = 0;
            // 
            // OperationsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "OperationsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Operations";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OperationsDataGridView).EndInit();
            FiltersPanel.ResumeLayout(false);
            FiltersPanel.PerformLayout();
            TypeGb.ResumeLayout(false);
            TypeGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            SearchGb.ResumeLayout(false);
            SearchGb.PerformLayout();
            LeftSidePanel.ResumeLayout(false);
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Panel panel1;
        private Panel ProgressPanel;
        private Label ProgressLbl;
        private ProgressBar progressBar1;
        private Label ProgressLblOperations;
        private ProgressBar progressBar2;
        private Panel FiltersPanel;
        private Button AddCategoryBtn;
        private PictureBox pictureBox1;
        private GroupBox SearchGb;
        private RadioButton ProductRb;
        private ComboBox comboBox1;
        private TextBox SearchTxt;
        private Guna.UI2.WinForms.Guna2ImageButton FiltersCollapse;
        private Guna.UI2.WinForms.Guna2ImageButton FiletersBtn;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView OperationsDataGridView;
        private Panel LeftSidePanel;
        private Guna.UI2.WinForms.Guna2ImageButton LeftSideCollapse;
        private Button ShowReportBtn;
        private RadioButton EmployeeRb;
        private RadioButton SupplierRb;
        private GroupBox TypeGb;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
        private CheckBox OutCb;
        private CheckBox InCb;
        private Button ChartBtn;
    }
}