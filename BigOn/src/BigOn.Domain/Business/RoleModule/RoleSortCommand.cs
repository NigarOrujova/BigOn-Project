using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.RoleModule
{
    public class RoleSortCommand : IRequest<JsonResponse>
    {
        public int EntityId { get; set; }
        public int AboveEntityId { get; set; }


        public class RoleSortCommandHandler : IRequestHandler<RoleSortCommand, JsonResponse>
        {
            private readonly BigOnDbContext db;

            public RoleSortCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<JsonResponse> Handle(RoleSortCommand request, CancellationToken cancellationToken)
            {
                var firstRoleEntry = await db.Roles
                    .FirstOrDefaultAsync(m => m.Id == request.AboveEntityId, cancellationToken);

                byte rank = firstRoleEntry.Rank;


                var movedRoleEntry = await db.Roles.FirstOrDefaultAsync(m => m.Id == request.EntityId, cancellationToken);
                movedRoleEntry.Rank = Convert.ToByte(rank >= 1 ? --rank : rank);

                rank = movedRoleEntry.Rank;

                var anotherRoles = await db.Roles
                    .Where(m => m.Id != request.AboveEntityId && m.Id != request.EntityId && m.Rank <= rank)
                    .OrderByDescending(m => m.Rank)
                    .ToListAsync(cancellationToken);

                foreach (var item in anotherRoles)
                {
                    item.Rank = rank >= 1 ? --rank : rank;
                }

                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Sorted!"
                };
            }
        }
    }
}
