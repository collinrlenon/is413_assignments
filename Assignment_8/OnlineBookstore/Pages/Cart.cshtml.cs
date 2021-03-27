using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookstore.Infrastructure;
using OnlineBookstore.Models;

namespace OnlineBookstore.Pages
{
    public class CartModel : PageModel
    {
        //Getting into about what items are out there
        private iOnlineBookstoreRepository repository;
        public CartModel(iOnlineBookstoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        //Methods
        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(bk =>
                bk.Book.BookID == bookID).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
