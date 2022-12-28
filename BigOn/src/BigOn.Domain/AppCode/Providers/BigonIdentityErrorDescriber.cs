using Microsoft.AspNetCore.Identity;

namespace BigOn.Domain.AppCode.Providers
{
    public class BigonIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateRoleName(string role)
        {
            //return base.DuplicateRoleName(role);
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = $"{role} bu rol artiq movcuddur"
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = "rol adi bosh buraxila bilmez"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            //return base.DuplicateEmail(email);

            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $"'{email}' artiq movcuddur"
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = $"İstifadəçi hazırda {role}-roldadır"
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = $"İstifadəçi {role}-rolda deyil"
            };
        }
    }
}
