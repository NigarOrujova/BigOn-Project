using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.CategoryModule
{
    public class CategoryCreateCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
        {
            private readonly BigOnDbContext db;

            public CategoryCreateCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
            {
                var category = new Category()
                {
                    Name = request.Name,
                    ParentId = request.ParentId,
                };

                await db.Categories.AddAsync(category, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return category;
            }
        }
    }
}
