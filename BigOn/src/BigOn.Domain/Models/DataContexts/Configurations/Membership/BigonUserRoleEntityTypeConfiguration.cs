using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<BigonUserRole>
    {
        public void Configure(EntityTypeBuilder<BigonUserRole> builder)
        {
            //composite primary key
            builder.HasKey(k => new
            {
                k.UserId,
                k.RoleId
            });

            builder.ToTable("UserRoles", "Membership");
        }
    }
}
