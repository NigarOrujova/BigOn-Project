using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.Entities.Membership;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.UserModule
{
    public class UsersPagedQuery : PageableModel, IRequest<PagedViewModel<BigonUser>>
    {
        public override int PageSize
        {
            get
            {
                return base.PageSize;
            }
            set
            {
                if (value <= 15)
                {
                    base.PageSize = 15;
                }
                else
                {
                    base.PageSize = value;
                }
            }
        }


        public class UsersPagedQueryHandler : IRequestHandler<UsersPagedQuery, PagedViewModel<BigonUser>>
        {
            private readonly UserManager<BigonUser> userManager;

            public UsersPagedQueryHandler(UserManager<BigonUser> userManager)
            {
                this.userManager = userManager;
            }

            public Task<PagedViewModel<BigonUser>> Handle(UsersPagedQuery request, CancellationToken cancellationToken)
            {
                var query = userManager.Users
                    .OrderBy(m => m.EmailConfirmed)
                    .ThenByDescending(m => m.Id);


                var pagedData = new PagedViewModel<BigonUser>(query, request.PageIndex, request.PageSize);

                return Task.FromResult(pagedData);
            }
        }
    }
}
