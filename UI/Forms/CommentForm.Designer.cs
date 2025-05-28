namespace Warehouse.UI.Forms
{
    partial class CommentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentForm));
            txtComment = new TextBox();
            label1 = new Label();
            SaveBtn = new Button();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // txtComment
            // 
            txtComment.Font = new Font("Segoe UI", 10.8F);
            txtComment.Location = new Point(12, 45);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(412, 122);
            txtComment.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(157, 28);
            label1.TabIndex = 1;
            label1.Text = "Leave comment";
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.DarkGreen;
            SaveBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(22, 173);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = SystemColors.ControlDark;
            CancelBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            CancelBtn.Location = new Point(122, 173);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 29);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // CommentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(436, 209);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(label1);
            Controls.Add(txtComment);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CommentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Comment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtComment;
        private Label label1;
        private Button SaveBtn;
        private Button CancelBtn;
    }
}