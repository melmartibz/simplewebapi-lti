using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMVC.Models;
using SimpleMVC.Models.Entities;
using SimpleMVC.Service;

namespace SimpleMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Category> list = (_categoryService.GetAllCategories()).Result.ToList();
            return View(list);
        }
    }
}
