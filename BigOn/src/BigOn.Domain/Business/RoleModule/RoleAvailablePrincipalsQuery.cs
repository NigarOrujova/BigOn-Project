using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Dtos.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RoleAvailablePrincipalsQuery : IRequest<IEnumerable<AvailablePrincipal>>
    {
        public int RoleId { get; set; }


        public class RoleAvailablePrincipalsQueryHandler : IRequestHandler<RoleAvailablePrincipalsQuery, IEnumerable<AvailablePrincipal>>
        {
            private readonly BigOnDbContext db;

            public RoleAvailablePrincipalsQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<AvailablePrincipal>> Handle(RoleAvailablePrincipalsQuery request, CancellationToken cancellationToken)
            {
                var principals = AppClaimProvider.principals ?? new string[] { };


                var claims = await db.RoleClaims.Where(m => m.RoleId == request.RoleId && m.ClaimValue.Equals("1"))
                    .Select(m => m.ClaimType)
                    .ToArrayAsync(cancellationToken);


                var result = (from p in principals
                              join c in claims on p equals c into l_join_principals
                              from lp in l_join_principals.DefaultIfEmpty()
                              select new AvailablePrincipal
                              {
                                  PrincipalName = p,
                                  Selected = lp != null
                              }).AsEnumerable();

                return result;
            }
        }
    }
}
