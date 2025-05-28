namespace Warehouse.UI.Forms
{
    partial class ReceiptsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptsForm));
            SuspendLayout();
            // 
            // ReceiptsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 503);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReceiptsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receipts";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion
    }
}