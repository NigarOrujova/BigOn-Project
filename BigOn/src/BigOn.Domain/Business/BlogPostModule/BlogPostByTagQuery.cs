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
    public class BlogPostByTagQuery : IRequest<List<BlogPost>>
    {
        public int TagId { get; set; }
        public class BlogPostsAllQueryHandler : IRequestHandler<BlogPostByTagQuery, List<BlogPost>>
        {
            private readonly BigOnDbContext db;

            public BlogPostsAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<List<BlogPost>> Handle(BlogPostByTagQuery request, CancellationToken cancellationToken)
            {
                //var data = await db.BlogPosts
                //    .Include(bp => bp.TagCloud.Where(tc => tc.TagId == request.TagId))
                // .Where(m => m.TagCloud.Any() && m.DeletedDate == null)

                var data = await (from bp in db.BlogPosts
                            join tc in db.BlogPostTagCloud on bp.Id equals tc.BlogPostId
                            where tc.TagId == request.TagId
                            select bp)
                            .Distinct()
                            .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
