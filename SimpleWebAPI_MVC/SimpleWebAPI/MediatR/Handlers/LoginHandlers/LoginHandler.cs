using MediatR;
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
    public class LoginHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly IUserRepo _userRepo;
        public LoginHandler(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return _userRepo.AuthenticateUser(request.username, request.password); });
        }
    }
}
