using System;
using System.Collections.Generic;
using System.Text;

public enum ExistentGenre { Fiction,Nonfiction};

namespace Business
{
    public class Book
    {
        const int MAX_LENGTH = 100;
        public Book(string title,int year,double price,ExistentGenre genre)
        {
            BookId = Guid.NewGuid();
            Title = title;
            if (Title.Length > MAX_LENGTH)
                Title = Title.Substring(0, MAX_LENGTH);
            Year = year;
            Price = price;
            Genre = genre;
        }

        public Guid BookId { get; private set; }

        public string Title { get; private set; }

        public int Year{ get; private set; }

        public double Price { get; private set; }

        public ExistentGenre Genre { get; private set; }
    }
}
