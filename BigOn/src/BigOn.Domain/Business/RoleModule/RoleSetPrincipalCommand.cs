using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RoleSetPrincipalCommand : IRequest<JsonResponse>
    {
        public int RoleId { get; set; }
        public string PrincipalName { get; set; }
        public bool Selected { get; set; }

        public class RoleSetPrincipalCommandHandler : IRequestHandler<RoleSetPrincipalCommand, JsonResponse>
        {
            private readonly RoleManager<BigonRole> roleManager;
            private readonly BigOnDbContext db;

            public RoleSetPrincipalCommandHandler(RoleManager<BigonRole> roleManager, BigOnDbContext db)
            {
                this.roleManager = roleManager;
                this.db = db;
            }
            public async Task<JsonResponse> Handle(RoleSetPrincipalCommand request, CancellationToken cancellationToken)
            {
                var response = new JsonResponse
                {
                    Error = false
                };

                var role = await roleManager.Roles.FirstOrDefaultAsync(m => m.Id == request.RoleId, cancellationToken);


                if (role == null)
                {
                    response.Error = true;
                    response.Message = "Rol mövcud deyil";
                    goto end;
                }


                if (Array.IndexOf((AppClaimProvider.principals ?? new string[] { }), request.PrincipalName) == -1)
                {
                    response.Error = true;
                    response.Message = $"{request.PrincipalName} mövcud deyil";
                    goto end;
                }

                var hasClaim = await db.RoleClaims.AnyAsync(m => m.RoleId == request.RoleId && m.ClaimType.Equals(request.PrincipalName)
                && m.ClaimValue.Equals("1"), cancellationToken);

                if (request.Selected && hasClaim)
                {
                    response.Error = true;
                    response.Message = $"`{role.Name}` artiq {request.PrincipalName} selahiyyete sahibdir";
                    goto end;
                }
                else if (!request.Selected && hasClaim == false)
                {
                    response.Error = true;
                    response.Message = $"`{role.Name}` {request.PrincipalName} selahiyyetde deyil";
                    goto end;
                }


                if (request.Selected)
                {
                    await roleManager.AddClaimAsync(role, new Claim(request.PrincipalName, "1"));

                    response.Message = $"`{role.Name}` {request.PrincipalName}`a əlavə edildi";
                }
                else
                {
                    await roleManager.RemoveClaimAsync(role, new Claim(request.PrincipalName, "1"));

                    response.Message = $"`{role.Name}` {request.PrincipalName}`dan çıxarıldı";
                }
            end:
                return response;
            }
        }
    }
}
