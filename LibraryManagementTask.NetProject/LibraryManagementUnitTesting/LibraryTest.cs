using System;
using System.Collections.Generic;
using LibraryManagementTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryManagementUnitTesting
{
    [TestClass]
    public class LibraryTest
    {
        private Library library;

        [TestInitialize]
        public void Setup()
        {
            library = new Library();
        }
        [TestMethod]
        public void AddBookTest()
        {
            Book book = new Book("Csharp", "John", "12345");

            
            library.AddBook(book);

             
            Assert.AreEqual(1, library.Books.Count);
            Assert.AreEqual("Csharp", library.Books[0].Title);
        }
        [TestMethod]
        public void RegisterBorrowerTest()
        {
            
            Borrower borrower = new Borrower("Oggy", "1");

            
            library.RegisterBorrower(borrower);

            
            Assert.AreEqual(1, library.Borrowers.Count);
            Assert.AreEqual("Oggy", library.Borrowers[0].Name);
        }
        //[TestMethod]
        //public void ReturnBookTest()
        //{
        //    Book book = new Book("Csharp", "John", "12345");
        //    Borrower borrower = new Borrower("Oggy", "1");
        //    library.BorrowBook("12345", "1");
        //    library.ReturnBook("12345", "1");
        //    Assert.IsFalse(book.IsBorrowed);
        //    Assert.AreEqual(0,borrower.BorrowedBooks.Count);
        //}
        [TestMethod]
        public void ViewBooks()
        {
            Book book = new Book("Csharp", "john", "12345");
            Book book1 = new Book("Python", "peter", "67890");
            library.AddBook(book);
            library.AddBook(book1);
            List<Book> books = library.ViewBooks();
            Assert.AreEqual(2, books.Count);
        }



    }
}
