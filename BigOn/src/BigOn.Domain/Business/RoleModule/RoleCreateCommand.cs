using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RoleCreateCommand : IRequest<BigonRole>
    {
        public string Name { get; set; }


        public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, BigonRole>
        {
            private readonly RoleManager<BigonRole> roleManager;
            private readonly IActionContextAccessor ctx;

            public RoleCreateCommandHandler(RoleManager<BigonRole> roleManager,IActionContextAccessor ctx)
            {
                this.roleManager = roleManager;
                this.ctx = ctx;
            }


            public async Task<BigonRole> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
            {
                var role = new BigonRole
                {
                    Name = request.Name
                };

                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ctx.AddModelError("Name", error.Description);
                    }

                    return null;
                }


                return role;
            }
        }
    }
}
