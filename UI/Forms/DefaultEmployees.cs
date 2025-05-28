using System.Data;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class DefaultEmployees : Form
    {
        private bool isLoaded = false;
        private List<EmployeeDto> allEmployers = new();

        private readonly IEmployeeService employeeService;
        public DefaultEmployees(IEmployeeService employeeService)
        {
            InitializeComponent();

            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));

            InitializeDataGridColumns();
            LoadData();
        }

        private async Task LoadData()
        {
            await LoadEmployers();
        }

        private void UpdateProgress(int current, int total)
        {
            if (total == 0) return;

            int percent = (int)((current / (float)total) * 100);
            progressBar3.Value = percent;
            label1.Text = $"Загрузка: {percent}% ({current} из {total})";
        }

        private async Task LoadEmployers()
        {
            try
            {
                ProgressPanel.Visible = true;
                progressBar3.Value = 0;
                label1.Text = "Loading products...";

                allEmployers = new List<EmployeeDto>();
                var productsFromDb = await employeeService.GetAllAsync();
                int total = productsFromDb.Count();
                int count = 0;

                foreach (var product in productsFromDb)
                {
                    allEmployers.Add(product);
                    count++;
                    UpdateProgress(count, total);
                    await Task.Delay(10);
                }

                EmployersDataGridView.DataSource = allEmployers.ToList();
                isLoaded = true;
                label1.Text = "Products loaded successfully";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке продуктов: {ex.Message}");
                label1.Text = "Ошибка загрузки";
            }
            finally
            {
                await Task.Delay(500);
                ProgressPanel.Visible = false;
            }
        }

        private async void InitializeDataGridColumns()
        {
            EmployersDataGridView.AutoGenerateColumns = false;
            EmployersDataGridView.RowHeadersVisible = true;
            EmployersDataGridView.RowHeadersWidth = 30;
            EmployersDataGridView.Columns.Clear();

            EmployersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmployeeId",
                HeaderText = "Employee ID",
                DataPropertyName = "EmployeeId",
                Visible = false
            });
            EmployersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "Employer",
                DataPropertyName = "FullName",
                Visible = true
            });
            EmployersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Visible = true
            });
            EmployersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Phone",
                DataPropertyName = "PhoneNumber",
                Visible = true
            });
            EmployersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Role",
                HeaderText = "Role",
                DataPropertyName = "Role",
                Visible = false
            });
        }

        private void FiltersImageButton_Click(object sender, EventArgs e)
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

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltersImageButton_Click(sender, e);
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            string searchValue = SearchTxt.Text.ToLower();
            IEnumerable<EmployeeDto> filtered = allEmployers;

            if (!string.IsNullOrEmpty(searchValue))
            {
                filtered = filtered.Where(e => e.FullName?.ToLower().Contains(searchValue) == true);
            }

            EmployersDataGridView.DataSource = filtered.ToList();
        }

        private void EmployersDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
