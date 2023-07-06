namespace UsersAPI.Domain.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string email)
            :base($"O email informado '{email}' já está cadastrado. Tente outro.")
        {
        }
    }
}
