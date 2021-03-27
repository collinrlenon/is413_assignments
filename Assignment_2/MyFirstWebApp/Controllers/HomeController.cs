using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Controllers
{
    //Class to control my program
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   
            return View();
        }

        [HttpGet("GradeCalculator")]
        public IActionResult GradeCalculator ()
        {
            return View();
        }

        [HttpPost("GradeCalculator")]
        public IActionResult GradeCalculator (GradeCalculatorModel model)
        {
            return View();
        }
    }
}
