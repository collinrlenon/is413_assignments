using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Models;
using OnlineBookstore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    //Setting page sizes and variables
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iOnlineBookstoreRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, iOnlineBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        //Action to pass in the parameter and model
        public IActionResult Index(string category, int pageNum = 1)
        {

            //Create this model that pulls our data and fixes our page numbering
            return View(new BookListViewModel
                {
                    Books = _repository.Books
                        .Where(b => category == null || b.Category == category)
                        .OrderBy(b => b.BookID)
                        .Skip((pageNum - 1) * PageSize)
                        .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.Books.Count() :
                            _repository.Books.Where(x => x.Category == category).Count()
                    },
                    CurrentCategory = category
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
