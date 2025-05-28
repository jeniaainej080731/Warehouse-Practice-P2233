using System.Text.RegularExpressions;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class EditSupplierForm : Form
    {
        private readonly ISupplierService supplierService;
        private readonly SupplierDto supplierDto;
        private bool isLoaded = false;

        public EditSupplierForm(ISupplierService supplierService, SupplierDto supplierDto)
        {
            InitializeComponent();

            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.supplierDto = supplierDto ?? throw new ArgumentNullException(nameof(supplierDto));

            this.Load += EditSupplierForm_Load;
        }

        private void EditSupplierForm_Load(object sender, EventArgs e)
        {
            NameTxt.Text = supplierDto.SupplierName;
            AddressTxt.Text = supplierDto.SupplierAddress;

            var parts = (supplierDto.ContactInfo ?? "")
                            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                var kv = part.Split(new[] { ':' }, 2);
                if (kv.Length != 2) continue;
                var key = kv[0].Trim().ToLower();
                var val = kv[1].Trim();
                if (key == "phone") PhoneTxt.Text = val;
                if (key == "email") EmailTxt.Text = val;
            }

            photoPathLbl.Text = supplierDto.PhotoPath ?? "";

            isLoaded = true;
        }

        private void ChoosePhotoBtn_Click(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            try
            {
                openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog1.Title = "Выберите новое фото поставщика";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog1.FileName;

                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string relFolder = Path.Combine("Resources", "Images", "Suppliers");
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

                    supplierDto.PhotoPath = Path.Combine(relFolder, fileName).Replace("\\", "/");
                    photoPathLbl.Text = supplierDto.PhotoPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе фото: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            try
            {
                string name = NameTxt.Text.Trim();
                string address = AddressTxt.Text.Trim();
                string phone = PhoneTxt.Text.Trim();
                string email = EmailTxt.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("Имя и адрес — обязательные поля.",
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
                    MessageBox.Show("Введите корректный e‑mail адрес.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                supplierDto.SupplierName = name;
                supplierDto.SupplierAddress = address;
                supplierDto.ContactInfo = $"Phone: +{phoneClean}, Email: {email}";

                await supplierService.UpdateAsync(supplierDto);
                MessageBox.Show("Поставщик успешно обновлён.",
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
            this.Close();
        }
    }
}
