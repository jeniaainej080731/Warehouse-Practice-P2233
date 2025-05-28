using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class EditProductForm : Form
    {
        private readonly int productId;
        private readonly int employeeId;

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IEmployeeService employeeService;
        private readonly ISupplierService supplierService;
        private readonly IOperationService operationService;

        public EditProductForm(int productId, int employeeId, IProductService productService, IEmployeeService employeeService, ICategoryService categoryService, ISupplierService supplierService, IOperationService operationService)
        {
            InitializeComponent();

            this.productId = productId;
            this.employeeId = employeeId;
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));

            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var product = await productService.GetByIdAsync(productId);
                var categories = await categoryService.GetAllAsync();
                var employee = await employeeService.GetByIdAsync(employeeId);
                var suppliers = await supplierService.GetAllAsync();
                var operation = await operationService.GetByProductIdAsync(productId);

                CategoriesCb.Items.Clear();
                CategoriesCb.DataSource = categories.ToList();
                CategoriesCb.DisplayMember = "CategoryName";
                CategoriesCb.ValueMember = "CategoryId";
                CategoriesCb.SelectedValue = product.CategoryId;

                QuantityNud.Text = product.ProductQuantity.ToString();

                SuppliersCb.Items.Clear();
                SuppliersCb.DataSource = suppliers.ToList();
                SuppliersCb.DisplayMember = "SupplierName";
                SuppliersCb.ValueMember = "SupplierId";
                SuppliersCb.SelectedValue = operation.SupplierId;

                ProductNameTxt.Text = product.ProductName;
                PriceTxt.Text = product.ProductPrice.ToString("F2");
                EmployeeTxt.Text = employee.FullName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async Task SetOperation(int productId, int supplierId, int employeeId, int quantity)
        {
            var product = await productService.GetByIdAsync(productId);
            var supplier = await supplierService.GetByIdAsync(supplierId);
            var employee = await employeeService.GetByIdAsync(employeeId);

            var operationDto = new OperationDto
            {
                ProductId = product.ProductId,
                SupplierId = supplier.SupplierId,
                EmployeeId = employee.EmployeeId,
                OperationType = "UPD",
                OperationDate = DateTime.Now,
                QuantityInOperation = quantity,

                ProductName = product?.ProductName ?? "(deleted)",
                SupplierName = supplier?.SupplierName ?? "(deleted)",
                EmployeeName = employee?.FullName ?? "(deleted)"
            };

            await operationService.AddAsync(operationDto);
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedCategory = CategoriesCb.SelectedItem as CategoryDto;
                var existedProduct = await productService.GetByIdAsync(productId);

                DateTime productDt = existedProduct.DateOfReceipt;
                string productCode = existedProduct.ProductCode;

                var product = new ProductDto
                {
                    ProductId = productId,
                    ProductName = ProductNameTxt.Text,
                    ProductPrice = decimal.Parse(PriceTxt.Text),
                    ProductQuantity = (int)QuantityNud.Value,
                    DateOfReceipt = productDt,
                    ProductCode = productCode,
                    CategoryId = (int)CategoriesCb.SelectedValue,
                    CategoryName = selectedCategory?.CategoryName
                };

                await productService.UpdateAsync(product);

                await SetOperation(product.ProductId,
                                   (int)SuppliersCb.SelectedValue,
                                    employeeId,
                                    product.ProductQuantity);

                MessageBox.Show("Product updated successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                var error = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Error updating product: {error}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
