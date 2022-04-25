using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _iBook;

        public BookController(IBook iBook)
        {
            _iBook = iBook;
        }
        // GET: api/<BookController>
        [HttpGet("")]
        public async Task<IEnumerable<Book>> GetBookAsync()
        {
            var details = await _iBook.GetBookAsync();
            return details;
        }

        // GET api/<BookController>/5
        [HttpGet("{bookId}")]
        [ActionName("GetBook")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            var detail = await _iBook.GetBook(bookId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }

        // POST api/<BookController>
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            await _iBook.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { bookId = book.BookId }, book);
        }

        // PUT api/<BookController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] Book book)
        {
            var detail = await _iBook.UpdateBookAsync(book);
            if (detail != null)
            {
                return Ok(detail);
            }
            else
            {
                return NotFound(" not found");
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int bookId)
        {
            await _iBook.DeleteBookAsync(bookId);
            return Ok();
        }
    }
}
