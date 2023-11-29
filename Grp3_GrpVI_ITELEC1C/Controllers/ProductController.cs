using Grp3_GrpVI_ITELEC1C.Models;
using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class ProductController : Controller
    {
        private IProductDataService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductDataService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
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
            if (product.Photo != null && product.Photo.Length > 0)
            {
                // Save the uploaded file to the wwwroot/img folder
                var uploadsFolder = Path.Combine("wwwroot", "img");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.Photo.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await product.Photo.CopyToAsync(fileStream);
                }
                product.PhotoFile = uniqueFileName;
                product.PhotoPath = Path.Combine("/img/", uniqueFileName);
            }
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
