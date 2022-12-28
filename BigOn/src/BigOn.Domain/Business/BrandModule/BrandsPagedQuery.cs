using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.BrandModule
{
    public class BrandsPagedQuery : PageableModel, IQuery<PagedViewModel<Brand>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize < 10)
                {
                    return 10;
                }

                return base.PageSize;
            }
        }



        public class BrandsPagedQueryHandler : IRequestHandler<BrandsPagedQuery, PagedViewModel<Brand>>
        {
            private readonly BigOnDbContext db;

            public BrandsPagedQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<PagedViewModel<Brand>> Handle(BrandsPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Brands
                 .Where(m => m.DeletedDate == null)
                 .OrderByDescending(m => m.Id);


                var pagedData = new PagedViewModel<Brand>(query, request.PageIndex, request.PageSize);

                return pagedData;
            }
        }
    }
}
