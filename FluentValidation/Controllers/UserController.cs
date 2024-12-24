using Business.Models;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Project.Validator;

namespace Presentation.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetUser()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet]
        public bool DeleteUser(int userId) => _userService.DeleteUser(userId);
        [HttpPost]
        [Route("InsertUser")]
        public UserDto InsertUser(UserDto model)
        {
            var validator = new UserValidator();
            var result = validator.Validate(model);

            if (result.IsValid)
            {
                return _userService.InsertUser(model);
            }
            return null;
        }
        [HttpPost]
        [Route("UpdateUser")]
        public UserDto UpdateUser(UserDto model)
        {
            var validator = new UserValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                return _userService.UpdateUser(model);
            }
            return null;
        }
    }
}
