using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Business.FilterModule;
using BigOn.Domain.Business.ShopModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator mediator;

        public ShopController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(SearchFilterQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", response);
            }

            return View(response);
        }


        [Route("wishlist.html")]
        public async Task<IActionResult> Wishlist(WishlistQuery query)
        {
            var response = await mediator.Send(query);

            if (response != null)
            {
                return View(response);
            }

            TempData["InfoMessage"] = "Istek sehifeniz boshdur";

            if (Request.Headers.TryGetValue("Referer", out StringValues values))
            {
                return Redirect(values.First());
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToBasket(AddToBasketCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }

        [Authorize]
        [Route("basket.html")]
        public async Task<IActionResult> Basket()
        {
            return View();
        }
    }
}
