using Data.Entities.UserManagement;
using UserManagement.Models;

namespace UserManagement.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<UserDTO> Create(CreateUserRequest request);
        Task<bool> IsUserCreated(CreateUserRequest userRequest);


    }
}
