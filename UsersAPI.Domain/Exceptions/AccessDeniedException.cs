namespace UsersAPI.Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public override string Message 
            => "Acesso negado. Usuário e/ou senha inválidos.";
    }
}
