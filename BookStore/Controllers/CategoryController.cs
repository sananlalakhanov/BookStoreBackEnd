using BookStore.Data.Entities;
using BookStore.Helpers;
using BookStore.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : ControllerBase
    {
        private readonly IServiceBase<Category> _service;
        public CategoryController(IServiceBase<Category> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        //[MyAuthorizeAttribute]
        [Authorize]
        public List<Category> GetAllCategory()
        {
            var user = HttpContext.User;
            var result = _service.GetAll(new string[] { "Books" }).ToList();
            return result;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public Category GetCategoryById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public Category AddCategory(Category category)
        {
            _service.Add(category);
            return category;
        }

        [HttpPost]
        [Route("update")]
        public Category UpdateCategory(Category category)
        {
            _service.Update(category);
            return category;
        }

        [HttpPost]
        [Route("delete")]
        public Category DeleteCategory(Category category)
        {
            _service.Delete(category.Id);
            return category;
        }

        
    }
}
