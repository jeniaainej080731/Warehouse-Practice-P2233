using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class EmployeeDetailsForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private bool isAdmin;
        private EmployeeDto employeeDto;

        public EmployeeDetailsForm(bool isAdmin, EmployeeDto employeeDto, IEmployeeService employeeService)
        {
            InitializeComponent();

            this._employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.employeeDto = employeeDto ?? throw new ArgumentNullException(nameof(employeeDto));
            this.isAdmin = isAdmin;
        }

        private void EmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (isAdmin)
                {
                    DeleteBtn.Visible = true;
                    EditBtn.Visible = true;
                }
                else
                {
                    DeleteBtn.Visible = false;
                    EditBtn.Visible = false;
                }

                string employeeName = string.IsNullOrWhiteSpace(employeeDto.FullName)
                    ? "—"
                    : employeeDto.FullName;
                string employeePosition = string.IsNullOrWhiteSpace(employeeDto.Role)
                    ? "—"
                    : employeeDto.Role;
                string employeePhone = string.IsNullOrWhiteSpace(employeeDto.PhoneNumber)
                    ? "—"
                    : employeeDto.PhoneNumber;
                string employeeEmail = string.IsNullOrWhiteSpace(employeeDto.Email)
                    ? "—"
                    : employeeDto.Email;

                InfoTxt.Text = $"{employeeName}\r\n{employeePosition}\r\n{employeePhone}\r\n{employeeEmail}";

                if (!string.IsNullOrWhiteSpace(employeeDto.PhotoPath) && File.Exists(employeeDto.PhotoPath))
                {
                    var image = Image.FromFile(employeeDto.PhotoPath);
                    pictureBox1.Image = image;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.plug;
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while loading employee data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _employeeService.DeleteAsync(employeeDto.EmployeeId);
                    MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditEmployerForm editEmployerForm = new EditEmployerForm(_employeeService, employeeDto);
            editEmployerForm.ShowDialog();
            this.Close();
        }
    }
}
