using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<BigonRoleClaim>
    {
        public void Configure(EntityTypeBuilder<BigonRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
