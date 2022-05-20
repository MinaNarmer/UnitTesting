using Library.API.Data.Models;
using System;
using System.Collections.Generic;

namespace Library.API.Data.Services
{
    public interface IBookService
    {

        IEnumerable<Book> GetAll();

        Book Add(Book book);

        Book GetById(Guid id);

        void Remove(Guid id);

    }
}
