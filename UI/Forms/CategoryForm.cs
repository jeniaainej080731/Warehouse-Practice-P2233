using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService categoryService;
        public CategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();

            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await categoryService.GetAllAsync();
            CategoriesCb.DisplayMember = "CategoryName";
            CategoriesCb.ValueMember = "CategoryId";
            CategoriesCb.DataSource = categories.ToList();
            CategoriesCb.SelectedIndex = 0;
        }

        private async void CategoriesCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DescriptionTxt.Text = await categoryService.GetDescriptionById((int)CategoriesCb.SelectedValue);
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            using (var addCategory = new AddCategoryForm(categoryService))
            {
                addCategory.ShowDialog();
                await LoadCategoriesAsync();
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCategory = (int)CategoriesCb.SelectedValue;
                if (selectedCategory == 0)
                {
                    MessageBox.Show("Please select a category to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await categoryService.DeleteAsync(selectedCategory);
                    MessageBox.Show("Category deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCategoriesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
