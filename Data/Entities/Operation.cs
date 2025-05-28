using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Operations")]
    public class Operation
    {
        [Key]
        [Column("operation_id")]
        public int OperationId { get; set; }

        [Required]
        [Column("operation_type")]
        public string OperationType { get; set; } // "IN" || "OUT" || "UPD" 

        [Required]
        [Column("quantity_in_operation")]
        public int QuantityInOperation { get; set; }

        [Required]
        [Column("operation_date")]
        public DateTime OperationDate { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }

        [ForeignKey(nameof(Supplier))]
        [Column("supplier_id")]
        public int SupplierId { get; set; }
        [Column("supplier_name")]
        public string SupplierName { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        [Column("employee_name")]
        public string EmployeeName { get; set; }

        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
        public Employee Employee { get; set; }
    }

}
