using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models
{
    [Table("product_spec_values")]
    public class ProductSpecValue
    {
        [Key]
        [Column("value_id")]
        public int Id { get; set; }

        [Required]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("spec_id")]
        public int SpecId { get; set; }

        [Required]
        [Column("value")]
        public string Value { get; set; } = null!;

        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;

        [ForeignKey("SpecId")]
        public Specification Specification { get; set; } = null!;
    }
}
