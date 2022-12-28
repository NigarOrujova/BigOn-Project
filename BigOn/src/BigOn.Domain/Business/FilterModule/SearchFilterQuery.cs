using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.FilterModule
{
    public class SearchFilterQuery : PageableModel, IRequest<PagedViewModel<Product>>
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int[] Brands { get; set; }
        public int[] Colors { get; set; }
        public int[] Materials { get; set; }
        public int[] Types { get; set; }
        public int[] Sizes { get; set; }

        public override int PageSize
        {
            get
            {
                if (base.PageSize < 12)
                {
                    base.PageSize = 12;
                }

                return base.PageSize;
            }
        }


        public class SearchFilterQueryHandler : IRequestHandler<SearchFilterQuery, PagedViewModel<Product>>
        {
            private readonly BigOnDbContext db;

            public SearchFilterQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }


            public async Task<PagedViewModel<Product>> Handle(SearchFilterQuery request, CancellationToken cancellationToken)
            {
                var catalogQuery = db.ProductCatalog
                    .Where(m => m.DeletedDate == null)
                    .AsQueryable();

                if (request.Colors != null && request.Colors.Length > 0)
                {
                    catalogQuery = catalogQuery.Where(m => request.Colors.Contains(m.ColorId));
                }

                if (request.Materials != null && request.Materials.Length > 0)
                {
                    catalogQuery = catalogQuery.Where(m => request.Materials.Contains(m.MaterialId));
                }

                if (request.Types != null && request.Types.Length > 0)
                {
                    catalogQuery = catalogQuery.Where(m => request.Types.Contains(m.TypeId));
                }

                if (request.Sizes != null && request.Sizes.Length > 0)
                {
                    catalogQuery = catalogQuery.Where(m => request.Sizes.Contains(m.SizeId));
                }

                var productIds = await catalogQuery.Select(m => m.ProductId).Distinct()
                                     .ToArrayAsync(cancellationToken);

                var productsQuery = (from p in db.Products.Include(m => m.Images.Where(i => i.IsMain))
                                     where productIds.Contains(p.Id)
                                     where p.DeletedDate == null
                                     select p);

                if (request.Min <= request.Max && request.Min > 0)
                {
                    productsQuery = productsQuery.Where(m => m.Price >= request.Min && m.Price <= request.Max);
                }

                if (request.Brands != null && request.Brands.Length > 0)
                {
                    productsQuery = productsQuery.Where(m => request.Brands.Contains(m.BrandId));
                }


                productsQuery = productsQuery.OrderByDescending(m => m.Id);

                var pagedData = new PagedViewModel<Product>(productsQuery, request.PageIndex, request.PageSize);

                return pagedData;
            }
        }
    }
}
