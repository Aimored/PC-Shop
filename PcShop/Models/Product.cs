using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = null!;

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Required]
        [Column("stock")]
        public int Stock { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Required]
        [Column("type_id")]
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public ProductType Type { get; set; } = null!;

        public ICollection<ProductSpecValue> Specifications { get; set; } = new List<ProductSpecValue>();
    }
}
