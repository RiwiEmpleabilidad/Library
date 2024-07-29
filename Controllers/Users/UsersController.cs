using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Users;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _userService;

        public UsersController(IUsersServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Create
            _userService.Add(user);
            return Ok(user);
        }
    }
}