using Grp3_GrpVI_ITELEC1C.Models;
using Grp3_GrpVI_ITELEC1C.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    public class OrderController : Controller
    {

        private IOrderDataService _service;

        public OrderController(IOrderDataService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _service.GetOrderAsync();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orders = await _service.GetOrderAsync();
            var order = orders.Where(x => x.Id == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(Order order)
        {
            await _service.DeleteOrderAsync(order);
            return RedirectToAction("Index");
        }
    }
}
