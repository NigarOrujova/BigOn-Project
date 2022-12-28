using Microsoft.AspNetCore.Mvc;

namespace TagHelpersCustomize.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
