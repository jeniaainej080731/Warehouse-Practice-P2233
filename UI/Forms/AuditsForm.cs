using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class AuditsForm : Form
    {
        private readonly IOperationService _opService;
        private readonly IAuditService _auditService;
        private readonly int _employeeId;
        private bool isCollapsed = false;

        // Источник для грида
        private BindingList<InventoryRow> _rows;

        public AuditsForm(
            int employeeId,
            IOperationService opService,
            IAuditService auditService)
        {
            InitializeComponent();

            _employeeId = employeeId;
            _opService = opService ?? throw new ArgumentNullException(nameof(opService));
            _auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));

            // Настраиваем грид
            InitializeDataGrid();

            // События
            Load += AuditsForm_Load;
            MakeAuditBtn.Click += MakeAuditBtn_Click;
            MakeReportBtn.Click += MakeReportBtn_Click;
        }

        private void InitializeDataGrid()
        {
            var grid = AuditsDataGridView;
            grid.AutoGenerateColumns = false;
            grid.RowHeadersVisible = true;
            grid.Columns.Clear();

            // Товар
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product",
                DataPropertyName = nameof(InventoryRow.ProductName),
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            // Ожидается
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Expected",
                DataPropertyName = nameof(InventoryRow.Expected),
                ReadOnly = true,
                Width = 80
            });
            // Проверено (редактируемое)
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Checked",
                DataPropertyName = nameof(InventoryRow.Checked),
                ReadOnly = false,
                Width = 80
            });
            // Разница
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Diff",
                DataPropertyName = nameof(InventoryRow.Diff),
                ReadOnly = true,
                Width = 80
            });

            // При изменении ячейки в столбце Checked пересчитываем Diff
            grid.CellEndEdit += (s, e) =>
            {
                if (e.ColumnIndex == 2) // Checked column
                {
                    var row = _rows[e.RowIndex];
                    row.Diff = row.Expected - row.Checked;
                    grid.Refresh();
                }
            };
        }

        private async void AuditsForm_Load(object sender, EventArgs e)
        {
            // 1. Загрузить все операции
            var ops = (await _opService.GetAllWithDetailsAsync()).ToList();

            // 2. Сгруппировать по продукту и посчитать Expected = sum(IN) - sum(OUT)
            var list = ops
                .GroupBy(o => new { o.ProductId, o.ProductName })
                .Select(g => new InventoryRow
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.ProductName,
                    Expected = g.Where(o => o.OperationType == "IN").Sum(o => o.QuantityInOperation)
                                - g.Where(o => o.OperationType == "OUT").Sum(o => o.QuantityInOperation),
                    Checked = 0,
                    Diff = 0
                })
                .ToList();

            // 3. Привязать к BindingList и отобразить
            _rows = new BindingList<InventoryRow>(list);
            AuditsDataGridView.DataSource = _rows;
        }

        private async void MakeAuditBtn_Click(object sender, EventArgs e)
        {
            int saved = 0;

            foreach (var r in _rows)
            {
                try
                {
                    var dto = new AuditDto
                    {
                        ProductId = r.ProductId,
                        EmployeeId = _employeeId,
                        CheckedQuantity = r.Checked,
                        InventoryAuditComments = "",              // пустой комментарий
                        AuditDate = DateTime.Now
                    };
                    await _auditService.AddAsync(dto);
                    saved++;
                }
                catch
                {
                    // игнорируем ошибки по строкам
                }
            }

            MessageBox.Show($"{saved} из {_rows.Count} записей сохранены.",
                "Инвентаризация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MakeReportBtn_Click(object sender, EventArgs e)
        {
            // Для «галочки» просто выводим сводку по Diff
            int positive = _rows.Count(r => r.Diff >= 0);
            int negative = _rows.Count(r => r.Diff < 0);

            MessageBox.Show(
                $"Проверено товаров: {_rows.Count}\n" +
                $"В норме (>=0): {positive}\n" +
                $"Недостачи (<0): {negative}",
                "Отчёт инвентаризации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void AuditsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void LeftSideCollapse_Click(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                LeftSidePanel.Width = 169;
                MakeAuditBtn.Text = "Make Audition";
                MakeReportBtn.Text = "Make Report";
                ExitFormBtn.Visible = true;
                isCollapsed = false;
            }
            else
            {
                LeftSidePanel.Width = 55;
                MakeAuditBtn.Text = string.Empty;
                MakeAuditBtn.Text = string.Empty;
                ExitFormBtn.Visible = false;
                isCollapsed = true;
            }
        }

        private void ExitFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Примитивная модель строки для грида
        private class InventoryRow
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Expected { get; set; }
            public int Checked { get; set; }
            public int Diff { get; set; }
        }
    }
}
