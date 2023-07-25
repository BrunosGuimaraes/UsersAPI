using UsersAPI.Domain.ValueObjects;

namespace UsersAPI.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        string CreateToken(UserAuthVO user);
    }
}
