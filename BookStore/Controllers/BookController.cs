using BookStore.Data.Entities;
using BookStore.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceBase<Book> _service;
        public BookController(IServiceBase<Book> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public List<Book> GetAllBook()
        {
            return _service.GetAll(new string[] { "Category" , "Author" }).ToList();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public Book GetBookById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public Book AddBook(Book book)
        {
            _service.Add(book);
            return book;
        }

        [HttpPost]
        [Route("update")]
        public Book UpdateBook(Book book)
        {
            _service.Update(book);
            return book;
        }

        [HttpPost]
        [Route("delete")]
        public Book DeleteBook(Book book)
        {
            _service.Delete(book.Id);
            return book;
        }
    }
}
