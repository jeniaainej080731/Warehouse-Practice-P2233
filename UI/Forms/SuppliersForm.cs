using Warehouse.Data.DTO;
using Warehouse.Services.Interfaces;

namespace Warehouse.UI.Forms
{
    public partial class SuppliersForm : Form
    {
        private readonly ISupplierService _supplierService;
        private List<SupplierDto> _suppliers;
        private bool isLoaded = false;
        private bool isAdmin;
        private List<SupplierDto> _filteredSuppliers;

        public SuppliersForm(bool isAdmin, ISupplierService supplierService)
        {
            InitializeComponent();

            this._supplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            this.isAdmin = isAdmin;
        }

        private async void SuppliersForm_Load(object sender, EventArgs e)
        {
            _suppliers = (await _supplierService.GetAllAsync()).ToList();
            _filteredSuppliers = _suppliers;
            RenderSupplierCards(_filteredSuppliers);
            isLoaded = true;
        }

        private async void RenderSupplierCards(List<SupplierDto> suppliersToRender)
        {
            foreach (Control c in MainPanel.Controls)
            {
                if (c is PictureBox pb && pb.Image != null)
                    pb.Image.Dispose();
                c.Dispose();
            }
            MainPanel.Controls.Clear();

            int cardWidth = SupplierCard.Width;
            int cardHeight = SupplierCard.Height;
            int spacing = 20;
            int panelWidth = MainPanel.ClientSize.Width;

            int leftMargin = 5;
            int topMargin = 10;

            int cardsPerRow = Math.Max(1, (panelWidth + spacing) / (cardWidth + spacing));

            for (int i = 0; i < suppliersToRender.Count; i++)
            {
                var supplier = suppliersToRender[i];
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;

                var newCard = new Panel
                {
                    Width = cardWidth,
                    Height = cardHeight,
                    BackColor = SupplierCard.BackColor,
                    BorderStyle = SupplierCard.BorderStyle,
                    Location = new Point(
                        leftMargin + col * (cardWidth + spacing),
                        topMargin + row * (cardHeight + spacing))
                };

                // PictureBox
                var pictureBox = new PictureBox
                {
                    Size = pictureBox1.Size,
                    Location = pictureBox1.Location,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = await LoadImage(supplier.PhotoPath)
                };
                newCard.Controls.Add(pictureBox);


                // InfoPanel
                var infoPanel = new Panel
                {
                    Location = InfoPanel.Location,
                    Size = InfoPanel.Size,
                    BackColor = InfoPanel.BackColor
                };

                // FullNameLbl
                var fullNameLbl = new Label
                {
                    AutoSize = true,
                    MaximumSize = new Size(infoPanel.Width - 10, 0),
                    Text = supplier.SupplierName,
                    Font = FullNameLbl.Font,
                    ForeColor = FullNameLbl.ForeColor,
                    Location = FullNameLbl.Location
                };
                infoPanel.Controls.Add(fullNameLbl);

                // ShowMoreLbl
                var showMoreLbl = new Label
                {
                    AutoSize = true,
                    Text = "Show More",
                    Font = ShowMoreLbl.Font,
                    ForeColor = ShowMoreLbl.ForeColor,
                    Location = ShowMoreLbl.Location,
                    Cursor = Cursors.Hand
                };
                showMoreLbl.Click += async (s, e) =>
                {
                    var detailsForm = new SupplierDetailsForm(isAdmin, supplier, _supplierService);
                    detailsForm.ShowDialog();
                    _suppliers = (await _supplierService.GetAllAsync()).ToList();
                    _filteredSuppliers = _suppliers;
                    RenderSupplierCards(_filteredSuppliers);
                };
                infoPanel.Controls.Add(showMoreLbl);

                newCard.Controls.Add(infoPanel);
                MainPanel.Controls.Add(newCard);
            }
        }

        private async void MainPanel_Resize(object sender, EventArgs e)
        {
            if (_filteredSuppliers != null && _filteredSuppliers.Any())
                RenderSupplierCards(_filteredSuppliers);
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

                return Properties.Resources.plug;
            }
            catch
            {
                return Properties.Resources.plug;
            }
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;

            string searchValue = SearchTxt.Text.ToLower();

            _filteredSuppliers = string.IsNullOrWhiteSpace(searchValue)
                ? _suppliers
                : _suppliers.Where(s => s.SupplierName?.ToLower().Contains(searchValue) == true).ToList();

            RenderSupplierCards(_filteredSuppliers);
        }

        private void ExitFormBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier(_supplierService);
            addSupplier.ShowDialog();
            _suppliers = (await _supplierService.GetAllAsync()).ToList();
            _filteredSuppliers = _suppliers;
            RenderSupplierCards(_filteredSuppliers);
        }
    }
}
