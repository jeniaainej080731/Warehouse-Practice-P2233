namespace Warehouse.UI.Forms
{
    partial class DefaultSuppliers
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultSuppliers));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ProgressPanel = new Panel();
            ProgressLbl_Suppliers = new Label();
            progressBar2 = new ProgressBar();
            ProgressLbl = new Label();
            progressBar1 = new ProgressBar();
            FiltersPanel = new Panel();
            FilterBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            pictureBox1 = new PictureBox();
            SearchTxt = new TextBox();
            FiltersCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            menuStrip1 = new MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            SuppliersDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            ProgressPanel.SuspendLayout();
            FiltersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SuppliersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.Transparent;
            ProgressPanel.Controls.Add(ProgressLbl_Suppliers);
            ProgressPanel.Controls.Add(progressBar2);
            ProgressPanel.Controls.Add(ProgressLbl);
            ProgressPanel.Controls.Add(progressBar1);
            ProgressPanel.Dock = DockStyle.Bottom;
            ProgressPanel.Location = new Point(0, 451);
            ProgressPanel.Name = "ProgressPanel";
            ProgressPanel.Size = new Size(912, 52);
            ProgressPanel.TabIndex = 3;
            // 
            // ProgressLbl_Suppliers
            // 
            ProgressLbl_Suppliers.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressLbl_Suppliers.AutoSize = true;
            ProgressLbl_Suppliers.BackColor = Color.Transparent;
            ProgressLbl_Suppliers.Location = new Point(12, 5);
            ProgressLbl_Suppliers.Name = "ProgressLbl_Suppliers";
            ProgressLbl_Suppliers.Size = new Size(15, 20);
            ProgressLbl_Suppliers.TabIndex = 5;
            ProgressLbl_Suppliers.Text = "-";
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
            // FiltersPanel
            // 
            FiltersPanel.BackColor = Color.LightCyan;
            FiltersPanel.Controls.Add(ExitFormBtn);
            FiltersPanel.Controls.Add(FilterBtn);
            FiltersPanel.Controls.Add(pictureBox1);
            FiltersPanel.Controls.Add(SearchTxt);
            FiltersPanel.Controls.Add(FiltersCollapse);
            FiltersPanel.Dock = DockStyle.Top;
            FiltersPanel.Location = new Point(0, 28);
            FiltersPanel.Name = "FiltersPanel";
            FiltersPanel.Size = new Size(912, 58);
            FiltersPanel.TabIndex = 4;
            // 
            // FilterBtn
            // 
            FilterBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FilterBtn.BackColor = Color.Transparent;
            FilterBtn.BackgroundImageLayout = ImageLayout.Stretch;
            FilterBtn.CheckedState.ImageSize = new Size(64, 64);
            FilterBtn.HoverState.ImageSize = new Size(15, 15);
            FilterBtn.Image = (Image)resources.GetObject("FilterBtn.Image");
            FilterBtn.ImageOffset = new Point(0, 0);
            FilterBtn.ImageRotate = 0F;
            FilterBtn.ImageSize = new Size(15, 15);
            FilterBtn.IndicateFocus = true;
            FilterBtn.Location = new Point(889, 39);
            FilterBtn.Name = "FilterBtn";
            FilterBtn.PressedState.ImageSize = new Size(15, 15);
            FilterBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            FilterBtn.Size = new Size(15, 15);
            FilterBtn.TabIndex = 9;
            FilterBtn.UseTransparentBackground = true;
            FilterBtn.Click += FilterBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(251, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // SearchTxt
            // 
            SearchTxt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SearchTxt.Location = new Point(65, 14);
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
            FiltersCollapse.Location = new Point(1434, 4);
            FiltersCollapse.Name = "FiltersCollapse";
            FiltersCollapse.PressedState.ImageSize = new Size(15, 15);
            FiltersCollapse.ShadowDecoration.CustomizableEdges = customizableEdges3;
            FiltersCollapse.Size = new Size(15, 15);
            FiltersCollapse.TabIndex = 2;
            FiltersCollapse.UseTransparentBackground = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(912, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(125, 26);
            filterToolStripMenuItem.Text = "Filter";
            filterToolStripMenuItem.Click += filterToolStripMenuItem_Click;
            // 
            // SuppliersDataGridView
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(179, 223, 219);
            SuppliersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            SuppliersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            SuppliersDataGridView.ColumnHeadersHeight = 24;
            SuppliersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(204, 233, 231);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(85, 185, 175);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            SuppliersDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            SuppliersDataGridView.Dock = DockStyle.Fill;
            SuppliersDataGridView.GridColor = Color.FromArgb(177, 222, 218);
            SuppliersDataGridView.Location = new Point(0, 86);
            SuppliersDataGridView.MultiSelect = false;
            SuppliersDataGridView.Name = "SuppliersDataGridView";
            SuppliersDataGridView.ReadOnly = true;
            SuppliersDataGridView.RowHeadersVisible = false;
            SuppliersDataGridView.RowHeadersWidth = 51;
            SuppliersDataGridView.Size = new Size(912, 365);
            SuppliersDataGridView.TabIndex = 6;
            SuppliersDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            SuppliersDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(179, 223, 219);
            SuppliersDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            SuppliersDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            SuppliersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            SuppliersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            SuppliersDataGridView.ThemeStyle.BackColor = Color.White;
            SuppliersDataGridView.ThemeStyle.GridColor = Color.FromArgb(177, 222, 218);
            SuppliersDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(0, 150, 136);
            SuppliersDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            SuppliersDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            SuppliersDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            SuppliersDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            SuppliersDataGridView.ThemeStyle.HeaderStyle.Height = 24;
            SuppliersDataGridView.ThemeStyle.ReadOnly = true;
            SuppliersDataGridView.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(204, 233, 231);
            SuppliersDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            SuppliersDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            SuppliersDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            SuppliersDataGridView.ThemeStyle.RowsStyle.Height = 29;
            SuppliersDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(85, 185, 175);
            SuppliersDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            SuppliersDataGridView.RowPostPaint += SuppliersDataGridView_RowPostPaint;
            // 
            // ExitFormBtn
            // 
            ExitFormBtn.BackColor = Color.Transparent;
            ExitFormBtn.BackgroundImageLayout = ImageLayout.Stretch;
            ExitFormBtn.CheckedState.ImageSize = new Size(64, 64);
            ExitFormBtn.HoverState.ImageSize = new Size(26, 26);
            ExitFormBtn.Image = (Image)resources.GetObject("ExitFormBtn.Image");
            ExitFormBtn.ImageOffset = new Point(0, 0);
            ExitFormBtn.ImageRotate = 0F;
            ExitFormBtn.ImageSize = new Size(24, 24);
            ExitFormBtn.IndicateFocus = true;
            ExitFormBtn.Location = new Point(12, 13);
            ExitFormBtn.Name = "ExitFormBtn";
            ExitFormBtn.PressedState.ImageSize = new Size(27, 27);
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
            ExitFormBtn.Size = new Size(32, 32);
            ExitFormBtn.TabIndex = 10;
            ExitFormBtn.UseTransparentBackground = true;
            ExitFormBtn.Click += ExitFormBtn_Click;
            // 
            // DefaultSuppliers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(SuppliersDataGridView);
            Controls.Add(FiltersPanel);
            Controls.Add(ProgressPanel);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "DefaultSuppliers";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suppliers";
            WindowState = FormWindowState.Maximized;
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            FiltersPanel.ResumeLayout(false);
            FiltersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SuppliersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel ProgressPanel;
        private Label ProgressLbl;
        private ProgressBar progressBar1;
        private Label ProgressLbl_Suppliers;
        private ProgressBar progressBar2;
        private Panel FiltersPanel;
        private PictureBox pictureBox1;
        private TextBox SearchTxt;
        private Guna.UI2.WinForms.Guna2ImageButton FiltersCollapse;
        private Guna.UI2.WinForms.Guna2ImageButton FilterBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView SuppliersDataGridView;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
    }
}