using System.Diagnostics;
using Warehouse.Services.Interfaces;
using Warehouse.UI.Forms;

namespace Warehouse.UI
{
    public partial class MainForm : Form
    {
        // Soo many services...
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IEmployeeService employeeService;
        private readonly IOperationService operationService;
        private readonly IDeletedProductService deletedProductService;
        private readonly IAuditService auditService;
        private readonly ILoginRoleService loginRoleService;
        private readonly IReceiptService receiptService;

        private readonly int employeeId; // to identify the current employee
        private readonly bool isAdmin; // to check if the current employee is an admin

        public MainForm(int employeeId, bool isAdmin,
            IProductService productService, ICategoryService categoryService, ISupplierService supplierService,
            IEmployeeService employeeService, IOperationService operationService, IDeletedProductService deletedProductService,
            IAuditService auditService, ILoginRoleService loginRoleService, IReceiptService receiptService)
        {
            InitializeComponent();

            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.deletedProductService = deletedProductService ?? throw new ArgumentNullException(nameof(deletedProductService));
            this.auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));
            this.loginRoleService = loginRoleService ?? throw new ArgumentNullException(nameof(loginRoleService));
            this.receiptService = receiptService ?? throw new ArgumentNullException(nameof(receiptService));
            this.employeeId = employeeId;
            this.isAdmin = isAdmin;
        }

        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm(employeeId, productService, categoryService, supplierService, employeeService, operationService, deletedProductService);
            productsForm.Show();
        }

        private void OperationsBtn_Click(object sender, EventArgs e)
        {
            OperationsForm operationsForm = new OperationsForm(operationService, productService, employeeService, supplierService, deletedProductService);
            operationsForm.Show();
        }

        private void AuditsBtn_Click(object sender, EventArgs e)
        {
            AuditsForm auditsForm = new AuditsForm(employeeId, operationService, auditService);
            auditsForm.Show();
        }

        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(isAdmin, supplierService);
            suppliersForm.Show();
        }

        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(isAdmin, employeeService, loginRoleService);
            employeesForm.Show();
        }

        private void ReceiptsBtn_Click(object sender, EventArgs e)
        {
            MakeInvoice makeReceipt = new MakeInvoice(employeeId, employeeService, productService, receiptService, supplierService);
            makeReceipt.ShowDialog();
        }

        // InvoiceBtn refers to the method ReceiptsBtn_Click,
        // because I'm confused and make receipt as invoice. ('cause I'm stoopid)
        private void InvoiceBtn_Click(object sender, EventArgs e)
        {
            // Here needs to be implemented the logic for invoice management,
            // but I didn't had enough time to do it.
        }

        private void backupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupsForm backupsForm = new BackupsForm();
            backupsForm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/jeniaainej080731/Warehouse-Practice-P2233/tree/master"; // my GitHub page
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии ссылки: {ex.Message}");
            }
        }

        private void authEmployerToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
