using SimpleMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVC.Service
{
    public interface IUserAuth
    {
        Task<User> AuthenticateUser(string username, string password);
        Task<User> Register(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string username);
    }
}
