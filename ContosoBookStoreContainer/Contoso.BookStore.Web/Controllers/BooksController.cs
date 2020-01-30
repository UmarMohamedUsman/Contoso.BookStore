using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Contoso.BookStore.Web.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Contoso.BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        BookAPI _bookAPI = new BookAPI();
        readonly IConfiguration _configuration;

        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();

            HttpClient client = _bookAPI.InitializeClient(_configuration);
            HttpResponseMessage httpResponse = await client.GetAsync("api/book");

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(result);
            }
            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BookId,BookName,PublishedDate,Author,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _bookAPI.InitializeClient(_configuration);

                var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/book", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        // GET: Books/Edit/1
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Book> books = new List<Book>();
            HttpClient client = _bookAPI.InitializeClient(_configuration);
            HttpResponseMessage res = await client.GetAsync("api/book");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(result);
            }

            var book = books.SingleOrDefault(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("BookId,BookName,PublishedDate,Author,Price")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _bookAPI.InitializeClient(_configuration);

                var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/book", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        // GET: Books/Delete/1
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Book> books = new List<Book>();
            HttpClient client = _bookAPI.InitializeClient(_configuration);
            HttpResponseMessage res = await client.GetAsync("api/book");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(result);
            }

            var book = books.SingleOrDefault(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            HttpClient client = _bookAPI.InitializeClient(_configuration);
            HttpResponseMessage res = client.DeleteAsync($"api/book/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}