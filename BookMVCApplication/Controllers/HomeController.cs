using BookMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }
        //Books List
        public ActionResult About()
        {
            ViewBag.Message = "List Of Books";
            var books = _context.Books.ToList();
            return View(books);
        }
        //Delete Button
        public ActionResult BookDelete(Book book)//model binding
        {
            var entry = _context.Entry(book);
            if (entry.State == EntityState.Detached)
                _context.Books.Attach(book);

            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("About","Home");
        }
        //details
        public ActionResult BookDetail(Book book)
        {
            var books = _context.Books.SingleOrDefault(c => c.Id == book.Id);

            return View(books);
        }
        //form

        //newBook
        public ActionResult NewBook(Book book)//model binding
        {
            /*var bookInDb = _context.Books.Single(c => c.Id == book.Id);
            if (book.BookName == bookInDb.BookName)
            {

                return RedirectToAction("New");
            }
            else
            {*/
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("About","Home");
            //}

        }
        public ActionResult New()
        {//just to create form
            return View();
        }
        public ActionResult New1(Book book)
        {//just to UPDATE form
            return View(book);
        }
        //UPDATE FORM
        public ActionResult BookEdit(Book book)
        {
            var customerInDb = _context.Books.Find(book.Id);

                customerInDb.BookName = book.BookName;

            
                _context.SaveChanges();

                return RedirectToAction("About", book);
            
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}