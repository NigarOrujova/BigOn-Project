using BigOn.Domain.Models.Dtos.Roles;
using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.UserModule
{
    public class UserAvailableRolesQuery : IRequest<IEnumerable<AvailableRole>>
    {
        public int UserId { get; set; }


        public class UserAvailableRolesQueryHandler : IRequestHandler<UserAvailableRolesQuery, IEnumerable<AvailableRole>>
        {
            private readonly UserManager<BigonUser> userManager;
            private readonly RoleManager<BigonRole> roleManager;

            public UserAvailableRolesQueryHandler(UserManager<BigonUser> userManager, RoleManager<BigonRole> roleManager)
            {
                this.userManager = userManager;
                this.roleManager = roleManager;
            }
            public async Task<IEnumerable<AvailableRole>> Handle(UserAvailableRolesQuery request, CancellationToken cancellationToken)
            {
                var user = await userManager.Users.FirstOrDefaultAsync(m => m.Id == request.UserId, cancellationToken);

                var userRoles = await userManager.GetRolesAsync(user);

                var roles = (await roleManager.Roles.ToListAsync(cancellationToken))
                            .Select(m => new AvailableRole
                            {
                                RoleName = m.Name,
                                Selected = userRoles.Contains(m.Name)
                            });


                return roles;
            }
        }
    }





}
