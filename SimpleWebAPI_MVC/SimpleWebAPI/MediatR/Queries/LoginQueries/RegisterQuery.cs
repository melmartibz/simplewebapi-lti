using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Queries.LoginQueries
{
    public class RegisterQuery : IRequest<User>
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public RegisterQuery(string _username, string _pass, string _email)
        {
            username = _username;
            password = _pass;
            email = _email;
        }
    }
}
