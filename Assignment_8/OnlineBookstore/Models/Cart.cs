using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    // Cart class to create our line
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem (Book bk, int qty)
        {
            CartLine line = Lines.Where(b => b.Book.BookID == bk.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        //RemoveLine function
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(b => b.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();

        //Figure out the double/decimal thing here
        public double ComputeTotalSum() => Lines.Sum(e => e.Book.Price * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
