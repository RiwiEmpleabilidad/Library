using Library.App.Interfaces.Users;
using Library.Data;
using Library.Models;
using Library.Utils;

namespace Library.App.Services;

public class UsersService : IUsersServices
{
    private readonly BaseContext _context;

    private readonly Bcrypt _bcrypt;

    public UsersService(BaseContext context, Bcrypt bcrypt)
    {
        _context = context;
        _bcrypt = bcrypt;
    }

    public void Add(User user)
    {
        user.Password = _bcrypt.HashPassword(user.Password);
        _context.users.Add(user);
        _context.SaveChanges();
    }
}