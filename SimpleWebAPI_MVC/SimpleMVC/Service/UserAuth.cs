using Microsoft.AspNetCore.Components;
using SimpleMVC.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.Service
{
    public class UserAuth : IUserAuth
    {
        private readonly HttpClient _httpClient;
        public UserAuth(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<User> AuthenticateUser(string username, string password)
        {
            return (await _httpClient.GetJsonAsync<User>($"api/Login/username={username}&password={password}"));
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            string uname = user.Username;
            string pass = user.Password;
            string email = user.Email;

            var payload = "{\"username\": \"" + uname + "\",\"password\": \"" + pass + "\",\"email\": \"" + email + "\"}";

            HttpContent parameters = new StringContent(payload, Encoding.UTF8, "application/json");

            return (await _httpClient.PostJsonAsync<User>("api/Login", parameters));
        }
    }
}
