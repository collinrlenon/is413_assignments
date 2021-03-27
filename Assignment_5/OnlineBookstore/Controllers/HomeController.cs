using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iOnlineBookstoreRepository _repository;

        public HomeController(ILogger<HomeController> logger, iOnlineBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Action to pass in the parameter and model
        public IActionResult Index()
        {
            return View(_repository.Books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
