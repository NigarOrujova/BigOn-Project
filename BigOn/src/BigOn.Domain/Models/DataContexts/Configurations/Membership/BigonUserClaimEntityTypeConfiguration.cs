using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<BigonUserClaim>
    {
        public void Configure(EntityTypeBuilder<BigonUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
