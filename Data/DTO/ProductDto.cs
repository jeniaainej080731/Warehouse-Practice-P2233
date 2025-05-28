namespace Warehouse.Data.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCode { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
