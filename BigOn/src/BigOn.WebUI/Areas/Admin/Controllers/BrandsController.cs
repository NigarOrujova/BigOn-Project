using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Business.BrandModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

//https://dotnetthoughts.net/detecting-ajax-requests-in-aspnet-core/
namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.brands.index")]
        public async Task<IActionResult> Index(BrandsPagedQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListBody", response);
            }

            return View(response);
        }

        [Authorize(Policy = "admin.brands.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Create(BrandCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.brands.details")]
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        [Authorize(Policy = "admin.brands.remove")]
        public async Task<IActionResult> Remove(BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var newQuery = new BrandsPagedQuery
            {
                PageIndex = command.PageIndex,
                PageSize = command.PageSize
            };

            var data = await mediator.Send(newQuery);
            return PartialView("_ListBody", data);
        }
    }
}
