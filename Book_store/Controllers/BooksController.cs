
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book_store.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book_store.Controllers
{
public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BooksController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: BOOKS
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.Publisher).ToListAsync();
            return View(books);
        }

        // GET: BOOKS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: BOOKS/Create
        public IActionResult Create()
        {
            ViewBag.Publishers = new SelectList(_context.Publishers, "Id", "Name");
            return View();
        }

        // POST: BOOKS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            var name = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                if (book.ImageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString()
                        + Path.GetExtension(book.ImageFile.FileName);
                    string filePath = Path.Combine(
                        _webHostEnvironment.WebRootPath,
                        "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await book.ImageFile.CopyToAsync(stream);
                    }
                    book.ImageUrl = "/images/" + fileName;

                }
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Publishers = new SelectList(
                _context.Publishers.AsNoTracking(),
                "Id",
                "Name");
            return View(book);
        }

        public IActionResult AddToReadingList(int id)
        {
            int count = HttpContext.Session.GetInt32("ReadingCount") ?? 0;
            count++;
            HttpContext.Session.SetInt32("ReadingCount", count);
            TempData["Success"] = "Book added to reading list successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: BOOKS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BOOKS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Price,ImageUrl,PublisherId,Publisher")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: BOOKS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BOOKS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int? id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}