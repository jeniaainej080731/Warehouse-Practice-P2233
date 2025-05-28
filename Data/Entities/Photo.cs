using System.ComponentModel.DataAnnotations;

namespace Warehouse.Data.Entities
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
