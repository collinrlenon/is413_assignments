using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    //Controller class
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse appResponse)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                //Don't let it store the movie if it has this name
                if (appResponse.Title.ToLower() == "Independence Day".ToLower())
                {
                    //Don't store the model and show the denial page
                    return View("SubmittedForm", appResponse);
                }
                else
                {
                    //Store the model and show the confirmation page
                    TempStorage.AddApplication(appResponse);
                    return View("SubmittedForm", appResponse);
                }
            }
            else
            {
                //List out the validation errors
                return View();
            }
        }

        public IActionResult MovieList()
        {
            return View(TempStorage.Applications);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
