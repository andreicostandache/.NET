using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books;
        public BookRepository()
        {
            books = new List<Book>();
            books.Add(new Book("ceva", 2000, 10, ExistentGenre.Fiction));
            books.Add(new Book("test", 2001, 20, ExistentGenre.Nonfiction));
            books.Add(new Book("proba", 2002, 30, ExistentGenre.Fiction));
            books.Add(new Book("test2", 2004, 40, ExistentGenre.Fiction));
            books.Add(new Book("carte", 2003, 100, ExistentGenre.Nonfiction));
            books.Add(new Book("book", 2005, 200, ExistentGenre.Fiction));
            books.Add(new Book("alta carte", 2007, 400, ExistentGenre.Nonfiction));
            books.Add(new Book("altceva", 2010, 500, ExistentGenre.Nonfiction));
            books.Add(new Book("exemplu", 2014, 210, ExistentGenre.Fiction));
            books.Add(new Book("carte2", 2015, 1000, ExistentGenre.Nonfiction));
        }
        public IEnumerable<Book> RetrieveAllBooks()
        {
            return from book in books select book; 
        }
        public IEnumerable<Book> RetrieveAllOrderByYearDescending()
        {
            return from book in books orderby book.Year descending select book;
        }
        public IEnumerable<Book> RetrieveAllOrderByYearAscending()
        {
            return from book in books orderby book.Year ascending select book;
        }
        public IEnumerable<Book> RetrieveAllOrderByPriceAscending()
        {
            return from book in books orderby book.Price select book;
        }
        public IEnumerable<Book> RetrieveAllOrderByPriceDescending()
        {
            return from book in books orderby book.Price descending select book;
        }
        public IEnumerable<IGrouping<ExistentGenre,Book>> RetrieveAllBooksGroupedByGenre()
        {
            return from book in books group book by book.Genre;
        }
    }
}
