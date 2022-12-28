using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostRelatedQuery : IRequest<List<BlogPost>>
    {
        public int PostId { get; set; }
        public int Size { get; set; }


        public class BlogPostRelatedQueryHandler : IRequestHandler<BlogPostRelatedQuery, List<BlogPost>>
        {
            private readonly BigOnDbContext db;
            public BlogPostRelatedQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<List<BlogPost>> Handle(BlogPostRelatedQuery request, CancellationToken cancellationToken)
            {
                /*
                 select distinct BlogPostId from [dbo].[BlogPostTagCloud] 
                  where BlogPostId <> @id 
                  and TagId in (
                    select TagId from [dbo].[BlogPostTagCloud] where BlogPostId=@id
                    )

                select * from dbo.BlogPosts
                where Id in (2
                ,3
                ,4
                ,97) 
                 */

                var tagIds = await db.BlogPostTagCloud.Where(b => b.BlogPostId == request.PostId)
                               .Select(b => b.TagId)
                               .ToArrayAsync(cancellationToken);

                var relatedBlogPostIds = await db.BlogPostTagCloud
                                         .Where(b => tagIds.Contains(b.TagId)
                                         && b.BlogPostId != request.PostId)
                                         .Select(b => b.BlogPostId)
                                         .Distinct()
                                         .ToArrayAsync(cancellationToken);

                var relatedPosts = await db.BlogPosts.Where(bp => relatedBlogPostIds.Contains(bp.Id)
                                        && bp.DeletedDate == null
                                        && bp.PublishDate != null)
                                        .OrderByDescending(bp => bp.PublishDate)
                                        .Take(request.Size <= 2 ? 2 : request.Size)
                                        .ToListAsync(cancellationToken);

                return relatedPosts;
            }
        }
    }
}
