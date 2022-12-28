using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.ShopModule
{
    public class WishlistQuery : IRequest<List<Product>>
    {
        public class WishlistQueryHandler : IRequestHandler<WishlistQuery, List<Product>>
        {
            private readonly BigOnDbContext db;
            private readonly IActionContextAccessor ctx;

            public WishlistQueryHandler(BigOnDbContext db,IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<List<Product>> Handle(WishlistQuery request, CancellationToken cancellationToken)
            {
                if (ctx.ActionContext.HttpContext.Request.Cookies.TryGetValue("wishlist", out string wishlist))
                {
                    //[1,2,3,4]
                    var productIds = JsonConvert.DeserializeObject<int[]>(wishlist);

                    var products = await db.Products
                    .Include(m => m.Images.Where(m => m.IsMain))
                    .Where(m => productIds.Contains(m.Id))
                    .ToListAsync(cancellationToken);

                    return products;
                }

                return null;
            }
        }
    }
}
