using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkCoreJwtTokenAuth.Interfaces;
using Library.App.Interfaces;
using Library.App.Interfaces.Users;
using Library.Data;
using Library.Models;
using Library.Utils;
using Microsoft.AspNetCore.Identity;

namespace Library.App.Services
{
    public class UsersService : IUsersServices
    {
        private readonly BaseContext _context;
        private readonly Bcrypt _bcrypt;
        private readonly IMailerSendService _mailerSendService;

        public UsersService(BaseContext context, Bcrypt bcrypt, IMailerSendService mailerSendService)
        {
            _context = context;
            _bcrypt = bcrypt;
            _mailerSendService = mailerSendService;
        }

        public async Task AddAsync(User user)
        {
            user.Password = _bcrypt.HashPassword(user.Password);
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            var savedUser = await _context.users.FindAsync(user.Id);

            if (savedUser == null)
            {
                throw new Exception("No se pudo encontrar el usuario asociado al registro.");
            }

            // Enviar correo de confirmación
            var from = "MS_MlGdXH@trial-v69oxl59dkxg785k.mlsender.net"; // Correo electrónico del remitente
            var fromName = "Library"; // Nombre del remitente
            var to = new List<string> { savedUser.Email }; // Correo electrónico del usuario
            var toNames = new List<string> { savedUser.Name }; // Nombre del usuario
            var subject = "Registro Exitoso";
            var text = $"Hola {savedUser.Name}, tu registro ha sido exitoso";
            var html = $"<p>Bienvenido/a {savedUser.Name}, ahora podrás gozar de todos nuestros beneficios.</p>";

            await _mailerSendService.SendEmailAsync(from, fromName, to, toNames, subject, text, html);
        }
    }


}
