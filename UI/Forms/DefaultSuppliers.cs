using System.Data;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class DefaultSuppliers : Form
    {
        private bool isLoaded = false;
        private List<SupplierDto> allSuppliers = new();

        private readonly ISupplierService supplierService;

        public DefaultSuppliers(ISupplierService supplierService)
        {
            InitializeComponent();

            this.supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));

            InitializeDataGridColumns();
            LoadData();
        }

        private async Task LoadData()
        {
            await LoadSuppliers();
        }

        private void UpdateProgress(int current, int total)
        {
            if (total == 0) return;

            int percent = (int)((current / (float)total) * 100);
            progressBar2.Value = percent;
            ProgressLbl_Suppliers.Text = $"Загрузка: {percent}% ({current} из {total})";
        }

        private async Task LoadSuppliers()
        {
            try
            {
                ProgressPanel.Visible = true;
                progressBar2.Value = 0;
                ProgressLbl_Suppliers.Text = "Loading products...";

                allSuppliers = new List<SupplierDto>();
                var productsFromDb = await supplierService.GetAllAsync();
                int total = productsFromDb.Count();
                int count = 0;

                foreach (var product in productsFromDb)
                {
                    allSuppliers.Add(product);
                    count++;
                    UpdateProgress(count, total);
                    await Task.Delay(10);
                }

                SuppliersDataGridView.DataSource = allSuppliers.ToList();
                isLoaded = true;
                ProgressLbl_Suppliers.Text = "Products loaded successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке продуктов: {ex.Message}");
                ProgressLbl_Suppliers.Text = "Ошибка загрузки";
            }
            finally
            {
                await Task.Delay(500);
                ProgressPanel.Visible = false;
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterBtn_Click(sender, e);
        }

        private void FilterBtn_Click(object sender, EventArgs e)
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

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            string searchValue = SearchTxt.Text.ToLower();
            IEnumerable<SupplierDto> filtered = allSuppliers;

            if (!string.IsNullOrEmpty(searchValue))
            {
                filtered = filtered.Where(s => s.SupplierName?.ToLower().Contains(searchValue) == true);
            }

            SuppliersDataGridView.DataSource = filtered.ToList();
        }

        private async void InitializeDataGridColumns()
        {
            SuppliersDataGridView.AutoGenerateColumns = false;
            SuppliersDataGridView.RowHeadersVisible = true;
            SuppliersDataGridView.RowHeadersWidth = 30;
            SuppliersDataGridView.Columns.Clear();

            SuppliersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SupplierId",
                HeaderText = "Supplier ID",
                DataPropertyName = "SupplierId",
                Visible = false
            });
            SuppliersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SupplierName",
                HeaderText = "Supplier",
                DataPropertyName = "SupplierName",
                Visible = true
            });
            SuppliersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContactInfo",
                HeaderText = "Contacts",
                DataPropertyName = "ContactInfo",
                Visible = true
            });
            SuppliersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SupplierAddress",
                HeaderText = "Address",
                DataPropertyName = "SupplierAddress",
                Visible = true
            });
        }

        private void SuppliersDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void ExitFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
