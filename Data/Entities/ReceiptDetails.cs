using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("ReceiptDetails")]
    public class ReceiptDetails
    {
        [Key]
        [Column("receipt_details_id")]
        public int ReceiptDetailsId { get; set; }

        [Required]
        [Column("quantity_in_receipt")]
        public int QuantityInReceipt { get; set; }

        [Required, Column("price_in_receipt", TypeName = "decimal(12,2)")]
        public decimal PriceInReceipt { get; set; }

        [ForeignKey(nameof(Receipt))]
        [Column("receipt_id")]
        public int ReceiptId { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("employee_id")]
        public int ProductId { get; set; }

        public Receipt Receipt { get; set; }
        public Product Product { get; set; }
    }
}
