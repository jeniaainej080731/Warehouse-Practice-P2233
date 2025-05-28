using System.Data;
using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private List<EmployeeDto> _employees;
        private List<EmployeeDto> _filteredEmployees;
        private bool isLoaded = false;
        private bool isAdmin;

        public EmployeesForm(bool isAdmin, IEmployeeService employeeService)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this._employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));

        }

        private async void EmployeesForm_Load(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                AddBtn.Visible = false;
            }

            _employees = (await _employeeService.GetAllAsync()).ToList();
            _filteredEmployees = new List<EmployeeDto>(_employees);
            RenderEmployeeCards(_filteredEmployees);
            isLoaded = true;
        }

        private async void RenderEmployeeCards(List<EmployeeDto> employeesToRender)
        {
            // Очистка и Disposing
            foreach (Control c in MainPanel.Controls)
            {
                if (c is PictureBox pb && pb.Image != null)
                    pb.Image.Dispose();
                c.Dispose();
            }
            MainPanel.Controls.Clear();

            int cardWidth = EmployeeCard.Width;
            int cardHeight = EmployeeCard.Height;
            int spacing = 20;
            int panelWidth = MainPanel.ClientSize.Width;

            int cardsPerRow = Math.Max(1, (panelWidth + spacing) / (cardWidth + spacing));
            int totalContentWidth = cardsPerRow * cardWidth + (cardsPerRow - 1) * spacing;
            int leftMargin = Math.Max(0, (panelWidth - totalContentWidth) / 2);
            int topMargin = 10;

            for (int i = 0; i < employeesToRender.Count; i++)
            {
                var emp = employeesToRender[i];
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                var newCard = new Panel
                {
                    Width = cardWidth,
                    Height = cardHeight,
                    BackColor = EmployeeCard.BackColor,
                    BorderStyle = EmployeeCard.BorderStyle,
                    Location = new Point(
                        leftMargin + col * (cardWidth + spacing),
                        topMargin + row * (cardHeight + spacing))
                };

                // PictureBox
                var pictureBox = new PictureBox
                {
                    Size = pictureBox3.Size,
                    Location = pictureBox3.Location,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = await LoadImage(emp.PhotoPath)
                };
                newCard.Controls.Add(pictureBox);

                // Info panel
                var infoPanel = new Panel
                {
                    Location = InfoPanel.Location,
                    Size = InfoPanel.Size,
                    BackColor = InfoPanel.BackColor
                };

                // Full name
                var nameLbl = new Label
                {
                    AutoSize = true,
                    MaximumSize = new Size(infoPanel.Width - 10, 0),
                    Text = emp.FullName,
                    Font = FullNameLbl.Font,
                    ForeColor = FullNameLbl.ForeColor,
                    Location = FullNameLbl.Location
                };
                infoPanel.Controls.Add(nameLbl);

                // RoleLbl
                var roleLbl = new Label
                {
                    AutoSize = true,
                    MaximumSize = new Size(infoPanel.Width - 10, 0),
                    Text = emp.Role,
                    Font = RoleLbl.Font,
                    ForeColor = RoleLbl.ForeColor,
                    Location = RoleLbl.Location
                };
                infoPanel.Controls.Add(roleLbl);

                // Show more
                var showMoreLbl = new Label
                {
                    AutoSize = true,
                    Text = "Show More",
                    Font = ShowMoreLbl.Font,
                    ForeColor = ShowMoreLbl.ForeColor,
                    Location = ShowMoreLbl.Location,
                    Cursor = Cursors.Hand
                };
                showMoreLbl.Click += async (s, ev) =>
                {
                    var detailsForm = new EmployeeDetailsForm(isAdmin, emp, _employeeService);
                    detailsForm.ShowDialog();
                    // Обновление после закрытия
                    _employees = (await _employeeService.GetAllAsync()).ToList();
                    _filteredEmployees = new List<EmployeeDto>(_employees);
                    RenderEmployeeCards(_filteredEmployees);
                };
                infoPanel.Controls.Add(showMoreLbl);

                newCard.Controls.Add(infoPanel);
                MainPanel.Controls.Add(newCard);
            }
        }

        private async Task<Image> LoadImage(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    if (File.Exists(fullPath))
                        return Image.FromFile(fullPath);
                }
            }
            catch { }
            return Properties.Resources.plug;
        }

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            if (_filteredEmployees?.Any() == true)
                RenderEmployeeCards(_filteredEmployees);
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            string searchValue = SearchTxt.Text.ToLower();
            _filteredEmployees = string.IsNullOrWhiteSpace(searchValue)
                ? new List<EmployeeDto>(_employees)
                : _employees.Where(x => x.FullName.ToLower().Contains(searchValue)).ToList();
            RenderEmployeeCards(_filteredEmployees);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            var addForm = new AddEmployeeForm(_employeeService);
            addForm.ShowDialog();
            _employees = (await _employeeService.GetAllAsync()).ToList();
            _filteredEmployees = new List<EmployeeDto>(_employees);
            RenderEmployeeCards(_filteredEmployees);
        }
    }
}
