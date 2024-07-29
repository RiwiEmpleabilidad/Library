using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;


namespace Library.App.Interfaces.Users
{
    public interface IUsersServices
    {
         Task AddAsync(User user);
    }
}