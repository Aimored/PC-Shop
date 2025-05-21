using PcShop.Models;

namespace PcShop.Models.ViewModels
{
    public class UserProfileViewModel
    {
        public User User { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
