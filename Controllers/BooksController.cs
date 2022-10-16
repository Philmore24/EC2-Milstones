using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EC2_1701497.Data;
using EC2_1701497.Models;
using EC2_1701497.ViewModels;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EC2_1701497.Controllers
{
    public class BooksController : Controller
    {
        private readonly EC2_1701497Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BooksController(EC2_1701497Context context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostEnvironment = hostingEnvironment;  
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Title,Author,PublishDate,Quantity,Price,Image")] BookCreateViewModel book)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (book.Image != null)
                {
                    string UploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + book.Image.FileName;
                    string filepath = Path.Combine(UploadFolder, uniqueFileName);
                    book.Image.CopyTo(new FileStream(filepath, FileMode.Create));

                }
                Book newbook = new Book
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Quantity = book.Quantity,
                    Price = book.Price,
                    Image = uniqueFileName
                };
                _context.Add(newbook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
       

       

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

       


        // GET: Books/BuyNow/5
        public async Task<IActionResult> BuyNow(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            OrderViewModel bookmodel = new OrderViewModel();
            bookmodel.BookOrder = book;
            bookmodel.Quantity = 1;

            return View(bookmodel);
        }


        // POST: Books/Buy Now/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyNow(OrderViewModel bookmodel)
        {
            var book = await _context.Book.FindAsync(bookmodel.Id);

            if (book != null)
            {

                bookmodel.BookOrder = book;

                Order newOrder = new Order();
                newOrder.BookId = book.ISBN;
                newOrder.Quantity = bookmodel.Quantity;
                newOrder.UserId = 1;
                newOrder.Total = (bookmodel.Quantity * bookmodel.BookOrder.Price);
                newOrder.OrderDate = DateTime.Now;

                _context.Add(newOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookmodel);
        }



        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            BookCreateViewModel bookmodel = new BookCreateViewModel
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Author = book.Author,
                PublishDate = book.PublishDate,
                Quantity = book.Quantity,
                Price = book.Price
            };
            return View(bookmodel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN,Title,Author,PublishDate,Quantity,Price,Image")] BookCreateViewModel bookedit)
        {
            if (id != bookedit.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = null;
                    if (bookedit.Image != null)
                    {
                        string UploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + bookedit.Image.FileName;
                        string filepath = Path.Combine(UploadFolder, uniqueFileName);
                        bookedit.Image.CopyTo(new FileStream(filepath, FileMode.Create));

                    }
                    Book bookk = new Book
                    {
                        ISBN = bookedit.ISBN,
                        Title = bookedit.Title,
                        Author = bookedit.Author,
                        PublishDate = bookedit.PublishDate,
                        Quantity = bookedit.Quantity,
                        Price = bookedit.Price,
                        Image = uniqueFileName


                    };
                    _context.Update(bookk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bookedit.ISBN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookedit);
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ISBN == id);
        }
    }
}
