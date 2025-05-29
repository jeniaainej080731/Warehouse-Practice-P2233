using Microsoft.IdentityModel.Tokens;
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
        private readonly IOperationService _operationService;
        private readonly IAuditService _auditService;
        private readonly IProductService _productService;
        private readonly int _employeeId;
        private bool _isSidePanelCollapsed = false;

        private BindingList<InventoryRow> _inventoryRows;
        private List<ProductDto> _allProducts;

        public AuditsForm(
            int employeeId,
            IOperationService operationService,
            IAuditService auditService,
            IProductService productService)
        {
            InitializeComponent();

            _employeeId = employeeId;
            _operationService = operationService ?? throw new ArgumentNullException(nameof(operationService));
            _auditService = auditService ?? throw new ArgumentNullException(nameof(auditService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));

            InitializeDataGrid();
            SetupEventHandlers();
        }

        private void InitializeDataGrid()
        {
            AuditsDataGridView.AutoGenerateColumns = false;
            AuditsDataGridView.RowHeadersVisible = true;
            AuditsDataGridView.AllowUserToAddRows = false;
            AuditsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AuditsDataGridView.Columns.Clear();

            AuditsDataGridView.RowPostPaint += (sender, e) =>
            {
                var grid = (DataGridView)sender;
                var rowIdx = (e.RowIndex + 1).ToString();
                var centerFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var headerBounds = new Rectangle(
                    e.RowBounds.Left,
                    e.RowBounds.Top,
                    grid.RowHeadersWidth,
                    e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            };

            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Product ID",
                    DataPropertyName = nameof(InventoryRow.ProductId),
                    ReadOnly = true,
                    Visible = false,
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Product Name",
                    DataPropertyName = nameof(InventoryRow.ProductName),
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Expected Quantity",
                    DataPropertyName = nameof(InventoryRow.ExpectedQuantity),
                    ReadOnly = true,
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                },
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Checked Quantity",
                    DataPropertyName = nameof(InventoryRow.CheckedQuantity),
                    ReadOnly = false,
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                },
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Difference",
                    DataPropertyName = nameof(InventoryRow.Difference),
                    ReadOnly = true,
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "N0",
                        ForeColor = Color.Black,
                        BackColor = Color.LightGray
                    }
                }
            };
            foreach (var col in columns) AuditsDataGridView.Columns.Add(col);

            AuditsDataGridView.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    var row = (InventoryRow)AuditsDataGridView.Rows[e.RowIndex].DataBoundItem;
                    if (row.Difference < 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                    else if (row.Difference > 0)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                }
            };

            AuditsDataGridView.CellEndEdit += (sender, e) =>
            {
                if (e.ColumnIndex == 3)
                {
                    var row = (InventoryRow)AuditsDataGridView.Rows[e.RowIndex].DataBoundItem;
                    row.RecalculateDifference();
                    AuditsDataGridView.InvalidateRow(e.RowIndex);
                }
            };
        }

        private void SetupEventHandlers()
        {
            Load += async (s, e) => await LoadInventoryDataAsync();
            btnMakeAudit.Click += async (s, e) => await SaveAuditAsync();
            btnMakeReport.Click += ShowAuditReport;
            btnToggleSidePanel.Click += ToggleSidePanel;
            btnExit.Click += (s, e) => Close();
            txtSearch.TextChanged += FilterProducts;
        }

        private async Task LoadInventoryDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _allProducts = (await _productService.GetAllAsync()).ToList();
                var operations = (await _operationService.GetAllWithDetailsAsync()).ToList();

                var validIds = new HashSet<int>(_allProducts.Select(p => p.ProductId));
                var opsFiltered = operations.Where(o => validIds.Contains(o.ProductId)).ToList();

                var inventory = opsFiltered
                    .GroupBy(o => new { o.ProductId, o.ProductName })
                    .Select(g => new InventoryRow
                    {
                        ProductId = g.Key.ProductId,
                        ProductName = g.Key.ProductName,
                        ExpectedQuantity = g.Where(o => o.OperationType == "IN").Sum(o => o.QuantityInOperation)
                                         - g.Where(o => o.OperationType == "OUT").Sum(o => o.QuantityInOperation),
                        CheckedQuantity = 0
                    })
                    .ToList();

                var withoutOps = _allProducts
                    .Where(p => !inventory.Any(i => i.ProductId == p.ProductId))
                    .Select(p => new InventoryRow
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        ExpectedQuantity = p.ProductQuantity,
                        CheckedQuantity = 0
                    });

                inventory.AddRange(withoutOps);
                _inventoryRows = new BindingList<InventoryRow>(inventory.OrderBy(x => x.ProductName).ToList());
                AuditsDataGridView.DataSource = _inventoryRows;

                lblStatus.Text = $"Loaded {_inventoryRows.Count} products for inventory";
                statusStrip1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task SaveAuditAsync()
        {
            AuditsDataGridView.EndEdit();
            AuditsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (_inventoryRows == null || _inventoryRows.Count == 0)
            {
                MessageBox.Show("No inventory data to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                int savedCount = 0;
                var errors = new List<string>();

                foreach (var row in _inventoryRows.Where(r => r.CheckedQuantity != 0))
                {
                    try
                    {
                        var dto = new AuditDto
                        {
                            ProductId = row.ProductId,
                            EmployeeId = _employeeId,
                            CheckedQuantity = row.CheckedQuantity,
                            InventoryAuditComments = $"Audit difference: {row.Difference}",
                            AuditDate = DateTime.Now
                        };
                        await _auditService.AddAsync(dto);
                        savedCount++;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Product {row.ProductName}: {ex.Message}");
                    }
                }

                MessageBox.Show($"Saved {savedCount} of {_inventoryRows.Count} audit records." +
                                (errors.Any() ? $"\nErrors:\n{string.Join("\n", errors.Take(5))}" : string.Empty),
                                "Audit Results",
                                MessageBoxButtons.OK,
                                savedCount > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (savedCount > 0)
                {
                    ShowAuditReport(this, EventArgs.Empty);
                    await LoadInventoryDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving audit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowAuditReport(object sender, EventArgs e)
        {
            if (_inventoryRows == null || !_inventoryRows.Any())
            {
                MessageBox.Show("No inventory data to report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var checkedItems = _inventoryRows.Count(r => r.CheckedQuantity != 0);
            var perfectMatches = _inventoryRows.Count(r => r.Difference == 0 && r.CheckedQuantity != 0);
            var shortages = _inventoryRows.Count(r => r.Difference < 0 && r.CheckedQuantity != 0);
            var overages = _inventoryRows.Count(r => r.Difference > 0 && r.CheckedQuantity != 0);
            var notChecked = _inventoryRows.Count(r => r.CheckedQuantity == 0);

            var totalShortage = _inventoryRows.Where(r => r.Difference < 0).Sum(r => Math.Abs(r.Difference));
            var totalOverage = _inventoryRows.Where(r => r.Difference > 0).Sum(r => r.Difference);

            string report = $@"Inventory Audit Report
------------------------
Total Products: {_inventoryRows.Count}
Checked Products: {checkedItems}
Not Checked: {notChecked}

Matches: {perfectMatches}
Shortages: {shortages} (Total: {totalShortage})
Overages: {overages} (Total: {totalOverage})

Generated: {DateTime.Now:yyyy-MM-dd HH:mm}";

            MessageBox.Show(report, "Inventory Audit Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FilterProducts(object sender, EventArgs e)
        {
            if (_inventoryRows == null) return;

            var searchText = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                AuditsDataGridView.DataSource = _inventoryRows;
                return;
            }

            var filtered = _inventoryRows
                .Where(r => r.ProductName.ToLower().Contains(searchText) ||
                            r.ProductId.ToString().Contains(searchText))
                .ToList();

            AuditsDataGridView.DataSource = new BindingList<InventoryRow>(filtered);
        }

        private void ToggleSidePanel(object sender, EventArgs e)
        {
            if (_isSidePanelCollapsed)
            {
                panelLeft.Width = 200;
                btnMakeAudit.Text = "Save Audit";
                btnMakeReport.Text = "Generate Report";
                btnExit.Visible = true;
                _isSidePanelCollapsed = false;
            }
            else
            {
                panelLeft.Width = 60;
                btnMakeAudit.Text = string.Empty;
                btnMakeReport.Text = string.Empty;
                btnExit.Visible = false;
                _isSidePanelCollapsed = true;
            }
        }

        private class InventoryRow
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int ExpectedQuantity { get; set; }
            public int CheckedQuantity { get; set; }
            public int Difference { get; private set; }

            public void RecalculateDifference()
            {
                Difference = CheckedQuantity - ExpectedQuantity;
            }
        }
    }
}
