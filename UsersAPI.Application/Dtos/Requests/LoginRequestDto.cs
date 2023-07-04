using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public  class LoginRequestDto
    {
        [Required(ErrorMessage ="Informe o email de acesso.")]
        [EmailAddress(ErrorMessage ="Informe um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Informe a senha de acesso.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
            ErrorMessage ="Informe a senha forte com pelo menos 8 caracteres.")]
        public string? Password { get; set; }
    }
}
