using BigOn.Domain.Business.CategoryModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.categories.index")]
        public async Task<IActionResult> Index(CategoryTreeQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }

        [Authorize(Policy = "admin.categories.create")]
        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.ParentId = new SelectList(categories, "Id","Name", null, "ParentName");
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "admin.categories.create")]
        public async Task<IActionResult> Create(CategoryCreateCommand command)
        {
            var response = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "admin.categories.edit")]
        public async Task<IActionResult> Edit(CategorySingleQuery query)
        {
            var response = await mediator.Send(query);
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.ParentId = new SelectList(categories, "Id", "Name", response.ParentId, "ParentName");

            var command = new CategoryEditCommand();
            command.Id = response.Id;
            command.Name = response.Name;
            command.ParentId = response.ParentId;
            return View(command);
        }

        [HttpPost]
        [Authorize(Policy = "admin.categories.edit")]
        public async Task<IActionResult> Edit(CategoryEditCommand command)
        {
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
