using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Test
{
    interface ITest
    {
        void When_RetrieveAllBooksIsCalled_Then_ShouldReturnEnumerableOfBooks();
        void When_RetrieveAllOrderByYearDescending_Then_ShouldReturnEnumerableOfBooksOrderedByYearDescending();
        void When_RetrieveAllOrderByYearAscending_Then_ShouldReturnEnumerableOfBooksOrderedByYearAscending();
        void When_RetrieveAllOrderByPriceDescending_Then_ShouldReturnEnumerableOfBooksOrderedByPriceDescending();
        void When_RetrieveAllOrderByPriceAscending_Then_ShouldReturnEnumerableOfBooksOrderedByPriceAscending();
        void When_RetrieveAllBooksGroupByGenreIsCalled_Then_ShouldReturnGroupsOfGenres();

    }
}
