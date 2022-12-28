using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SerilogIntro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            logger.LogDebug("Invoke: Home/Index");
            logger.LogInformation("Invoke: Home/Index");
            logger.LogWarning("Invoke: Home/Index");
            logger.LogError("Invoke: Home/Index");
            logger.LogCritical("Invoke: Home/Index");

            return View();
        }
    }
}
