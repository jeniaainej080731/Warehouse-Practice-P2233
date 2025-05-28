using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Deleted_Products")]
    public class DeletedProduct
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("product_name", TypeName = "nvarchar(max)")]
        public string ProductName { get; set; }

        [Required]
        [Column("product_quantity")]
        public int ProductQuantity { get; set; }

        [Required, Column("product_price", TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        [Required, MaxLength(12)]
        [Column("product_code", TypeName = "varchar(12)")]
        public string ProductCode { get; set; }

        [Required]
        [Column("date_of_receipt", TypeName = "date")]
        public DateTime DateOfReceipt { get; set; }

        [ForeignKey(nameof(Category))]
        [Column("category_id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
