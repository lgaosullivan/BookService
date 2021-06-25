using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookService.Models;

namespace BookService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
                var books = await _context.Books
                        .FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

    // PUT: api/Books/5 api/book/{bookId}/update 
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}/update")]
    public async Task<IActionResult> PutBooks(int id, Books books)
    {
        if (id != books.Id)
        {
            return BadRequest();
        }

        _context.Entry(books).State = EntityState.Modified;

        try
        {
            _context.Update(books);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
        }

            return CreatedAtAction("GetBooks", new { id = books.Id }, books);
    }

    // POST: api/book/create
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("create")]
    public async Task<ActionResult<Books>> PostBooks(Books books)
    {
        _context.Books.Add(books);
            _context.Categories.Add((Category)books.Categories);
            await _context.SaveChangesAsync();

        return CreatedAtAction("GetBooks", new { id = books.Id }, books.Id);
    }
    }
}
