using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigOn.Domain.Models.DataContexts.Configurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            //builder.HasKey(k => new
            //{
            //    k.ProductId,
            //    k.CreatedByUserId
            //});

            builder.Property(m=>m.Id)
                .UseIdentityColumn();


            builder.ToTable("Basket");
        }
    }
}
