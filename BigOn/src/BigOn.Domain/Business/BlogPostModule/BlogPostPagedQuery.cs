using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostPagedQuery : PageableModel, IRequest<PagedViewModel<BlogPost>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 9)
                    base.PageSize = 9;

                return base.PageSize;
            }
        }

        public class BlogPostsPagedQueryHandler : IRequestHandler<BlogPostPagedQuery, PagedViewModel<BlogPost>>
        {
            private readonly BigOnDbContext db;

            public BlogPostsPagedQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<BlogPost>> Handle(BlogPostPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.BlogPosts
                 .Where(m => m.DeletedDate == null)
                 .AsQueryable();

                query = query.OrderByDescending(m => m.PublishDate);

                var data = new PagedViewModel<BlogPost>(query, request.PageIndex, request.PageSize);

                return data;
            }
        }
    }
}
