using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    interface IBookRepository
    {
        IEnumerable<Book> RetrieveAllBooks();
        IEnumerable<Book> RetrieveAllOrderByYearDescending();
        IEnumerable<Book> RetrieveAllOrderByYearAscending();
        IEnumerable<Book> RetrieveAllOrderByPriceAscending();
        IEnumerable<Book> RetrieveAllOrderByPriceDescending();
        IEnumerable<IGrouping<ExistentGenre, Book>> RetrieveAllBooksGroupedByGenre();
    }
}
