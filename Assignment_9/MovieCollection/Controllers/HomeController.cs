using MovieCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        //Initializing different variables
        private readonly ILogger<HomeController> _logger;

        private MovieCollectionDBContext _context;

        private IMovieCollectionRepository _repository;

        public HomeController(ILogger<HomeController> logger, MovieCollectionDBContext context, IMovieCollectionRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        //Home page action
        public IActionResult Index()
        {
            return View();
        }

        //Podcast action
        public IActionResult Podcasts()
        {
            return View();
        }

        //Get part of add movie action
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        //Post part of add movie action
        [HttpPost]
        public IActionResult AddMovie(Movies movie)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return View("MovieList", _context.Movies);
            }
            //Show validation errors
            else
            {
                return View("AddMovie");
            }

        }

        public static int statId;

        //Post part of edit movie action
        [HttpPost]
        public IActionResult EditMovie(int id)
        {
            statId = id;
            return View("EditMovie", new MovieCollectionViewModel
            {
                MovieMod = _context.Movies.Single(x => x.MovieID == statId),
                Id = statId
            });
        }

        //Post part of update movie action
        [HttpPost]
        public IActionResult UpdateMovie(MovieCollectionViewModel model)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                var movie = _context.Movies.Single(x => x.MovieID == statId);

                _context.Entry(movie).Property(x => x.Category).CurrentValue = model.MovieMod.Category;
                _context.Entry(movie).Property(x => x.Title).CurrentValue = model.MovieMod.Title;
                _context.Entry(movie).Property(x => x.Year).CurrentValue = model.MovieMod.Year;
                _context.Entry(movie).Property(x => x.Director).CurrentValue = model.MovieMod.Director;
                _context.Entry(movie).Property(x => x.Rating).CurrentValue = model.MovieMod.Rating;
                _context.Entry(movie).Property(x => x.Edited).CurrentValue = model.MovieMod.Edited;
                _context.Entry(movie).Property(x => x.LentTo).CurrentValue = model.MovieMod.LentTo;
                _context.Entry(movie).Property(x => x.Notes).CurrentValue = model.MovieMod.Notes;
                _context.SaveChanges();

                return RedirectToAction("MovieList");
            }
            //Show validation errors
            else
            {
                return View(new MovieCollectionViewModel
                {
                    MovieMod = _context.Movies.Single(x => x.MovieID == statId),
                    Id = statId
                });
            }
        }

        //Delete a movie action
        public IActionResult DeleteMovie(int id)
        {
            _context.Remove(_context.Movies.Single(x => x.MovieID == id));
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Show the movie list action
        public IActionResult MovieList()
        {
            return View(_context.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
