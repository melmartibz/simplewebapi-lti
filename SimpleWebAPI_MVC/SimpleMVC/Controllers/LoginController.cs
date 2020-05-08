using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMVC.Models.Entities;
using SimpleMVC.Service;

namespace SimpleMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserAuth _userAuth;

        public LoginController(ILogger<LoginController> logger, IUserAuth userAuth)
        {
            _logger = logger;
            _userAuth = userAuth;
        }
        public IActionResult Index()
        {
            User user = (_userAuth.AuthenticateUser("Weeddnim", "123password")).Result;
            return View(user);
        }

        [HttpPost]
        public IActionResult Authenticate(User user)
        {
            User output = (_userAuth.AuthenticateUser(user.Username, user.Password)).Result;

            return View("TokenView", output);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            User output = (_userAuth.Register(user)).Result;

            return View("Authenticate", output);
        }
    }
}