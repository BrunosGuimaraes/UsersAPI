using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? dataContext;

        public UnitOfWork(DataContext? dataContext)
        {
            this.dataContext = dataContext;
        }

        public IUserRepository UserRepository => new UserRepository(dataContext);

        public void SaveChanges()
        {
            dataContext?.SaveChanges();
        }
        public void Dispose()
        {
           dataContext?.Dispose();
        }
    }
}
