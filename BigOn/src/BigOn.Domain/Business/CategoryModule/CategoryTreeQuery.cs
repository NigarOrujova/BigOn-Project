using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.CategoryModule
{
    public class CategoryTreeQuery : IRequest<List<Category>>
    {
        public class CategoryTreeQueryHandler : IRequestHandler<CategoryTreeQuery, List<Category>>
        {
            private readonly BigOnDbContext db;

            public CategoryTreeQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<List<Category>> Handle(CategoryTreeQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Categories
                 .Include(c => c.Parent)
                 .Include(c => c.Children.Where(c => c.DeletedDate == null))
                 .Where(c => c.DeletedDate == null)
                 .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
