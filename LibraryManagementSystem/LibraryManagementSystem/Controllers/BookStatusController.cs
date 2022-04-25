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
    public class BookStatusController : ControllerBase
    {
        private readonly IBookStatus _iBook;

        public BookStatusController(IBookStatus iBook)
        {
            _iBook = iBook;
        }
        // GET: api/<BookController>
        [HttpGet("")]
        public async Task<IEnumerable<BookStatus>> GetBookAsync()
        {
            var details = await _iBook.GetBookStatusAsync();
            return details;
        }

        // GET api/<BookController>/5
        [HttpGet("{bookId}")]
        [ActionName("GetBook")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId)
        {
            var detail = await _iBook.GetBookStatus(bookId);
            if (detail != null)
            {
                return Ok(detail);
            }
            return NotFound(" Not Found");
        }

        // POST api/<BookController>
        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookStatus book)
        {
            await _iBook.AddBookStatus(book);
            return CreatedAtAction(nameof(GetBook), new { bookId = book.BookStatusId }, book);
        }

        // PUT api/<BookController>/5
        [HttpPut("")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookStatus book)
        {
            var detail = await _iBook.UpdateBookStatusAsync(book);
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
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int bookId)
        {
            await _iBook.DeleteBookStatusAsync(bookId);
            return Ok();
        }
    }
}
