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
    public class AuthorController : ControllerBase
    {
        private readonly IServiceBase<Author> _service;
        public AuthorController(IServiceBase<Author> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public List<Author> GetAllAuthor()
        {
            return _service.GetAll(new string[] { "Books" }).ToList();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public Author GetAuthorById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public Author AddAuthor(Author author)
        {
            _service.Add(author);
            return author;
        }

        [HttpPost]
        [Route("update")]
        public Author UpdateAuthor(Author author)
        {
            _service.Update(author);
            return author;
        }

        [HttpPost]
        [Route("delete")]
        public Author DeleteAuthor(Author author)
        {
            _service.Delete(author.Id);
            return author;
        }
    }
}
