using BigOn.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BigOn.Domain.Models.DataContexts.Configurations.Membership
{
    public class BigonUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<BigonUserToken>
    {
        public void Configure(EntityTypeBuilder<BigonUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
