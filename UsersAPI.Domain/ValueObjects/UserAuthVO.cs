namespace UsersAPI.Domain.ValueObjects
{
    public class UserAuthVO
    {
        public Guid Id { get; set; }
        public string? Name{ get; set; }
        public string? Email{ get; set; }
        public string? Role{ get; set; }
        public DateTime SignedAt { get; set; }
    }
}
