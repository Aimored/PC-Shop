using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models
{
    [Table("tovar")]
    public class Tovar
    {
        [Key]
        [Column("idTovara")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("cost")]
        public int Cost { get; set; }

        [Required]
        [Column("kol")]
        public int Quantity { get; set; }

        [Required]
        [Column("kategoriya_id")]
        public int CategoryId { get; set; }

        [Required]
        [Column("image_path")]
        public required string ImagePath { get; set; }
    }
}
