using UsersAPI.Domain.Models;

namespace UsersAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}
