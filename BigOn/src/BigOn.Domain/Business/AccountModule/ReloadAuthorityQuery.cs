using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.Models.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.AccountModule
{
    public class ReloadAuthorityQuery : IRequest<bool>
    {
        public ClaimsPrincipal User { get; set; }


        public class ReloadAuthorityQueryHandler : IRequestHandler<ReloadAuthorityQuery, bool>
        {
            private readonly BigOnDbContext db;

            public ReloadAuthorityQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<bool> Handle(ReloadAuthorityQuery request, CancellationToken cancellationToken)
            {
                var userId = request.User.GetUserId();

                if (request.User.Identity is ClaimsIdentity ci)
                {
                    var roles = await (from ur in db.UserRoles
                     join r in db.Roles on ur.RoleId equals r.Id
                     where ur.UserId == userId
                     select r.Name)
                     .ToArrayAsync(cancellationToken);

                    foreach (var roleName in roles)
                    {
                        ci.AddClaim(new Claim(ClaimTypes.Role, roleName));
                    }

                    var currentClaims = await (from ur in db.UserRoles
                                               join rc in db.RoleClaims on ur.RoleId equals rc.RoleId
                                               where ur.UserId == userId && rc.ClaimValue.Equals("1")
                                               select rc.ClaimType)

                    .Union(from uc in db.UserClaims
                           where uc.UserId == userId && uc.ClaimValue.Equals("1")
                           select uc.ClaimType)

                    .Distinct()
                    .ToArrayAsync(cancellationToken);

                    var excepted = (from p in (AppClaimProvider.principals ?? new string[] { })
                                    join c in ci.Claims on p equals c.Type
                                    select c.Type)
                    .Except(currentClaims);

                    var claims = ci.Claims.Where(c => excepted.Contains(c.Type))
                        .ToArray();

                    foreach (var claim in claims)
                    {
                        ci.RemoveClaim(claim);
                    }

                    excepted = currentClaims.Except(from p in (AppClaimProvider.principals ?? new string[] { })
                                                    join c in ci.Claims on p equals c.Type
                                                    select c.Type);

                    foreach (var claimName in excepted)
                    {
                        ci.AddClaim(new Claim(claimName, "1"));
                    }
                }


                return true;
            }
        }
    }
}
