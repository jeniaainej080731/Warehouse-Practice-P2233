using Warehouse.Services.Interfaces;

namespace Warehouse
{
    public partial class TestOutProductsTableForm : Form
    {
        private readonly IProductService productService;
        private readonly IEmployeeService employeeService;
        private readonly ICategoryService categoryService;
        private readonly IAuditService auditService;

        public TestOutProductsTableForm(IProductService productService, IEmployeeService employeeService, ICategoryService categoryService, IAuditService auditService)
        {
            InitializeComponent();
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));
        }

        private async void loadProductsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var products = await productService.GetAllAsync();
                dataGridView1.DataSource = products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private async void loadEmpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var employees = await employeeService.GetAllAsync();
                dataGridView1.DataSource = employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}");
            }
        }

        private async void loadCatbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var categories = await categoryService.GetAllAsync();
                dataGridView1.DataSource = categories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private async void loadAuditsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                var audits = await auditService.GetAllAsync();
                dataGridView1.DataSource = audits.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audits: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
