using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newsSite.Models;
using ViewModels;
using newsSite.DAL.Repositories;

namespace newsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected IRepositoryBase<Category> categoriesRepository;

        public HomeController(ILogger<HomeController> logger, IRepositoryBase<Category> repository)
        {
            _logger = logger;
            this.categoriesRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            var category = model.DTO;
            categoriesRepository.Insert(category);
            return View("Index");
        }
    }
}
