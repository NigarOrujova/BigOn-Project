using Microsoft.AspNetCore.Mvc;

namespace SignalRIntro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
