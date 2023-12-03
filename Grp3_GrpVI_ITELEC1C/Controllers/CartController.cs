using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve cart items and display the Cart view
            var cartItems = await _cartService.GetCartItemsAsync();
            return View(cartItems);
        }
    }
}
