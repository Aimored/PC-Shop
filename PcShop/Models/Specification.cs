using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models
{
    [Table("specifications")]
    public class Specification
    {
        [Key]
        [Column("spec_id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = null!;

        [Required]
        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("unit")]
        public string? Unit { get; set; }

        [ForeignKey("TypeId")]
        public ProductType Type { get; set; } = null!;
    }
}
