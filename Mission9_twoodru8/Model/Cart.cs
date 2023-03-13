using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;

namespace Mission9_twoodru8.Model
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new();
        

        public virtual void AddItem (Book book, int qty)
        {
            CartLineItem line = Items.Where(b=>b.Book.BookId == book.BookId)
                .FirstOrDefault();
            if(line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double Calculatetotal()
        {
            double sum = Items.Sum(x => x.Book.Price * x.Quantity);
            return sum;
        }
    }

    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
