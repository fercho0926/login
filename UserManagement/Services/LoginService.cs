using Azure.Core;
using Data;
using Data.Entities.UserManagement;
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagement.Models;
using UserManagement.Models.Login;

namespace UserManagement.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _appDbContext;

        public LoginService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public async Task<User> UserActive(string  email)
        {
            return await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);// && u.IsActive);
        }


        public async Task<bool> Login(LoginDTORequest request, User user)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                // Compare computedHash with user's PasswordHash byte by byte
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return false; // Authentication failed
                    }
                }
            }

            return true;
        }

    }
}
