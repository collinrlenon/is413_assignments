using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.Models;

namespace OnlineBookstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private iOnlineBookstoreRepository repository;
        public NavigationMenuViewComponent (iOnlineBookstoreRepository repo)
        {
            repository = repo;
        }
        //Uses Linq to pull the Category data (like SQL)
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
