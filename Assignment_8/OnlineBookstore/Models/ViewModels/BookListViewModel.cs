using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models.ViewModels
{
    //Model to create book list view 
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
