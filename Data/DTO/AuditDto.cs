namespace Warehouse.Data.DTO
{
    public class AuditDto
    {
        public int InventoryAuditId { get; set; }
        public int ProductId { get; set; }
        public int EmployeeId { get; set; }
        public int CheckedQuantity { get; set; }
        public DateTime AuditDate { get; set; }
        public string InventoryAuditComments { get; set; }

        // Только для отображения при чтении:
        public string ProductName { get; set; }
        public string EmployeeName { get; set; }

        // Опционально — для UI вычисления:
        public int ExpectedQuantity { get; set; }
        public int Difference { get; set; }
    }
}