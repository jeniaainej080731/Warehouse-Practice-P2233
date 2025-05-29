namespace Warehouse.UI.Forms
{
    partial class AuditsForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            AuditsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            panelLeft = new Panel();
            btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            btnToggleSidePanel = new Guna.UI2.WinForms.Guna2ImageButton();
            btnMakeReport = new Button();
            btnMakeAudit = new Button();
            ProgressPanel = new Panel();
            lblStatus = new Label();
            progressBar2 = new ProgressBar();
            ProgressLbl = new Label();
            progressBar1 = new ProgressBar();
            txtSearch = new TextBox();
            statusStrip1 = new StatusStrip();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuditsDataGridView).BeginInit();
            panelLeft.SuspendLayout();
            ProgressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(AuditsDataGridView);
            panel1.Controls.Add(panelLeft);
            panel1.Controls.Add(ProgressPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(912, 503);
            panel1.TabIndex = 0;
            // 
            // AuditsDataGridView
            // 
            AuditsDataGridView.AllowUserToAddRows = false;
            AuditsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(192, 239, 212);
            AuditsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(46, 204, 113);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            AuditsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            AuditsDataGridView.ColumnHeadersHeight = 24;
            AuditsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(213, 244, 226);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(115, 221, 160);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            AuditsDataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            AuditsDataGridView.Dock = DockStyle.Fill;
            AuditsDataGridView.GridColor = Color.FromArgb(187, 238, 208);
            AuditsDataGridView.Location = new Point(169, 0);
            AuditsDataGridView.MultiSelect = false;
            AuditsDataGridView.Name = "AuditsDataGridView";
            AuditsDataGridView.ReadOnly = true;
            AuditsDataGridView.RowHeadersVisible = false;
            AuditsDataGridView.RowHeadersWidth = 51;
            AuditsDataGridView.Size = new Size(743, 451);
            AuditsDataGridView.TabIndex = 5;
            AuditsDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Emerald;
            AuditsDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(192, 239, 212);
            AuditsDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            AuditsDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            AuditsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            AuditsDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            AuditsDataGridView.ThemeStyle.BackColor = Color.White;
            AuditsDataGridView.ThemeStyle.GridColor = Color.FromArgb(187, 238, 208);
            AuditsDataGridView.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(46, 204, 113);
            AuditsDataGridView.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            AuditsDataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            AuditsDataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            AuditsDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            AuditsDataGridView.ThemeStyle.HeaderStyle.Height = 24;
            AuditsDataGridView.ThemeStyle.ReadOnly = true;
            AuditsDataGridView.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(213, 244, 226);
            AuditsDataGridView.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            AuditsDataGridView.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            AuditsDataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            AuditsDataGridView.ThemeStyle.RowsStyle.Height = 29;
            AuditsDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(115, 221, 160);
            AuditsDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.PaleTurquoise;
            panelLeft.Controls.Add(txtSearch);
            panelLeft.Controls.Add(btnExit);
            panelLeft.Controls.Add(btnToggleSidePanel);
            panelLeft.Controls.Add(btnMakeReport);
            panelLeft.Controls.Add(btnMakeAudit);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(169, 451);
            panelLeft.TabIndex = 4;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundImageLayout = ImageLayout.Stretch;
            btnExit.CheckedState.ImageSize = new Size(64, 64);
            btnExit.HoverState.ImageSize = new Size(26, 26);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageOffset = new Point(0, 0);
            btnExit.ImageRotate = 0F;
            btnExit.ImageSize = new Size(24, 24);
            btnExit.IndicateFocus = true;
            btnExit.Location = new Point(126, 9);
            btnExit.Name = "btnExit";
            btnExit.PressedState.ImageSize = new Size(27, 27);
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnExit.Size = new Size(32, 32);
            btnExit.TabIndex = 3;
            btnExit.UseTransparentBackground = true;
            // 
            // btnToggleSidePanel
            // 
            btnToggleSidePanel.BackColor = Color.Transparent;
            btnToggleSidePanel.BackgroundImageLayout = ImageLayout.Stretch;
            btnToggleSidePanel.CheckedState.ImageSize = new Size(64, 64);
            btnToggleSidePanel.HoverState.ImageSize = new Size(0, 0);
            btnToggleSidePanel.Image = (Image)resources.GetObject("btnToggleSidePanel.Image");
            btnToggleSidePanel.ImageOffset = new Point(0, 0);
            btnToggleSidePanel.ImageRotate = 0F;
            btnToggleSidePanel.ImageSize = new Size(40, 30);
            btnToggleSidePanel.IndicateFocus = true;
            btnToggleSidePanel.Location = new Point(10, 9);
            btnToggleSidePanel.Name = "btnToggleSidePanel";
            btnToggleSidePanel.PressedState.ImageSize = new Size(0, 0);
            btnToggleSidePanel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnToggleSidePanel.Size = new Size(30, 30);
            btnToggleSidePanel.TabIndex = 3;
            btnToggleSidePanel.UseTransparentBackground = true;
            // 
            // btnMakeReport
            // 
            btnMakeReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnMakeReport.BackColor = Color.MediumTurquoise;
            btnMakeReport.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnMakeReport.Image = (Image)resources.GetObject("btnMakeReport.Image");
            btnMakeReport.Location = new Point(14, 128);
            btnMakeReport.Name = "btnMakeReport";
            btnMakeReport.Size = new Size(144, 47);
            btnMakeReport.TabIndex = 2;
            btnMakeReport.Text = "Make Report";
            btnMakeReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMakeReport.UseVisualStyleBackColor = false;
            // 
            // btnMakeAudit
            // 
            btnMakeAudit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnMakeAudit.BackColor = Color.MediumTurquoise;
            btnMakeAudit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnMakeAudit.Image = (Image)resources.GetObject("btnMakeAudit.Image");
            btnMakeAudit.Location = new Point(14, 75);
            btnMakeAudit.Name = "btnMakeAudit";
            btnMakeAudit.Size = new Size(144, 47);
            btnMakeAudit.TabIndex = 2;
            btnMakeAudit.Text = "Make Audition";
            btnMakeAudit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMakeAudit.UseVisualStyleBackColor = false;
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.Transparent;
            ProgressPanel.Controls.Add(statusStrip1);
            ProgressPanel.Controls.Add(lblStatus);
            ProgressPanel.Controls.Add(progressBar2);
            ProgressPanel.Controls.Add(ProgressLbl);
            ProgressPanel.Controls.Add(progressBar1);
            ProgressPanel.Dock = DockStyle.Bottom;
            ProgressPanel.Location = new Point(0, 451);
            ProgressPanel.Name = "ProgressPanel";
            ProgressPanel.Size = new Size(912, 52);
            ProgressPanel.TabIndex = 3;
            ProgressPanel.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.Location = new Point(12, 5);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(15, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "-";
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
            // txtSearch
            // 
            txtSearch.Location = new Point(14, 196);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(144, 27);
            txtSearch.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 30);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(912, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // AuditsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 503);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AuditsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Audits";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AuditsDataGridView).EndInit();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel ProgressPanel;
        private Label ProgressLbl;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private ProgressBar progressBar2;
        private Panel panelLeft;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2ImageButton btnToggleSidePanel;
        private Button btnMakeAudit;
        private Guna.UI2.WinForms.Guna2DataGridView AuditsDataGridView;
        private Button btnMakeReport;
        private TextBox txtSearch;
        private StatusStrip statusStrip1;
    }
}