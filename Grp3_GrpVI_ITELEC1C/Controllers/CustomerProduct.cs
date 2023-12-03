using System;
using Grp3_GrpVI_ITELEC1C.Data;
using Grp3_GrpVI_ITELEC1C.Models;
using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class CustomerProduct : Controller
    {

        private IProductDataService _service;
        private ICartService _cartService;
        private readonly AppDbContext _appDbContext;

        public CustomerProduct(IProductDataService service, ICartService cartService, AppDbContext appDbContext)
        {
            _service = service;
            _cartService = cartService;
            _appDbContext = appDbContext;

        }
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Order(int id)
        {
            var products = await _service.GetProductsAsync();
            var product = products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Order(int id, int quantity)
        {
            var products = await _service.GetProductsAsync();
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                // Add the selected product to the cart
                await _cartService.AddToCartAsync(product, quantity);

                // Redirect to the Cart action in the CartController
                return RedirectToAction("Index", "Cart");
            }

            // Handle the case where the product is not found
            return RedirectToAction("Index", "CustomerProduct");
        }


    }
}
