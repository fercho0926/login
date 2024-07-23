using Data.Entities.UserManagement;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Models.Login;
using UserManagement.Services;

namespace Api.Controllers
{

    public class LoginController : BaseApiController
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;

        public LoginController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login (LoginDTORequest request) {

            var UserActive =  await _loginService.UserActive(request.Email);

            if (UserActive == null) return Unauthorized("No valid User");

            var loginSuccessful = await _loginService.Login(request, UserActive);

            if (!loginSuccessful)
            {
                return Unauthorized("Invalid Password");
            }

            return new UserDTO
            {
                Email = request.Email,
                Token = _tokenService.createToken(UserActive)

            };

        }

    }
}
