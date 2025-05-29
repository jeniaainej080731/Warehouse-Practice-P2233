using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using Warehouse.Data.DTO;

namespace Warehouse.UI.Reports
{
    public class OperationsReport : IDocument
    {
        private readonly List<OperationDto> _operations;
        private readonly Dictionary<int, decimal> _productPrices;
        private readonly Dictionary<int, decimal> _deletedProductPrices;
        private readonly int _inCount;
        private readonly int _outCount;
        private readonly decimal _inTotal;
        private readonly decimal _outTotal;
        private readonly DateTime _created = DateTime.Now;

        public OperationsReport(
            List<OperationDto> operations,
            Dictionary<int, decimal> productPrices,
            Dictionary<int, decimal> deletedProductPrices,
            int inCount,
            int outCount,
            decimal inTotal,
            decimal outTotal)
        {
            _operations = operations ?? throw new ArgumentNullException(nameof(operations));
            _productPrices = productPrices ?? throw new ArgumentNullException(nameof(productPrices));
            _deletedProductPrices = deletedProductPrices ?? throw new ArgumentNullException(nameof(deletedProductPrices));
            _inCount = inCount;
            _outCount = outCount;
            _inTotal = inTotal;
            _outTotal = outTotal;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            var mdl = new CultureInfo("ro-MD");

            // Подготовка диаграммы
            var pieImage = GeneratePieChart(_inCount, _outCount);
            using var pieStream = new MemoryStream();
            pieImage.Save(pieStream, System.Drawing.Imaging.ImageFormat.Png);
            pieStream.Position = 0;

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));

                // Header
                page.Header().Height(60).Background(Colors.Grey.Lighten3).Padding(10).Row(row =>
                {
                    row.RelativeItem().AlignLeft()
                       .Text("📊 Отчёт по операциям")
                       .SemiBold().FontSize(18).FontColor(Colors.Blue.Darken2);

                    row.ConstantItem(100).AlignRight()
                       .Text(_created.ToString("yyyy-MM-dd"))
                       .FontSize(10).FontColor(Colors.Black);
                });

                // Content
                page.Content().PaddingVertical(15).Column(col =>
                {
                    // Статистика
                    col.Item().Text("Общая статистика").Bold().FontSize(14).FontColor(Colors.Blue.Darken1);
                    col.Item().PaddingBottom(5).LineHorizontal(1).LineColor(Colors.Grey.Lighten1);

                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(def =>
                        {
                            def.ConstantColumn(200);
                            def.RelativeColumn();
                        });

                        // Заголовки
                        table.Header(header =>
                        {
                            header.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text("Показатель").SemiBold();
                            header.Cell().Background(Colors.Grey.Lighten4).Padding(5).Text("Значение").SemiBold().AlignRight();
                        });

                        // Данные
                        AddStatRow(table, "IN-операций (кол-во):", _inCount.ToString());
                        AddStatRow(table, "IN-операций (общая стоимость):", _inTotal.ToString("C", mdl));
                        AddStatRow(table, "OUT-операций (кол-во):", _outCount.ToString());
                        AddStatRow(table, "OUT-операций (общая стоимость):", _outTotal.ToString("C", mdl));
                    });

                    // Диаграмма
                    col.Item().PaddingTop(20).Text("Диаграмма: соотношение IN/OUT").Bold().FontSize(14);
                    col.Item().PaddingTop(5).AlignCenter().Height(300).Image(pieStream.ToArray());
                });

                // Footer
                page.Footer().AlignCenter()
                    .Text($"© 2025 jeniaainej080731 • Generated {_created:yyyy-MM-dd HH:mm}")
                    .FontSize(9).FontColor(Colors.Grey.Darken1);
            });
        }

        // Исправленная подпись: TableDescriptor вместо ITableDescriptor
        private void AddStatRow(QuestPDF.Fluent.TableDescriptor table, string name, string value)
        {
            table.Cell().Background(Colors.White).Padding(5).Text(name);
            table.Cell().Background(Colors.White).Padding(5).Text(value).AlignRight();
        }

        private System.Drawing.Image GeneratePieChart(int inCount, int outCount)
        {
            using var chart = new Chart
            {
                Width = 400,
                Height = 250,
                BackColor = System.Drawing.Color.White
            };

            chart.ChartAreas.Add(new ChartArea());

            var series = new Series { ChartType = SeriesChartType.Pie, ["PieLabelStyle"] = "Outside" };
            series.Points.AddXY("IN", inCount);
            series.Points.AddXY("OUT", outCount);

            chart.Series.Add(series);
            chart.Legends.Add(new Legend { LegendStyle = LegendStyle.Table, Docking = Docking.Bottom });

            var bmp = new Bitmap(chart.Width, chart.Height);
            chart.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
            return bmp.Clone() as System.Drawing.Image;
        }
    }
}
