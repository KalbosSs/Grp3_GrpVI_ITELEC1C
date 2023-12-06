using Grp3_GrpVI_ITELEC1C.Data;
using Grp3_GrpVI_ITELEC1C.Models;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Services
{
    public class CartService : ICartService
    {
        private AppDbContext _appDbContext;

        public CartService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddToCartAsync(Product product, int quantity)
        {
            // Create a new cart item based on the product details
            var existingCartItem = await _appDbContext.Carts
             .FirstOrDefaultAsync(c => c.ProductName == product.ProductName);

            if (existingCartItem != null)
            {
                // Update quantity and total price if the product already exists
                existingCartItem.Quantity += quantity;
                existingCartItem.TotalPrice = existingCartItem.Price * existingCartItem.Quantity;
            }
            else
            {
                // Create a new cart item based on the product details
                var cartItem = new Cart
                {
              
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Description = product.Description,
                    Stock = product.Stock,
                    TotalPrice = product.Price * quantity,
                    PhotoPath = product.PhotoPath,
                    Quantity = quantity
                };

                // Add the cart item to the database
                await _appDbContext.Carts.AddAsync(cartItem);
            }

            // Save changes to the database
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<Cart>> GetCartItemsAsync()
        {
            return await _appDbContext.Carts.ToListAsync();
        }

        public async Task DeleteCartItemAsync(Cart cart)
        {
            var selectedCartItem = await _appDbContext.Carts.Where(x => cart.Id == x.Id).FirstOrDefaultAsync();

            if (selectedCartItem != null)
            {
                _appDbContext.Carts.Remove(selectedCartItem);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCartItemAsync(Cart cart)
        {
            var selectedCartItem = await _appDbContext.Carts.Where(x => cart.Id == x.Id).FirstOrDefaultAsync();

            if (selectedCartItem != null)
            {
                selectedCartItem.Quantity = cart.Quantity;
                selectedCartItem.TotalPrice = selectedCartItem.Price * selectedCartItem.Quantity;
                await _appDbContext.SaveChangesAsync();
            }
        }
        public Order GetOrderDetails()
        {
            var cartItems = _appDbContext.Carts.ToList();
            var orderDetails = string.Join(", ", cartItems.Select(item => $"{item.ProductName} (Quantity: {item.Quantity}, Total Price: ₱{item.TotalPrice})"));
            decimal totalOrders = cartItems.Sum(item => item.TotalPrice);

            return new Order
            {
                OrderDetails = orderDetails,
                TotalOrders = totalOrders
            };
        }
        public async Task ClearCartAsync()
        {
            var cartItems = await _appDbContext.Carts.ToListAsync();
            _appDbContext.Carts.RemoveRange(cartItems);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task PlaceOrderAsync(string customerName)
        {
            var orderDetails = GetOrderDetails();
            var order = new Order
            {
                OrderDetails = orderDetails.OrderDetails,
                TotalOrders = orderDetails.TotalOrders,
                CustomerName = customerName
            };
            _appDbContext.Orders.Add(order);
            await _appDbContext.SaveChangesAsync();

            await ClearCartAsync();
        }
    }
}
