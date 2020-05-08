using MediatR;
using SimpleWebAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Queries.LoginQueries
{
    public class LoginQuery : IRequest<User>
    {
        public string username { get; }
        public string password { get; }
        public LoginQuery(string _uname, string _pass)
        {
            username = _uname;
            password = _pass;
        }
    }
}
