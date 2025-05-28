using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        [Column("invoice_id")]
        public int InvoiceId { get; set; }

        [Required, Column("invoice_total_amount", TypeName = "decimal(12,2)")]
        public decimal InvoiceTotalAmount { get; set; }

        [Required]
        [Column("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column("invoice_comments")]
        public string InvoiceComments { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        public Employee Employee { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
