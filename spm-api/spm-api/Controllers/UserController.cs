using Microsoft.AspNetCore.Mvc;
using spm_api.Entity;
using spm_api.Interfaces.Services;
using spm_api.Services.Dtos.Models;
using System.Collections.Generic;

namespace spm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public void Create(UserDto userDto)
        {
            _userService.CreateUser(userDto);
        }

        [HttpPut]
        public void Update(UserDto userDto)
        {
            _userService.UpdateUser(userDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginDto loginDto)
        {
            var user = _userService.Login(loginDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
