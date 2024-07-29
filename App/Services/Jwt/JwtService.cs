using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Library.App.Interfaces.Jwt;
using Library.Data;
using Library.Models.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Library.App.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly BaseContext _context;

        public JwtService(BaseContext context)
        {
            _context = context;
        }

        public string GeneratedToken(UserDto user)
        {
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E")); //variable key
            var SigninCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            //This apart id for permissions
            //Add token opstions
            var TokenOptions = new JwtSecurityToken(
                issuer: @Environment.GetEnvironmentVariable("Issuer"),
                audience: @Environment.GetEnvironmentVariable("Audience"),
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: SigninCredentials
            );
            //Token Generated
            var TokenString = new JwtSecurityTokenHandler().WriteToken(TokenOptions);

            return TokenString;
        }
    }
}