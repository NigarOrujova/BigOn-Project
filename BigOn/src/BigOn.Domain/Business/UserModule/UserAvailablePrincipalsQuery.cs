using BigOn.Domain.AppCode.Providers;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Dtos.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.UserModule
{
    public class UserAvailablePrincipalsQuery : IRequest<IEnumerable<AvailablePrincipal>>
    {
        public int UserId { get; set; }


        public class UserAvailablePrincipalsQueryHandler : IRequestHandler<UserAvailablePrincipalsQuery, IEnumerable<AvailablePrincipal>>
        {
            private readonly BigOnDbContext db;

            public UserAvailablePrincipalsQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<AvailablePrincipal>> Handle(UserAvailablePrincipalsQuery request, CancellationToken cancellationToken)
            {
                var principals = AppClaimProvider.principals ?? new string[] { };


                var claims = await db.UserClaims.Where(m => m.UserId == request.UserId && m.ClaimValue.Equals("1"))
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
