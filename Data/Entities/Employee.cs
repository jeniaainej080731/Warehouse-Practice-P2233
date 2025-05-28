using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Warehouse.Data.Entities
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("employee_name", TypeName = "nvarchar(max)")]
        public string FullName { get; set; }

        [Required]
        [Column("login_id")]
        public int LoginId { get; set; }

        [Required, EmailAddress(ErrorMessage = "Incorrect email address")]
        [Column("email", TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        [Required, StringLength(15)]
        [Column("phone", TypeName = "nvarchar(13)")]
        public string PhoneNumber { get; set; }

        [AllowNull]
        [Column("photo_path")]
        public string PhotoPath { get; set; }

        [ForeignKey("LoginId")]
        public virtual LoginRole LoginRole { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Operation> Operations { get; set; }
        public ICollection<Audit> InventoryAudits { get; set; }
    }
}
