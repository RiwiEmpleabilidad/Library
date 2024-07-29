using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.App.Interfaces.Users
{
    public interface IUsersServices
    {
        public void Add(User user);
    }
}