using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class DetailsForm : Form
    {
        private readonly int productId;
        private readonly int employeeId;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IEmployeeService employeeService;
        private readonly ISupplierService supplierService;
        private readonly IOperationService operationService;
        private readonly IDeletedProductService deletedProductService;
        public DetailsForm(int productId, int employeeId, IProductService productService, ICategoryService categoryService, IEmployeeService employeeService, ISupplierService supplierService, IOperationService operationService, IDeletedProductService deletedProductService)
        {
            InitializeComponent();

            this.productId = productId;
            this.employeeId = employeeId;
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.deletedProductService = deletedProductService ?? throw new ArgumentNullException(nameof(deletedProductService));

            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var product = await productService.GetByIdAsync(productId);
                var categories = await categoryService.GetAllAsync();
                var suppliers = await supplierService.GetAllAsync();
                var operation = await operationService.GetByProductIdAsync(productId);

                CategoryTxt.Text = product.CategoryName ?? "(deleted)";
                QuantityTxt.Text = product.ProductQuantity.ToString();
                SupplierTxt.Text = operation.SupplierName;

                if (operation == null)
                {
                    MessageBox.Show("No operation found for this product.");
                    return;
                }

                ProductNameTxt.Text = product.ProductName;
                PriceTxt.Text = product.ProductPrice.ToString("F2");
                EmployeeTxt.Text = operation.EmployeeName;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task SetOperation(ProductDto product)
        {
            var operation = await operationService.GetByProductIdAsync(product.ProductId);
            var employee = await employeeService.GetByIdAsync(employeeId);
            var supplier = await supplierService.GetByIdAsync(operation.SupplierId);

            var operationDto = new OperationDto
            {
                ProductId = product.ProductId,
                SupplierId = operation.SupplierId,
                EmployeeId = employeeId,
                OperationType = "OUT",
                OperationDate = DateTime.Now,
                QuantityInOperation = product.ProductQuantity,

                ProductName = product.ProductName,
                SupplierName = supplier?.SupplierName ?? "(deleted)",
                EmployeeName = employee?.FullName ?? "(deleted)"
            };

            await operationService.AddAsync(operationDto);
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes)
                return;

            try
            {
                var product = await productService.GetByIdAsync(productId);
                if (product == null)
                {
                    MessageBox.Show("Product not found.");
                    return;
                }

                var deletedProduct = new DeletedProductsDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductQuantity = product.ProductQuantity,
                    ProductPrice = product.ProductPrice,
                    ProductCode = product.ProductCode,
                    DateOfReceipt = product.DateOfReceipt,
                    CategoryId = product.CategoryId
                };

                await deletedProductService.AddAsync(deletedProduct);

                await SetOperation(product);

                await productService.DeleteAsync(product.ProductId);

                MessageBox.Show("Product deleted successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}");
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                EditProductForm editProductForm = new EditProductForm(productId, employeeId, productService, employeeService, categoryService, supplierService, operationService);
                this.Close();
                editProductForm.ShowDialog();
            }
        }
    }
}
