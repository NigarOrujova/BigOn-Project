using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.ShopModule
{
    public class ShopFilterPagedQuery : PageableModel, IRequest<PagedViewModel<Product>>
    {
        public override int PageSize
        {
            get
            {
                if (base.PageSize<8)
                {
                    base.PageSize = 8;
                }

                return base.PageSize;
            }
        }


        public class ShopFilterPagedQueryHandler : IRequestHandler<ShopFilterPagedQuery, PagedViewModel<Product>>
        {
            private readonly BigOnDbContext db;

            public ShopFilterPagedQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }

            public async Task<PagedViewModel<Product>> Handle(ShopFilterPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Products
                    .Include(m => m.Images.Where(i => i.IsMain))
                    .Where(m => m.DeletedDate == null)
                    .OrderByDescending(m => m.Id)
                    .AsQueryable();


                var pagedData = new PagedViewModel<Product>(query,request.PageIndex,request.PageSize);

                return pagedData;

            }
        }
    }
}
