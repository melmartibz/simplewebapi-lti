using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleWebAPI.Data;
using SimpleWebAPI.Models.Entities;
using SimpleWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebAPI.Models.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly MainDBContext _mainDBContext;
        private readonly IConfiguration _configuration;
        public UserRepo(MainDBContext mainDBContext, IConfiguration configuration)
        {
            _mainDBContext = mainDBContext;
            _configuration = configuration;
        }

        public User AuthenticateUser(string username, string password)
        {
            User exists = _mainDBContext.Users.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
            if (exists != null)
            {
                var ssecKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(ssecKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                { 
                    new Claim("uname", exists.Username),
                    new Claim("email", exists.Email)
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: creds
                    );

                var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
                exists.Token = encodetoken;

                return exists;
            }
            return new User();
        }

        public User GetUserByEmail(string email)
        {
            return _mainDBContext.Users.Where(p => p.Email == email).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _mainDBContext.Users.Where(p => p.Username == username).FirstOrDefault();
        }

        public async Task<User> Register(User user)
        {
            _mainDBContext.Users.Add(user);
            await _mainDBContext.SaveChangesAsync();
            return user;
        }


    }
}
