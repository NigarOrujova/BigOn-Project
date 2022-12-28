using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.CategoryModule
{
    public class CategorySingleQuery : IRequest<Category>
    {
        public int Id { get; set; }


        public class CategorySingleQueryHandler : IRequestHandler<CategorySingleQuery, Category>
        {
            private readonly BigOnDbContext db;

            public CategorySingleQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategorySingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Categories
                   .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return entity;
            }
        }
    }
}
