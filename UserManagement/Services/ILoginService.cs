using Data.Entities.UserManagement;
using UserManagement.Models.Login;

namespace UserManagement.Services
{
    public interface ILoginService
    {
        Task<User> UserActive(string email);
        Task<bool> Login(LoginDTORequest request, User user);    }
}
