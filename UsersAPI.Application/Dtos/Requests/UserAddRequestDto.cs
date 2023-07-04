using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class UserAddRequestDto
    {
        [Required(ErrorMessage = "Informe o seu nome completo.")]
        [MinLength(8, ErrorMessage = "Informe o nome completo com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe o nome completo com no máximo {1} caracteres.")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
          ErrorMessage = "Informe a senha forte com pelo menos 8 caracteres.")]
        public string? Password { get; set; }

        [Required(ErrorMessage ="Confirme a senha de acesso.")]
        [Compare("Password", ErrorMessage = "Senhas não conferem.")]
        public string? PasswordConfirm { get; set; }
    }
}
