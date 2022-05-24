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
        [HttpGet("User")]
        public IActionResult SelectUser()
        {
            return Ok(_userService.SelectUser());
        }

        [HttpPost]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserModel userModel )
        {
            _userService.Update(userModel);
            return Ok("user updated successfully");
        }
    }
}
