using Grp3_GrpVI_ITELEC1C.Models;
using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class ProductController : Controller
    {
        private IProductDataService _service;

        public ProductController(IProductDataService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            await _service.AddProductAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var products = await _service.GetProductsAsync();
            var product = products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            await _service.DeleteProductAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var products = await _service.GetProductsAsync();
            var product = products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _service.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }
    }
}
