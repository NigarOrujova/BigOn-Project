using BigOn.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigOn.Domain.Models.DataContexts.Configurations
{
    public class ContactPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired();

            builder.Property(t => t.Subject)
                .IsRequired();

            builder.Property(t => t.Message)
                .IsRequired();
        }
    }
}
