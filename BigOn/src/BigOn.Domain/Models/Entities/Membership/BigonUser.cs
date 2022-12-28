using Microsoft.AspNetCore.Identity;

namespace BigOn.Domain.Models.Entities.Membership
{
    public class BigonUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImagePath { get; set; }
        public string CoverImagePath { get; set; }
    }
}
