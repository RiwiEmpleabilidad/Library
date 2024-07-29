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
         public async Task<IActionResult> Register(User user)
        {
            await _userService.AddAsync(user);
            return Ok("Usuario registrado y correo de confirmación enviado.");
        }
    }
}