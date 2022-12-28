using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonRoleEntityTypeConfiguration : IEntityTypeConfiguration<BigonRole>
    {
        public void Configure(EntityTypeBuilder<BigonRole> builder)
        {
            builder.ToTable("Roles","Membership");
        }
    }
}
