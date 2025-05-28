using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class OperationsCharts : Form
    {
        private readonly IOperationService operationService;
        public OperationsCharts(IOperationService operationService)
        {
            InitializeComponent();

            this.operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
        }

        private async void OperationsCharts_Load(object sender, EventArgs e)
        {
            var operations = (await operationService.GetAllWithDetailsAsync()).ToList();
            if (operations.Count == 0)
            {
                MessageBox.Show("Нет операций для отображения.");
                return;
            }

            // 📊 Соотношение IN / OUT
            var inCount = operations.Count(o => o.OperationType == "IN");
            var outCount = operations.Count(o => o.OperationType == "OUT");

            pieChart1.Series = new ISeries[]
            {
                new PieSeries<int> { Values = new[] { inCount }, Name = "IN" },
                new PieSeries<int> { Values = new[] { outCount }, Name = "OUT" }
            };

            // 📈 График поставщиков
            var supplierGroups = operations
                .Where(o => o.OperationType == "IN" && !string.IsNullOrWhiteSpace(o.SupplierName))
                .GroupBy(o => o.SupplierName)
                .Select(g => new
                {
                    Supplier = g.Key,
                    Quantity = g.Sum(o => o.QuantityInOperation)
                })
                .ToList();

            cartesianChart1.Series = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Поставки",
                    Values = supplierGroups.Select(g => g.Quantity).ToArray()
                }
            };

            cartesianChart1.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = supplierGroups.Select(g => g.Supplier).ToArray(),
                    LabelsRotation = 15
                }
            };

            cartesianChart1.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Количество"
                }
            };
        }
    }
}