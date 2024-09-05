using CRDUASPProject.Data;
using CRDUASPProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRDUASPProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public BooksController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Create(Book book)
        {
            return View(book);
        }
        //post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book, bool UpdateBool)
        {
            if(!BooksFinal(book))
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public bool BooksFinal(Book book)
        {
            var BookFromDB = _dbContext.Books.Find(book.id.ToString());
            if (BookFromDB != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        BookFromDB.Name=book.Name;
                        _dbContext.Books.Update(BookFromDB);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    return false;
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _dbContext.Books.Add(book);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    return false;
                }
            }
            return true;
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var BookFromDB = _dbContext.Books.Find(id.ToString());
            return RedirectToAction("Create", BookFromDB);
        }
        ////post request
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _dbContext.Books.Update(book);
        //            _dbContext.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //    return View(book);
        //}
        public IActionResult Delete(int? id)
        {
            var BookFromDB = _dbContext.Books.Find(id.ToString());
            _dbContext.Books.Remove(BookFromDB);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult abc()
        {
            try
            {
            throw new Exception("lalalala");
            }
            catch(Exception ex) { }
            return RedirectToAction("Index");
        }
        //post request
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _dbContext.Books;
            return View(objList);
        }
    }
}
