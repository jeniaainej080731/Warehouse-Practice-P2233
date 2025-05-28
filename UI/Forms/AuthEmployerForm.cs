using System;
using System.Linq;
using System.Windows.Forms;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AuthEmployerForm : Form
    {
        private readonly ILoginRoleService _loginRoleService;
        private readonly IEmployeeService _employeeService;

        public AuthEmployerForm(
            ILoginRoleService loginRoleService,
            IEmployeeService employeeService)
        {
            InitializeComponent();
            _loginRoleService = loginRoleService ?? throw new ArgumentNullException(nameof(loginRoleService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        private async void AuthEmployerForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Предполагаем, что GetAllAsync возвращает IEnumerable<EmployeeDto>
                var employees = await _employeeService.GetAllAsync();
                EmployeesCb.Items.Clear();
                foreach (var emp in employees)
                {
                    // Отображаем в списке имя, но храним сам DTO в Item
                    EmployeesCb.Items.Add(emp);
                }

                string[] roles = ["Admin", "User"];
                foreach (var role in roles)
                {
                    RoleCb.Items.Add(role);
                }

                EmployeesCb.DisplayMember = nameof(EmployeeDto.FullName);
                EmployeesCb.ValueMember = nameof(EmployeeDto.LoginId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при загрузке сотрудников: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmployeesCb.SelectedItem is not EmployeeDto selectedEmployee)
                {
                    MessageBox.Show(
                        "Пожалуйста, выберите сотрудника.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (RoleCb.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите роль.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var loginRoleDto = new LoginRoleDto
                {
                    LoginId = selectedEmployee.LoginId,
                    Role = RoleCb.SelectedItem.ToString().Trim()
                };

                await _loginRoleService.AddAsync(loginRoleDto);

                MessageBox.Show(
                    "Роль успешно сохранена.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при сохранении роли: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
