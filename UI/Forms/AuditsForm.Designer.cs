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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuditsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            AuditsDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            LeftSidePanel = new Panel();
            ExitFormBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            LeftSideCollapse = new Guna.UI2.WinForms.Guna2ImageButton();
            MakeReportBtn = new Button();
            MakeAuditBtn = new Button();
            ProgressPanel = new Panel();
            ProgressLbl_Audits = new Label();
            progressBar2 = new ProgressBar();
            ProgressLbl = new Label();
            progressBar1 = new ProgressBar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuditsDataGridView).BeginInit();
            LeftSidePanel.SuspendLayout();
            ProgressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(AuditsDataGridView);
            panel1.Controls.Add(LeftSidePanel);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 239, 212);
            AuditsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(46, 204, 113);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            AuditsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            AuditsDataGridView.ColumnHeadersHeight = 24;
            AuditsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(213, 244, 226);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(115, 221, 160);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            AuditsDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
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
            AuditsDataGridView.RowPostPaint += AuditsDataGridView_RowPostPaint;
            // 
            // LeftSidePanel
            // 
            LeftSidePanel.BackColor = Color.PaleTurquoise;
            LeftSidePanel.Controls.Add(ExitFormBtn);
            LeftSidePanel.Controls.Add(LeftSideCollapse);
            LeftSidePanel.Controls.Add(MakeReportBtn);
            LeftSidePanel.Controls.Add(MakeAuditBtn);
            LeftSidePanel.Dock = DockStyle.Left;
            LeftSidePanel.Location = new Point(0, 0);
            LeftSidePanel.Name = "LeftSidePanel";
            LeftSidePanel.Size = new Size(169, 451);
            LeftSidePanel.TabIndex = 4;
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
            ExitFormBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
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
            LeftSideCollapse.ShadowDecoration.CustomizableEdges = customizableEdges2;
            LeftSideCollapse.Size = new Size(30, 30);
            LeftSideCollapse.TabIndex = 3;
            LeftSideCollapse.UseTransparentBackground = true;
            LeftSideCollapse.Click += LeftSideCollapse_Click;
            // 
            // MakeReportBtn
            // 
            MakeReportBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MakeReportBtn.BackColor = Color.MediumTurquoise;
            MakeReportBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            MakeReportBtn.Image = (Image)resources.GetObject("MakeReportBtn.Image");
            MakeReportBtn.Location = new Point(14, 128);
            MakeReportBtn.Name = "MakeReportBtn";
            MakeReportBtn.Size = new Size(144, 47);
            MakeReportBtn.TabIndex = 2;
            MakeReportBtn.Text = "Make Report";
            MakeReportBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            MakeReportBtn.UseVisualStyleBackColor = false;
            MakeReportBtn.Click += MakeReportBtn_Click;
            // 
            // MakeAuditBtn
            // 
            MakeAuditBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MakeAuditBtn.BackColor = Color.MediumTurquoise;
            MakeAuditBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            MakeAuditBtn.Image = (Image)resources.GetObject("MakeAuditBtn.Image");
            MakeAuditBtn.Location = new Point(14, 75);
            MakeAuditBtn.Name = "MakeAuditBtn";
            MakeAuditBtn.Size = new Size(144, 47);
            MakeAuditBtn.TabIndex = 2;
            MakeAuditBtn.Text = "Make Audition";
            MakeAuditBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            MakeAuditBtn.UseVisualStyleBackColor = false;
            MakeAuditBtn.Click += MakeAuditBtn_Click;
            // 
            // ProgressPanel
            // 
            ProgressPanel.BackColor = Color.Transparent;
            ProgressPanel.Controls.Add(ProgressLbl_Audits);
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
            // ProgressLbl_Audits
            // 
            ProgressLbl_Audits.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProgressLbl_Audits.AutoSize = true;
            ProgressLbl_Audits.BackColor = Color.Transparent;
            ProgressLbl_Audits.Location = new Point(12, 5);
            ProgressLbl_Audits.Name = "ProgressLbl_Audits";
            ProgressLbl_Audits.Size = new Size(15, 20);
            ProgressLbl_Audits.TabIndex = 5;
            ProgressLbl_Audits.Text = "-";
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
            Load += AuditsForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AuditsDataGridView).EndInit();
            LeftSidePanel.ResumeLayout(false);
            ProgressPanel.ResumeLayout(false);
            ProgressPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel ProgressPanel;
        private Label ProgressLbl;
        private ProgressBar progressBar1;
        private Label ProgressLbl_Audits;
        private ProgressBar progressBar2;
        private Panel LeftSidePanel;
        private Guna.UI2.WinForms.Guna2ImageButton ExitFormBtn;
        private Guna.UI2.WinForms.Guna2ImageButton LeftSideCollapse;
        private Button MakeAuditBtn;
        private Guna.UI2.WinForms.Guna2DataGridView AuditsDataGridView;
        private Button MakeReportBtn;
    }
}