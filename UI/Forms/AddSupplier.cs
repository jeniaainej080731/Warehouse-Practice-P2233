using System.Text.RegularExpressions;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AddSupplier : Form
    {
        private readonly ISupplierService supplierService;
        public AddSupplier(ISupplierService supplierService)
        {
            InitializeComponent();

            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string supplierName = NameTxt.Text.Trim();
                string supplierAddress = AddressTxt.Text.Trim();
                string phoneNumber = PhoneTxt.Text.Trim();
                string email = EmailTxt.Text.Trim();
                string? photoPath = string.IsNullOrWhiteSpace(photoPathLbl.Text)
                                            ? string.Empty
                                            : photoPathLbl.Text.Trim();

                if (string.IsNullOrWhiteSpace(supplierName) ||
                    string.IsNullOrWhiteSpace(supplierAddress))
                {
                    MessageBox.Show("Имя и адрес — обязательные поля.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phoneClean = Regex.Replace(phoneNumber, @"\D", "");
                if (!string.IsNullOrEmpty(phoneNumber) &&
                    !Regex.IsMatch(phoneClean, @"^\d{5,15}$"))
                {
                    MessageBox.Show("Введите корректный номер телефона (5–15 цифр).",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(email) &&
                    !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Введите корректный e‑mail адрес.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(photoPath) &&
                    !File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, photoPath)))
                {
                    MessageBox.Show("Выбранное фото не найдено.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newSupplier = new SupplierDto
                {
                    SupplierName = supplierName,
                    SupplierAddress = supplierAddress,
                    ContactInfo = $"Phone: +{phoneClean}, Email: {email}",
                    PhotoPath = photoPath
                };

                await supplierService.AddAsync(newSupplier);
                MessageBox.Show("Поставщик успешно добавлен.",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении поставщика:\n{ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChoosePhotoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog1.Title = "Выберите изображение поставщика";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog1.FileName;

                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string relativeFolder = @"Resources\Images\Suppliers";
                    string destinationFolder = Path.Combine(projectDirectory, relativeFolder);

                    if (!Directory.Exists(destinationFolder))
                        Directory.CreateDirectory(destinationFolder);

                    string fileName = Path.GetFileName(selectedPath);
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    if (File.Exists(destinationPath))
                    {
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                        string ext = Path.GetExtension(fileName);
                        fileName = $"{nameWithoutExt}_{Guid.NewGuid().ToString("N").Substring(0, 8)}{ext}";
                        destinationPath = Path.Combine(destinationFolder, fileName);
                    }

                    File.Copy(selectedPath, destinationPath);

                    photoPathLbl.Text = Path.Combine("Resources/Images/Suppliers", fileName).Replace("\\", "/");
                }
                else
                {
                    photoPathLbl.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при выборе изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
