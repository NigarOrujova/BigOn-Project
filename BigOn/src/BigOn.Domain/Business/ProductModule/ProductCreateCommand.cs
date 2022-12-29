using BigOn.Application.Extensions;
using BigOn.Domain.AppCode.Extensions;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using BigOn.Domain.Models.FormModels;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.ProductModule
{
    public class ProductCreateCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public ImageItem[] Images { get; set; }

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
        {
            private readonly BigOnDbContext db;
            private readonly IHostEnvironment env;

            public ProductCreateCommandHandler(BigOnDbContext db, IHostEnvironment env)
            {
                this.db = db;
                this.env = env;
            }

            public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                
                var product = new Product();
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.Name = request.Name;
                product.Slug = request.Name.ToSlug();
                product.StockKeepingUnit = Guid.NewGuid().ToString();
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;

                product.Images = new List<ProductImage>();

                foreach (var item in request.Images.Where(i => i.File != null))
                {
                    var image = new ProductImage();
                    image.IsMain = item.IsMain;

                    image.Path = item.File.GetRandomImagePath("product");

                    await env.SaveAsync(item.File, image.Path, cancellationToken);

                    product.Images.Add(image);
                }

                await db.Products.AddAsync(product, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                product.StockKeepingUnit = $"SKU{product.Id:000000}";
                await db.SaveChangesAsync(cancellationToken);


                return product;
            }
        }
    }
}
