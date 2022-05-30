using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("SelectUser")]
        public IActionResult SelectUser()
        {
            return Ok(_userService.SelectUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserModel userModel )
        {
            _userService.Update(userModel);
            return Ok("user updated successfully");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int userId)
        {
            _userService.Delete(userId);
            return Ok(" user deleted successfully");
        }

        [HttpGet("SelectUserById")]
        public IActionResult SelectUserById(int userId)
        {
            return Ok(_userService.SelectUserById(userId));
        }
    }
}
