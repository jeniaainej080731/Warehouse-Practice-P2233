namespace Warehouse.UI.Forms
{
    public partial class CommentForm : Form
    {
        public string CommentText { get; private set; } = "";

        public CommentForm(string initialComment = "")
        {
            InitializeComponent();
            txtComment.Text = initialComment;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            CommentText = txtComment.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
