using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<BigonUserLogin>
    {
        public void Configure(EntityTypeBuilder<BigonUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
