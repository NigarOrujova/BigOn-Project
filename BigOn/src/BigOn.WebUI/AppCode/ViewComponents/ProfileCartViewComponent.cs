using BigOn.Domain.Business.CategoryModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BigOn.WebUI.AppCode.ViewComponents
{
    public class ProfileCartViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProfileCartViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userIdstr = UserClaimsPrincipal.Claims
                .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            var userId = Convert.ToInt32(userIdstr);

            return View();
        }
    }
}
