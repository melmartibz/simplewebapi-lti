using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Interfaces
{
    public interface IUserRepo
    {
        User AuthenticateUser(string username, string password);
        Task<User> Register(User user);
        User GetUserByEmail(string email);
        User GetUserByUsername(string username);
    }
}
