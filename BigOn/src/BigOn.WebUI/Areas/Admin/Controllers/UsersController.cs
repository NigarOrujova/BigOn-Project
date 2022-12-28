using BigOn.Domain.Business.UserModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "sa")]
    public class UsersController : Controller
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(UsersPagedQuery query)
        {
            var data = await mediator.Send(query);

            return View(data);
        }

        public async Task<IActionResult> Details(UserDetailQuery query)
        {
            ViewBag.AvailableRoles = await mediator.Send(new UserAvailableRolesQuery() { UserId = query.Id });
            ViewBag.AvailablePrincipals = await mediator.Send(new UserAvailablePrincipalsQuery() { UserId = query.Id });

            var data = await mediator.Send(query);

            return View(data);
        }

        [HttpPost]
        [Authorize(Policy = "admin.users.setrole")]
        public async Task<IActionResult> SetRole(UserSetRoleCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }

        [HttpPost]
        [Authorize(Policy = "admin.users.setprincipal")]
        public async Task<IActionResult> SetPrincipal(UserSetPrincipalCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }
    }
}
