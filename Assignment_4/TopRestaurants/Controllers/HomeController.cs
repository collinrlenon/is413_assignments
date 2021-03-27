using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TopRestaurants.Models;

namespace TopRestaurants.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> recommendationList = new List<string>();

            //Loop through the model and list out the recommendations
            foreach (RecommendationModel r in Models.RecommendationModel.GetRestaurants())
            {
                string? dish = r.FavDish ?? "It's all tasty!";
                string? site = r.Website ?? "Coming soon.";

                recommendationList.Add($"Rank: {r.Rank} | Name: {r.Name} | Favorite Dish: {r.FavDish} | Address: {r.Address} | Phone: {r.Phone} | Website: {r.Website}");
            }

            return View(recommendationList);
        }

        //[HttpGet("RestaurantForm")]
        public IActionResult RestaurantForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RestaurantForm(FormModel appResponse)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                //string? dish = appResponse.FavDish ?? "It's all tasty!";
                //string? site = appResponse.Website ?? "Coming soon.";

                //Store the data temporarily and pass it to the list
                TempStorage.AddApplication(appResponse);
                return RedirectToAction("RestaurantList");
            }
            else
            {
                //List out the validation errors
                return View();
            }
        }

        public IActionResult RestaurantList()
        {
            //Return the view with storage
            return View(TempStorage.Applications);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
