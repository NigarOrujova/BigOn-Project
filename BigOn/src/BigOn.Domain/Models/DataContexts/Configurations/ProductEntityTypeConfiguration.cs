using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Slug)
                .IsRequired();

            builder.Property(t => t.StockKeepingUnit)
                .IsRequired();

            builder.Property(t => t.ShortDescription)
                .IsRequired();
        }
    }
}
