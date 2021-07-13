using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class BookRepository2: IBookRepository
    {
        private List<Book> books;
        public BookRepository2()
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
            return books;
        }
        public IEnumerable<Book> RetrieveAllOrderByYearDescending()
        {
            return books.OrderByDescending(b => b.Year);
        }
        public IEnumerable<Book> RetrieveAllOrderByYearAscending()
        {
            return books.OrderBy(b => b.Year);
        }
        public IEnumerable<Book> RetrieveAllOrderByPriceAscending()
        {
            return books.OrderBy(b => b.Price);
        }
        public IEnumerable<Book> RetrieveAllOrderByPriceDescending()
        {
            return books.OrderByDescending(b => b.Price);
        }
        public IEnumerable<IGrouping<ExistentGenre, Book>> RetrieveAllBooksGroupedByGenre()
        {
            return books.GroupBy(b => b.Genre);
        }
    }
}
