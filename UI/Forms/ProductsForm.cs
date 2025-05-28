using System.Data;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class ProductsForm : Form
    {
        private bool isCollapsed = false;
        private bool isLoaded = false;
        private readonly int employeeId;
        private List<ProductDto> allProducts = new();

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IEmployeeService employeeService;
        private readonly IOperationService operationService;
        private readonly IDeletedProductService deletedProductService;

        public ProductsForm(int employeeId, IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IEmployeeService employeeService, IOperationService operationService, IDeletedProductService deletedProductService)
        {
            InitializeComponent();

            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.deletedProductService = deletedProductService ?? throw new ArgumentNullException(nameof(deletedProductService));
            this.employeeId = employeeId;

            InitializeDataGridColumns();
            LoadData();
        }

        private async Task LoadData()
        {
            await LoadProductsAsync();
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = (await categoryService.GetAllAsync()).ToList();
                categories.Insert(0, new CategoryDto { CategoryName = "All" });
                CategoriesCb.DataSource = categories;
                CategoriesCb.DisplayMember = "CategoryName";
                CategoriesCb.ValueMember = "CategoryId";
                CategoriesCb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void UpdateProgress(int current, int total)
        {
            if (total == 0) return;

            int percent = (int)((current / (float)total) * 100);
            progressBar1.Value = percent;
            ProgressLbl.Text = $"Загрузка: {percent}% ({current} из {total})";
        }

        private async Task LoadProductsAsync()
        {
            try
            {
                ProgressPanel.Visible = true;
                progressBar1.Value = 0;
                ProgressLbl.Text = "Loading products...";

                allProducts = new List<ProductDto>();
                var productsFromDb = await productService.GetAllAsync();
                int total = productsFromDb.Count();
                int count = 0;

                foreach (var product in productsFromDb)
                {
                    allProducts.Add(product);
                    count++;
                    UpdateProgress(count, total);
                    await Task.Delay(10);
                }

                ProductsDataGridView.DataSource = allProducts.ToList();
                isLoaded = true;
                ProgressLbl.Text = "Products loaded successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке продуктов: {ex.Message}");
                ProgressLbl.Text = "Ошибка загрузки";
            }
            finally
            {
                await Task.Delay(500);
                ProgressPanel.Visible = false;
            }
        }

        private async void InitializeDataGridColumns()
        {
            ProductsDataGridView.AutoGenerateColumns = false;
            ProductsDataGridView.RowHeadersVisible = true;
            ProductsDataGridView.RowHeadersWidth = 30;
            ProductsDataGridView.Columns.Clear();

            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductId",
                HeaderText = "Product ID",
                DataPropertyName = "ProductId",
                Visible = false
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product",
                DataPropertyName = "ProductName",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductQuantity",
                HeaderText = "Quantity",
                DataPropertyName = "ProductQuantity",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductPrice",
                HeaderText = "Price",
                DataPropertyName = "ProductPrice",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductCode",
                HeaderText = "Code",
                DataPropertyName = "ProductCode",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfReceipt",
                HeaderText = "Date Of Receipt",
                DataPropertyName = "DateOfReceipt",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Category",
                DataPropertyName = "CategoryName",
                Visible = true
            });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryId",
                HeaderText = "Category ID",
                DataPropertyName = "CategoryId",
                Visible = false
            });
        }

        private void FiltersCollapse_Click(object sender, EventArgs e)
        {
            if (FiltersPanel.Visible)
            {
                FiltersPanel.Visible = false;
            }
            else
            {
                FiltersPanel.Visible = true;
            }
        }

        private void LeftSideCollapse_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                LeftSidePanel.Width = 169;
                AddBtn.Text = "Add Product";
                ShowDetailsBtn.Text = "Show Details";
                ExitFormBtn.Visible = true;
                isCollapsed = false;
            }
            else
            {
                LeftSidePanel.Width = 55;
                AddBtn.Text = string.Empty;
                ShowDetailsBtn.Text = string.Empty;
                ExitFormBtn.Visible = false;
                isCollapsed = true;
            }
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltersCollapse_Click(sender, e);
        }

        private void ApplyFilters()
        {
            if (!isLoaded) return;

            string searchValue = SearchTxt.Text.ToLower();
            IEnumerable<ProductDto> filtered = allProducts;

            if (CategoriesCb.SelectedItem is CategoryDto selectedCategory && selectedCategory.CategoryId != 0)
            {
                filtered = filtered.Where(p => p.CategoryId == selectedCategory.CategoryId);
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                if (NameRb.Checked)
                {
                    filtered = filtered.Where(p => p.ProductName?.ToLower().Contains(searchValue) == true);
                }
                else if (CodeRb.Checked)
                {
                    filtered = filtered.Where(p => p.ProductCode?.ToLower().Contains(searchValue) == true);
                }
            }

            ProductsDataGridView.DataSource = filtered.ToList();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                ApplyFilters();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                ApplyFilters();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var addProductForm = new AddProductForm(employeeId, productService, categoryService, supplierService, employeeService, operationService);
                addProductForm.FormClosed += async (s, args) =>
                {
                    await LoadProductsAsync();
                };
                addProductForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Add Product form: {ex.Message}");
            }
        }

        private void AddCategoryBtn_Click(object sender, EventArgs e)
        {
            using (CategoryForm category = new CategoryForm(categoryService))
            {
                category.ShowDialog();
            }
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(
                rowIdx,
                this.Font,
                SystemBrushes.ControlText,
                headerBounds,
                centerFormat);
        }

        private async void ProductsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0) return;

            var selectedRow = ProductsDataGridView.SelectedRows[0];
            var productId = selectedRow.Cells[0].Value?.ToString();

            if (int.TryParse(productId, out int id))
            {
                try
                {
                    using (DetailsForm form = new DetailsForm(id, employeeId, productService, categoryService, employeeService, supplierService, operationService, deletedProductService))
                    {
                        form.ShowDialog();
                        ProductsDataGridView.DataSource = await productService.GetAllAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening product details: {ex.Message}");
                }
            }
        }

        private void ExitFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ShowDetailsBtn_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0) return;

            var selectedRow = ProductsDataGridView.SelectedRows[0];
            var productId = selectedRow.Cells[0].Value?.ToString();

            if (int.TryParse(productId, out int id))
            {
                try
                {
                    using (DetailsForm form = new DetailsForm(id, employeeId, productService, categoryService, employeeService, supplierService, operationService, deletedProductService))
                    {
                        form.ShowDialog();
                        ProductsDataGridView.DataSource = await productService.GetAllAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening product details: {ex.Message}");
                }
            }
        }
    }

}

