namespace Warehouse.Data.DTO
{
    public class ReceiptDto
    {
        public int ReceiptId { get; set; }
        public string CustomerName { get; set; }
        public decimal ReceiptTotalAmount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int QuantityInReceipt { get; set; }
        public decimal PriceInReceipt { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
