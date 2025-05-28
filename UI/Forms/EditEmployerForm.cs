using System.Text.RegularExpressions;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class EditEmployerForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeDto _employerDto;
        private bool isLoaded = false;

        public EditEmployerForm(IEmployeeService employeeService, EmployeeDto employeeDto)
        {
            InitializeComponent();

            this._employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _employerDto = employeeDto ?? throw new ArgumentNullException(nameof(employeeDto));
        }

        private void EditEmployerForm_Load(object sender, EventArgs e)
        {
            NameTxt.Text = _employerDto.FullName;
            RoleTxt.Text = _employerDto.Role;
            PhoneTxt.Text = _employerDto.PhoneNumber;
            EmailTxt.Text = _employerDto.Email;

            photoPathLbl.Text = _employerDto.PhotoPath ?? "";
            isLoaded = true;
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            try
            {
                string name = NameTxt.Text.Trim();
                string role = RoleTxt.Text.Trim();
                string phone = PhoneTxt.Text.Trim();
                string email = EmailTxt.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("Имя, фамилия и должность — обязательные поля.",
                                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phoneClean = Regex.Replace(phone, @"\D", "");
                if (!string.IsNullOrEmpty(phone) &&
                    !Regex.IsMatch(phoneClean, @"^\d{5,15}$"))
                {
                    MessageBox.Show("Введите корректный номер телефона (5–15 цифр).",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(email) &&
                    !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Введите корректный e-mail адрес.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _employerDto.FullName = name;
                _employerDto.Role = role;
                _employerDto.PhoneNumber = phone;
                _employerDto.Email = email;

                await _employeeService.UpdateAsync(_employerDto);

                MessageBox.Show("Сотрудник успешно обновлён.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите отменить изменения? Все несохранённые данные будут потеряны.",
                "Отмена",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ChoosePhotoBtn_Click(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog1.Title = "Выберите новое фото сотрудника";

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
                    _employerDto.PhotoPath = Path.Combine(relFolder, fileName).Replace("\\", "/");
                    photoPathLbl.Text = _employerDto.PhotoPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе фото: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
