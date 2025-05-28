using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Warehouse
{
    public partial class TestReportForm : Form
    {
        public TestReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            // Подготовим данные для примера
            var items = new List<(string Name, int Qty, decimal Price)>
            {
                ("Товар A", 2, 150.00m),
                ("Товар B", 1, 299.99m),
                ("Итого", 3, 599.99m)
            };

            // Сгенерируем PDF
            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Report.pdf");

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("Простой отчёт").SemiBold().FontSize(20).AlignCenter();
                    page.Content().Table(table =>
                    {
                        // Определяем три колонки
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(60);
                            columns.ConstantColumn(80);
                        });

                        // Заголовки
                        table.Header(header =>
                        {
                            header.Cell().Element(container => CellStyle(container)).Text("Название");
                            header.Cell().Element(CellStyle).Text("Кол-во");
                            header.Cell().Element(CellStyle).Text("Цена");
                        });

                        // Данные
                        foreach (var item in items)
                        {
                            table.Cell().Element(CellStyle).Text(item.Name);
                            table.Cell().Element(CellStyle).Text(item.Qty.ToString());
                            table.Cell().Element(CellStyle).Text(item.Price.ToString("0.00"));
                        }

                        static IContainer CellStyle(IContainer container) =>
                            container.BorderBottom(1).PaddingVertical(5);
                    });
                    page.Footer().AlignRight().Text($"Сгенерировано: {DateTime.Now:dd.MM.yyyy HH:mm}");
                });
            })
            .GeneratePdf(filePath);

            MessageBox.Show($"Отчёт сохранён:\n{filePath}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
