using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    internal class BigonUserEntityTypeConfiguration : IEntityTypeConfiguration<BigonUser>
    {
        public void Configure(EntityTypeBuilder<BigonUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}
