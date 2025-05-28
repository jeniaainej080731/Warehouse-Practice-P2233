using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Warehouse.Data.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required, MaxLength(150)]
        [Column("category_name", TypeName = "nvarchar(150)")]
        public string CategoryName { get; set; }

        [Required]
        [Column("category_description", TypeName = "ntext")]
        public string CategoryDescription { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
