namespace Data.Entities.UserManagement
{
    public class User : BaseAuditCode
    {

        public Guid UserId { get; set; }

        public int Identification { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public  required string Email { get; set; }
        public string? Phone { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public bool IsActive { get; set; }

        public List<UserToAddress> UserToAddresses{ get; set; } = [];

    }
}
