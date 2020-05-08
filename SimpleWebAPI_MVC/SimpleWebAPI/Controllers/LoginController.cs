using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleWebAPI.MediatR.Queries.LoginQueries;
using SimpleWebAPI.MediatR.Queries.ProductQueries;
using SimpleWebAPI.Models.Entities;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration configuration, IMediator mediator)
        {
            _config = configuration;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Load()
        {
            return Ok(new User { Username = "", Password = "" });
        }

        [HttpGet("username={username}&password={password}")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var query = new LoginQuery(username, password);
            var output = await _mediator.Send(query);

            if(output.UserID != Guid.Empty) return Ok( new { token = output.Token });

            return BadRequest("User does not exist");
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                string username = user.Username;
                string password = user.Password;
                string email = user.Email;

                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(email))
                    return BadRequest("Provide username, password and email");

                var query = new RegisterQuery(username, password, email);
                var output = await _mediator.Send(query);

                if (!String.IsNullOrEmpty(output.Token))
                {
                    ModelState.AddModelError("userregister", output.Token);
                    return BadRequest(ModelState);
                }

                return Ok(output);
                //return CreatedAtAction(nameof(Login), new { username = output.Username, password = output.Password }, output);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}