using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using LibrarySystem.Enum;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BorrowsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Borrows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrow>>> GetBorrow()
        {
            return await _context.Borrow.ToListAsync();
        }

        // GET: api/Borrows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrow>> GetBorrow(int id)
        {
            var borrow = await _context.Borrow.Include(b => b.Book).Include(b => b.User).FirstOrDefaultAsync(b => b.BorrowId == id);

            if (borrow == null)
            {
                return NotFound();
            }

            return borrow;
        }

        // PUT: api/Borrows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Borrow>> PutBorrow(int id, UpdateBorrowDto update)
        {


            var type = (TypeEnum)TypeEnum.Parse(typeof(TypeEnum), User.Claims.FirstOrDefault(c => c.Type == "Type").Value);
            if (type != TypeEnum.Admin)
            {
                return Unauthorized();
            }

            var borrow = await _context.Borrow.Include(b => b.Book).FirstOrDefaultAsync(b => b.BorrowId == id);
            var rule =  await _context.Rule.FirstOrDefaultAsync(r => r.Type == type);
            var duedate = borrow.BorrowDate.AddDays(rule.LimitDay);
       
            var book = await _context.Book.FirstOrDefaultAsync(b => b.BookID == borrow.Book.BookID );
            if (update.Status == TypeEnum.Losted && duedate < DateTime.Now)
            {
                
                borrow.Fines = book.Price * 2 + (5*(int)((DateTime.Now - duedate).TotalDays));
            }
            else if(update.Status == TypeEnum.Losted)
            {
                
                borrow.Fines = book.Price * 2;
            }
            else if (update.Status == TypeEnum.Late)
            {
                borrow.Fines = 5 * (int)((DateTime.Now - duedate).TotalDays);
            }
            

            borrow.Status = update.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Borrows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Borrow>> PostBorrow(AddBorrowDto borrow)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            if (user == null) return Unauthorized();

            var type =(TypeEnum)TypeEnum.Parse(typeof(TypeEnum),User.Claims.FirstOrDefault(c => c.Type == "Type").Value);
            var rule = await _context.Rule.FirstOrDefaultAsync(r => r.Type == type);
            var amount = rule.BookAmount;
            var count = _context.Borrow.Count(b => b.User.PID == user && (b.Status == TypeEnum.Borrowing || b.Status == TypeEnum.Wait));
            

            if (amount > count)
            {
                var newUser = new User() { PID = user };
                _context.Attach(newUser);

                var book = new Book() { BookID = borrow.Book };
                _context.Attach(book);



                var newBorrow = new Borrow()
                {
                    User = newUser,
                    Book = book,
                    Status = TypeEnum.Wait,

                };
                _context.Borrow.Add(newBorrow);


                await _context.SaveChangesAsync();


                return CreatedAtAction("GetBorrow", new { id = newBorrow.BorrowId }, borrow);
            }
            return BadRequest("Book Limited");
        }

        // DELETE: api/Borrows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Borrow>> DeleteBorrow(int id)
        {
            var borrow = await _context.Borrow.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }

            _context.Borrow.Remove(borrow);
            await _context.SaveChangesAsync();

            return borrow;
        }
    }
}
