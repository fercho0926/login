namespace UserManagement.Models.Login
{
    public class LoginDTORequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
