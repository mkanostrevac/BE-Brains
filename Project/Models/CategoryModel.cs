using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("categories")]
    public class CategoryModel
    {
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}