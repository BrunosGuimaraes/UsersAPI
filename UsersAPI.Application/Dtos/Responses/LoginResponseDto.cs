namespace UsersAPI.Application.Dtos.Responses
{
    public class LoginResponseDto
    {
        public string? AcessToken { get; set; }
        public DateTime? Expiration { get; set; }
        public UserResponseDto? User { get; set; }
    }
}
