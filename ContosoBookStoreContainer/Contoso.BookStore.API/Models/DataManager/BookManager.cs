using Contoso.BookStore.API.Data;
using Contoso.BookStore.API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Contoso.BookStore.API.Models.DataManager
{
    public class BookManager : IDataRepository<Book, long>
    {
        private readonly ApplicationDbContext _context;
        public BookManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public long Add(Book book)
        {
            _context.books.Add(book);
            var bookId = _context.SaveChanges();
            return bookId;
        }

        public long Delete(long id)
        {
            var bookId = 0;
            var book = _context.books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
            {
                _context.books.Remove(book);
                bookId = _context.SaveChanges();
            }
            return bookId;
        }

        public long Update(long id, Book b)
        {
            long bookId = 0;
            var book = _context.books.Find(id);
            if (book != null)
            {
                book.Author = b.Author;
                book.BookName = b.BookName;
                book.Price = b.Price;
                book.PublishedDate = b.PublishedDate;
                bookId = _context.SaveChanges();
            }
            return bookId;
        }
        public Book Get(long id)
        {
            return _context.books.FirstOrDefault(b => b.BookId == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.books.ToList();
        }
    }
}
