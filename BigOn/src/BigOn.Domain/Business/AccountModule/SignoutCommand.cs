using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.AccountModule
{
    public class SignoutCommand : IRequest<bool>
    {
        public class SignoutCommandHandler : IRequestHandler<SignoutCommand, bool>
        {
            private readonly IActionContextAccessor ctx;

            public SignoutCommandHandler(IActionContextAccessor ctx)
            {
                this.ctx = ctx;
            }


            public async Task<bool> Handle(SignoutCommand request, CancellationToken cancellationToken)
            {
                await ctx.ActionContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return true;
            }
        }
    }
}
