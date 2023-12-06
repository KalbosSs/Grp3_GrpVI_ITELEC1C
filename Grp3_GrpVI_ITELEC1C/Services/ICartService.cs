using Grp3_GrpVI_ITELEC1C.Models;

namespace Grp3_GrpVI_ITELEC1C.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(Product product, int quantity);
        Task<List<Cart>> GetCartItemsAsync();
        Task UpdateCartItemAsync(Cart cart);
        Task DeleteCartItemAsync(Cart cart);
        Order GetOrderDetails();
        Task PlaceOrderAsync(string customerName);
        Task ClearCartAsync();
    }
}
