using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities.Membership;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RolesPagedQuery : PageableModel, IRequest<PagedViewModel<BigonRole>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 15)
                    return base.PageSize = 15;

                return base.PageSize;
            }
            set
            {
                base.PageSize = value;
            }
        }

        public class RolesPagedQueryHandler : IRequestHandler<RolesPagedQuery, PagedViewModel<BigonRole>>
        {
            private readonly RoleManager<BigonRole> roleManager;

            public RolesPagedQueryHandler(RoleManager<BigonRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            public Task<PagedViewModel<BigonRole>> Handle(RolesPagedQuery request, CancellationToken cancellationToken)
            {
                var query = roleManager.Roles.OrderByDescending(m => m.Rank);

                var pagedDate = new PagedViewModel<BigonRole>(query, request.PageIndex, request.PageSize);

                return Task.FromResult(pagedDate);
            }
        }
    }
}
