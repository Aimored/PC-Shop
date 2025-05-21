using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcShop.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("customer_name")]
        public string? CustomerName { get; set; }

        [Column("customer_email")]
        public string? CustomerEmail { get; set; }

        // Добавляем поле для связи с пользователем
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        // Навигационное свойство к пользователю
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
