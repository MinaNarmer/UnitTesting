using Library.API.Controllers;
using Library.API.Data.Models;
using Library.API.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.Test
{
    public class BooksCotrollerTest
    {
        BooksController _controller;
        IBookService _bookService;

        public BooksCotrollerTest()
        {
            _bookService = new BookService() ;
            _controller = new BooksController(_bookService); ;
        }

        [Fact]

        public void GetAllTest()
        {
            //arrange
            // act
            var result = _controller.Get();
            //assert
            Assert.IsType<OkObjectResult>(result.Result);
            
            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Book>>(list.Value);


            var listBooks = list.Value as List<Book>;
            Assert.Equal(5, listBooks.Count);
        }
        [Theory]
        [InlineData("0f8fad5b-d9cb-469f-a165-70867728950e", "0f8fad5b-d9cb-469f-a165-70867728950a")]
        public void GetById(string guid1 ,string guid2)
        {
            //arrange

            var validGuid = new Guid(guid1);
            var validGuid2 = new Guid(guid2);

            //act
            var notFoundResult = _controller.Get(validGuid2);
            var okResult = _controller.Get(validGuid);


            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            Assert.IsType<OkObjectResult>(okResult.Result);

            var item = okResult.Result as OkObjectResult;
            Assert.IsType<Book>(item.Value);

            var book = item.Value as Book;
            Assert.Equal(validGuid, book.Id);
        }
    }
}
