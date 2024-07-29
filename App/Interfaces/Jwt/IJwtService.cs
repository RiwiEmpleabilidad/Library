using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.DTOs;

namespace Library.App.Interfaces.Jwt
{
    public interface IJwtService
    {
        string GeneratedToken(UserDto user);
    }
}