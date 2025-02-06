using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementTask
{
    public class Borrower
    {
        public string Name { get; set; }    
        public string LibraryCardNumber {  get; set; }  
        public List<Book> BorrowedBooks { get; set; }
        public Borrower(string name , string librarycardnumber) {
            Name = name;
            LibraryCardNumber = librarycardnumber;
            BorrowedBooks = new List<Book>();
        }
        public void BorrowBook(Book book)
        {
            if (book.IsBorrowed)
            {
                throw new InvalidOperationException("Book is already borrowed.");
            }

            book.Borrow();
            BorrowedBooks.Add(book);
        }
        public void ReturnBook(Book book)
        {
            if (!BorrowedBooks.Contains(book))
            {
                throw new InvalidOperationException("This book was not borrowed by this user.");
            }

            book.Return();
            BorrowedBooks.Remove(book);
        }

    }
}
