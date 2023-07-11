namespace UsersAPI.Infra.Messages.Models
{
    public class AuthResponseModel
    {
        public string? Message { get; set; }
        public string? Client { get; set; }
        public DateTime Expiration { get; set; }
        public string? Token { get; set; }
    }

}
