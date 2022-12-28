using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostRecentQuery : IRequest<List<BlogPost>>
    {
        public int Size { get; set; }

        public class BlogPostsAllQueryHandler : IRequestHandler<BlogPostRecentQuery, List<BlogPost>>
        {
            private readonly BigOnDbContext db;

            public BlogPostsAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<List<BlogPost>> Handle(BlogPostRecentQuery request, CancellationToken cancellationToken)
            {
                var data = await db.BlogPosts
                 .Where(m => m.DeletedDate == null)
                 .OrderByDescending(m => m.Id)
                 .Take(request.Size < 2 ? 2 : request.Size)
                 .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
