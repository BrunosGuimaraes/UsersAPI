namespace UsersAPI.Infra.Security.Settings
{
    public class TokenSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? SecretKey { get; set; }
        public int ExpirationInMinutes { get; set; }
    }

}
