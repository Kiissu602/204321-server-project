using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Models.Dto;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Authorization;
using LibrarySystem.Enum;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ImageService _imageService;

        public BooksController(DatabaseContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<Book>> GetBook(SearchBookDto booka)
        {
            var book = await _context.Book.FirstOrDefaultAsync(b => b.BookName == booka.BookName);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutBook(string id, AddBookDto book)
        {
            var type = new BookType() { TypeID = book.Type };
            _context.Attach(type);

            string Img = _imageService.SaveImg(book.ImgBook);
            var Type = User.Claims.FirstOrDefault(c => c.Type == "Type").Value;

            if (Type != TypeEnum.Admin.ToString())
            {
                return Unauthorized();
            }

            var newBook = new Book()
            {
                BookID = id,
                BookName = book.BookName,
                Writer = book.Writer,
                Publisher = book.Publisher,
                YearPublic = book.YearPublic,
                NumPage = book.NumPage,
                Price = book.Price,
                PrintEdit = book.PrintEdit,
                BookType = type,
                BookImg = Img,
            };

             _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Book>> Postbook([FromForm] AddBookDto book)
        {
            var type = new BookType() { TypeID = book.Type };
            _context.Attach(type);

            string Img = _imageService.SaveImg(book.ImgBook);
            var Type = User.Claims.FirstOrDefault(c => c.Type == "Type").Value;

            if (Type != TypeEnum.Admin.ToString())
            {
                return Unauthorized();
            }
            var newBook = new Book()
            {
                BookID = book.BookID,
                BookName = book.BookName,
                Writer = book.Writer,
                Publisher = book.Publisher,
                YearPublic = book.YearPublic,
                NumPage = book.NumPage,
                Price = book.Price,
                PrintEdit = book.PrintEdit,
                BookType = type,
                BookImg = Img,
            };


            _context.Book.Add(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(string id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(string id)
        {
            return _context.Book.Any(e => e.BookID == id);
        }
    }
}
