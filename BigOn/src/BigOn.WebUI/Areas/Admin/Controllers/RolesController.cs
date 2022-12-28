using BigOn.Domain.Business.RoleModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IMediator mediator;

        public RolesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.roles.index")]
        public async Task<IActionResult> Index(RolesPagedQuery query)
        {
            var response = await mediator.Send(query);

            return View(response);
        }

        [Authorize(Policy = "admin.roles.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "admin.roles.create")]
        public async Task<IActionResult> Create(RoleCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }




        [Authorize(Policy = "admin.roles.details")]
        public async Task<IActionResult> Details(RoleSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            ViewBag.AvailablePrincipals = await mediator.Send(new RoleAvailablePrincipalsQuery { RoleId = response.Id });
            return View(response);
        }

        [HttpPost]
        [Authorize(Policy = "admin.roles.setprincipal")]
        public async Task<IActionResult> SetPrincipal(RoleSetPrincipalCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }

        [HttpPost]
        [Authorize(Roles = "sa")]
        public async Task<IActionResult> RoleSorting(RoleSortCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }
    }
}
