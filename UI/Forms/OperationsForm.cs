using QuestPDF.Fluent;
using System.Diagnostics;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class OperationsForm : Form
    {
        private bool isCollapsed = false;
        private bool isLoaded = false;
        private List<OperationDto> allOperations = new();

        private readonly IOperationService operationService;
        private readonly IProductService productService;
        private readonly IEmployeeService employeeService;
        private readonly ISupplierService supplierService;
        private readonly IDeletedProductService deletedProductService;

        public OperationsForm(IOperationService operationService, IProductService productService, IEmployeeService employeeService, ISupplierService supplierService, IDeletedProductService deletedProductService)
        {
            InitializeComponent();

            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.deletedProductService = deletedProductService ?? throw new ArgumentNullException(nameof(deletedProductService));

            InitializeDataGridColumns();
            LoadData();
        }

        private async Task LoadData()
        {
            await LoadOperations();
        }

        private async void InitializeDataGridColumns()
        {
            OperationsDataGridView.AutoGenerateColumns = false;
            OperationsDataGridView.RowHeadersVisible = true;
            OperationsDataGridView.RowHeadersWidth = 30;
            OperationsDataGridView.Columns.Clear();

            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OperationId",
                HeaderText = "Operation Id",
                DataPropertyName = "OperationId",
                Visible = false
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OperationType",
                HeaderText = "Operation",
                DataPropertyName = "OperationType",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QuantityInOperation",
                HeaderText = "Quantity",
                DataPropertyName = "QuantityInOperation",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OperationDate",
                HeaderText = "Date",
                DataPropertyName = "OperationDate",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Product",
                DataPropertyName = "ProductName",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductId",
                HeaderText = "Product Id",
                DataPropertyName = "ProductId",
                Visible = false
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SupplierName",
                HeaderText = "Supplier",
                DataPropertyName = "SupplierName",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SupplierId",
                HeaderText = "Supplier Id",
                DataPropertyName = "SupplierId",
                Visible = false
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmployeeName",
                HeaderText = "Performed by",
                DataPropertyName = "EmployeeName",
                Visible = true
            });
            OperationsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmployeeId",
                HeaderText = "Employee Id",
                DataPropertyName = "EmployeeId",
                Visible = false
            });
        }

        private void UpdateProgress(int current, int total)
        {
            if (total == 0) return;

            int percent = (int)((current / (float)total) * 100);
            progressBar2.Value = percent;
            ProgressLblOperations.Text = $"Loading: {percent}% ({current} of {total})";
        }

        private async Task LoadOperations()
        {
            try
            {
                ProgressPanel.Visible = true;
                ProgressLblOperations.Text = "Loading operations...";
                progressBar2.Value = 0;

                allOperations = new List<OperationDto>();
                var operationsFromDb = (await operationService.GetAllWithDetailsAsync())
                    .OrderByDescending(o => o.OperationDate)
                    .ToList();
                int total = operationsFromDb.Count();
                int count = 0;

                foreach (var operation in operationsFromDb)
                {
                    allOperations.Add(operation);
                    count++;
                    UpdateProgress(count, total);
                    await Task.Delay(10);
                }

                OperationsDataGridView.DataSource = operationsFromDb.ToList();
                ProgressLblOperations.Text = "Loading completed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading operations: " + ex.Message);
                ProgressLblOperations.Text = "Error loading operations.";
            }
            finally
            {
                ProgressPanel.Visible = false;
                isLoaded = true;
            }
        }

        private void FiletersBtn_Click(object sender, EventArgs e)
        {
            if (FiltersPanel.Visible)
            {
                FiltersPanel.Visible = false;
            }
            else
            {
                FiltersPanel.Visible = true;
            }
        }

        private void LeftSideCollapse_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                LeftSidePanel.Width = 169;
                ShowReportBtn.Text = "Report";
                ChartBtn.Text = "Charts";
                ExitFormBtn.Visible = true;
                isCollapsed = false;
            }
            else
            {
                LeftSidePanel.Width = 55;
                ShowReportBtn.Text = string.Empty;
                ChartBtn.Text = string.Empty;
                ExitFormBtn.Visible = false;
                isCollapsed = true;
            }
        }

        private void OperationsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                grid.RowHeadersWidth,
                e.RowBounds.Height);

            e.Graphics.DrawString(
                rowIdx,
                this.Font,
                SystemBrushes.ControlText,
                headerBounds,
                centerFormat);
        }

        private async void ShowReportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

                // 1. Получаем все операции
                var operations = (await operationService.GetAllWithDetailsAsync()).ToList();
                if (operations.Count == 0)
                {
                    MessageBox.Show("Нет данных для создания отчёта.", "Отчёт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Собираем цены активных продуктов (те, что ещё в таблице Products)
                var productIds = operations.Select(o => o.ProductId).Distinct();
                var productPrices = new Dictionary<int, decimal>();
                var existingProductIds = new HashSet<int>();

                foreach (var id in productIds)
                {
                    var product = await productService.GetByIdAsync(id);
                    if (product != null)
                    {
                        existingProductIds.Add(id);
                        productPrices[id] = product.ProductPrice;
                    }
                }

                // 3. Цены удалённых продуктов для OUT (как раньше, без фильтрации)
                var deletedProductPrices = new Dictionary<int, decimal>();
                foreach (var op in operations.Where(o => o.OperationType == "OUT"))
                {
                    var deleted = await deletedProductService.GetByProductId(op.ProductId);
                    deletedProductPrices[op.ProductId] = deleted?.ProductPrice ?? 0m;
                }

                // 4. Считаем итоги
                //   IN: только по существующим продуктам
                decimal inTotal = operations
                    .Where(o => o.OperationType == "IN" && existingProductIds.Contains(o.ProductId))
                    .Sum(o => productPrices[o.ProductId] * o.QuantityInOperation);

                int inCount = operations
                    .Count(o => o.OperationType == "IN" && existingProductIds.Contains(o.ProductId));

                //   OUT: без изменений
                decimal outTotal = operations
                    .Where(o => o.OperationType == "OUT")
                    .Sum(o => (deletedProductPrices.TryGetValue(o.ProductId, out var price) ? price : 0m)
                               * o.QuantityInOperation);

                int outCount = operations.Count(o => o.OperationType == "OUT");

                // 5. Создаём отчёт с новыми параметрами
                var report = new Reports.OperationsReport(
                    operations,
                    productPrices,
                    deletedProductPrices,
                    inCount,
                    outCount,
                    inTotal,
                    outTotal
                    );

                var filePath = Path.Combine(
                    Path.GetTempPath(),
                    $"OperationsReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                report.GeneratePdf(filePath);

                MessageBox.Show($"Отчёт успешно сгенерирован и сохранён по пути: \n{filePath}",
                                "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (MessageBox.Show("Хотите открыть отчёт?", "Report",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчёта: {ex.InnerException?.Message ?? ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (!isLoaded || allOperations == null) return;

            string search = SearchTxt.Text.Trim().ToLower();
            var filtered = allOperations.AsEnumerable();

            // Фильтрация по тексту
            if (!string.IsNullOrEmpty(search))
            {
                if (ProductRb.Checked)
                {
                    filtered = filtered.Where(o => o.ProductName?.ToLower().Contains(search) == true);
                }
                else if (SupplierRb.Checked)
                {
                    filtered = filtered.Where(o => o.SupplierName?.ToLower().Contains(search) == true);
                }
                else if (EmployeeRb.Checked)
                {
                    filtered = filtered.Where(o => o.EmployeeName?.ToLower().Contains(search) == true);
                }
            }

            // Фильтрация по типу операции
            bool filterIn = InCb.Checked;
            bool filterOut = OutCb.Checked;

            if (filterIn && !filterOut)
                filtered = filtered.Where(o => o.OperationType == "IN");
            else if (filterOut && !filterIn)
                filtered = filtered.Where(o => o.OperationType == "OUT");
            // если оба выключены — показываем всё

            OperationsDataGridView.DataSource = filtered.ToList();
        }


        private void ExitFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiletersBtn_Click(sender, e);
        }

        private void InRb_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void OutRb_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ChartBtn_Click(object sender, EventArgs e)
        {
            OperationsCharts operationsCharts = new OperationsCharts(operationService);
            operationsCharts.Show();
        }
    }
}
