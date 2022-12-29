using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.AppCode.Infrastructure;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.ShopModule
{
    public class AddToBasketCommand : IRequest<JsonResponse>
    {
        public int ProductId { get; set; }

        public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, JsonResponse>
        {
            private readonly BigOnDbContext db;
            private readonly IActionContextAccessor ctx;

            public AddToBasketCommandHandler(BigOnDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<JsonResponse> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
            {
                var userId = ctx.GetUserId();

                var basket = await db.Baskets.FirstOrDefaultAsync(m => m.ProductId == request.ProductId
                && m.CreatedByUserId == userId, cancellationToken);

                if (basket != null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Mehsul sizin sebetde movcuddur"
                    };
                }


                basket = new Basket
                {
                    ProductId = request.ProductId,
                    CreatedByUserId = userId.Value,
                    Quantity = 1
                };

                await db.AddAsync(basket, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Sebete elave edildi"
                };
            }
        }
    }
}
