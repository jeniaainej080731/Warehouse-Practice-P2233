using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Data.Entities
{
    [Table("Login_Roles")]
    public class LoginRole
    {
        [Key]
        [Column("login_id")]
        public int LoginId { get; set; }

        [Column("_login")]
        [Required, MaxLength(150)]
        public string Login { get; set; }

        [Column("_password")]
        [Required]
        public string Password { get; set; }

        [Column("_role")]
        [Required]
        public string Role { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
