using System.Diagnostics;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;
using Warehouse.UI.Reports;

namespace Warehouse.UI.Forms
{
    public partial class MakeInvoice : Form
    {
        private readonly int employeeId;

        private readonly IProductService productService;
        private readonly IReceiptService receiptService;
        private readonly IEmployeeService employeeService;
        private readonly ISupplierService supplierService;

        private ProductDto selectedProduct;
        private int selectedSupplier;

        private readonly string qrUrl = "https://github.com/jeniaainej080731";

        public MakeInvoice(int employeeId,
            IEmployeeService employeeService, IProductService productService, IReceiptService receiptService,
            ISupplierService supplierService)
        {
            InitializeComponent();

            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.receiptService = receiptService ?? throw new ArgumentNullException(nameof(receiptService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.employeeId = employeeId;

            this.FormClosed += (s, e) => CancelBtn_Click(s, e);
        }

        private async void MakeReceipt_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var suppliers = await supplierService.GetAllAsync();
                CustomerCb.DataSource = suppliers.ToList();
                CustomerCb.DisplayMember = "SupplierName";
                CustomerCb.ValueMember = "SupplierId";
                CustomerCb.SelectedIndex = 0;

                ProductsCb.DataSource = null;
                ProductsCb.DisplayMember = "ProductName";
                ProductsCb.ValueMember = "ProductId";
                ProductsCb.SelectedIndex = -1;

                ProductsLb.DataSource = null;
                ProductsLb.DisplayMember = "ProductName";
                ProductsLb.ValueMember = "ProductId";

                var employee = await employeeService.GetByIdAsync(employeeId);
                if (employee != null)
                {
                    EmployerTxt.Text = employee.FullName;
                }
                else
                {
                    EmployerTxt.Text = "Unknown Employee";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProductsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedProduct = (ProductDto)ProductsCb.SelectedItem;

                if (selectedProduct != null)
                {
                    QuantityNud.Value = selectedProduct.ProductQuantity;
                    PriceTxt.Text = $"{selectedProduct.ProductPrice * selectedProduct.ProductQuantity:C}";
                }
                else
                {
                    QuantityNud.Value = 0;
                    PriceTxt.Text = "0.00";
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Please select a valid product.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void QuantityNud_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int quantity = (int)QuantityNud.Value;
            //    if (selectedProduct != null)
            //    {
            //        await CheckQuantityInBase(selectedProduct);
            //        PriceTxt.Text = $"{selectedProduct.ProductPrice * quantity:C}";
            //    }
            //    else
            //    {
            //        PriceTxt.Text = "0.00";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error calculating price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private async Task CheckQuantityInBase(ProductDto product)
        {
            try
            {
                if (product == null)
                {
                    MessageBox.Show("Выберите товар для проверки количества.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (product != null)
                {
                    int availableQuantity = product.ProductQuantity;
                    if (availableQuantity <= 0)
                    {
                        MessageBox.Show("Товар отсутствует на складе.", "Недостаточно товара", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        QuantityNud.Value = 0;
                    }
                    else
                    {
                        QuantityNud.Maximum = availableQuantity;
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось получить информацию о товаре.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке количества товара: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MakeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

                // 1. Валидация ввода
                if (selectedSupplier == null)
                {
                    MessageBox.Show("Select supplier.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int quantity = (int)QuantityNud.Value;
                if (quantity <= 0)
                {
                    MessageBox.Show("Количество должно быть больше 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Сборка DTO
                var total = selectedProduct.ProductPrice * quantity;
                var receiptDto = new ReceiptDto
                {
                    CustomerName = CustomerCb.ToString().Trim(),
                    ReceiptDate = DateTime.Now,
                    EmployeeId = employeeId,
                    EmployeeName = EmployerTxt.Text,
                    ReceiptTotalAmount = total,
                    ProductId = selectedProduct.ProductId,
                    ProductName = selectedProduct.ProductName,
                    QuantityInReceipt = quantity,
                    PriceInReceipt = selectedProduct.ProductPrice
                };

                // 3. Сохранение в базу
                var saved = await receiptService.AddAsync(receiptDto);
                if (saved == null)
                {
                    MessageBox.Show("Не удалось сохранить чек.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Генерация PDF через QuestPDF
                // Предполагаем, что ваш класс ReceiptReport принимает один ReceiptDto
                // для заголовка и список ReceiptDto для деталей (в данном случае – один элемент)
                var details = new List<ReceiptDto> { saved };
                var lines = ProductsLb.Items
                    .Cast<ProductDto>()
                    .Select(p => (p.ProductName, p.ProductQuantity, p.ProductPrice));

                var report = new ReceiptReport(
                    customerName: CustomerCb.Text,
                    employeeName: EmployerTxt.Text,
                    date: DateTime.Now,
                    lines: lines,
                    qrUrl: qrUrl);

                var fileName = $"Receipt_{saved.ReceiptDate:yyyyMMdd}_{saved.ProductId}_{saved.QuantityInReceipt}.pdf";
                var pdfPath = Path.Combine(Path.GetTempPath(), fileName);

                report.GeneratePdf(pdfPath);

                // 5. Уведомление и открытие PDF
                MessageBox.Show($"Чек сохранён и PDF сгенерирован:\n{pdfPath}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Открытие PDF
                DialogResult result = MessageBox.Show(
                    "Чек успешно создан. Хотите открыть PDF-файл?",
                    "Открыть PDF",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = pdfPath,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                if (ex.InnerException != null)
                {
                    msg += ex.InnerException.Message;
                }

                MessageBox.Show($"Ошибка при создании чека: {msg}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите отменить создание чека?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void CustomerCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CustomerCb.SelectedIndex == 0) return;

                selectedSupplier = (int)CustomerCb.SelectedValue;

                var products = await productService.GetBySupplierAsync(selectedSupplier);

                ProductsCb.DataSource = products.ToList();
                ProductsCb.DisplayMember = "ProductName";
                ProductsCb.ValueMember = "ProductId";
                ProductsCb.SelectedIndex = -1;

                ProductsLb.DataSource = products.ToList();
                ProductsLb.DisplayMember = "ProductName";
                ProductsLb.ValueMember = "ProductId";
                ProductsLb.SelectedIndex = -1;
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Пожалуйста, выберите корректного покупателя.", "Неверный выбор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProductsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedProduct = (ProductDto)ProductsLb.SelectedItem;
                if (selectedProduct != null)
                {
                    QuantityNud.Value = selectedProduct.ProductQuantity;
                    PriceTxt.Text = $"{selectedProduct.ProductPrice * selectedProduct.ProductQuantity:C}";
                }
                else
                {
                    QuantityNud.Value = 0;
                    PriceTxt.Text = "0.00";
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Пожалуйста, выберите корректный товар.", "Неверный выбор", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
