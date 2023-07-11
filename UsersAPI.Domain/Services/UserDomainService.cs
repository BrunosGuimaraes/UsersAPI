using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Messages;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? unitOfWork;
        private readonly IUserMessageProducer? userMessageProducer;

        public UserDomainService(IUnitOfWork? unitOfWork, IUserMessageProducer? userMessageProducer)
        {
            this.unitOfWork = unitOfWork;
            this.userMessageProducer = userMessageProducer;
        }

        public void Add(User user)
        {
            if (Get(user.Email) != null) throw new EmailAlreadyExistsException(user.Email);

            unitOfWork?.UserRepository.Add(user);
            unitOfWork?.SaveChanges();

            userMessageProducer?.Send(new ValueObjects.UserMessageVO
            {
                Id = user.Id,
                SendedAt = DateTime.Now,
                To = user.Email,
                Subject = "Conta de usuário",
                Body = $@"Olá, {user.Name}, Parabéns, seu cadastro foi realizado com sucesso em nosso sistema."
            }); 
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
