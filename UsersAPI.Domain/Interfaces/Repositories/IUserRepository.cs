using UsersAPI.Domain.Entities;

namespace UsersAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}
