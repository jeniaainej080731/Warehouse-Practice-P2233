using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Receipts")]
    public class Receipt
    {
        [Key]
        [Column("receipt_id")]
        public int ReceiptId { get; set; }

        [Required]
        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Required, Column("receip_total_amount", TypeName = "decimal(12,2)")]
        public decimal ReceiptTotalAmount { get; set; }

        [Required]
        [Column("receipt_date")]
        public DateTime ReceiptDate { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public ICollection<ReceiptDetails> ReceiptDetails { get; set; }
    }
}
