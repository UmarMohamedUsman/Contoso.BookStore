using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contoso.BookStore.API.Models;
using Contoso.BookStore.API.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IDataRepository<Book, long> _idataRepo;

        public BookController(IDataRepository<Book, long> dataRepo)
        {
            _idataRepo = dataRepo;
        }

        //Get: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _idataRepo.GetAll();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _idataRepo.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]Book book)
        {
            _idataRepo.Add(book);
        }

        [HttpPut]
        public void Put([FromBody]Book book)
        {
            _idataRepo.Update(book.BookId, book);
        }

        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _idataRepo.Delete(id);
        }
    }
}