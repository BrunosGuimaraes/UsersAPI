using UsersAPI.Domain.ValueObjects;

namespace UsersAPI.Domain.Interfaces.Messages
{
    public interface IUserMessageProducer
    {
        void Send(UserMessageVO userMessage);
    }
}
