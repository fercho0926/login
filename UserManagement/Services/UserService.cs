using Data;
using Data.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagement.Models;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITokenService _tokenService;

        public UserService(AppDbContext appDbContext, ITokenService tokenService)
        {
            _appDbContext = appDbContext;
            _tokenService = tokenService;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<UserDTO> Create(CreateUserRequest request)
        {
            {

                using var hmac = new HMACSHA512();


                var user = new User
                {
                    UserId = new Guid(),
                    FirstName = request.FirstName.ToLower(),
                    LastName = "vasquez",
                    Identification = request.Identification,
                    CreatedBy = "MIlton",
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key,
                    Email = request.Email

                };

                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();
                return new UserDTO
                {
                    Email = user.Email,
                    Token = _tokenService.createToken(user)
                };
            }
        }

            public async Task<bool> IsUserCreated(CreateUserRequest userRequest)
            {
                return await _appDbContext.Users.AnyAsync(u => u.Email == userRequest.Email || u.Identification == userRequest.Identification);
            }




        }
    }
