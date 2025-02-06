using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementTask
{
    public class Program
    {
        static void Main(string[] args)
        { 
            Library library = new Library(); 
            library.AddBook(new Book("csharp", "John", "12345"));
            library.AddBook(new Book("Python", "peter", "67890"));
            library.AddBook(new Book("Java", "David", "1112131415"));
            library.RegisterBorrower(new Borrower("Oggy", "1"));
            library.RegisterBorrower(new Borrower("Bob", "2"));
            try
            {
                library.BorrowBook("12345", "1");
                Console.WriteLine("Oggy borrowed Csharp.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("\nAvailable Books:");
            foreach (var book in library.ViewBooks())
            {
                Console.WriteLine($"{book.Title} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
            }



        }
    }
}
