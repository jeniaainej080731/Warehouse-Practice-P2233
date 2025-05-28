using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AddCategoryForm : Form
    {
        private readonly List<CategoryDto> categories = new List<CategoryDto>();

        private readonly ICategoryService categoryService;

        public AddCategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();

            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

            LoadCategories();
        }

        private async void LoadCategories()
        {
            try
            {
                var loadedCategories = await categoryService.GetAllAsync();
                categories.AddRange(loadedCategories);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке категорий: " + ex.Message);
                this.Close();
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = CategoryNameTxt.Text;
                string description = DescriptionTxt.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Category description cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var categoryDto = new CategoryDto
                {
                    CategoryName = name,
                    CategoryDescription = description
                };

                if (categories.Any(c =>
                    string.Equals(c.CategoryName, categoryDto.CategoryName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(c.CategoryDescription, categoryDto.CategoryDescription, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Category already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    await categoryService.AddAsync(categoryDto);
                }

                MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the category: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
