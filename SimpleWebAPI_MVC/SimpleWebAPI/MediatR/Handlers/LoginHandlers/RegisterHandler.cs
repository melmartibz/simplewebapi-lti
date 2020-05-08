using MediatR;
using Microsoft.AspNetCore.Identity;
using SimpleWebAPI.MediatR.Queries.LoginQueries;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleWebAPI.MediatR.Handlers.LoginHandlers
{
    public class RegisterHandler : IRequestHandler<RegisterQuery, User>
    {
        private readonly IUserRepo _userRepo;
        public RegisterHandler(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            User useret = new User();
            User exists = _userRepo.GetUserByUsername(request.username);
            
            if (exists != null)
            {
                useret.Token = "Username exists";
                return await Task.Run(() => { return useret; });
            }
            else
            {
                User emailused = _userRepo.GetUserByEmail(request.email);
                if (emailused != null)
                {
                    useret.Token = "Email has been used exists";
                    return await Task.Run(() => { return useret; });
                }

                useret.Username = request.username;
                useret.Password = request.password;
                useret.Email = request.email;

                return await _userRepo.Register(useret);
            }
        }
    }
}
