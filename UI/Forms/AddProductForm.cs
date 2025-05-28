using System.Globalization;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AddProductForm : Form
    {
        private int employeeId;
        private readonly string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IEmployeeService employeeService;
        private readonly IOperationService operationService;

        public AddProductForm(int employeeId, IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IEmployeeService employeeService, IOperationService operationService)
        {
            InitializeComponent();
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.employeeId = employeeId;

            LoadData();
        }

        private async Task LoadData()
        {
            await LoadCategoriesAsync();
            await LoadSuppliersAsync();
            await SetEmployee();
        }

        private async Task SetEmployee()
        {
            try
            {
                var employee = await employeeService.GetByIdAsync(employeeId);
                if (employee != null)
                {
                    PerformedEmpTxtb.Text = employee.FullName;
                }
                else
                {
                    PerformedEmpTxtb.Text = "Unknown Employee";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee: {ex.Message}");
                PerformedEmpTxtb.Text = string.Empty;
            }
        }

        private async Task LoadSuppliersAsync()
        {
            try
            {
                var suppliers = await supplierService.GetAllAsync();
                SuppliersCb.DataSource = suppliers.ToList();
                SuppliersCb.DisplayMember = "SupplierName";
                SuppliersCb.ValueMember = "SupplierId";
                SuppliersCb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}");
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await categoryService.GetAllAsync();
                CategoriesCbox.DataSource = categories.ToList();
                CategoriesCbox.DisplayMember = "CategoryName";
                CategoriesCbox.ValueMember = "CategoryId";
                CategoriesCbox.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private void PriceTxtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            string separator = decimalSeparator;

            if (!char.IsDigit(number) && number != (char)Keys.Back && number.ToString() != separator)
            {
                e.Handled = true;
                return;
            }

            if (number.ToString() == separator && PriceTxtb.Text.Contains(separator))
            {
                e.Handled = true;
            }
        }

        private void PriceTxtb_TextChanged(object sender, EventArgs e)
        {
            string separator = decimalSeparator;

            if (separator == "." && PriceTxtb.Text.Contains(","))
            {
                PriceTxtb.Text = PriceTxtb.Text.Replace(',', '.');
                PriceTxtb.SelectionStart = PriceTxtb.Text.Length;
            }
            else if (separator == "," && PriceTxtb.Text.Contains("."))
            {
                PriceTxtb.Text = PriceTxtb.Text.Replace('.', ',');
                PriceTxtb.SelectionStart = PriceTxtb.Text.Length;
            }

            string[] parts = PriceTxtb.Text.Split(separator.ToCharArray());

            if (parts.Length > 1 && parts[1].Length > 2)
            {
                PriceTxtb.Text = parts[0] + separator + parts[1].Substring(0, 2);
                PriceTxtb.SelectionStart = PriceTxtb.Text.Length;
            }

            if (parts[0].Length > 7)
            {
                PriceTxtb.Text = parts[0].Substring(0, 7) + (parts.Length > 1 ? separator + parts[1] : "");
                PriceTxtb.SelectionStart = PriceTxtb.Text.Length;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Cancel?",
                "Are you sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private string GenerateProductCode(string categoryName, int productId)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("Category name cannot be null or empty.");

            var prefix = categoryName.Substring(0, Math.Min(3, categoryName.Length)).ToUpper();
            return $"{prefix}{productId}";
        }

        private async Task SetOperation(int productId, int employeeId, int supplierId, int quantity)
        {
            var product = await productService.GetByIdAsync(productId);
            var supplier = await supplierService.GetByIdAsync(supplierId);
            var employee = await employeeService.GetByIdAsync(employeeId);

            var operationDto = new OperationDto
            {
                ProductId = productId,
                SupplierId = supplierId,
                EmployeeId = employeeId,
                OperationType = "IN",
                OperationDate = DateTime.Now,
                QuantityInOperation = quantity,

                ProductName = product?.ProductName ?? "(deleted)",
                SupplierName = supplier?.SupplierName ?? "(deleted)",
                EmployeeName = employee?.FullName ?? "(deleted)"
            };

            await operationService.AddAsync(operationDto);
        }


        private async void AddBtn_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductNameTxtb.Text) ||
                string.IsNullOrEmpty(PriceTxtb.Text) ||
                QuantityNumeric.Value == 0 ||
                SuppliersCb.SelectedValue == string.Empty ||
                CategoriesCbox.SelectedValue == string.Empty)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                CategoryDto selectedCategory = (CategoryDto)CategoriesCbox.SelectedItem;
                if (selectedCategory == null)
                {
                    MessageBox.Show("Invalid category selected.");
                    return;
                }

                var productDto = new ProductDto
                {
                    ProductName = ProductNameTxtb.Text,
                    ProductPrice = decimal.Parse(PriceTxtb.Text),
                    ProductQuantity = (int)QuantityNumeric.Value,
                    CategoryId = (int)CategoriesCbox.SelectedValue,
                    CategoryName = selectedCategory.CategoryName,
                    ProductCode = "TEMP",
                    DateOfReceipt = DateTime.Now
                };

                var createdProduct = await productService.AddAsync(productDto);

                createdProduct.ProductCode = GenerateProductCode(selectedCategory.CategoryName, createdProduct.ProductId);
                await productService.UpdateAsync(createdProduct);

                await SetOperation(createdProduct.ProductId, employeeId, (int)SuppliersCb.SelectedValue, (int)QuantityNumeric.Value);

                MessageBox.Show("Product added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}");
            }
        }
    }
}
