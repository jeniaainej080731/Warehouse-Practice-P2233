using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI
{
    public partial class LoginForm : Form
    {
        private bool isVisible = false;

        private readonly ILoginRoleService loginRoleService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IEmployeeService employeeService;
        private readonly IOperationService operationService;
        private readonly IDeletedProductService deletedProductService;
        private readonly IAuditService auditService;
        private readonly IReceiptService receiptService;

        private int userID;
        private bool isAdmin;
        private bool _isLoggingIn = false;

        public LoginForm(ILoginRoleService loginRoleService, IProductService productService, ICategoryService categoryService,
            ISupplierService supplierService, IEmployeeService employeeService, IOperationService operationService,
            IDeletedProductService deletedProductService, IAuditService auditService, IReceiptService receiptService)
        {
            InitializeComponent();

            this.loginRoleService = loginRoleService ?? throw new ArgumentNullException(nameof(loginRoleService));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.deletedProductService = deletedProductService ?? throw new ArgumentNullException(nameof(deletedProductService));
            this.auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));
            this.receiptService = receiptService ?? throw new ArgumentNullException(nameof(receiptService));

            this.AcceptButton = EnterBtn;
        }

        private async void EnterBtn_Click(object sender, EventArgs e)
        {
            string userLogin = LoginTxt.Text.Trim();
            string userPassword = PasswordTxt.Text;

            if (string.IsNullOrWhiteSpace(userLogin) || string.IsNullOrEmpty(userPassword))
            {
                MessageBox.Show(
                    "Пожалуйста, введите логин и пароль.",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_isLoggingIn) return;
            _isLoggingIn = true;
            EnterBtn.Enabled = false;

            try
            {
                LoginRoleDto loginRole = await loginRoleService.GetByCredentials(userLogin, userPassword);
                userID = loginRole.LoginId;
                isAdmin = await loginRoleService.IsAdmin(userID);

                if (loginRole != null)
                {
                    MainForm mainForm = new MainForm(userID, isAdmin,
                        productService, categoryService, supplierService,
                        employeeService, operationService, deletedProductService,
                        auditService, loginRoleService, receiptService);
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Неверный логин или пароль.",
                        "Ошибка авторизации",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException nex)
            {
                MessageBox.Show(
                    $"Пожалуйста, проверьте правильность введенных данных: {nex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Произошла ошибка при попытке авторизации: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _isLoggingIn = false;
                EnterBtn.Enabled = true;
            }
        }

        private void SeePassBtn_Click(object sender, EventArgs e)
        {
            if (!isVisible)
            {
                PasswordTxt.PasswordChar = '\0';
                SeePassBtn.Image = Properties.Resources.seepass;
                isVisible = true;
            }
            else
            {
                PasswordTxt.PasswordChar = '※';
                SeePassBtn.Image = Properties.Resources.dontseepass;
                isVisible = false;
            }
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnterBtn_Click(sender, e);
            }
        }

        private void LoginTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoginForm_KeyPress(sender, e);
        }

        private void PasswordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoginForm_KeyPress(sender, e);
        }
    }
}
