using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class SupplierDetailsForm : Form
    {
        private readonly ISupplierService supplierService;
        private readonly SupplierDto supplierDto;
        private bool isAdmin;
        public SupplierDetailsForm(bool isAdmin, SupplierDto supplierDto, ISupplierService supplierService)
        {
            InitializeComponent();

            this.isAdmin = isAdmin;
            this.supplierDto = supplierDto;
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
        }

        private void SupplierDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isAdmin)
                {
                    DeleteBtn.Visible = false;
                }

                string supplierName = string.IsNullOrWhiteSpace(supplierDto.SupplierName)
                    ? "—"
                    : supplierDto.SupplierName;

                string supplierAddress = string.IsNullOrWhiteSpace(supplierDto.SupplierAddress)
                    ? "—"
                    : supplierDto.SupplierAddress;

                string supplierContacts = string.IsNullOrWhiteSpace(supplierDto.ContactInfo)
                    ? "—"
                    : supplierDto.ContactInfo;

                InfoTxt.Text = $"{supplierName}\r\n{supplierAddress}\r\n{supplierContacts}";

                if (!string.IsNullOrWhiteSpace(supplierDto.PhotoPath) && File.Exists(supplierDto.PhotoPath))
                {
                    var image = Image.FromFile(supplierDto.PhotoPath);
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
                    $"Произошла ошибка при загрузке данных поставщика: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditSupplierForm editSupplierForm = new EditSupplierForm(supplierService, supplierDto);
            editSupplierForm.ShowDialog();
            this.Close();
        }

        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Вы уверены, что хотите удалить этого поставщика?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    await supplierService.DeleteAsync(supplierDto.SupplierId);
                    MessageBox.Show("Поставщик успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Произошла ошибка при удалении поставщика: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
