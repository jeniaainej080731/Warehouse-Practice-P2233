using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Warehouse.Data.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Required]
        [Column("supplier_name", TypeName = "nvarchar(max)")]
        public string SupplierName { get; set; }

        [Required]
        [Column("contact_info", TypeName = "ntext")]
        public string ContactInfo { get; set; }

        [Required]
        [Column("supplier_address", TypeName = "text")]
        public string SupplierAddress { get; set; }
        [Column("photo_path")]
        [AllowNull]
        public string PhotoPath { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}
