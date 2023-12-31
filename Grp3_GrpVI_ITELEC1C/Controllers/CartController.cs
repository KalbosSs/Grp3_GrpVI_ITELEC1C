﻿using Grp3_GrpVI_ITELEC1C.Data;
using Grp3_GrpVI_ITELEC1C.Models;
using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<IActionResult> EditCart(int id)
        {
            var carts = await _cartService.GetCartItemsAsync();
            var cart = carts.Where(x => x.Id == id).FirstOrDefault();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> EditCart(Cart cart)
        {
            await _cartService.UpdateCartItemAsync(cart);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var carts = await _cartService.GetCartItemsAsync();
            var cart = carts.Where(x => x.Id == id).FirstOrDefault();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCart(Cart cart)
        {
            await _cartService.DeleteCartItemAsync(cart);
            return RedirectToAction("Index");
        }
        public IActionResult OrderForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string customerName)
        {
            await _cartService.PlaceOrderAsync(customerName);
            var orderDetails = _cartService.GetOrderDetails();


            
            return RedirectToAction("Index");
        }

    }
}
