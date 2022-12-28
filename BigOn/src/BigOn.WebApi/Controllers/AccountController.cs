using BigOn.Domain.AppCode.Services;
using BigOn.Domain.Business.AccountModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ITokenService tokenService;

        public AccountController(IMediator mediator, ITokenService tokenService)
        {
            this.mediator = mediator;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(SigninCommand command)
        {
            var user = await mediator.Send(command);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = tokenService.BuildToken(user);

            return Ok(new
            {
                error = false,
                accessToken = token
            });
        }
    }
}
