using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations
{
    internal class ProductCatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<ProductCatalogItem>
    {
        public void Configure(EntityTypeBuilder<ProductCatalogItem> builder)
        {
            //composite primary key
            builder.HasKey(k => new
            {
                k.ProductId,
                k.ColorId,
                k.SizeId,
                k.MaterialId,
                k.TypeId
            });

            builder.Property(m => m.Id)
                .UseIdentityColumn();

            builder.ToTable("ProductCatalog");
        }
    }
}
