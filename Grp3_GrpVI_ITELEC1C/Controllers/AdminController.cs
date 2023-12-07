using Grp3_GrpVI_ITELEC1C.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public IActionResult Index()
        {
            return View();
        }
        public AdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Check if the entered email and password match the values in the admin table
            if (!ModelState.IsValid)
            {
                return View("Index"); // Return to the login page with validation errors
            }

            // Check if the entered email and password match the values in the admin table
            var admin = _appDbContext.Admins.FirstOrDefault(a => a.AdminEmail == email && a.AdminPassword == password);

            if (admin != null)
            {
                // Successful login
                return RedirectToAction("Index", "Product");
            }
            else
            {
                // Redirect back to the login page with an error message
                ViewData["ErrorMessage"] = "Invalid email or password";
                return View("Index");
            }
        }
    }
}
