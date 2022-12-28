using AutoMapper;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Dtos.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.FilterModule
{
    public class SearchPanelQuery : IRequest<SearchPanelDto>
    {


        public class SearchPanelQueryHandler : IRequestHandler<SearchPanelQuery, SearchPanelDto>
        {
            private readonly BigOnDbContext db;
            private readonly IMapper mapper;

            public SearchPanelQueryHandler(BigOnDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<SearchPanelDto> Handle(SearchPanelQuery request, CancellationToken cancellationToken)
            {
                var response = new SearchPanelDto();

                //response.Brands = await db.Products.Include(m => m.Brand)
                //    .Select(m => m.Brand)
                //    .Distinct()
                //    .ToArrayAsync(cancellationToken);

                response.Brands = mapper.Map<HolderChooseDto[]>(await db.Products.Include(m => m.Brand)
                .Select(m => m.Brand)
                .Distinct()
                .ToArrayAsync(cancellationToken));

                response.Sizes = mapper.Map<HolderChooseDto[]>(await db.ProductCatalog
                    .Include(m => m.Size)
                    .Select(m => m.Size)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));

                response.Colors = mapper.Map<HolderChooseDto[]>(await db.ProductCatalog
                    .Include(m => m.Color)
                    .Select(m => m.Color)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));

                response.Materials = mapper.Map<HolderChooseDto[]>(await db.ProductCatalog
                    .Include(m => m.Material)
                    .Select(m => m.Material)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));

                response.Types = mapper.Map<HolderChooseDto[]>(await db.ProductCatalog
                    .Include(m => m.Type)
                    .Select(m => m.Type)
                    .Distinct()
                    .ToArrayAsync(cancellationToken));


                var priceRange = await db.ProductCatalog
                    .Include(m => m.Product)
                    .Select(m => new { GroupId = 1, Price = m.Product.Price })
                    .GroupBy(m => m.GroupId)
                    .Select(m => new { Min = m.Min(m => m.Price), Max = m.Max(m => m.Price) })
                    .FirstOrDefaultAsync(cancellationToken);


                //5.0
                response.MinPrice = (int)Math.Floor(priceRange.Min ?? 0);
                response.MaxPrice = (int)Math.Ceiling(priceRange.Max ?? 0);


                return response;

            }
        }
    }
}
