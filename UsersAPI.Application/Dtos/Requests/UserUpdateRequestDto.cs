using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class UserUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe o seu nome completo.")]
        [MinLength(8, ErrorMessage = "Informe o nome completo com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe o nome completo com no máximo {1} caracteres.")]
        public string? Name { get; set; }
    }
}
