using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RoleSingleQuery : IRequest<BigonRole>
    {
        public int Id { get; set; }


        public class RoleSingleQueryHandler : IRequestHandler<RoleSingleQuery, BigonRole>
        {
            private readonly RoleManager<BigonRole> roleManager;

            public RoleSingleQueryHandler(RoleManager<BigonRole> roleManager)
            {
                this.roleManager = roleManager;
            }
            public async Task<BigonRole> Handle(RoleSingleQuery request, CancellationToken cancellationToken)
            {
                if (request.Id < 1)
                    return null;


                var model = await roleManager.Roles.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return model;
            }
        }
    }
}
