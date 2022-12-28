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
    public class FaqEntityTypeConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasKey(k=>k.Id);

            builder.Property(k=>k.Id)
                .UseIdentityColumn();

            builder.Property(t => t.Question)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.Answer)
                .IsRequired();

            builder.ToTable("Faqs");
        }
    }
}
