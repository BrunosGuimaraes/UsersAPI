using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? unitOfWork;

        public UserDomainService(IUnitOfWork? unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            if (Get(user.Email) != null)
                throw new EmailAlreadyExistsException(user.Email);

            unitOfWork?.UserRepository.Add(user);
            unitOfWork?.SaveChanges();
        }

        public void Update(User user)
        {
            unitOfWork?.UserRepository.Update(user);
            unitOfWork?.SaveChanges();
        }

        public void Delete(User user)
        {
            unitOfWork?.UserRepository.Delete(user);
            unitOfWork?.SaveChanges();
        }

        public User? Get(Guid id)
        {
            return unitOfWork?.UserRepository.GetById(id);
        }

        public User? Get(string email)
        {
           return unitOfWork?.UserRepository.Get(u => u.Email.Equals(email));
        }

        public User? Get(string email, string password)
        {
            return unitOfWork?.UserRepository.Get(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
