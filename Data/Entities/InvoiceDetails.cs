using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Invoice_Details")]
    public class InvoiceDetails
    {
        [Key]
        [Column("invoice_details_id")]
        public int InvoiceDetailsId { get; set; }

        [Required]
        [Column("quantity_in_invoice")]
        public int QuantityInInvoice { get; set; }

        [Required, Column("price_in_invoice", TypeName = "decimal(12,2)")]
        public decimal PriceInInvoice { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
