using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.AccountModule
{
    public class RegisterConfirmationCommand : IRequest<BigonUser>
    {
        public string Token { get; set; }

        public class RegisterConfirmationCommandHandler : IRequestHandler<RegisterConfirmationCommand, BigonUser>
        {
            private readonly UserManager<BigonUser> userManager;
            private readonly ICryptoService cryptoService;
            private readonly IActionContextAccessor ctx;

            public RegisterConfirmationCommandHandler(UserManager<BigonUser> userManager,
                ICryptoService cryptoService,
                IActionContextAccessor ctx)
            {
                this.userManager = userManager;
                this.cryptoService = cryptoService;
                this.ctx = ctx;
            }

            public async Task<BigonUser> Handle(RegisterConfirmationCommand request, CancellationToken cancellationToken)
            {
                var plainToken = cryptoService.Decrypt(request.Token); // 1-dafdfwefwsadsaasd

                var match = Regex.Match(plainToken, @"(?<id>\d+)-(?<token>.+)");

                if (!match.Success)
                {
                    ctx.ActionContext.ModelState.AddModelError("Token", "Token zedelenib!");
                    return null;
                }

                string token = match.Groups["token"].Value;

                var user = await userManager.FindByIdAsync(match.Groups["id"].Value);

                if (user == null)
                {
                    ctx.ActionContext.ModelState.AddModelError("Token", "Istifadeci movcud deyil!");
                    return null;
                }
                else if (user.EmailConfirmed)
                {
                    ctx.ActionContext.ModelState.AddModelError("Token", "Istifadeci artiq tesdiq edilib!");
                    return null;
                }
                var response = await userManager.ConfirmEmailAsync(user, token);

                if (!response.Succeeded)
                {
                    foreach (var item in response.Errors)
                    {
                        ctx.ActionContext.ModelState.AddModelError("Token", item.Description);
                    }

                    return null;
                }


                return user;
            }
        }
    }
}
