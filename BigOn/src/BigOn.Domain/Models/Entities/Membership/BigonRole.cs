using Microsoft.AspNetCore.Identity;

namespace BigOn.Domain.Models.Entities.Membership
{
    public class BigonRole : IdentityRole<int>
    {
        public byte Rank { get; set; }
    }
}
