using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class ForgotPasswordRequestDto
    {
        [Required(ErrorMessage = "Informe o email do usuário.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string? Email { get; set; }
    }
}
