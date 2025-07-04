﻿using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AuthEmployerForm : Form
    {
        private readonly ILoginRoleService _loginRoleService;
        private readonly IEmployeeService _employeeService;
        private readonly string _name;

        public int CreatedLoginId { get; private set; }

        public AuthEmployerForm(string name,
            ILoginRoleService loginRoleService,
            IEmployeeService employeeService)
        {
            InitializeComponent();
            _loginRoleService = loginRoleService ?? throw new ArgumentNullException(nameof(loginRoleService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _name = name;

            this.FormClosed += (s, e) => CancelBtn_Click(s, e);
        }

        private async void AuthEmployerForm_Load(object sender, EventArgs e)
        {
            try
            {
                EmployerTxt.Text = _name;
                string[] roles = ["Admin", "User"];
                foreach (var role in roles)
                {
                    RoleCb.Items.Add(role);
                }
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
                if (string.IsNullOrWhiteSpace(LoginTxt.Text))
                    throw new ArgumentException("Login is required");
                if (string.IsNullOrWhiteSpace(PasswordTxt.Text))
                    throw new ArgumentException("Password is required");
                if (RoleCb.SelectedItem == null)
                    throw new ArgumentException("Role is required");

                var loginRoleDto = new LoginRoleDto
                {
                    Login = LoginTxt.Text,
                    Password = PasswordTxt.Text,
                    Role = RoleCb.SelectedItem.ToString()
                };

                CreatedLoginId = await _loginRoleService.AddAsync(loginRoleDto);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving credentials: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
