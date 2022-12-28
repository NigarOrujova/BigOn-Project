using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostRemoveCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }

        public class BlogPostRemoveCommandHandler : IRequestHandler<BlogPostRemoveCommand, JsonResponse>
        {
            private readonly BigOnDbContext db;

            public BlogPostRemoveCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<JsonResponse> Handle(BlogPostRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = db.BlogPosts
                   .FirstOrDefault(m => m.Id == request.Id && m.DeletedDate == null);


                if (entity == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Qeyd tapilmadi"
                    };
                }

                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Success"
                };
            }
        }
    }
}
