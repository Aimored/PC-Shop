namespace PcShop.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }  // Было TovarId
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }  // Было Cost
        public int Quantity { get; set; }
    }
}
