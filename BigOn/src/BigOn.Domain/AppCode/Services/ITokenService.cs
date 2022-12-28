using BigOn.Domain.Models.Entities.Membership;

namespace BigOn.Domain.AppCode.Services
{
    public interface ITokenService
    {
        string BuildToken(BigonUser user);
        bool ValidateToken(string token);
    }
}
