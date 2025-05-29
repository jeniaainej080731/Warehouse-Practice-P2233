using System.Text.RegularExpressions;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AddEmployeeForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoginRoleService _loginRoleService;

        public AddEmployeeForm(IEmployeeService employeeService, ILoginRoleService loginRoleService)
        {
            InitializeComponent();
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _loginRoleService = loginRoleService ?? throw new ArgumentNullException(nameof(loginRoleService));

            this.FormClosed += (s, e) => CancelBtn_Click(s, e);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to cancel? All unsaved changes will be lost.",
                "Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = NameTxt.Text.Trim();

                using var authForm = new AuthEmployerForm(fullName, _loginRoleService, _employeeService);
                if (authForm.ShowDialog() != DialogResult.OK)
                {
                    return; // Пользователь отменил создание
                }

                string email = EmailTxt.Text.Trim();
                string phone = PhoneTxt.Text.Trim();
                string? photoPath = string.IsNullOrWhiteSpace(photoPathLbl.Text)
                    ? string.Empty
                    : photoPathLbl.Text.Trim();

                // 1. Required fields
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Full name and email are required.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Email validation
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Enter a valid email address.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Phone validation (digits only, 5-15 digits)
                var phoneClean = Regex.Replace(phone, "\\D", "");
                if (!string.IsNullOrEmpty(phone) && !Regex.IsMatch(phoneClean, "^\\d{5,15}$"))
                {
                    MessageBox.Show("Enter a valid phone number (5–15 digits).",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Photo exists
                if (!string.IsNullOrEmpty(photoPath) &&
                    !File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, photoPath)))
                {
                    MessageBox.Show("Selected photo not found.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newEmployee = new EmployeeDto
                {
                    FullName = fullName,
                    Email = email,
                    PhoneNumber = Regex.Replace(phone, "\\D", ""),
                    PhotoPath = photoPath,
                    LoginId = authForm.CreatedLoginId // Используем ID из формы аутентификации
                };

                await _employeeService.AddAsync(newEmployee);

                MessageBox.Show("Employee successfully added.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding employee:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChoosePhotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog1.Title = "Select employee photo";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog1.FileName;
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string relFolder = Path.Combine("Resources", "Images", "Employees");
                    string destFolder = Path.Combine(baseDir, relFolder);

                    if (!Directory.Exists(destFolder))
                        Directory.CreateDirectory(destFolder);

                    string fileName = Path.GetFileName(selectedPath);
                    string destPath = Path.Combine(destFolder, fileName);

                    if (File.Exists(destPath))
                    {
                        string nameNoExt = Path.GetFileNameWithoutExtension(fileName);
                        string ext = Path.GetExtension(fileName);
                        fileName = $"{nameNoExt}_{Guid.NewGuid():N}{ext}";
                        destPath = Path.Combine(destFolder, fileName);
                    }

                    File.Copy(selectedPath, destPath);
                    photoPathLbl.Text = Path.Combine(relFolder, fileName).Replace("\\", "/");
                }
                else
                {
                    photoPathLbl.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting photo: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
