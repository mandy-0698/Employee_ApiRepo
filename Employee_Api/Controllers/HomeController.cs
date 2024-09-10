using Microsoft.AspNetCore.Mvc;

namespace Employee_Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
