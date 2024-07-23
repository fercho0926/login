namespace UserManagement.Models
{
    public class CreateUserRequest
    {

        public required int Identification { get; set; }
        public  required string Email { get; set; }
        public required string FirstName { get; set; }
        public  string? LastName { get; set; }
        public required string Password { get; set; }

    }
}
