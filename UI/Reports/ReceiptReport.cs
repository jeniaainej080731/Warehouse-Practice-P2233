using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace Warehouse.UI.Reports
{
    public class ReceiptReport : IDocument
    {
        private readonly string _customerName;
        private readonly string _employeeName;
        private readonly DateTime _date;
        private readonly List<(string Name, int Quantity, decimal Price)> _lines;
        private readonly string _qrUrl;

        public ReceiptReport(
            string customerName,
            string employeeName,
            DateTime date,
            IEnumerable<(string Name, int Quantity, decimal Price)> lines,
            string qrUrl)
        {
            _customerName = customerName;
            _employeeName = employeeName;
            _date = date;
            _lines = lines.ToList();
            _qrUrl = qrUrl;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            var culture = CultureInfo.CurrentCulture;
            var accentColor = Colors.Blue.Darken3;
            var headerTextColor = Colors.White;

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                // Шапка документа
                page.Header().Background(accentColor).Padding(15).Column(column =>
                {
                    column.Item().AlignCenter().Text("НАКЛАДНАЯ")
                        .FontColor(headerTextColor)
                        .Bold().FontSize(20);

                    column.Item().PaddingTop(10).Row(row =>
                    {
                        row.RelativeColumn().Stack(stack =>
                        {
                            stack.Item().Text("Клиент:").FontColor(headerTextColor).SemiBold();
                            stack.Item().PaddingTop(5).Text(_customerName).FontColor(headerTextColor);
                        });

                        row.RelativeColumn().Stack(stack =>
                        {
                            stack.Item().Text("Дата оформления:").FontColor(headerTextColor).SemiBold();
                            stack.Item().PaddingTop(5).Text(_date.ToString("dd.MM.yyyy HH:mm")).FontColor(headerTextColor);
                        });

                        row.RelativeColumn().Stack(stack =>
                        {
                            stack.Item().Text("Сотрудник:").FontColor(headerTextColor).SemiBold();
                            stack.Item().PaddingTop(5).Text(_employeeName).FontColor(headerTextColor);
                        });
                    });
                });

                // Основное содержимое
                page.Content().Column(column =>
                {
                    // Таблица с товарами
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(4);
                            columns.ConstantColumn(70);
                            columns.ConstantColumn(90);
                            columns.ConstantColumn(110);
                        });

                        // Заголовок таблицы
                        table.Header(header =>
                        {
                            IContainer HeaderCellStyle(IContainer container) => container
                                .Background(Colors.Grey.Lighten3)
                                .PaddingVertical(8)
                                .PaddingHorizontal(5)
                                .BorderBottom(1.5f).BorderColor(accentColor);

                            header.Cell().Element(HeaderCellStyle).Text("Наименование товара");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Кол-во");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Цена");
                            header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Сумма");
                        });

                        // Строки с товарами
                        decimal total = 0;
                        foreach (var line in _lines)
                        {
                            var sum = line.Quantity * line.Price;
                            total += sum;

                            table.Cell().Element(CellStyle).Text(line.Name);
                            table.Cell().Element(CellStyle).AlignCenter().Text(line.Quantity.ToString());
                            table.Cell().Element(CellStyle).AlignRight().Text(line.Price.ToString("N2", culture));
                            table.Cell().Element(CellStyle).AlignRight().Text(sum.ToString("N2", culture));
                        }

                        // Итоговая строка
                        table.Footer(footer =>
                        {
                            IContainer FooterCellStyle(IContainer container) => container
                                .BorderTop(1.5f).BorderColor(accentColor)
                                .PaddingVertical(10);

                            footer.Cell().ColumnSpan(3).Element(FooterCellStyle).AlignRight().Text("ИТОГО:").Bold();
                            footer.Cell().Element(FooterCellStyle).AlignRight().Text(total.ToString("N2", culture)).Bold();
                        });
                    });

                    // QR-код и подпись
                    column.Item().PaddingTop(20).AlignCenter().Column(qrColumn =>
                    {
                        qrColumn.Item().Component(new QrComponent(_qrUrl));
                        qrColumn.Item().PaddingTop(5).Text("Отсканируйте QR-код, чтобы попасть в GitHub")
                            .FontSize(9)
                            .FontColor(Colors.Grey.Medium);
                    });
                });
            });
        }


        public void GeneratePdf(string filePath)
        {
            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            Document.Create(container => Compose(container)).GeneratePdf(filePath);
        }

        private class QrComponent : IComponent
        {
            private readonly string _url;

            public QrComponent(string url) => _url = url;

            public void Compose(IContainer container)
            {
                using var qr = GenerateQrImage(_url);
                using var ms = new MemoryStream();
                qr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;

                container.Border(1).BorderColor(Colors.Grey.Lighten1).Padding(5)
                    .Width(120).Height(120)
                    .Image(ms, ImageScaling.FitArea);
            }
        }

        private static Bitmap GenerateQrImage(string payload)
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            var code = new QRCode(data);
            return code.GetGraphic(20);
        }

        private static IContainer CellStyle(IContainer container) => container
            .BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
            .PaddingVertical(8)
            .PaddingHorizontal(5);
    }
}
