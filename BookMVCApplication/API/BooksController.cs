using BookMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMVCApplication.API
{
    public class BooksController : ApiController
    {
        ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        //
        public Book GetCustomerById(int? id)
        {
            return _context.Books.SingleOrDefault(c => c.Id == id);
        }
        //post method
        [HttpPost]
        public IHttpActionResult CreateCustomer(Book books)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);

                BadRequest();
            _context.Books.Add(books);
            _context.SaveChanges();
            return Ok(books);
        }
        //put-update
        //[HttpPut]
        public void PutBooks(int id, Book book)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Books.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.BookName = book.BookName;
            _context.SaveChanges();
        }
    }
}
