namespace Warehouse.Data.Entities
{
    public class InventoryRow
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ExpectedQuantity { get; set; }
        public int CheckedQuantity { get; set; }
        public int Difference => CheckedQuantity - ExpectedQuantity;
    }
}
