namespace Warehouse.Data.DTO
{
    public class InvoiceDto
    {
        public decimal InvoiceTotalAmount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceComments { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int QuantityInInvoice { get; set; }
        public decimal PriceInInvoice { get; set; }
    }
}
