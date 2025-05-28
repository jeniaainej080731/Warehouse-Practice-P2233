namespace Warehouse.Data.DTO
{
    public class OperationDto
    {
        public int OperationId { get; set; }
        public string OperationType { get; set; }
        public DateTime OperationDate { get; set; }
        public int QuantityInOperation { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
