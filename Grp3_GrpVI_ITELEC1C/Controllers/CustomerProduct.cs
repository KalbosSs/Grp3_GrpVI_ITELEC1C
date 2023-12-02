using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class CustomerProduct : Controller
    {

        private IProductDataService _service;

        public CustomerProduct(IProductDataService service)
        {
            _service = service;
            
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
    }
}
