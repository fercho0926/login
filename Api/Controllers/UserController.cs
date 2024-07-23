using Data.Entities.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;


namespace Api.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }


        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<UserDTO>> Create(CreateUserRequest userRequest)
        {

            var isUserCreated = await _userService.IsUserCreated(userRequest);

            if (isUserCreated)
            {
                return BadRequest("E-mail already exist : " + userRequest.Email);
            }


             return await _userService.Create(userRequest);

        }


        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
