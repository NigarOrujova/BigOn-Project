using BigOn.Domain.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.UserModule
{
    public class UserDetailQuery : IRequest<BigonUser>
    {
        public int Id { get; set; }


        public class UserDetailQueryHandler : IRequestHandler<UserDetailQuery, BigonUser>
        {
            private readonly UserManager<BigonUser> userManager;

            public UserDetailQueryHandler(UserManager<BigonUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<BigonUser> Handle(UserDetailQuery request, CancellationToken cancellationToken)
            {
                var data = await userManager.Users.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);


                return data;
            }
        }
    }
}
