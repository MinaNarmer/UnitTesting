using Library.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.API.Data.Services
{
    public class BookService : IBookService
    {

        private readonly List<Book> _books;


        public BookService()
        {
            _books = new List<Book>()
            {
                new Book(){ Title = "MinA",Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),Description="PLA PLA PLA ",Author="mINA"},
                new Book(){ Title = "MinA",Id = Guid.NewGuid(),Description="PLA PLA PLA ",Author="mINA"},
                new Book(){ Title = "MinA",Id = Guid.NewGuid(),Description="PLA PLA PLA ",Author="mINA"},
                new Book(){ Title = "MinA",Id = Guid.NewGuid(),Description="PLA PLA PLA ",Author="mINA"},
                new Book(){ Title = "MinA",Id = Guid.NewGuid(),Description="PLA PLA PLA ",Author="mINA"},

            };
        }
        public Book Add(Book book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            return _books ;
        }

        public Book GetById(Guid id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
