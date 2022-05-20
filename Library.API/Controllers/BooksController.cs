using Library.API.Data.Models;
using Library.API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var items = _bookService.GetAll();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var item = _bookService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _bookService.Add(book);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }


        [HttpDelete("{id}")]

        public ActionResult Remove(Guid id)
        {
            var existingItem = _bookService.GetById(id);
            if (existingItem == null) { return NotFound(); }
            _bookService.Remove(id);
            return Ok();


        }

    }

}
