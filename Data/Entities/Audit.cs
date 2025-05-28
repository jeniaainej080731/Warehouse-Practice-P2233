using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Inventory_Audit")]
    public class Audit
    {
        [Key]
        [Column("inventory_audit_id")]
        public int InventoryAuditId { get; set; }

        [Required]
        [Column("checked_quantity")]
        public int CheckedQuantity { get; set; }

        [Required]
        [Column("audit_date")]
        public DateTime AuditDate { get; set; }

        [Required]
        [Column("inventory_audit_comments")]
        public string InventoryAuditComments { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        // Навигации используем только при чтении с masterDbContext:
        public Product Product { get; set; }
        public Employee Employee { get; set; }
    }
}
